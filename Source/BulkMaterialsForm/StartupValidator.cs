// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm
// Type: BulkMaterialsForm.StartupValidator

using System;
using System.Windows.Forms;
using BulkMaterialsForm.Help;

namespace BulkMaterialsForm;

public static class StartupValidator
{
	private static ValidationResult _lastValidationResult;

	private const string LAST_VALIDATION_KEY = "LastValidationTime";

	private const string VALIDATION_COUNT_KEY = "ValidationCount";

	private const string HARDWARE_CHANGE_COUNT_KEY = "HardwareChangeCount";

	public static bool PerformStartupValidation()
	{
		try
		{
			LogSave.SaveExeLog("========== 开始启动安全验证 ==========");
			if (!ValidateSystemTime())
			{
				ShowSecurityAlert("系统时间异常", "检测到系统时间可能被篡改，请确保系统时间正确。");
				return false;
			}
			string text = EnhancedMachineFingerprint.GenerateFingerprint();
			LogSave.SaveExeLog("当前机器指纹: " + text.Substring(0, Math.Min(12, text.Length)) + "...");
			string savedFingerprint = EnhancedMachineFingerprint.GetSavedFingerprint();
			if (string.IsNullOrWhiteSpace(savedFingerprint))
			{
				LogSave.SaveExeLog("首次运行，保存机器指纹");
				EnhancedMachineFingerprint.SaveFingerprint(text);
				RecordValidationSuccess();
				return true;
			}
			if (!EnhancedMachineFingerprint.ValidateFingerprint(savedFingerprint, out var _, out var mismatchReason))
			{
				RecordHardwareChange();
				int hardwareChangeCount = GetHardwareChangeCount();
				string text2;
				string caption;
				if (hardwareChangeCount > 3)
				{
					text2 = $"检测到硬件环境频繁变化（第{hardwareChangeCount}次）。\n\n" + "变化详情：" + mismatchReason + "\n\n如果这是正常的硬件更换或虚拟机迁移，请选择'是'继续。\n系统将更新硬件指纹并要求重新激活软件。\n\n是否继续运行程序？\n（选择'是'将重置硬件变化计数并要求重新激活，选择'否'将退出程序）";
					caption = "硬件环境频繁变化检测";
				}
				else
				{
					text2 = "检测到硬件环境发生变化，这可能是正常的硬件升级。\n\n变化详情：" + mismatchReason + "\n\n硬件变化后需要重新验证软件激活状态。\n是否继续运行程序？\n（选择'是'将更新硬件指纹并要求重新激活，选择'否'将退出程序）";
					caption = "硬件环境变化检测";
				}
				if (MessageBox.Show(text2, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					EnhancedMachineFingerprint.SaveFingerprint(text);
					LogSave.SaveExeLog($"用户确认硬件变化（第{hardwareChangeCount}次），已更新机器指纹");
					if (hardwareChangeCount > 3)
					{
						ResetHardwareChangeCount();
						RecordHardwareChange();
						LogSave.SaveExeLog("硬件变化次数已重置");
					}
					MarkRequireReactivation();
					LogSave.SaveExeLog("硬件变化后需要重新激活，启动验证失败");
					return false;
				}
				LogSave.SaveExeLog("用户拒绝硬件变化，程序退出");
				return false;
			}
			if (!ValidateActivationStatus())
			{
				return false;
			}
			RecordValidationSuccess();
			LogSave.SaveExeLog("启动安全验证通过");
			return true;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("启动验证异常: " + ex.Message);
			ShowSecurityAlert("验证异常", "启动验证过程中发生异常：" + ex.Message);
			return false;
		}
	}

	private static bool ValidateSystemTime()
	{
		try
		{
			string text = New_IniFile.ReadContentValue("安全验证", "LastValidationTime", MainData.Spath);
			if (!string.IsNullOrWhiteSpace(text) && DateTime.TryParse(text, out var result) && DateTime.Now < result.AddMinutes(-5.0))
			{
				LogSave.SaveExeLog($"系统时间异常：当前时间 {DateTime.Now:yyyy-MM-dd HH:mm:ss}，上次验证时间 {result:yyyy-MM-dd HH:mm:ss}");
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("验证系统时间失败: " + ex.Message);
			return true;
		}
	}

	private static bool ValidateActivationStatus()
	{
		try
		{
			if (IsReactivationRequired())
			{
				LogSave.SaveExeLog("检测到需要重新激活，跳过启动验证中的激活检查，交由Program.cs处理");
				return true;
			}
			if (!Activation.IsActivate && !Activation.InitActivate())
			{
				LogSave.SaveExeLog("激活状态验证失败，但允许程序继续到激活流程");
				return true;
			}
			if (Activation.IsActivate && DateTime.Now > MainData.ExpTime)
			{
				LogSave.SaveExeLog($"系统已过期：到期时间 {MainData.ExpTime:yyyy-MM-dd HH:mm:ss}，当前时间 {DateTime.Now:yyyy-MM-dd HH:mm:ss}，继续到激活流程");
				return true;
			}
			if (Activation.IsActivate)
			{
				TimeSpan timeSpan = MainData.ExpTime - DateTime.Now;
				if (timeSpan.TotalDays <= 7.0 && timeSpan.TotalDays > 0.0)
				{
					MessageBox.Show($"系统将在 {(int)timeSpan.TotalDays} 天后过期（{MainData.ExpTime:yyyy-MM-dd HH:mm:ss}），请及时联系管理员续期。", "过期提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("验证激活状态失败: " + ex.Message);
			return true;
		}
	}

	private static void RecordValidationSuccess()
	{
		try
		{
			New_IniFile.WriteContentValue("安全验证", "LastValidationTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), MainData.Spath);
			string s = New_IniFile.ReadContentValue("安全验证", "ValidationCount", MainData.Spath);
			int num = 0;
			if (int.TryParse(s, out var result))
			{
				num = result;
			}
			num++;
			New_IniFile.WriteContentValue("安全验证", "ValidationCount", num.ToString(), MainData.Spath);
			LogSave.SaveExeLog($"验证成功记录已更新，总验证次数: {num}");
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("记录验证成功失败: " + ex.Message);
		}
	}

	private static void RecordHardwareChange()
	{
		try
		{
			string s = New_IniFile.ReadContentValue("安全验证", "HardwareChangeCount", MainData.Spath);
			int num = 0;
			if (int.TryParse(s, out var result))
			{
				num = result;
			}
			num++;
			New_IniFile.WriteContentValue("安全验证", "HardwareChangeCount", num.ToString(), MainData.Spath);
			LogSave.SaveExeLog($"硬件变化记录已更新，总变化次数: {num}");
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("记录硬件变化失败: " + ex.Message);
		}
	}

	private static int GetHardwareChangeCount()
	{
		try
		{
			if (int.TryParse(New_IniFile.ReadContentValue("安全验证", "HardwareChangeCount", MainData.Spath), out var result))
			{
				return result;
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取硬件变化次数失败: " + ex.Message);
		}
		return 0;
	}

	private static void ShowSecurityAlert(string title, string message)
	{
		MessageBox.Show(message, "安全验证失败 - " + title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	public static void ResetHardwareChangeCount()
	{
		try
		{
			New_IniFile.WriteContentValue("安全验证", "HardwareChangeCount", "0", MainData.Spath);
			LogSave.SaveExeLog("硬件变化计数已重置");
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("重置硬件变化计数失败: " + ex.Message);
		}
	}

	private static void MarkRequireReactivation()
	{
		try
		{
			New_IniFile.WriteContentValue("窗体框架配制", "isInst", "0", MainData.Spath);
			New_IniFile.WriteContentValue("安全验证", "RequireReactivation", "true", MainData.Spath);
			New_IniFile.WriteContentValue("安全验证", "HardwareChangeTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), MainData.Spath);
			LogSave.SaveExeLog("已标记需要重新激活（硬件变化）");
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("标记重新激活失败: " + ex.Message);
		}
	}

	public static bool IsReactivationRequired()
	{
		try
		{
			return New_IniFile.ReadContentValue("安全验证", "RequireReactivation", MainData.Spath) == "true";
		}
		catch
		{
			return false;
		}
	}

	public static void ClearReactivationFlag()
	{
		try
		{
			New_IniFile.WriteContentValue("安全验证", "RequireReactivation", "false", MainData.Spath);
			LogSave.SaveExeLog("已清除重新激活标记");
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("清除重新激活标记失败: " + ex.Message);
		}
	}

	public static string GetValidationStatistics()
	{
		try
		{
			string text = New_IniFile.ReadContentValue("安全验证", "LastValidationTime", MainData.Spath);
			string text2 = New_IniFile.ReadContentValue("安全验证", "ValidationCount", MainData.Spath);
			string text3 = New_IniFile.ReadContentValue("安全验证", "HardwareChangeCount", MainData.Spath);
			return "上次验证: " + text + "\n总验证次数: " + text2 + "\n硬件变化次数: " + text3;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取验证统计信息失败: " + ex.Message);
			return "无法获取统计信息";
		}
	}

	public static bool ValidateOnStartup()
	{
		try
		{
			_lastValidationResult = new ValidationResult
			{
				ValidationTime = DateTime.Now,
				FingerprintValid = false,
				ActivationValid = false,
				TimeValid = false,
				IsValid = false,
				FailureReason = ""
			};
			_lastValidationResult.TimeValid = ValidateSystemTime();
			if (!_lastValidationResult.TimeValid)
			{
				_lastValidationResult.FailureReason = "系统时间验证失败";
				return false;
			}
			string savedFingerprint = EnhancedMachineFingerprint.GetSavedFingerprint();
			if (string.IsNullOrWhiteSpace(savedFingerprint))
			{
				EnhancedMachineFingerprint.SaveFingerprint(EnhancedMachineFingerprint.GenerateFingerprint());
				_lastValidationResult.FingerprintValid = true;
			}
			else
			{
				_lastValidationResult.FingerprintValid = EnhancedMachineFingerprint.ValidateFingerprint(savedFingerprint, out var _, out var mismatchReason);
				if (!_lastValidationResult.FingerprintValid)
				{
					_lastValidationResult.FailureReason = "机器指纹验证失败: " + mismatchReason;
				}
			}
			_lastValidationResult.ActivationValid = ValidateActivationStatus();
			if (!_lastValidationResult.ActivationValid && string.IsNullOrEmpty(_lastValidationResult.FailureReason))
			{
				_lastValidationResult.FailureReason = "激活状态验证失败";
			}
			_lastValidationResult.IsValid = _lastValidationResult.TimeValid && _lastValidationResult.FingerprintValid && _lastValidationResult.ActivationValid;
			if (_lastValidationResult.IsValid)
			{
				RecordValidationSuccess();
			}
			return _lastValidationResult.IsValid;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("ValidateOnStartup异常: " + ex.Message);
			if (_lastValidationResult != null)
			{
				_lastValidationResult.IsValid = false;
				_lastValidationResult.FailureReason = "验证异常: " + ex.Message;
			}
			return false;
		}
	}

	public static ValidationResult GetLastValidationResult()
	{
		return _lastValidationResult;
	}
}
