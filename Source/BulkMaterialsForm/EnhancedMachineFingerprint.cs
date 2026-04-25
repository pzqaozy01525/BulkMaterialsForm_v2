// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm
// Type: BulkMaterialsForm.EnhancedMachineFingerprint

using System;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using BulkMaterialsForm.Help;
using Microsoft.Win32;

namespace BulkMaterialsForm;

public class EnhancedMachineFingerprint
{
	private const string FINGERPRINT_CACHE_KEY = "MachineFingerprint";

	private const string INSTALL_TIME_KEY = "FirstInstallTime";

	public static string GenerateFingerprint()
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			string cpuId = GetCpuId();
			stringBuilder.Append("CPU:" + cpuId + "|");
			string motherboardId = GetMotherboardId();
			stringBuilder.Append("MB:" + motherboardId + "|");
			string biosId = GetBiosId();
			stringBuilder.Append("BIOS:" + biosId + "|");
			string primaryDiskId = GetPrimaryDiskId();
			stringBuilder.Append("DISK:" + primaryDiskId + "|");
			string primaryMacAddress = GetPrimaryMacAddress();
			stringBuilder.Append("MAC:" + primaryMacAddress + "|");
			string windowsProductId = GetWindowsProductId();
			stringBuilder.Append("WIN:" + windowsProductId + "|");
			string machineName = Environment.MachineName;
			stringBuilder.Append("NAME:" + machineName + "|");
			string orCreateInstallTime = GetOrCreateInstallTime();
			stringBuilder.Append("INSTALL:" + orCreateInstallTime);
			string text = stringBuilder.ToString();
			string text2 = ComputeSha256Hash(text);
			LogSave.SaveExeLog("机器指纹生成成功: " + text2.Substring(0, 8) + "...");
			LogSave.SaveExeLog($"指纹原始数据长度: {text.Length} 字符");
			return text2;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("生成机器指纹失败: " + ex.Message);
			return ComputeSha256Hash($"FALLBACK:{Environment.MachineName}:{DateTime.Now.Ticks}");
		}
	}

	public static bool ValidateFingerprint(string savedFingerprint, out string currentFingerprint, out string mismatchReason)
	{
		currentFingerprint = GenerateFingerprint();
		mismatchReason = string.Empty;
		if (string.IsNullOrWhiteSpace(savedFingerprint))
		{
			mismatchReason = "未找到保存的机器指纹";
			return false;
		}
		if (savedFingerprint.Equals(currentFingerprint, StringComparison.OrdinalIgnoreCase))
		{
			LogSave.SaveExeLog("机器指纹验证通过");
			return true;
		}
		mismatchReason = AnalyzeFingerprintMismatch(savedFingerprint, currentFingerprint);
		LogSave.SaveExeLog("机器指纹验证失败: " + mismatchReason);
		return false;
	}

	public static void SaveFingerprint(string fingerprint)
	{
		try
		{
			New_IniFile.WriteContentValue("激活信息", "MachineFingerprint", fingerprint, MainData.Spath);
			LogSave.SaveExeLog("机器指纹已保存到配置文件");
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("保存机器指纹失败: " + ex.Message);
		}
	}

	public static string GetSavedFingerprint()
	{
		try
		{
			return New_IniFile.ReadContentValue("激活信息", "MachineFingerprint", MainData.Spath) ?? "";
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("读取保存的机器指纹失败: " + ex.Message);
			return string.Empty;
		}
	}

	public static bool HasSignificantHardwareChange(string savedFingerprint)
	{
		if (string.IsNullOrWhiteSpace(savedFingerprint))
		{
			return true;
		}
		string value = GenerateFingerprint();
		return !savedFingerprint.Equals(value, StringComparison.OrdinalIgnoreCase);
	}

	private static string GetCpuId()
	{
		try
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				return ((ManagementObject)managementObjectEnumerator.Current)["ProcessorId"]?.ToString() ?? "UNKNOWN_CPU";
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取CPU ID失败: " + ex.Message);
		}
		return "UNKNOWN_CPU";
	}

	private static string GetMotherboardId()
	{
		try
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string text = item["SerialNumber"]?.ToString();
				if (!string.IsNullOrWhiteSpace(text) && text != "To be filled by O.E.M.")
				{
					return text;
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取主板序列号失败: " + ex.Message);
		}
		return "UNKNOWN_MOTHERBOARD";
	}

	private static string GetBiosId()
	{
		try
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS");
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				return ((ManagementObject)managementObjectEnumerator.Current)["SerialNumber"]?.ToString() ?? "UNKNOWN_BIOS";
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取BIOS序列号失败: " + ex.Message);
		}
		return "UNKNOWN_BIOS";
	}

	private static string GetPrimaryDiskId()
	{
		try
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT SerialNumber, MediaType FROM Win32_DiskDrive WHERE MediaType='Fixed hard disk media'");
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string text = item["SerialNumber"]?.ToString();
				if (!string.IsNullOrWhiteSpace(text))
				{
					return text.Trim();
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取硬盘序列号失败: " + ex.Message);
		}
		return "UNKNOWN_DISK";
	}

	private static string GetPrimaryMacAddress()
	{
		try
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface in allNetworkInterfaces)
			{
				if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet && networkInterface.OperationalStatus == OperationalStatus.Up)
				{
					return networkInterface.GetPhysicalAddress().ToString();
				}
			}
			allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface2 in allNetworkInterfaces)
			{
				if (networkInterface2.NetworkInterfaceType != NetworkInterfaceType.Loopback && networkInterface2.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
				{
					return networkInterface2.GetPhysicalAddress().ToString();
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取MAC地址失败: " + ex.Message);
		}
		return "UNKNOWN_MAC";
	}

	private static string GetWindowsProductId()
	{
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
			return registryKey?.GetValue("ProductId")?.ToString() ?? "UNKNOWN_WINDOWS";
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取Windows产品ID失败: " + ex.Message);
		}
		return "UNKNOWN_WINDOWS";
	}

	private static string GetOrCreateInstallTime()
	{
		try
		{
			string text = New_IniFile.ReadContentValue("激活信息", "FirstInstallTime", MainData.Spath) ?? "";
			if (string.IsNullOrWhiteSpace(text))
			{
				text = DateTime.Now.Ticks.ToString();
				New_IniFile.WriteContentValue("激活信息", "FirstInstallTime", text, MainData.Spath);
				LogSave.SaveExeLog("首次安装时间已记录");
			}
			return text;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("处理安装时间失败: " + ex.Message);
			return DateTime.Now.Ticks.ToString();
		}
	}

	private static string ComputeSha256Hash(string input)
	{
		try
		{
			using SHA256 sHA = SHA256.Create();
			byte[] array = sHA.ComputeHash(Encoding.UTF8.GetBytes(input));
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString().ToUpperInvariant();
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("计算SHA256哈希失败: " + ex.Message);
			return input.GetHashCode().ToString("X8");
		}
	}

	private static string AnalyzeFingerprintMismatch(string saved, string current)
	{
		try
		{
			return "机器指纹不匹配 (保存: " + saved.Substring(0, Math.Min(8, saved.Length)) + "..., 当前: " + current.Substring(0, Math.Min(8, current.Length)) + "...)";
		}
		catch
		{
			return "机器指纹不匹配，无法分析具体原因";
		}
	}
}
