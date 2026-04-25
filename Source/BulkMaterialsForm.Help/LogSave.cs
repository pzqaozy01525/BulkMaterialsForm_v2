// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.LogSave

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BulkMaterialsForm.Help;

public class LogSave
{
	public static void XNCLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\消纳场Log.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void SaveExeLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\保存异常.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void GLLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\高凌Log.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void TYLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\腾跃Log.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void QYLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\QYLog.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void DHLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\DHLog.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void ZSLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\ZSLog.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void HXLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\HXLog.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void HKLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\HKLog.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void Log(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\Log.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void KaiFengV1(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\KaiFengV1.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void AnCheV1(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\AnCheV1.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void TZLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\台账日志.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void MQTTLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\MQTT.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void XHTcpLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\XHTcpLog.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void ZHLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\ZHLog.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void YBLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\YBLog.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void TCPLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\TCPLog日志.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void DBLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\地磅.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void DSFLog(string text)
	{
		try
		{
			string text2 = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			FileStream fileStream = new FileStream(text2 + "\\第三方推送.txt", FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
			streamWriter.WriteLine(text);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}
}
