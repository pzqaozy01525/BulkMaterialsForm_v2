// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.HybridActivationAPI

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BulkMaterialsForm.Help;
using Newtonsoft.Json;

namespace BulkMaterialsForm.API;

public class HybridActivationAPI
{
	private static readonly Lazy<HybridActivationAPI> _instance = new Lazy<HybridActivationAPI>(() => new HybridActivationAPI());

	private readonly CloudSyncService _cloudSync;

	private readonly ActivationCacheManager _cacheManager;

	private readonly NetworkDetector _networkDetector;

	private readonly SecurityHelper _securityHelper;

	private HttpClient _httpClient;

	private string _baseUrl;

	private bool _isInitialized;

	public static HybridActivationAPI Instance => _instance.Value;

	private HybridActivationAPI()
	{
		_cloudSync = new CloudSyncService();
		_cacheManager = new ActivationCacheManager();
		_networkDetector = new NetworkDetector();
		_securityHelper = new SecurityHelper();
	}

	public void Initialize()
	{
		if (_isInitialized)
		{
			return;
		}
		try
		{
			_baseUrl = (MainData.ServerIP ?? "").TrimEnd('/');
			if (string.IsNullOrWhiteSpace(_baseUrl))
			{
				LogSave.SaveExeLog("HybridActivationAPI: ServerIP未配置，将仅使用本地验证");
				_isInitialized = true;
				return;
			}
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(_baseUrl),
				Timeout = TimeSpan.FromSeconds(30.0)
			};
			string text = New_IniFile.ReadContentValue("窗体框架配制", "ApiKey", MainData.Spath);
			if (!string.IsNullOrWhiteSpace(text))
			{
				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", text);
			}
			_cloudSync.Initialize(_httpClient, _securityHelper);
			_cacheManager.Initialize();
			_isInitialized = true;
			LogSave.SaveExeLog("HybridActivationAPI初始化成功: " + _baseUrl);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("HybridActivationAPI初始化失败: " + ex.Message);
			_isInitialized = true;
		}
	}

	public async Task<ActivationResult> VerifyActivationAsync(string machineCode)
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		try
		{
			if (await _networkDetector.IsConnectedAsync() && _httpClient != null)
			{
				ActivationResult cloudResult = await VerifyFromCloudAsync(machineCode);
				if (cloudResult.IsSuccess)
				{
					await _cacheManager.UpdateCacheAsync(machineCode, cloudResult);
					LogSave.SaveExeLog($"云端验证成功，使用云端到期时间: {cloudResult.ExpireDate:yyyy-MM-dd}");
					return cloudResult;
				}
				LogSave.SaveExeLog("云端验证失败，降级到离线验证: " + cloudResult.Message);
			}
			ActivationResult localResult = VerifyFromLocalSecure(machineCode);
			if (localResult.IsValid)
			{
				if (await _cacheManager.VerifyFromCacheAsync(machineCode) != null)
				{
					if (_cacheManager.IsOfflineGraceValid())
					{
						return new ActivationResult
						{
							IsSuccess = true,
							IsValid = true,
							ExpireDate = localResult.ExpireDate,
							Message = $"离线验证成功（剩余{_cacheManager.GetRemainingGraceDays()}天）",
							LastVerifyTime = DateTime.Now,
							SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
							SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
							SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
						};
					}
					if (localResult.ExpireDate > DateTime.Now)
					{
						return new ActivationResult
						{
							IsSuccess = true,
							IsValid = true,
							ExpireDate = localResult.ExpireDate,
							Message = "离线验证成功（宽限期已过但许可证有效）",
							LastVerifyTime = DateTime.Now,
							SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
							SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
							SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
						};
					}
					return new ActivationResult
					{
						IsSuccess = false,
						IsValid = false,
						Message = "离线宽限期已过，请连接网络验证",
						ExpireDate = localResult.ExpireDate,
						SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
						SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
						SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
					};
				}
				return localResult;
			}
			ActivationResult activationResult = VerifyFromLocal(machineCode);
			if (activationResult.IsValid)
			{
				return activationResult;
			}
			return new ActivationResult
			{
				IsSuccess = false,
				IsValid = false,
				Message = "未找到有效授权",
				SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
				SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
				SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
			};
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("激活验证异常: " + ex.Message);
			ActivationResult activationResult2 = VerifyFromLocalSecure(SoftAuthorize.GetMachineCodeForAuth());
			if (activationResult2.IsValid)
			{
				return activationResult2;
			}
			return VerifyFromLocal(machineCode);
		}
	}

	private async Task<ActivationResult> VerifyFromCloudAsync(string machineCode)
	{
		_ = 1;
		try
		{
			string plainText = JsonConvert.SerializeObject(new
			{
				MachineCode = _securityHelper.HashMachineCode(machineCode),
				Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
				Action = "verify"
			});
			string data = _securityHelper.EncryptData(plainText);
			string signature = _securityHelper.GenerateSignature(data);
			StringContent content = new StringContent(JsonConvert.SerializeObject(new
			{
				Data = data,
				Signature = signature
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync("/api/v1/activation/verify", content);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				CloudApiResponse cloudApiResponse = JsonConvert.DeserializeObject<CloudApiResponse>(await httpResponseMessage.Content.ReadAsStringAsync());
				if (_securityHelper.VerifySignature(cloudApiResponse.Data, cloudApiResponse.Signature))
				{
					ActivationResult activationResult = JsonConvert.DeserializeObject<ActivationResult>(_securityHelper.DecryptData(cloudApiResponse.Data));
					if (activationResult != null && activationResult.ExpireDate > DateTime.Now)
					{
						activationResult.IsSuccess = true;
						activationResult.IsValid = true;
						activationResult.LastVerifyTime = DateTime.Now;
						UpdateSecureExpiryDate(activationResult.ExpireDate);
						LogSave.SaveExeLog($"云端激活验证成功，使用云端到期: {activationResult.ExpireDate:yyyy-MM-dd}");
						return activationResult;
					}
					if (activationResult != null && activationResult.ExpireDate <= DateTime.Now)
					{
						LogSave.SaveExeLog("云端验证: 许可证已过期");
						return new ActivationResult
						{
							IsSuccess = false,
							IsValid = false,
							ExpireDate = activationResult.ExpireDate,
							Message = "授权已过期",
							SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
							SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
							SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
						};
					}
				}
			}
			return new ActivationResult
			{
				IsSuccess = false,
				IsValid = false,
				Message = "云端验证失败",
				SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
				SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
				SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
			};
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("云端验证异常: " + ex.Message);
			return new ActivationResult
			{
				IsSuccess = false,
				IsValid = false,
				Message = "云端验证异常: " + ex.Message,
				SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
				SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
				SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
			};
		}
	}

	private ActivationResult VerifyFromLocalSecure(string machineCode)
	{
		try
		{
			var (flag, dateTime, text) = SecureActivationStore.VerifyActivationCode(machineCode);
			if (flag && dateTime.HasValue)
			{
				return new ActivationResult
				{
					IsSuccess = true,
					IsValid = true,
					ExpireDate = dateTime.Value,
					Message = "本地安全验证成功",
					LastVerifyTime = DateTime.Now,
					SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
					SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
					SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
				};
			}
			return new ActivationResult
			{
				IsSuccess = false,
				IsValid = false,
				Message = (text ?? "本地安全验证失败"),
				SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
				SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
				SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
			};
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("本地安全验证异常: " + ex.Message);
			return new ActivationResult
			{
				IsSuccess = false,
				IsValid = false,
				Message = "验证异常: " + ex.Message,
				SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
				SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
				SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
			};
		}
	}

	private ActivationResult VerifyFromLocal(string machineCode)
	{
		try
		{
			var (flag, dateTime, _) = SecureActivationStore.VerifyActivationCode(machineCode);
			if (flag && dateTime.HasValue)
			{
				return new ActivationResult
				{
					IsSuccess = true,
					IsValid = true,
					ExpireDate = dateTime.Value,
					Message = "本地验证成功（DPAPI）",
					LastVerifyTime = DateTime.Now,
					SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
					SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
					SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
				};
			}
			string text = New_IniFile.ReadContentValue("窗体框架配制", "激活码", MainData.Spath);
			if (!string.IsNullOrWhiteSpace(text))
			{
				SoftAuthorize softAuthorize = new SoftAuthorize();
				string info = softAuthorize.GetInfo();
				if (softAuthorize.CheckAuthorize(info, text))
				{
					string text2 = SecureActivationStore.DesDecrypt(text);
					DateTime? dateTime2 = null;
					if (!string.IsNullOrEmpty(text2) && text2.Contains("|"))
					{
						string[] array = text2.Split('|');
						if (array.Length >= 3 && DateTime.TryParse(array[2], out var result))
						{
							dateTime2 = result;
						}
					}
					DateTime dateTime3 = dateTime2 ?? MainData.ExpTime;
					if (dateTime3 > DateTime.Now)
					{
						return new ActivationResult
						{
							IsSuccess = true,
							IsValid = true,
							ExpireDate = dateTime3,
							Message = "本地验证成功（旧格式）",
							LastVerifyTime = DateTime.Now,
							SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
							SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
							SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
						};
					}
				}
			}
			if (MainData.ExpTime > DateTime.Now)
			{
				return new ActivationResult
				{
					IsSuccess = true,
					IsValid = true,
					ExpireDate = MainData.ExpTime,
					Message = "本地验证成功（INI，仅作参考）",
					LastVerifyTime = DateTime.Now,
					SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
					SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
					SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
				};
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("本地验证异常: " + ex.Message);
		}
		return new ActivationResult
		{
			IsSuccess = false,
			IsValid = false,
			Message = "本地验证失败",
			SupportName = New_IniFile.ReadContentValue("窗体框架配制", "SupportName", MainData.Spath),
			SupportPhone = New_IniFile.ReadContentValue("窗体框架配制", "SupportPhone", MainData.Spath),
			SupportCompany = New_IniFile.ReadContentValue("窗体框架配制", "SupportCompany", MainData.Spath)
		};
	}

	private void UpdateSecureExpiryDate(DateTime cloudExpiryDate)
	{
		try
		{
			(string MachineCode, string ActivationDate, string ExpiryDate, bool Success) tuple = SecureActivationStore.LoadActivationCode();
			var (machineCode, activationDate, _, _) = tuple;
			if (tuple.Success)
			{
				SecureActivationStore.SaveActivationCode(machineCode, activationDate, cloudExpiryDate.ToString("yyyy-MM-dd HH:mm:ss"));
				LogSave.SaveExeLog($"已更新DPAPI存储的到期时间: {cloudExpiryDate:yyyy-MM-dd}");
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("更新安全过期日期失败: " + ex.Message);
		}
	}

	public async Task<bool> SyncActivationAsync(string machineCode, string activationCode, DateTime expireDate)
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		try
		{
			return await _cloudSync.SyncActivationAsync(machineCode, activationCode, expireDate);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("同步激活信息失败: " + ex.Message);
			return false;
		}
	}

	public async Task<bool> SyncCustomerInfoAsync(CustomerInfo customerInfo)
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		try
		{
			return await _cloudSync.SyncCustomerInfoAsync(customerInfo);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("同步客户信息失败: " + ex.Message);
			return false;
		}
	}

	public async Task<ActivationSummary> GetActivationSummaryAsync(string machineCode)
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		ActivationSummary activationSummary = new ActivationSummary
		{
			MachineCode = machineCode
		};
		ActivationSummary activationSummary2 = activationSummary;
		activationSummary2.IsOnline = await _networkDetector.IsConnectedAsync();
		ActivationSummary summary = activationSummary;
		ActivationResult activationResult = await VerifyActivationAsync(machineCode);
		summary.IsActivated = activationResult.IsValid;
		summary.ExpireDate = activationResult.ExpireDate;
		summary.RemainingDays = (activationResult.ExpireDate - DateTime.Now).Days;
		summary.LastSyncTime = activationResult.LastVerifyTime;
		return summary;
	}

	public void StartBackgroundSync()
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		_cloudSync.StartBackgroundSync();
	}

	public void StopBackgroundSync()
	{
		_cloudSync.StopBackgroundSync();
	}

	public async Task<ActivationRequestResult> SubmitActivationRequestAsync(ActivationRequest request)
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		try
		{
			if (_httpClient == null)
			{
				return new ActivationRequestResult
				{
					Success = false,
					Message = "服务器地址未配置"
				};
			}
			string plainText = JsonConvert.SerializeObject(new
			{
				CompanyName = request.CompanyName,
				CreditCode = request.CreditCode,
				PollutionPermit = request.PollutionPermit,
				Contact = request.Contact,
				Phone = request.Phone,
				MachineCode = _securityHelper.HashMachineCode(request.MachineCode),
				ClientId = request.ClientId,
				RequestTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
				Version = "2.0"
			});
			string data = _securityHelper.EncryptData(plainText);
			string signature = _securityHelper.GenerateSignature(data);
			StringContent content = new StringContent(JsonConvert.SerializeObject(new
			{
				Data = data,
				Signature = signature
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync("/api/v1/activation/request", content);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				ActivationRequestResponse activationRequestResponse = JsonConvert.DeserializeObject<ActivationRequestResponse>(await httpResponseMessage.Content.ReadAsStringAsync());
				if (activationRequestResponse != null && activationRequestResponse.Success)
				{
					LogSave.SaveExeLog("激活请求提交成功: " + request.CompanyName);
					ActivationRequestResult result = new ActivationRequestResult
					{
						Success = true,
						Message = (activationRequestResponse.Message ?? "激活成功"),
						RequestId = activationRequestResponse.RequestId,
						ActivationCode = activationRequestResponse.ActivationCode,
						ExpireDate = activationRequestResponse.ExpireDate,
						CustomerId = activationRequestResponse.CustomerId,
						TenantId = activationRequestResponse.TenantId,
						CompanyName = activationRequestResponse.CompanyName,
						CreditCode = activationRequestResponse.CreditCode,
						Phone = activationRequestResponse.Phone,
						Contact = activationRequestResponse.Contact,
						AdminUsername = activationRequestResponse.AdminUsername,
						AdminPassword = activationRequestResponse.AdminPassword,
						IsActive = activationRequestResponse.IsActive
					};
					if (!string.IsNullOrWhiteSpace(activationRequestResponse.ActivationCode) && activationRequestResponse.ExpireDate.HasValue)
					{
						string machineCodeForAuth = SoftAuthorize.GetMachineCodeForAuth();
						string activationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
						string expiryDate = activationRequestResponse.ExpireDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
						SecureActivationStore.SaveActivationCode(machineCodeForAuth, activationDate, expiryDate);
						MainData.SaveExpTime(activationRequestResponse.ExpireDate.Value);
						Activation.MarkAsActivated("在线激活");
					}
					return result;
				}
				return new ActivationRequestResult
				{
					Success = false,
					Message = (activationRequestResponse?.Message ?? "服务器处理失败")
				};
			}
			return new ActivationRequestResult
			{
				Success = false,
				Message = $"HTTP {(int)httpResponseMessage.StatusCode}"
			};
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("提交激活请求异常: " + ex.Message);
			return new ActivationRequestResult
			{
				Success = false,
				Message = "提交失败: " + ex.Message
			};
		}
	}
}
