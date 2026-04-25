// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.LicenseStore

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BulkMaterialsForm.Help;

public static class LicenseStore
{
	private const string ProductFolder = "BulkMaterialsForm";

	private const string LicenseFileName = "license.dat";

	private const string MetaFileName = "license.meta.json";

	public static string GetProgramDataDir()
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "BulkMaterialsForm");
		Directory.CreateDirectory(text);
		return text;
	}

	public static string GetLicenseFilePath()
	{
		return Path.Combine(GetProgramDataDir(), "license.dat");
	}

	public static string GetMetaFilePath()
	{
		return Path.Combine(GetProgramDataDir(), "license.meta.json");
	}

	public static bool SaveLicenseContent(string licenseContent)
	{
		try
		{
			byte[] bytes = MachineLevelDataProtector.Protect(Encoding.UTF8.GetBytes(licenseContent));
			File.WriteAllBytes(GetLicenseFilePath(), bytes);
			LicenseMeta value = new LicenseMeta
			{
				LastUpdatedUtc = DateTime.UtcNow
			};
			File.WriteAllText(GetMetaFilePath(), JsonConvert.SerializeObject(value));
			return true;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("SaveLicenseContent error: " + ex.Message);
			return false;
		}
	}

	public static string LoadLicenseContent()
	{
		try
		{
			string licenseFilePath = GetLicenseFilePath();
			if (!File.Exists(licenseFilePath))
			{
				return null;
			}
			byte[] array = MachineLevelDataProtector.Unprotect(File.ReadAllBytes(licenseFilePath));
			return (array != null) ? Encoding.UTF8.GetString(array) : null;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("LoadLicenseContent error: " + ex.Message);
			return null;
		}
	}

	public static bool TryParseAndSaveLicense(string signedResponseJson, out string message)
	{
		try
		{
			JObject jObject = JObject.Parse(signedResponseJson);
			string empty = string.Empty;
			string empty2 = string.Empty;
			string text = "primary";
			if (jObject["LicenseJson"] != null || jObject["licenseJson"] != null)
			{
				empty = (jObject["LicenseJson"] ?? jObject["licenseJson"])?.ToString() ?? string.Empty;
				empty2 = (jObject["Signature"] ?? jObject["signature"])?.ToString() ?? string.Empty;
			}
			else
			{
				string s = jObject.ToString();
				JObject jObject2 = JObject.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(s)));
				string s2 = (jObject2["Payload"] ?? jObject2["payload"])?.ToString() ?? string.Empty;
				empty = Encoding.UTF8.GetString(Convert.FromBase64String(s2));
				empty2 = (jObject2["Signature"] ?? jObject2["signature"])?.ToString() ?? string.Empty;
				text = (jObject2["KeyId"] ?? jObject2["keyId"])?.ToString() ?? "primary";
			}
			if (string.IsNullOrWhiteSpace(empty) || string.IsNullOrWhiteSpace(empty2))
			{
				message = "缺少 LicenseJson 或 Signature 字段";
				return false;
			}
			string publicKeyById = GetPublicKeyById(text);
			LogSave.SaveExeLog($"[TryParseAndSaveLicense] 从配置读取公钥, keyId={text}, 公钥长度={publicKeyById?.Length ?? 0}");
			if (string.IsNullOrWhiteSpace(publicKeyById))
			{
				message = "公钥未配置";
				return false;
			}
			if (!VerifySignatureWithRsa(empty, empty2, publicKeyById))
			{
				message = "签名验证失败";
				return false;
			}
			string licenseContent = new JObject
			{
				["LicenseJson"] = empty,
				["Signature"] = empty2,
				["KeyId"] = text,
				["SavedAt"] = DateTime.UtcNow.ToString("O")
			}.ToString(Formatting.None);
			if (!SaveLicenseContent(licenseContent))
			{
				message = "保存授权文件失败";
				return false;
			}
			if (!TryParsePayload(licenseContent, out var _, out message))
			{
				return false;
			}
			message = "授权保存成功";
			return true;
		}
		catch (Exception ex)
		{
			message = "解析授权失败: " + ex.Message;
			return false;
		}
	}

	public static bool TryParsePayload(string licenseContent, out LicensePayload payload, out string message)
	{
		payload = null;
		message = null;
		try
		{
			JObject jObject = JObject.Parse(licenseContent);
			string empty = string.Empty;
			string text = string.Empty;
			string keyId = "primary";
			if (jObject["LicenseJson"] != null || jObject["licenseJson"] != null)
			{
				empty = (jObject["LicenseJson"] ?? jObject["licenseJson"])?.ToString() ?? string.Empty;
				text = (jObject["Signature"] ?? jObject["signature"])?.ToString() ?? string.Empty;
				keyId = (jObject["KeyId"] ?? jObject["keyId"])?.ToString() ?? "primary";
			}
			else
			{
				string text2 = (jObject["Payload"] ?? jObject["payload"])?.ToString() ?? string.Empty;
				if (!string.IsNullOrEmpty(text2))
				{
					empty = Encoding.UTF8.GetString(Convert.FromBase64String(text2));
					text = (jObject["Signature"] ?? jObject["signature"])?.ToString() ?? string.Empty;
					keyId = (jObject["KeyId"] ?? jObject["keyId"])?.ToString() ?? "primary";
				}
				else
				{
					empty = licenseContent;
				}
			}
			if (string.IsNullOrWhiteSpace(empty))
			{
				message = "授权内容为空";
				return false;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				string publicKeyById = GetPublicKeyById(keyId);
				if (string.IsNullOrWhiteSpace(publicKeyById))
				{
					message = "公钥未配置";
					return false;
				}
				if (!VerifySignatureWithRsa(empty, text, publicKeyById))
				{
					message = "签名验证失败";
					return false;
				}
			}
			payload = JsonConvert.DeserializeObject<LicensePayload>(empty);
			if (payload == null)
			{
				message = "授权载荷解析失败";
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			message = ex.Message;
			return false;
		}
	}

	public static bool CheckLocalValidity(out LicensePayload payload, out string message)
	{
		payload = null;
		message = null;
		string text = LoadLicenseContent();
		if (string.IsNullOrWhiteSpace(text))
		{
			message = "授权文件不存在";
			return false;
		}
		if (!TryParsePayload(text, out payload, out message))
		{
			return false;
		}
		try
		{
			string b = Activation.softAuthorize?.GetInfo() ?? new SoftAuthorize().GetInfo();
			if (!string.Equals(payload.MachineFingerprint, b, StringComparison.OrdinalIgnoreCase))
			{
				message = "机器指纹不匹配";
				return false;
			}
			DateTime? effectiveExpiryDate = payload.GetEffectiveExpiryDate();
			if (effectiveExpiryDate.HasValue)
			{
				DateTime valueOrDefault = effectiveExpiryDate.GetValueOrDefault();
				if (DateTime.Now > valueOrDefault)
				{
					message = "授权已过期";
					return false;
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			message = ex.Message;
			return false;
		}
	}

	public static void SaveLastCloudCheckUtc(DateTime utcNow)
	{
		try
		{
			LicenseMeta licenseMeta = (File.Exists(GetMetaFilePath()) ? (JsonConvert.DeserializeObject<LicenseMeta>(File.ReadAllText(GetMetaFilePath())) ?? new LicenseMeta()) : new LicenseMeta());
			licenseMeta.LastCloudCheckUtc = utcNow;
			licenseMeta.ConsecutiveFailures = 0;
			File.WriteAllText(GetMetaFilePath(), JsonConvert.SerializeObject(licenseMeta));
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("SaveLastCloudCheckUtc error: " + ex.Message);
		}
	}

	public static LicenseMeta LoadMeta()
	{
		try
		{
			return File.Exists(GetMetaFilePath()) ? (JsonConvert.DeserializeObject<LicenseMeta>(File.ReadAllText(GetMetaFilePath())) ?? new LicenseMeta()) : new LicenseMeta();
		}
		catch
		{
			return new LicenseMeta();
		}
	}

	public static void IncrementCloudFailure()
	{
		try
		{
			LicenseMeta licenseMeta = (File.Exists(GetMetaFilePath()) ? (JsonConvert.DeserializeObject<LicenseMeta>(File.ReadAllText(GetMetaFilePath())) ?? new LicenseMeta()) : new LicenseMeta());
			licenseMeta.ConsecutiveFailures = Math.Max(0, licenseMeta.ConsecutiveFailures) + 1;
			File.WriteAllText(GetMetaFilePath(), JsonConvert.SerializeObject(licenseMeta));
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("IncrementCloudFailure error: " + ex.Message);
		}
	}

	private static bool VerifySignatureWithRsa(string payloadJson, string signatureBase64, string publicKeyPem)
	{
		LogSave.SaveExeLog(string.Format("[VerifySignatureWithRsa] publicKeyPem 长度={0}, 包含XML标签={1}", publicKeyPem?.Length ?? 0, publicKeyPem?.Contains("<RSAKeyValue>")));
		if (string.IsNullOrWhiteSpace(payloadJson) || string.IsNullOrWhiteSpace(signatureBase64))
		{
			return false;
		}
		try
		{
			byte[] rgbSignature = Convert.FromBase64String(signatureBase64);
			byte[] bytes = Encoding.UTF8.GetBytes(payloadJson);
			using RSACryptoServiceProvider key = LoadRsaFromPem(publicKeyPem);
			LogSave.SaveExeLog("[VerifySignatureWithRsa] RSA对象创建成功，开始验证签名");
			RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(key);
			rSAPKCS1SignatureDeformatter.SetHashAlgorithm("SHA256");
			using SHA256 sHA = SHA256.Create();
			byte[] rgbHash = sHA.ComputeHash(bytes);
			bool flag = rSAPKCS1SignatureDeformatter.VerifySignature(rgbHash, rgbSignature);
			LogSave.SaveExeLog($"[VerifySignatureWithRsa] 签名验证结果: {flag}");
			return flag;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("RSA signature verification error: " + ex.Message);
			return false;
		}
	}

	private static RSACryptoServiceProvider LoadRsaFromPem(string publicKey)
	{
		string text = publicKey.Trim();
		LogSave.SaveExeLog($"[LoadRsaFromPem] 输入长度={text.Length}, 前50字符={((text.Length > 50) ? text.Substring(0, 50) : text)}");
		RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
		try
		{
			if (text.Contains("<RSAKeyValue>") || text.Contains("<Modulus>"))
			{
				LogSave.SaveExeLog("[LoadRsaFromPem] 尝试解析RSA XML参数");
				LoadRsaFromXmlString(rSACryptoServiceProvider, text);
				LogSave.SaveExeLog("[LoadRsaFromPem] RSA XML参数解析成功");
			}
			else
			{
				byte[] array = Convert.FromBase64String(ExtractBase64FromPem(text));
				LogSave.SaveExeLog($"[LoadRsaFromPem] 尝试使用 ImportCspBlob, keyBytes长度={array.Length}");
				rSACryptoServiceProvider.ImportCspBlob(array);
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LoadRsaFromPem] 异常: " + ex.GetType().Name + " - " + ex.Message);
			rSACryptoServiceProvider.Dispose();
			throw;
		}
		return rSACryptoServiceProvider;
	}

	private static void LoadRsaFromXmlString(RSACryptoServiceProvider rsa, string xml)
	{
		string text = xml.Trim();
		text = text.Replace("\r", "").Replace("\n", "").Replace("\t", "");
		text = RemoveInvalidChars(text);
		RSAParameters parameters = new RSAParameters
		{
			Modulus = Convert.FromBase64String(ExtractTag(text, "Modulus")),
			Exponent = Convert.FromBase64String(ExtractTag(text, "Exponent"))
		};
		if (HasTag(text, "P") && HasTag(text, "Q"))
		{
			parameters.P = Convert.FromBase64String(ExtractTag(text, "P"));
			parameters.Q = Convert.FromBase64String(ExtractTag(text, "Q"));
			parameters.DP = Convert.FromBase64String(ExtractTag(text, "DP"));
			parameters.DQ = Convert.FromBase64String(ExtractTag(text, "DQ"));
			parameters.InverseQ = Convert.FromBase64String(ExtractTag(text, "InverseQ"));
			parameters.D = Convert.FromBase64String(ExtractTag(text, "D"));
		}
		rsa.ImportParameters(parameters);
	}

	private static string RemoveInvalidChars(string s)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in s)
		{
			if (c >= ' ' && c != '\ufffe' && c != '\uffff')
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static string ExtractTag(string xml, string tagName)
	{
		string text = "<" + tagName + ">";
		string value = "</" + tagName + ">";
		int num = xml.IndexOf(text, StringComparison.Ordinal) + text.Length;
		int num2 = xml.IndexOf(value, StringComparison.Ordinal);
		return xml.Substring(num, num2 - num);
	}

	private static bool HasTag(string xml, string tagName)
	{
		if (xml.Contains("<" + tagName + ">"))
		{
			return xml.Contains("</" + tagName + ">");
		}
		return false;
	}

	private static string ExtractBase64FromPem(string pem)
	{
		return pem.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace("\r", "")
			.Replace("\n", "")
			.Replace(" ", "");
	}

	private static string GetPublicKeyById(string keyId)
	{
		string text = ((keyId == "secondary") ? "PublicKeySecondary" : "PublicKey");
		string text2 = New_IniFile.ReadContentValue("窗体框架配制", text, MainData.Spath);
		LogSave.SaveExeLog($"[GetPublicKeyById] 读取配置项={text}, 结果长度={text2?.Length ?? 0}, 前80字符={((text2 != null && text2.Length > 80) ? text2.Substring(0, 80) : text2)}");
		if (!string.IsNullOrWhiteSpace(text2))
		{
			return text2.Trim();
		}
		string environmentVariable = Environment.GetEnvironmentVariable("LICENSE_PUBLIC_KEY");
		if (!string.IsNullOrWhiteSpace(environmentVariable))
		{
			return environmentVariable;
		}
		LogSave.SaveExeLog("[GetPublicKeyById] 公钥未配置");
		return string.Empty;
	}
}
