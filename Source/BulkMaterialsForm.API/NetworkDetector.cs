// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.NetworkDetector

using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using BulkMaterialsForm.Help;

namespace BulkMaterialsForm.API;

public class NetworkDetector
{
	private string _testUrl;

	private int _testTimeoutSeconds;

	private DateTime _lastCheckTime;

	private bool _lastCheckResult;

	private readonly object _checkLock = new object();

	public NetworkDetector()
	{
		LoadConfiguration();
		_lastCheckTime = DateTime.MinValue;
		_lastCheckResult = false;
	}

	private void LoadConfiguration()
	{
		_testUrl = New_IniFile.ReadContentValue("窗体框架配制", "NetworkTestUrl", MainData.Spath);
		if (string.IsNullOrWhiteSpace(_testUrl))
		{
			_testUrl = "https://www.baidu.com";
		}
		if (!int.TryParse(New_IniFile.ReadContentValue("窗体框架配制", "NetworkTestTimeout", MainData.Spath), out _testTimeoutSeconds) || _testTimeoutSeconds <= 0)
		{
			_testTimeoutSeconds = 10;
		}
	}

	public async Task<bool> IsConnectedAsync()
	{
		_ = 1;
		try
		{
			lock (_checkLock)
			{
				if ((DateTime.Now - _lastCheckTime).TotalSeconds < 5.0)
				{
					return _lastCheckResult;
				}
			}
			if (!NetworkInterface.GetIsNetworkAvailable())
			{
				UpdateCheckResult(result: false);
				LogSave.SaveExeLog("网络检测：本地网络接口不可用");
				return false;
			}
			if (!(await CheckDnsAsync()))
			{
				UpdateCheckResult(result: false);
				LogSave.SaveExeLog("网络检测：DNS解析失败");
				return false;
			}
			bool flag = await CheckHttpConnectionAsync();
			UpdateCheckResult(flag);
			if (flag)
			{
				LogSave.SaveExeLog("网络检测：网络连接正常");
			}
			else
			{
				LogSave.SaveExeLog("网络检测：HTTP连接失败");
			}
			return flag;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"网络检测异常: {ex.Message}");
			UpdateCheckResult(result: false);
			return false;
		}
	}

	private async Task<bool> CheckDnsAsync()
	{
		return await Task.Run(delegate
		{
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry("www.baidu.com");
				return hostEntry != null && hostEntry.AddressList.Length != 0;
			}
			catch
			{
				try
				{
					Dns.GetHostEntry("8.8.8.8");
					return true;
				}
				catch
				{
					return false;
				}
			}
		});
	}

	private async Task<bool> CheckHttpConnectionAsync()
	{
		HttpClient httpClient = null;
		try
		{
			httpClient = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(_testTimeoutSeconds)
			};
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, _testUrl);
			HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
			return httpResponseMessage.IsSuccessStatusCode || httpResponseMessage.StatusCode == HttpStatusCode.Found || httpResponseMessage.StatusCode == HttpStatusCode.MovedPermanently;
		}
		catch (TaskCanceledException)
		{
			return false;
		}
		catch (HttpRequestException)
		{
			return false;
		}
		catch
		{
			return false;
		}
		finally
		{
			httpClient?.Dispose();
		}
	}

	public async Task<int> GetNetworkQualityAsync()
	{
		_ = 1;
		try
		{
			if (!(await IsConnectedAsync()))
			{
				return 0;
			}
			long num = await MeasureLatencyAsync();
			if (num < 0)
			{
				return 50;
			}
			if (num < 100)
			{
				return 100;
			}
			if (num < 300)
			{
				return 80;
			}
			if (num < 500)
			{
				return 60;
			}
			if (num < 1000)
			{
				return 40;
			}
			return 20;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"获取网络质量失败: {ex.Message}");
			return 0;
		}
	}

	private async Task<long> MeasureLatencyAsync()
	{
		return await Task.Run(delegate
		{
			try
			{
				using Ping ping = new Ping();
				PingReply pingReply = ping.Send("www.baidu.com");
				if (pingReply.Status == IPStatus.Success)
				{
					return pingReply.RoundtripTime;
				}
				pingReply = ping.Send("8.8.8.8");
				if (pingReply.Status == IPStatus.Success)
				{
					return pingReply.RoundtripTime;
				}
				return -1L;
			}
			catch
			{
				return -1L;
			}
		});
	}

	private void UpdateCheckResult(bool result)
	{
		lock (_checkLock)
		{
			_lastCheckTime = DateTime.Now;
			_lastCheckResult = result;
		}
	}

	public async Task<NetworkStatus> GetNetworkStatusAsync()
	{
		NetworkStatus status = new NetworkStatus
		{
			CheckTime = DateTime.Now
		};
		try
		{
			NetworkStatus networkStatus = status;
			networkStatus.IsConnected = await IsConnectedAsync();
			if (status.IsConnected)
			{
				networkStatus = status;
				networkStatus.QualityScore = await GetNetworkQualityAsync();
				networkStatus = status;
				networkStatus.Latency = await MeasureLatencyAsync();
				status.NetworkInterfaceInfo = GetNetworkInterfaceInfo();
			}
			else
			{
				status.QualityScore = 0;
				status.Latency = -1L;
				status.NetworkInterfaceInfo = "网络未连接";
			}
			status.StatusDescription = GetStatusDescription(status);
		}
		catch (Exception ex)
		{
			status.IsConnected = false;
			status.QualityScore = 0;
			status.Latency = -1L;
			status.StatusDescription = $"检测失败: {ex.Message}";
		}
		return status;
	}

	private string GetNetworkInterfaceInfo()
	{
		try
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface in allNetworkInterfaces)
			{
				if (networkInterface.OperationalStatus != OperationalStatus.Up || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Loopback)
				{
					continue;
				}
				foreach (UnicastIPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
				{
					if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
					{
						return $"{networkInterface.Name} ({unicastAddress.Address})";
					}
				}
			}
			return "未找到活动的网络接口";
		}
		catch
		{
			return "无法获取网络接口信息";
		}
	}

	private string GetStatusDescription(NetworkStatus status)
	{
		if (!status.IsConnected)
		{
			return "网络未连接";
		}
		string arg = ((status.QualityScore >= 80) ? "优秀" : ((status.QualityScore >= 60) ? "良好" : ((status.QualityScore < 40) ? "较差" : "一般")));
		string arg2 = ((status.Latency >= 0) ? $"，延迟{status.Latency}ms" : "");
		return $"网络质量{arg}{arg2}";
	}

	public async Task<bool> CheckUrlAccessibilityAsync(string url)
	{
		if (string.IsNullOrWhiteSpace(url))
		{
			return false;
		}
		HttpClient httpClient = null;
		try
		{
			httpClient = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(_testTimeoutSeconds)
			};
			return (await httpClient.GetAsync(url)).IsSuccessStatusCode;
		}
		catch
		{
			return false;
		}
		finally
		{
			httpClient?.Dispose();
		}
	}
}
