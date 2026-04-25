// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.Reboot

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;

namespace BulkMaterialsForm.Help;

public class Reboot
{
	private const string QuickName = "大宗物料V2";

	private static string systemStartPath => Environment.GetFolderPath(Environment.SpecialFolder.Startup);

	private static string appAllPath => Process.GetCurrentProcess().MainModule.FileName;

	private static string desktopPath => Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

	public static void SetMeAutoStart(bool onOff = true)
	{
		if (onOff)
		{
			List<string> quickFromFolder = GetQuickFromFolder(systemStartPath, appAllPath);
			if (quickFromFolder.Count >= 2)
			{
				for (int i = 1; i < quickFromFolder.Count; i++)
				{
					DeleteFile(quickFromFolder[i]);
				}
			}
			else if (quickFromFolder.Count < 1)
			{
				CreateShortcut(systemStartPath, "大宗物料V2", appAllPath, "");
			}
			return;
		}
		List<string> quickFromFolder2 = GetQuickFromFolder(systemStartPath, appAllPath);
		if (quickFromFolder2.Count > 0)
		{
			for (int j = 0; j < quickFromFolder2.Count; j++)
			{
				DeleteFile(quickFromFolder2[j]);
			}
		}
	}

	private static bool CreateShortcut(string directory, string shortcutName, string targetPath, string description = null, string iconLocation = null)
	{
		try
		{
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
			string pathLink = Path.Combine(directory, shortcutName + ".lnk");
			WshShell wshShell = (WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
			IWshShortcut obj = (IWshShortcut)(dynamic)wshShell.CreateShortcut(pathLink);
			obj.TargetPath = targetPath;
			obj.WorkingDirectory = Path.GetDirectoryName(targetPath);
			obj.WindowStyle = 1;
			obj.Description = description;
			obj.IconLocation = (string.IsNullOrWhiteSpace(iconLocation) ? targetPath : iconLocation);
			obj.Save();
			return true;
		}
		catch (Exception ex)
		{
			_ = ex.Message;
		}
		return false;
	}

	private static List<string> GetQuickFromFolder(string directory, string targetPath)
	{
		List<string> list = new List<string>();
		list.Clear();
		string[] files = Directory.GetFiles(directory, "*.lnk");
		if (files == null || files.Length < 1)
		{
			return list;
		}
		for (int i = 0; i < files.Length; i++)
		{
			if (GetAppPathFromQuick(files[i]) == targetPath)
			{
				list.Add(files[i]);
			}
		}
		return list;
	}

	private static string GetAppPathFromQuick(string shortcutPath)
	{
		if (File.Exists(shortcutPath))
		{
			WshShell wshShell = (WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
			return ((IWshShortcut)(dynamic)wshShell.CreateShortcut(shortcutPath)).TargetPath;
		}
		return "";
	}

	private static void DeleteFile(string path)
	{
		if (File.GetAttributes(path) == FileAttributes.Directory)
		{
			Directory.Delete(path, recursive: true);
		}
		else
		{
			File.Delete(path);
		}
	}

	public static void CreateDesktopQuick(string desktopPath = "", string quickName = "", string appPath = "")
	{
		if (GetQuickFromFolder(desktopPath, appPath).Count < 1)
		{
			CreateShortcut(desktopPath, quickName, appPath, "软件描述");
		}
	}
}
