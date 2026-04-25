// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.Activation

using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace BulkMaterialsForm.Help;

public class Activation
{
	public enum ActivationStatus
	{
		Unknown,
		NoLicense,
		Trial,
		Activated,
		Expired,
		Revoked,
		Suspended
	}

	public static SoftAuthorize softAuthorize = new SoftAuthorize();

	public static bool IsActivate = false;

	public static bool IsTrial = false;

	public static bool StartTrial()
	{
		try
		{
			if (SecureActivationStore.LoadAndVerifyTrial().IsActive)
			{
				LogSave.SaveExeLog("试用已存在，无需重复启动");
				return false;
			}
			string machineCodeForAuth = SoftAuthorize.GetMachineCodeForAuth();
			DateTime now = DateTime.Now;
			if (!SecureActivationStore.SaveTrialData(machineCodeForAuth, now))
			{
				LogSave.SaveExeLog("保存试用数据失败");
				return false;
			}
			DateTime dateTime = now.AddDays(15.0);
			MainData.SaveExpTime(dateTime);
			MainData.SaveActivationTime(now);
			IsTrial = true;
			IsActivate = false;
			LogSave.SaveExeLog($"试用已启动，有效期至{dateTime:yyyy-MM-dd}");
			return true;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("启动试用失败: " + ex.Message);
			return false;
		}
	}

	public static bool IsTrialActive()
	{
		try
		{
			if (SecureActivationStore.LoadAndVerifyTrial().IsActive)
			{
				IsTrial = true;
				return true;
			}
			IsTrial = false;
			return false;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("验证试用状态失败: " + ex.Message);
			return false;
		}
	}

	public static int GetTrialRemainingDays()
	{
		try
		{
			return SecureActivationStore.LoadAndVerifyTrial().RemainingDays;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取试用剩余天数失败: " + ex.Message);
			return 0;
		}
	}

	public static bool HasTrialExpired()
	{
		try
		{
			return !SecureActivationStore.LoadAndVerifyTrial().IsActive;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("检查试用过期失败: " + ex.Message);
			return true;
		}
	}

	public static bool InitActivate()
	{
		try
		{
			string info = softAuthorize.GetInfo();
			LogSave.SaveExeLog("[InitActivate] 当前机器码: " + info);
			var (flag, dateTime, arg) = SecureActivationStore.VerifyActivationCode(info);
			LogSave.SaveExeLog(string.Format("[InitActivate] DPAPI验证结果: isValid={0}, msg={1}, expiryDate={2}", flag, arg, dateTime?.ToString() ?? "null"));
			if (flag && dateTime.HasValue)
			{
				IsActivate = true;
				IsTrial = false;
				MainData.SaveExpTime(dateTime.Value);
				LogSave.SaveExeLog($"正式激活已确认，到期: {dateTime.Value:yyyy-MM-dd}");
				return true;
			}
			if (CheckActivationFile())
			{
				IsActivate = true;
				IsTrial = false;
				LogSave.SaveExeLog("从旧格式activation.dat迁移激活状态");
				return true;
			}
			IsActivate = false;
			if (IsTrialActive())
			{
				IsTrial = true;
				LogSave.SaveExeLog("当前为试用状态");
				return true;
			}
			LogSave.SaveExeLog("未检测到有效激活或试用");
			return false;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("初始化激活状态失败: " + ex.Message);
			return false;
		}
	}

	public static ActivationStatus GetActivationStatus()
	{
		try
		{
			SecureMeta secureMeta = SecureActivationStore.LoadMeta();
			if (!string.IsNullOrWhiteSpace(secureMeta.Status))
			{
				if (secureMeta.Status == "Revoked")
				{
					return ActivationStatus.Revoked;
				}
				if (secureMeta.Status == "Suspended")
				{
					return ActivationStatus.Suspended;
				}
			}
			var (flag, dateTime, text) = SecureActivationStore.VerifyActivationCode(softAuthorize.GetInfo());
			if (flag && dateTime.HasValue)
			{
				return ActivationStatus.Activated;
			}
			if (!string.IsNullOrWhiteSpace(text) && text.Contains("过期"))
			{
				return ActivationStatus.Expired;
			}
			if (IsTrialActive())
			{
				return ActivationStatus.Trial;
			}
			if (CheckActivationFile())
			{
				if (MainData.ExpTime > DateTime.Now)
				{
					return ActivationStatus.Activated;
				}
				return ActivationStatus.Expired;
			}
			return ActivationStatus.NoLicense;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取激活状态失败: " + ex.Message);
			return ActivationStatus.Unknown;
		}
	}

	public static void MarkAsRevoked(string reason = null)
	{
		try
		{
			IsActivate = false;
			IsTrial = false;
			SecureActivationStore.ClearActivationCode();
			LogSave.SaveExeLog("许可证已被撤销" + (string.IsNullOrWhiteSpace(reason) ? "" : (": " + reason)));
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("标记撤销状态失败: " + ex.Message);
		}
	}

	private static bool CheckActivationFile()
	{
		try
		{
			string path = Path.Combine(Application.StartupPath, "activation.dat");
			if (!File.Exists(path))
			{
				return false;
			}
			string text = File.ReadAllText(path);
			string info = softAuthorize.GetInfo();
			if (!softAuthorize.CheckAuthorize(info, text))
			{
				return false;
			}
			UpdateExpTimeFromActivation(text);
			if (!SecureActivationStore.LoadActivationCode().Success)
			{
				string text2 = (softAuthorize.CheckAuthorize(info, text) ? softAuthorize.GetInfo() : null);
				if (!string.IsNullOrEmpty(text2))
				{
					string[] array = text2.Split('|');
					if (array.Length >= 3 && DateTime.TryParse(array[2], out var _))
					{
						SecureActivationStore.SaveActivationCode(info, array[1], array[2]);
					}
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("检查激活文件失败: " + ex.Message);
			return false;
		}
	}

	public static void UpdateExpTimeFromActivation(string encryptedActivationCode)
	{
		try
		{
			string text = SecureActivationStore.DesDecrypt(encryptedActivationCode);
			if (string.IsNullOrEmpty(text) || !text.Contains("|"))
			{
				return;
			}
			string[] array = text.Split('|');
			if (array.Length >= 3)
			{
				string s = array[1];
				string s2 = array[2];
				DateTime activationTime = DateTime.Now;
				if (DateTime.TryParse(s, out var result))
				{
					activationTime = result;
				}
				if (DateTime.TryParse(s2, out var result2))
				{
					MainData.SaveExpTime(result2);
					MainData.SaveActivationTime(activationTime);
					MainData.RefreshExpTime();
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("更新系统到期时间失败: " + ex.Message);
		}
	}

	public static void MarkAsActivated(string source = null)
	{
		IsActivate = true;
		IsTrial = false;
		try
		{
			MainData.WriteString("窗体框架配制", "isInst", "2");
			New_IniFile.WriteContentValue("激活信息", "激活时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), MainData.Spath);
			New_IniFile.WriteContentValue("激活信息", "激活来源", source ?? "未知", MainData.Spath);
			SecureActivationStore.ClearTrialData();
			string path = Path.Combine(Application.StartupPath, "trial.dat");
			if (File.Exists(path))
			{
				try
				{
					File.Delete(path);
					LogSave.SaveExeLog("旧试用文件已清理");
				}
				catch (Exception ex)
				{
					LogSave.SaveExeLog("删除旧试用文件失败: " + ex.Message);
				}
			}
			LogSave.SaveExeLog("已标记为正式激活状态" + (string.IsNullOrWhiteSpace(source) ? string.Empty : ("（来源：" + source + "）")));
		}
		catch (Exception ex2)
		{
			LogSave.SaveExeLog("标记激活状态时写入配置失败：" + ex2.Message);
		}
	}

	public static bool SaveActivation(string activationCode)
	{
		try
		{
			softAuthorize.GetInfo();
			string text = SecureActivationStore.DesDecrypt(activationCode);
			if (string.IsNullOrEmpty(text) || !text.Contains("|"))
			{
				LogSave.SaveExeLog("激活码格式无效，无法保存");
				return false;
			}
			string[] array = text.Split('|');
			if (array.Length < 3)
			{
				LogSave.SaveExeLog("激活码数据不完整");
				return false;
			}
			if (!SecureActivationStore.SaveActivationCode(array[0], array[1], array[2]))
			{
				return false;
			}
			if (DateTime.TryParse(array[2], out var result))
			{
				MainData.SaveExpTime(result);
			}
			File.WriteAllText(Path.Combine(Application.StartupPath, "activation.dat"), activationCode);
			LogSave.SaveExeLog("激活码已保存（DPAPI加密）");
			return true;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("保存激活码失败: " + ex.Message);
			return false;
		}
	}

	public static string GetLocalIP(out string hostName)
	{
		hostName = Dns.GetHostName();
		IPHostEntry iPHostEntry = new IPHostEntry();
		iPHostEntry = Dns.GetHostEntry(hostName);
		if (iPHostEntry.AddressList.Length >= 1)
		{
			string result = "127.0.0.1";
			IPAddress[] addressList = iPHostEntry.AddressList;
			foreach (IPAddress iPAddress in addressList)
			{
				if (iPAddress.GetAddressBytes().Length == 4)
				{
					result = iPAddress.ToString();
					break;
				}
			}
			return result;
		}
		return "127.0.0.1";
	}
}
