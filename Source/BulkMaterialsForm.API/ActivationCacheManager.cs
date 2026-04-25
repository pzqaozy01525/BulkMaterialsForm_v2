// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.ActivationCacheManager

using System;
using System.IO;
using System.Threading.Tasks;
using BulkMaterialsForm.Help;
using Newtonsoft.Json;

namespace BulkMaterialsForm.API;

public class ActivationCacheManager
{
	private const int OFFLINE_GRACE_PERIOD_DAYS = 15;

	private string _cacheFilePath;

	private string _lastOnlineFilePath;

	private SecurityHelper _securityHelper;

	private DateTime _lastOnlineCheckTime;

	private readonly object _cacheLock = new object();

	public ActivationCacheManager()
	{
		_securityHelper = new SecurityHelper();
	}

	public void Initialize()
	{
		try
		{
			string text = Path.Combine(Path.GetDirectoryName(MainData.Spath), "Cache");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			_cacheFilePath = Path.Combine(text, "activation.cache");
			_lastOnlineFilePath = Path.Combine(text, "last_online.dat");
			LoadLastOnlineCheckTime();
			LogSave.SaveExeLog("ActivationCacheManager初始化成功，缓存路径: " + _cacheFilePath);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("ActivationCacheManager初始化失败: " + ex.Message);
		}
	}

	public async Task UpdateCacheAsync(string machineCode, ActivationResult result)
	{
		await Task.Run(delegate
		{
			try
			{
				lock (_cacheLock)
				{
					string plainText = JsonConvert.SerializeObject(new ActivationCacheData
					{
						MachineCode = machineCode,
						IsValid = result.IsValid,
						ExpireDate = result.ExpireDate,
						LastVerifyTime = result.LastVerifyTime,
						LastOnlineCheckTime = DateTime.Now,
						CacheVersion = "3.0",
						Message = result.Message,
						Status = result.Status
					}, Formatting.Indented);
					string contents = _securityHelper.EncryptData(plainText);
					File.WriteAllText(_cacheFilePath, contents);
					_lastOnlineCheckTime = DateTime.Now;
					SaveLastOnlineCheckTime();
					UpdateSecureExpiryFromCache(result);
					LogSave.SaveExeLog($"激活缓存已更新: 到期 {result.ExpireDate:yyyy-MM-dd}, 状态: {result.Status}");
				}
			}
			catch (Exception ex)
			{
				LogSave.SaveExeLog("更新激活缓存失败: " + ex.Message);
			}
		});
	}

	public async Task<ActivationResult> VerifyFromCacheAsync(string machineCode)
	{
		return await Task.Run(delegate
		{
			try
			{
				lock (_cacheLock)
				{
					if (!File.Exists(_cacheFilePath))
					{
						LogSave.SaveExeLog("激活缓存文件不存在");
						return (ActivationResult)null;
					}
					string cipherText = File.ReadAllText(_cacheFilePath);
					ActivationCacheData activationCacheData = JsonConvert.DeserializeObject<ActivationCacheData>(_securityHelper.DecryptData(cipherText));
					if (activationCacheData == null)
					{
						LogSave.SaveExeLog("缓存数据解析失败");
						return (ActivationResult)null;
					}
					if (activationCacheData.MachineCode != machineCode)
					{
						LogSave.SaveExeLog("缓存的机器码不匹配");
						return (ActivationResult)null;
					}
					(bool IsValid, DateTime? ExpiryDate, string Message) tuple = SecureActivationStore.VerifyActivationCode(machineCode);
					bool item = tuple.IsValid;
					DateTime? item2 = tuple.ExpiryDate;
					DateTime dateTime = ((item && item2.HasValue) ? item2.Value : activationCacheData.ExpireDate);
					if (dateTime < DateTime.Now)
					{
						LogSave.SaveExeLog($"许可证已过期（到期: {dateTime:yyyy-MM-dd}）");
						return new ActivationResult
						{
							IsSuccess = false,
							IsValid = false,
							ExpireDate = dateTime,
							Message = "授权已过期",
							LastVerifyTime = activationCacheData.LastVerifyTime,
							Status = "Expired",
							SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
							SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
							SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
						};
					}
					if (IsOfflineGraceValid())
					{
						return new ActivationResult
						{
							IsSuccess = true,
							IsValid = true,
							ExpireDate = dateTime,
							Message = $"从缓存验证（剩余{GetRemainingGraceDays()}天宽限期）",
							LastVerifyTime = activationCacheData.LastVerifyTime,
							Status = (activationCacheData.Status ?? "Active"),
							SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
							SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
							SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
						};
					}
					if (dateTime > DateTime.Now)
					{
						return new ActivationResult
						{
							IsSuccess = true,
							IsValid = true,
							ExpireDate = dateTime,
							Message = "离线验证成功（宽限期已过，但许可证有效至" + dateTime.ToString("yyyy-MM-dd") + "）",
							LastVerifyTime = activationCacheData.LastVerifyTime,
							Status = (activationCacheData.Status ?? "Active"),
							SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
							SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
							SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
						};
					}
					return new ActivationResult
					{
						IsSuccess = false,
						IsValid = false,
						ExpireDate = dateTime,
						Message = $"离线宽限期已过，请连接网络验证（许可证到期: {dateTime:yyyy-MM-dd}）",
						LastVerifyTime = activationCacheData.LastVerifyTime,
						Status = "Expired",
						SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
						SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
						SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
					};
				}
			}
			catch (Exception ex)
			{
				LogSave.SaveExeLog("从缓存验证失败: " + ex.Message);
				return (ActivationResult)null;
			}
		});
	}

	public bool IsOfflineGraceValid()
	{
		try
		{
			var (flag, dateTime, _) = SecureActivationStore.VerifyActivationCode(SoftAuthorize.GetMachineCodeForAuth());
			if (flag && dateTime.HasValue)
			{
				TimeSpan timeSpan = DateTime.Now - _lastOnlineCheckTime;
				bool result = timeSpan.TotalDays <= 15.0;
				LogSave.SaveExeLog($"离线宽限期检查: 已离线{timeSpan.TotalDays:F1}天, 宽限期{15}天, 许可证到期{dateTime.Value:yyyy-MM-dd}");
				return result;
			}
			return (DateTime.Now - _lastOnlineCheckTime).TotalDays <= 15.0;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("检查离线宽限期失败: " + ex.Message);
			return false;
		}
	}

	public int GetRemainingGraceDays()
	{
		try
		{
			int num = (int)(DateTime.Now - _lastOnlineCheckTime).TotalDays;
			int val = 15 - num;
			return Math.Max(0, val);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("获取剩余宽限天数失败: " + ex.Message);
			return 0;
		}
	}

	public void ClearCache()
	{
		try
		{
			lock (_cacheLock)
			{
				if (File.Exists(_cacheFilePath))
				{
					File.Delete(_cacheFilePath);
					LogSave.SaveExeLog("激活缓存已清除");
				}
				_lastOnlineCheckTime = DateTime.MinValue;
				SaveLastOnlineCheckTime();
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("清除缓存失败: " + ex.Message);
		}
	}

	private void LoadLastOnlineCheckTime()
	{
		try
		{
			if (File.Exists(_lastOnlineFilePath))
			{
				string cipherText = File.ReadAllText(_lastOnlineFilePath);
				if (DateTime.TryParse(_securityHelper.DecryptData(cipherText), out var result))
				{
					_lastOnlineCheckTime = result;
				}
				else
				{
					_lastOnlineCheckTime = DateTime.Now;
				}
			}
			else
			{
				_lastOnlineCheckTime = DateTime.Now;
				SaveLastOnlineCheckTime();
			}
			LogSave.SaveExeLog($"最后在线检查时间: {_lastOnlineCheckTime:yyyy-MM-dd HH:mm:ss}");
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("加载最后在线检查时间失败: " + ex.Message);
			_lastOnlineCheckTime = DateTime.Now;
		}
	}

	private void SaveLastOnlineCheckTime()
	{
		try
		{
			string plainText = _lastOnlineCheckTime.ToString("yyyy-MM-dd HH:mm:ss");
			string contents = _securityHelper.EncryptData(plainText);
			File.WriteAllText(_lastOnlineFilePath, contents);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("保存最后在线检查时间失败: " + ex.Message);
		}
	}

	private void UpdateSecureExpiryFromCache(ActivationResult result)
	{
		try
		{
			if (result.ExpireDate > DateTime.Now)
			{
				(string MachineCode, string ActivationDate, string ExpiryDate, bool Success) tuple = SecureActivationStore.LoadActivationCode();
				var (machineCode, activationDate, _, _) = tuple;
				if (!tuple.Success)
				{
					machineCode = SoftAuthorize.GetMachineCodeForAuth();
					activationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				}
				SecureActivationStore.SaveActivationCode(machineCode, activationDate, result.ExpireDate.ToString("yyyy-MM-dd HH:mm:ss"));
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("更新DPAPI过期日期失败: " + ex.Message);
		}
	}

	public CacheInfo GetCacheInfo()
	{
		try
		{
			lock (_cacheLock)
			{
				CacheInfo cacheInfo = new CacheInfo
				{
					CacheExists = File.Exists(_cacheFilePath),
					LastOnlineCheckTime = _lastOnlineCheckTime,
					IsOfflineGraceValid = IsOfflineGraceValid(),
					RemainingGraceDays = GetRemainingGraceDays(),
					GracePeriodDays = 15
				};
				if (cacheInfo.CacheExists)
				{
					try
					{
						string cipherText = File.ReadAllText(_cacheFilePath);
						ActivationCacheData activationCacheData = JsonConvert.DeserializeObject<ActivationCacheData>(_securityHelper.DecryptData(cipherText));
						if (activationCacheData != null)
						{
							(bool IsValid, DateTime? ExpiryDate, string Message) tuple = SecureActivationStore.VerifyActivationCode(SoftAuthorize.GetMachineCodeForAuth());
							bool item = tuple.IsValid;
							DateTime? item2 = tuple.ExpiryDate;
							cacheInfo.CachedExpireDate = ((item && item2.HasValue) ? item2.Value : activationCacheData.ExpireDate);
							cacheInfo.CachedMachineCode = ((activationCacheData.MachineCode != null) ? (activationCacheData.MachineCode.Substring(0, Math.Min(6, activationCacheData.MachineCode.Length)) + "***") : null);
							cacheInfo.CachedIsValid = activationCacheData.IsValid;
						}
					}
					catch (Exception ex)
					{
						LogSave.SaveExeLog("读取缓存信息失败: " + ex.Message);
					}
				}
				return cacheInfo;
			}
		}
		catch (Exception ex2)
		{
			LogSave.SaveExeLog("获取缓存信息失败: " + ex2.Message);
			return new CacheInfo();
		}
	}
}
