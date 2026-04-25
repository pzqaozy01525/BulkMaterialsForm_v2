// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.CloudSyncService

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BulkMaterialsForm.Help;
using Newtonsoft.Json;

namespace BulkMaterialsForm.API;

public class CloudSyncService
{
	private HttpClient _httpClient;

	private SecurityHelper _securityHelper;

	private Timer _syncTimer;

	private readonly Queue<PendingSyncItem> _pendingSyncQueue;

	private readonly object _syncLock = new object();

	private bool _isInitialized;

	private int _syncIntervalSeconds;

	public CloudSyncService()
	{
		_pendingSyncQueue = new Queue<PendingSyncItem>();
		_syncIntervalSeconds = 3600;
	}

	public void Initialize(HttpClient httpClient, SecurityHelper securityHelper)
	{
		if (!_isInitialized)
		{
			_httpClient = httpClient;
			_securityHelper = securityHelper;
			if (int.TryParse(New_IniFile.ReadContentValue("窗体框架配制", "CloudSyncInterval", MainData.Spath), out var result) && result > 0)
			{
				_syncIntervalSeconds = result;
			}
			LoadPendingQueue();
			_isInitialized = true;
			LogSave.SaveExeLog($"CloudSyncService初始化成功，同步间隔: {_syncIntervalSeconds}秒");
		}
	}

	public void StartBackgroundSync()
	{
		if (!_isInitialized)
		{
			LogSave.SaveExeLog("CloudSyncService未初始化，无法启动后台同步");
		}
		else if (_syncTimer == null)
		{
			_syncTimer = new Timer(async delegate
			{
				await ProcessSyncQueueAsync();
			}, null, TimeSpan.FromSeconds(10.0), TimeSpan.FromSeconds(_syncIntervalSeconds));
			LogSave.SaveExeLog("后台同步服务已启动");
		}
	}

	public void StopBackgroundSync()
	{
		_syncTimer?.Dispose();
		_syncTimer = null;
		SavePendingQueue();
		LogSave.SaveExeLog("后台同步服务已停止");
	}

	public async Task<bool> SyncActivationAsync(string machineCode, string activationCode, DateTime expireDate)
	{
		try
		{
			if (_httpClient == null)
			{
				AddToPendingQueue(machineCode, activationCode, expireDate);
				return false;
			}
			string plainText = JsonConvert.SerializeObject(new
			{
				MachineCode = _securityHelper.HashMachineCode(machineCode),
				ActivationCode = _securityHelper.EncryptData(activationCode),
				ExpireDate = expireDate.ToString("yyyy-MM-dd'T'HH:mm:ss"),
				Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
				Action = "sync"
			});
			string data = _securityHelper.EncryptData(plainText);
			string signature = _securityHelper.GenerateSignature(data);
			StringContent content = new StringContent(JsonConvert.SerializeObject(new
			{
				Data = data,
				Signature = signature
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync("/api/v1/activation/sync", content);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				LogSave.SaveExeLog($"激活信息同步成功: {machineCode.Substring(0, Math.Min(6, machineCode.Length))}***");
				return true;
			}
			LogSave.SaveExeLog($"激活信息同步失败: HTTP {(int)httpResponseMessage.StatusCode}");
			AddToPendingQueue(machineCode, activationCode, expireDate);
			return false;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"同步激活信息异常: {ex.Message}");
			AddToPendingQueue(machineCode, activationCode, expireDate);
			return false;
		}
	}

	public async Task<bool> SyncCustomerInfoAsync(CustomerInfo customerInfo)
	{
		try
		{
			if (_httpClient == null)
			{
				LogSave.SaveExeLog("SyncCustomerInfoAsync: HTTP客户端未初始化");
				return false;
			}
			string plainText = JsonConvert.SerializeObject(new
			{
				CustomerId = customerInfo.CustomerId,
				CompanyName = customerInfo.CompanyName,
				CreditCode = customerInfo.CreditCode,
				PollutionPermit = customerInfo.PollutionPermit,
				Contact = customerInfo.Contact,
				Phone = customerInfo.Phone,
				MachineCode = _securityHelper.HashMachineCode(customerInfo.MachineCode),
				ClientId = customerInfo.ClientId,
				SyncTime = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss"),
				Action = "customer_sync"
			});
			string data = _securityHelper.EncryptData(plainText);
			string signature = _securityHelper.GenerateSignature(data);
			StringContent content = new StringContent(JsonConvert.SerializeObject(new
			{
				Data = data,
				Signature = signature
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync("/api/v1/activation/customer-sync", content);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				LogSave.SaveExeLog($"客户信息同步成功: {customerInfo.CompanyName}");
				return true;
			}
			LogSave.SaveExeLog($"客户信息同步失败: HTTP {(int)httpResponseMessage.StatusCode}");
			return false;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"同步客户信息异常: {ex.Message}");
			return false;
		}
	}

	public async Task<int> BatchSyncActivationsAsync(List<PendingSyncItem> items)
	{
		if (items == null || items.Count == 0)
		{
			return 0;
		}
		try
		{
			string plainText = JsonConvert.SerializeObject(new
			{
				Activations = items.Select((PendingSyncItem item) => new
				{
					MachineCode = _securityHelper.HashMachineCode(item.MachineCode),
					ActivationCode = _securityHelper.EncryptData(item.ActivationCode),
					ExpireDate = item.ExpireDate.ToString("yyyy-MM-dd'T'HH:mm:ss")
				}).ToList(),
				Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
				Action = "batch_sync"
			});
			string data = _securityHelper.EncryptData(plainText);
			string signature = _securityHelper.GenerateSignature(data);
			StringContent content = new StringContent(JsonConvert.SerializeObject(new
			{
				Data = data,
				Signature = signature
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync("/api/v1/activation/batch-sync", content);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				BatchSyncResponse batchSyncResponse = JsonConvert.DeserializeObject<BatchSyncResponse>(await httpResponseMessage.Content.ReadAsStringAsync());
				LogSave.SaveExeLog($"批量同步成功: {batchSyncResponse?.SuccessCount ?? 0}/{items.Count}");
				return batchSyncResponse?.SuccessCount ?? 0;
			}
			LogSave.SaveExeLog($"批量同步失败: HTTP {(int)httpResponseMessage.StatusCode}");
			return 0;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"批量同步异常: {ex.Message}");
			return 0;
		}
	}

	private async Task ProcessSyncQueueAsync()
	{
		try
		{
			List<PendingSyncItem> itemsToSync;
			lock (_syncLock)
			{
				if (_pendingSyncQueue.Count == 0)
				{
					return;
				}
				itemsToSync = new List<PendingSyncItem>();
				int num = Math.Min(_pendingSyncQueue.Count, 100);
				for (int i = 0; i < num; i++)
				{
					itemsToSync.Add(_pendingSyncQueue.Dequeue());
				}
			}
			if (itemsToSync.Count <= 0)
			{
				return;
			}
			int num2 = await BatchSyncActivationsAsync(itemsToSync);
			if (num2 < itemsToSync.Count)
			{
				lock (_syncLock)
				{
					for (int j = num2; j < itemsToSync.Count; j++)
					{
						_pendingSyncQueue.Enqueue(itemsToSync[j]);
					}
				}
			}
			SavePendingQueue();
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"处理同步队列异常: {ex.Message}");
		}
	}

	private void AddToPendingQueue(string machineCode, string activationCode, DateTime expireDate)
	{
		lock (_syncLock)
		{
			if (!_pendingSyncQueue.Any((PendingSyncItem item) => item.MachineCode == machineCode))
			{
				_pendingSyncQueue.Enqueue(new PendingSyncItem
				{
					MachineCode = machineCode,
					ActivationCode = activationCode,
					ExpireDate = expireDate,
					AddedTime = DateTime.Now
				});
				SavePendingQueue();
				LogSave.SaveExeLog($"已添加到待同步队列: {machineCode.Substring(0, Math.Min(6, machineCode.Length))}***");
			}
		}
	}

	private void LoadPendingQueue()
	{
		try
		{
			string path = Path.Combine(Path.GetDirectoryName(MainData.Spath), "pending_sync.json");
			if (!File.Exists(path))
			{
				return;
			}
			List<PendingSyncItem> list = JsonConvert.DeserializeObject<List<PendingSyncItem>>(File.ReadAllText(path));
			if (list == null)
			{
				return;
			}
			lock (_syncLock)
			{
				_pendingSyncQueue.Clear();
				foreach (PendingSyncItem item in list)
				{
					_pendingSyncQueue.Enqueue(item);
				}
			}
			LogSave.SaveExeLog($"已加载待同步队列: {list.Count}条");
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"加载待同步队列失败: {ex.Message}");
		}
	}

	private void SavePendingQueue()
	{
		try
		{
			string path = Path.Combine(Path.GetDirectoryName(MainData.Spath), "pending_sync.json");
			List<PendingSyncItem> list;
			lock (_syncLock)
			{
				list = _pendingSyncQueue.ToList();
			}
			if (list.Count > 0)
			{
				string contents = JsonConvert.SerializeObject(list, Formatting.Indented);
				File.WriteAllText(path, contents);
			}
			else if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"保存待同步队列失败: {ex.Message}");
		}
	}
}
