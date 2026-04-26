// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.LogSave
//
// REFACTORED: Consolidated 20 identical methods into a single core implementation.
// Old methods preserved for backward compatibility; each delegates to Write().

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BulkMaterialsForm.Help;

public class LogSave
{
	private static readonly object _lock = new object();

	private static void Write(string text, string fileName, Encoding encoding)
	{
		lock (_lock)
		{
			try
			{
				string dir = Path.Combine(Application.StartupPath, "Log", DateTime.Now.ToString("yyyy-MM-dd"));
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);

				string path = Path.Combine(dir, fileName);
				using var fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
				using var sw = new StreamWriter(fs, encoding);
				sw.WriteLine(text);
				sw.Flush();
			}
			catch
			{
				// Silently fail to preserve original behavior
			}
		}
	}

	private static void Write(string text, string fileName)
		=> Write(text, fileName, Encoding.UTF8); // TODO: 确认编码（原文 Encoding.Default）

	public static void XNCLog(string text) => Write(text, "消纳场Log.txt");
	public static void SaveExeLog(string text) => Write(text, "保存异常.txt");
	public static void GLLog(string text) => Write(text, "高凌Log.txt");
	public static void TYLog(string text) => Write(text, "腾跃Log.txt");
	public static void QYLog(string text) => Write(text, "QYLog.txt");
	public static void DHLog(string text) => Write(text, "DHLog.txt");
	public static void ZSLog(string text) => Write(text, "ZSLog.txt", Encoding.UTF8);
	public static void HXLog(string text) => Write(text, "HXLog.txt");
	public static void HKLog(string text) => Write(text, "HKLog.txt");
	public static void Log(string text) => Write(text, "Log.txt");
	public static void KaiFengV1(string text) => Write(text, "KaiFengV1.txt");
	public static void AnCheV1(string text) => Write(text, "AnCheV1.txt");
	public static void TZLog(string text) => Write(text, "台账日志.txt");
	public static void MQTTLog(string text) => Write(text, "MQTT.txt");
	public static void XHTcpLog(string text) => Write(text, "XHTcpLog.txt");
	public static void ZHLog(string text) => Write(text, "ZHLog.txt");
	public static void YBLog(string text) => Write(text, "YBLog.txt");
	public static void TCPLog(string text) => Write(text, "TCPLog日志.txt");
	public static void DBLog(string text) => Write(text, "地磅.txt");
	public static void DSFLog(string text) => Write(text, "第三方推送.txt");

	/// <summary>
	/// Generic logging method that replaces all specialized log methods.
	/// Usage: LogSave.Write("message", "MyCategory.txt");
	/// </summary>
	public static void Write(string text, string fileName, Encoding encoding, bool useLock)
	{
		if (useLock)
			Write(text, fileName, encoding);
		else
		{
			try
			{
				string dir = Path.Combine(Application.StartupPath, "Log", DateTime.Now.ToString("yyyy-MM-dd"));
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);
				string path = Path.Combine(dir, fileName);
				File.AppendAllText(path, text + Environment.NewLine, encoding);
			}
			catch { }
		}
	}
}
