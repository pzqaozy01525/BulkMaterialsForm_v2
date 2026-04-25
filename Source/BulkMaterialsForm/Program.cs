// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm
// Type: BulkMaterialsForm.Program

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.View;

namespace BulkMaterialsForm;

internal static class Program
{
	private static bool _isStarting = false;

	private static readonly object _startupLock = new object();

	private static Mutex _instanceMutex;

	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.ThreadException += Application_ThreadException;
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		try
		{
			AddNativeSearchPaths();
			_instanceMutex = new Mutex(initiallyOwned: true, "Global\\BulkMaterialsForm_SingleInstance", out var createdNew);
			if (!createdNew)
			{
				LogSave.SaveExeLog("检测到已有实例在运行，本次启动将退出，并请求置前已有实例");
				try
				{
					SingleInstanceIpc.BroadcastShowMainWindow();
					return;
				}
				catch
				{
					return;
				}
			}
			bool flag = StartupValidator.PerformStartupValidation();
			bool flag2 = StartupValidator.IsReactivationRequired();
			if (!flag && !flag2)
			{
				LogSave.SaveExeLog("启动安全验证失败（非硬件变化），程序退出");
				return;
			}
			if (!flag && flag2)
			{
				LogSave.SaveExeLog("启动安全验证失败（硬件变化），继续到激活流程");
			}
			bool flag3 = Activation.InitActivate();
			bool flag4 = DateTime.Now > MainData.ExpTime;
			if (!flag3 || flag2 || flag4)
			{
				if (flag4 && flag3)
				{
					LogSave.SaveExeLog($"系统已过期（到期时间 {MainData.ExpTime:yyyy-MM-dd HH:mm:ss}），显示激活窗口以便续期");
				}
				else
				{
					LogSave.SaveExeLog($"需要激活：isActivated={flag3}, requireReactivation={flag2}, isExpired={flag4}");
				}
				if (new FormActivate().ShowDialog() != DialogResult.OK)
				{
					LogSave.SaveExeLog("用户取消激活或激活失败，程序退出");
					MessageBox.Show("软件未激活，程序将退出。", "激活失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				LogSave.SaveExeLog("激活窗体返回成功");
				if (flag2)
				{
					StartupValidator.ClearReactivationFlag();
					LogSave.SaveExeLog("激活成功，已清除重新激活标记");
				}
				try
				{
					LogSave.SaveExeLog("开始验证激活状态");
					if (!Activation.InitActivate() || (!Activation.IsActivate && !Activation.IsTrial))
					{
						LogSave.SaveExeLog("激活窗体返回成功但激活状态验证失败，程序退出");
						MessageBox.Show("激活验证失败，程序将退出。", "激活验证失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					LogSave.SaveExeLog($"激活状态验证成功：IsActivate={Activation.IsActivate}, IsTrial={Activation.IsTrial}");
					try
					{
						EnhancedMachineFingerprint.SaveFingerprint(EnhancedMachineFingerprint.GenerateFingerprint());
						LogSave.SaveExeLog("激活成功后已更新机器指纹");
					}
					catch (Exception ex)
					{
						LogSave.SaveExeLog("更新机器指纹失败: " + ex.Message);
					}
				}
				catch (Exception ex2)
				{
					LogSave.SaveExeLog("激活状态验证异常: " + ex2.Message);
					MessageBox.Show("激活状态验证异常：" + ex2.Message, "激活验证异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				LogSave.SaveExeLog("激活流程完成，程序继续启动");
			}
			if (string.IsNullOrWhiteSpace(MainData.server) || string.IsNullOrWhiteSpace(MainData.database))
			{
				LogSave.SaveExeLog("数据库未配置，显示数据库设置对话框");
				new DataBaseSet().ShowDialog();
				if (string.IsNullOrWhiteSpace(MainData.server) || string.IsNullOrWhiteSpace(MainData.database))
				{
					MessageBox.Show("数据库未设置，程序将退出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			if (!TestDatabaseConnectionWithTimeout())
			{
				LogSave.SaveExeLog("数据库连接失败，显示数据库设置对话框");
				new DataBaseSet().ShowDialog();
				if (!TestDatabaseConnectionWithTimeout())
				{
					MessageBox.Show("数据库连接失败，程序将退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			DBHelp.Init();
			if (string.IsNullOrWhiteSpace(MainData.XMMC))
			{
				LogSave.SaveExeLog("项目名称未配置，显示系统设置对话框");
				new SystemSetForm().ShowDialog();
				if (string.IsNullOrWhiteSpace(MainData.XMMC))
				{
					LogSave.SaveExeLog("项目名称仍未配置，但允许继续运行");
				}
			}
			string text = MainData.ServerIP ?? "";
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(MainData.XMMC))
			{
				CommonHelper.GetGLResultModel(text.TrimEnd('/') + "/ExpTime/GetExpTime?register=" + Activation.softAuthorize.GetInfo() + "&project_name=" + MainData.XMMC, "");
			}
			LogSave.SaveExeLog("准备直接启动主窗体...");
			StartMainFormDirectly();
		}
		catch (Exception ex3)
		{
			MessageBox.Show("程序启动失败：" + ex3.Message + "\n\n详细信息已记录到日志文件。", "启动错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			LogSave.SaveExeLog($"Program.Main 启动异常: {ex3}");
		}
	}

	private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
	{
		Exception exception = e.Exception;
		MessageBox.Show("应用程序遇到错误，请查看日志文件获取详细信息。", "应用程序错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		LogSave.SaveExeLog($"Application_ThreadException: {exception}");
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception arg = e.ExceptionObject as Exception;
		MessageBox.Show("发生未处理的严重错误，请重启应用程序。", "严重错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		LogSave.SaveExeLog($"CurrentDomain_UnhandledException: {arg}");
	}

	private static void StartMainFormDirectly()
	{
		lock (_startupLock)
		{
			if (_isStarting)
			{
				LogSave.SaveExeLog("检测到重复启动，忽略此次启动请求");
				return;
			}
			_isStarting = true;
		}
		try
		{
			LogSave.SaveExeLog("========== 开始直接启动主程序 ==========");
			LogSave.SaveExeLog($"进程ID: {Process.GetCurrentProcess().Id}");
			LogSave.SaveExeLog($"启动时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
			FormMain mainForm = new FormMain
			{
				WindowState = FormWindowState.Maximized,
				ShowInTaskbar = true,
				Visible = true
			};
			LogSave.SaveExeLog("主窗体已创建，准备启动消息循环");
			Application.Run(mainForm);
			LogSave.SaveExeLog("消息循环已结束");
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"启动应用程序失败：{ex}");
			MessageBox.Show("启动应用程序失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Environment.Exit(1);
		}
		finally
		{
			lock (_startupLock)
			{
				_isStarting = false;
			}
		}
	}

	private static bool TestDatabaseConnectionWithTimeout()
	{
		try
		{
			LogSave.SaveExeLog("开始数据库连接测试（带超时）...");
			Task<bool> task = Task.Run(() => DataClass.connectTestW());
			if (task.Wait(TimeSpan.FromSeconds(5.0)))
			{
				bool result = task.Result;
				LogSave.SaveExeLog($"数据库连接测试完成，结果：{result}");
				return result;
			}
			LogSave.SaveExeLog("数据库连接测试超时（5秒）");
			return false;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("数据库连接测试异常：" + ex.Message);
			return false;
		}
	}

	private static void AddNativeSearchPaths()
	{
		try
		{
			string startupPath = Application.StartupPath;
			string[] obj = new string[5] { "HK", "DH", "HX", "SDK_QianYe", "ZHENSHI" };
			string text = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
			string[] array = obj;
			foreach (string path in array)
			{
				string text2 = Path.Combine(startupPath, path);
				if (Directory.Exists(text2) && text.IndexOf(text2, StringComparison.OrdinalIgnoreCase) < 0)
				{
					text = text2 + ";" + text;
				}
			}
			Environment.SetEnvironmentVariable("PATH", text, EnvironmentVariableTarget.Process);
		}
		catch
		{
		}
	}
}
