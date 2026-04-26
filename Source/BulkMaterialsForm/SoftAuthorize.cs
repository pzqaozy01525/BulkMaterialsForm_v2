// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm
// Type: BulkMaterialsForm.SoftAuthorize

using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BulkMaterialsForm.Help;

namespace BulkMaterialsForm;

public class SoftAuthorize
{
	private string machine_code;

	public string FinalCode { get; private set; }

	public static string LastVerifiedCode { get; private set; }

	public string GetInfo()
	{
		try
		{
			string text = "";
			try
			{
				using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
				using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
				if (managementObjectEnumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
					text += managementObject["ProcessorId"];
				}
			}
			catch (Exception ex)
			{
				LogSave.SaveExeLog("获取CPU ID失败: " + ex.Message);
			}
			try
			{
				using ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive WHERE MediaType='Fixed hard disk media' OR MediaType='Fixed media'");
				foreach (ManagementObject item in managementObjectSearcher2.Get())
				{
					string text2 = item["SerialNumber"]?.ToString();
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text += text2.Trim();
						break;
					}
				}
			}
			catch (Exception ex2)
			{
				LogSave.SaveExeLog("获取磁盘序列号失败: " + ex2.Message);
			}
			try
			{
				using ManagementObjectSearcher managementObjectSearcher3 = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS");
				foreach (ManagementObject item2 in managementObjectSearcher3.Get())
				{
					if (item2["SerialNumber"] != null)
					{
						text += item2["SerialNumber"].ToString();
						break;
					}
				}
			}
			catch (Exception ex3)
			{
				LogSave.SaveExeLog("获取BIOS序列号失败: " + ex3.Message);
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				LogSave.SaveExeLog("警告：无法获取硬件标识，使用备用方案");
				text = Environment.MachineName + Environment.UserName;
			}
			return ByteToHexString(new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(text))).Substring(0, 25);
		}
		catch (Exception ex4)
		{
			LogSave.SaveExeLog("获取机器码异常: " + ex4.Message);
			return "";
		}
	}

	public static string GetMachineCodeForAuth()
	{
		try
		{
			string text = "";
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor"))
			{
				using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
				if (managementObjectEnumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
					text += managementObject["ProcessorId"];
				}
			}
			using (ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive WHERE MediaType='Fixed hard disk media' OR MediaType='Fixed media'"))
			{
				foreach (ManagementObject item in managementObjectSearcher2.Get())
				{
					string text2 = item["SerialNumber"]?.ToString();
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text += text2.Trim();
						break;
					}
				}
			}
			using (ManagementObjectSearcher managementObjectSearcher3 = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
			{
				foreach (ManagementObject item2 in managementObjectSearcher3.Get())
				{
					if (item2["SerialNumber"] != null)
					{
						text += item2["SerialNumber"].ToString();
						break;
					}
				}
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = Environment.MachineName + Environment.UserName;
			}
			using MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			return ByteToHexString(mD5CryptoServiceProvider.ComputeHash(Encoding.Unicode.GetBytes(text))).Substring(0, 25);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取机器码失败: " + ex.Message);
			return "";
		}
	}

	public static void SaveLog(string text)
	{
		try
		{
			FileStream fileStream = new FileStream(Application.StartupPath + "\\doc.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8); // TODO: 确认编码（原文 Encoding.Default）
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("SaveLog写入失败: " + ex.Message);
		}
	}

	public bool CheckAuthorize(string code, string pass)
	{
		string text = SecureActivationStore.DesDecrypt(pass);
		if (code != text)
		{
			return false;
		}
		LastVerifiedCode = code;
		return true;
	}

	public string GetMachineCodeString()
	{
		return machine_code;
	}

	public static string ByteToHexString(byte[] InBytes)
	{
		return ByteToHexString(InBytes, '\0');
	}

	public static string ByteToHexString(byte[] InBytes, char segment)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (byte b in InBytes)
		{
			if (segment == '\0')
			{
				stringBuilder.Append($"{b:X2}");
			}
			else
			{
				stringBuilder.Append($"{b:X2}{segment}");
			}
		}
		if (segment != 0 && stringBuilder.Length > 1 && stringBuilder[stringBuilder.Length - 1] == segment)
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		LastVerifiedCode = stringBuilder.ToString();
		return stringBuilder.ToString();
	}
}
