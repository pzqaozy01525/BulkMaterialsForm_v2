// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.SecureActivationStore

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace BulkMaterialsForm.Help;

internal static class SecureActivationStore
{
	private const string ProductFolder = "BulkMaterialsForm";

	private const string SecureDirName = "SecureData";

	private const string ActivationFileName = "activation.bin";

	private const string TrialFileName = "trial.bin";

	private const string MetaFileName = "meta.bin";

	private static string GetSecureDir()
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "BulkMaterialsForm", "SecureData");
		Directory.CreateDirectory(text);
		return text;
	}

	private static string GetActivationFilePath()
	{
		return Path.Combine(GetSecureDir(), "activation.bin");
	}

	private static string GetTrialFilePath()
	{
		return Path.Combine(GetSecureDir(), "trial.bin");
	}

	private static string GetMetaFilePath()
	{
		return Path.Combine(GetSecureDir(), "meta.bin");
	}

	public static bool SaveActivationCode(string machineCode, string activationDate, string expiryDate)
	{
		try
		{
			string text = machineCode + "|" + activationDate + "|" + expiryDate;
			LogSave.SaveExeLog("[SaveActivationCode] 原始payload: " + text);
			string text2 = DesEncrypt(text);
			if (string.IsNullOrEmpty(text2))
			{
				LogSave.SaveExeLog("[SaveActivationCode] DES加密返回空，拒绝写入");
				return false;
			}
			LogSave.SaveExeLog($"[SaveActivationCode] DES加密后长度: {text2.Length}");
			byte[] array = MachineLevelDataProtector.Protect(Encoding.UTF8.GetBytes(text2));
			LogSave.SaveExeLog($"[SaveActivationCode] DPAPI加密后字节长度: {array.Length}");
			File.WriteAllBytes(GetActivationFilePath(), array);
			SaveMeta(expiryDate);
			LogSave.SaveExeLog("激活码已安全保存（DPAPI加密）");
			return true;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("保存激活码失败: " + ex.Message);
			return false;
		}
	}

	public static (string MachineCode, string ActivationDate, string ExpiryDate, bool Success) LoadActivationCode()
	{
		try
		{
			string activationFilePath = GetActivationFilePath();
			if (!File.Exists(activationFilePath))
			{
				return (MachineCode: string.Empty, ActivationDate: string.Empty, ExpiryDate: string.Empty, Success: false);
			}
			byte[] array = MachineLevelDataProtector.Unprotect(File.ReadAllBytes(activationFilePath));
			if (array == null)
			{
				LogSave.SaveExeLog("[LoadActivationCode] DPAPI解密失败，删除损坏文件并触发重新激活");
				try
				{
					File.Delete(activationFilePath);
				}
				catch
				{
				}
				return (MachineCode: string.Empty, ActivationDate: string.Empty, ExpiryDate: string.Empty, Success: false);
			}
			string text = DesDecrypt(Encoding.UTF8.GetString(array));
			if (string.IsNullOrEmpty(text) || !text.Contains("|"))
			{
				return (MachineCode: string.Empty, ActivationDate: string.Empty, ExpiryDate: string.Empty, Success: false);
			}
			string[] array2 = text.Split('|');
			if (array2.Length < 3)
			{
				return (MachineCode: string.Empty, ActivationDate: string.Empty, ExpiryDate: string.Empty, Success: false);
			}
			LogSave.SaveExeLog("激活码已加载（DPAPI解密）");
			return (MachineCode: array2[0], ActivationDate: array2[1], ExpiryDate: array2[2], Success: true);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("加载激活码失败: " + ex.Message);
			return (MachineCode: string.Empty, ActivationDate: string.Empty, ExpiryDate: string.Empty, Success: false);
		}
	}

	public static (bool IsValid, DateTime? ExpiryDate, string Message) VerifyActivationCode(string currentMachineCode)
	{
		var (text, text2, text3, flag) = LoadActivationCode();
		LogSave.SaveExeLog(string.Format("[VerifyActivationCode] storedMachineCode={0}, activationDate={1}, expiryDateStr={2}, success={3}", text ?? "null", text2, text3 ?? "null", flag));
		if (!flag)
		{
			return (IsValid: false, ExpiryDate: null, Message: "未找到激活码");
		}
		if (text != currentMachineCode)
		{
			LogSave.SaveExeLog("机器码不匹配: 存储=" + text?.Substring(0, 8) + "..., 当前=" + currentMachineCode?.Substring(0, 8) + "...");
			return (IsValid: false, ExpiryDate: null, Message: "机器指纹不匹配");
		}
		if (!DateTime.TryParse(text3, out var result))
		{
			LogSave.SaveExeLog("解析过期日期失败: " + text3);
			return (IsValid: false, ExpiryDate: null, Message: "激活码格式无效");
		}
		if (result <= DateTime.Now)
		{
			LogSave.SaveExeLog($"激活码已过期: {result:yyyy-MM-dd}");
			return (IsValid: false, ExpiryDate: result, Message: "授权已过期");
		}
		LogSave.SaveExeLog($"激活码验证成功，到期时间: {result:yyyy-MM-dd}");
		return (IsValid: true, ExpiryDate: result, Message: "验证成功");
	}

	public static void ClearActivationCode()
	{
		try
		{
			string activationFilePath = GetActivationFilePath();
			if (File.Exists(activationFilePath))
			{
				byte[] bytes = new byte[File.ReadAllBytes(activationFilePath).Length];
				File.WriteAllBytes(activationFilePath, bytes);
				File.Delete(activationFilePath);
				LogSave.SaveExeLog("激活码已清除");
			}
			string metaFilePath = GetMetaFilePath();
			if (File.Exists(metaFilePath))
			{
				File.Delete(metaFilePath);
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("清除激活码失败: " + ex.Message);
		}
	}

	public static bool SaveTrialData(string machineCode, DateTime startTime)
	{
		try
		{
			string s = $"{machineCode}|{startTime:yyyy-MM-dd HH:mm:ss}|{DateTime.Now.AddDays(15.0):yyyy-MM-dd HH:mm:ss}";
			byte[] bytes = MachineLevelDataProtector.Protect(Encoding.UTF8.GetBytes(s));
			File.WriteAllBytes(GetTrialFilePath(), bytes);
			LogSave.SaveExeLog("试用数据已安全保存（DPAPI加密）");
			return true;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("保存试用数据失败: " + ex.Message);
			return false;
		}
	}

	public static (bool IsActive, DateTime StartTime, int RemainingDays) LoadAndVerifyTrial()
	{
		try
		{
			string trialFilePath = GetTrialFilePath();
			if (!File.Exists(trialFilePath))
			{
				return (IsActive: false, StartTime: DateTime.MinValue, RemainingDays: 0);
			}
			byte[] array = MachineLevelDataProtector.Unprotect(File.ReadAllBytes(trialFilePath));
			if (array == null)
			{
				LogSave.SaveExeLog("DPAPI解密试用数据失败");
				return (IsActive: false, StartTime: DateTime.MinValue, RemainingDays: 0);
			}
			string text = Encoding.UTF8.GetString(array);
			if (string.IsNullOrEmpty(text) || !text.Contains("|"))
			{
				return (IsActive: false, StartTime: DateTime.MinValue, RemainingDays: 0);
			}
			string[] array2 = text.Split('|');
			if (array2.Length < 3)
			{
				return (IsActive: false, StartTime: DateTime.MinValue, RemainingDays: 0);
			}
			string obj = array2[0];
			string info = new SoftAuthorize().GetInfo();
			if (obj != info)
			{
				LogSave.SaveExeLog("试用数据机器码不匹配");
				return (IsActive: false, StartTime: DateTime.MinValue, RemainingDays: 0);
			}
			if (!DateTime.TryParse(array2[1], out var result))
			{
				return (IsActive: false, StartTime: DateTime.MinValue, RemainingDays: 0);
			}
			if (!DateTime.TryParse(array2[2], out var result2))
			{
				return (IsActive: false, StartTime: DateTime.MinValue, RemainingDays: 0);
			}
			if (DateTime.Now > result2)
			{
				LogSave.SaveExeLog($"试用已过期: {result2:yyyy-MM-dd}");
				return (IsActive: false, StartTime: result, RemainingDays: 0);
			}
			int num = (int)Math.Ceiling((result2 - DateTime.Now).TotalDays);
			LogSave.SaveExeLog($"试用有效，剩余{num}天");
			return (IsActive: true, StartTime: result, RemainingDays: Math.Max(0, num));
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("验证试用数据失败: " + ex.Message);
			return (IsActive: false, StartTime: DateTime.MinValue, RemainingDays: 0);
		}
	}

	public static void ClearTrialData()
	{
		try
		{
			string trialFilePath = GetTrialFilePath();
			if (File.Exists(trialFilePath))
			{
				byte[] bytes = new byte[File.ReadAllBytes(trialFilePath).Length];
				File.WriteAllBytes(trialFilePath, bytes);
				File.Delete(trialFilePath);
				LogSave.SaveExeLog("试用数据已清除");
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("清除试用数据失败: " + ex.Message);
		}
	}

	private static void SaveMeta(string expiryDate)
	{
		try
		{
			string s = JsonConvert.SerializeObject(new SecureMeta
			{
				ExpiryDate = expiryDate,
				LastChecked = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
			});
			byte[] bytes = MachineLevelDataProtector.Protect(Encoding.UTF8.GetBytes(s));
			File.WriteAllBytes(GetMetaFilePath(), bytes);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("保存激活元数据失败: " + ex.Message);
		}
	}

	public static SecureMeta LoadMeta()
	{
		try
		{
			string metaFilePath = GetMetaFilePath();
			if (!File.Exists(metaFilePath))
			{
				return new SecureMeta();
			}
			byte[] array = MachineLevelDataProtector.Unprotect(File.ReadAllBytes(metaFilePath));
			if (array == null)
			{
				return new SecureMeta();
			}
			return JsonConvert.DeserializeObject<SecureMeta>(Encoding.UTF8.GetString(array)) ?? new SecureMeta();
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("加载激活元数据失败: " + ex.Message);
			return new SecureMeta();
		}
	}

	internal static string DesEncrypt(string plainText)
	{
		try
		{
			string desKeyFromSecureStorage = GetDesKeyFromSecureStorage();
			if (string.IsNullOrEmpty(desKeyFromSecureStorage) || desKeyFromSecureStorage.Length < 8)
			{
				LogSave.SaveExeLog($"DES加密失败: 密钥长度不足 (实际={desKeyFromSecureStorage?.Length ?? 0})");
				return string.Empty;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(desKeyFromSecureStorage.Substring(0, 8));
			if (bytes.Length != 8)
			{
				LogSave.SaveExeLog($"DES加密失败: 密钥字节长度={bytes.Length}，期望8");
				return string.Empty;
			}
			byte[] rgbIV = bytes;
			using DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			using MemoryStream memoryStream = new MemoryStream();
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
			byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("DES加密失败: " + ex.Message);
			return string.Empty;
		}
	}

	internal static string DesDecrypt(string cipherText)
	{
		if (string.IsNullOrEmpty(cipherText))
		{
			LogSave.SaveExeLog("[DesDecrypt] 输入为空，拒绝解密");
			return string.Empty;
		}
		try
		{
			string desKeyFromSecureStorage = GetDesKeyFromSecureStorage();
			if (string.IsNullOrEmpty(desKeyFromSecureStorage) || desKeyFromSecureStorage.Length < 8)
			{
				LogSave.SaveExeLog($"[DesDecrypt] 密钥长度不足={desKeyFromSecureStorage?.Length ?? 0}");
				return string.Empty;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(desKeyFromSecureStorage.Substring(0, 8));
			if (bytes.Length != 8)
			{
				LogSave.SaveExeLog($"[DesDecrypt] 密钥字节长度={bytes.Length}，期望8");
				return string.Empty;
			}
			byte[] rgbIV = bytes;
			byte[] array = Convert.FromBase64String(cipherText);
			using DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			using MemoryStream memoryStream = new MemoryStream();
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("DES解密失败: " + ex.Message);
			return string.Empty;
		}
	}

	private static string GetDesKeyFromSecureStorage()
	{
		try
		{
			string path = Path.Combine(GetSecureDir(), ".key");
			if (File.Exists(path))
			{
				byte[] array = MachineLevelDataProtector.Unprotect(File.ReadAllBytes(path));
				if (array != null && array.Length >= 8)
				{
					string text = Encoding.UTF8.GetString(array);
					LogSave.SaveExeLog($"[GetDesKeyFromSecureStorage] 已加载密钥, 长度={text.Length}");
					return text;
				}
				LogSave.SaveExeLog("[GetDesKeyFromSecureStorage] 密钥文件损坏或长度不足，删除并重新生成");
				try
				{
					File.Delete(path);
				}
				catch
				{
				}
			}
			string text2 = GenerateRandomDesKey();
			byte[] bytes = MachineLevelDataProtector.Protect(Encoding.UTF8.GetBytes(text2));
			File.WriteAllBytes(path, bytes);
			LogSave.SaveExeLog("已为当前安装实例生成新的DES密钥（DPAPI保护）");
			return text2;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("读取DES密钥失败: " + ex.Message + "，使用备用密钥");
			return "DFLTKEY1";
		}
	}

	private static string GenerateRandomDesKey()
	{
		using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
		byte[] array = new byte[8];
		randomNumberGenerator.GetBytes(array);
		char[] array2 = new char[8];
		for (int i = 0; i < 8; i++)
		{
			array2[i] = (char)(65 + array[i] % 26);
		}
		return new string(array2);
	}
}
