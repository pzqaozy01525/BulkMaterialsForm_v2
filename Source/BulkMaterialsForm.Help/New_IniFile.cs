// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.New_IniFile

using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BulkMaterialsForm.Help;

public class New_IniFile
{
	[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

	[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
	private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

	public static void WriteContentValue(string section, string key, string value, string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return;
		}
		try
		{
			if (File.Exists(path))
			{
				WritePrivateProfileString(section ?? "", key ?? "", value ?? "", path);
			}
		}
		catch
		{
		}
	}

	public static string ReadContentValue(string Section, string key, string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return "";
		}
		try
		{
			if (!File.Exists(path))
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder(1024);
			if (GetPrivateProfileString(Section ?? "", key ?? "", "", stringBuilder, 1024, path) == 0)
			{
				return "";
			}
			string text = stringBuilder.ToString();
			return (text == null) ? "" : text.Trim();
		}
		catch
		{
			return "";
		}
	}

	public static bool ReadBoolean(string Section, string key, string path, bool defaultValue = false)
	{
		string text = ReadContentValue(Section, key, path);
		if (string.IsNullOrWhiteSpace(text))
		{
			return defaultValue;
		}
		switch (text.Trim().ToLowerInvariant())
		{
		case "true":
		case "1":
		case "yes":
		case "on":
			return true;
		case "false":
		case "0":
		case "no":
		case "off":
			return false;
		default:
			return defaultValue;
		}
	}

	public static int ReadInt(string Section, string key, string path, int defaultValue = 0)
	{
		string text = ReadContentValue(Section, key, path);
		if (string.IsNullOrWhiteSpace(text))
		{
			return defaultValue;
		}
		if (int.TryParse(text.Trim(), out var result))
		{
			return result;
		}
		return defaultValue;
	}
}
