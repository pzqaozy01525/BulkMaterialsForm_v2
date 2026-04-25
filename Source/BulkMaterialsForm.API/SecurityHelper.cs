// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.SecurityHelper

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using BulkMaterialsForm.Help;
using Newtonsoft.Json;

namespace BulkMaterialsForm.API;

public class SecurityHelper
{
	private string _encryptionKey;

	private string _signatureKey;

	private string _hashSalt;

	private readonly byte[] _defaultIV = new byte[16]
	{
		18, 52, 86, 120, 144, 171, 205, 239, 18, 52,
		86, 120, 144, 171, 205, 239
	};

	private readonly bool _useRandomIV;

	public SecurityHelper()
	{
		LoadSecurityKeys();
		_useRandomIV = !string.IsNullOrWhiteSpace(New_IniFile.ReadContentValue("窗体框架配制", "UseRandomIV", MainData.Spath));
	}

	private void LoadSecurityKeys()
	{
		_encryptionKey = New_IniFile.ReadContentValue("窗体框架配制", "EncryptionKey", MainData.Spath);
		_signatureKey = New_IniFile.ReadContentValue("窗体框架配制", "SignatureKey", MainData.Spath);
		_hashSalt = New_IniFile.ReadContentValue("窗体框架配制", "HashSalt", MainData.Spath);
		if (string.IsNullOrWhiteSpace(_encryptionKey))
		{
			_encryptionKey = "BulkMaterialsForm2024CloudSync32";
			LogSave.SaveExeLog("警告：使用默认加密密钥，生产环境请修改配置");
		}
		if (string.IsNullOrWhiteSpace(_signatureKey))
		{
			_signatureKey = "BulkMaterialsFormSignature2024SecureKey64Characters";
			LogSave.SaveExeLog("警告：使用默认签名密钥，生产环境请修改配置");
		}
		if (string.IsNullOrWhiteSpace(_hashSalt))
		{
			_hashSalt = "BulkMaterialsFormSalt2024";
			LogSave.SaveExeLog("警告：使用默认哈希盐值，生产环境请修改配置");
		}
		_encryptionKey = PadOrTruncate(_encryptionKey, 32);
	}

	public string EncryptData(string plainText)
	{
		if (string.IsNullOrEmpty(plainText))
		{
			return string.Empty;
		}
		try
		{
			using Aes aes = Aes.Create();
			aes.Key = Encoding.UTF8.GetBytes(_encryptionKey);
			if (_useRandomIV)
			{
				aes.GenerateIV();
			}
			else
			{
				aes.IV = _defaultIV;
			}
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			using ICryptoTransform transform = aes.CreateEncryptor();
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(aes.IV, 0, aes.IV.Length);
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
			{
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.FlushFinalBlock();
			}
			return Convert.ToBase64String(memoryStream.ToArray());
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"加密数据失败: {ex.Message}");
			throw new CryptographicException("数据加密失败", ex);
		}
	}

	public string DecryptData(string cipherText)
	{
		if (string.IsNullOrEmpty(cipherText))
		{
			return string.Empty;
		}
		try
		{
			byte[] array = Convert.FromBase64String(cipherText);
			byte[] array2 = new byte[16];
			byte[] array3 = new byte[array.Length - 16];
			Array.Copy(array, 0, array2, 0, 16);
			Array.Copy(array, 16, array3, 0, array3.Length);
			using Aes aes = Aes.Create();
			aes.Key = Encoding.UTF8.GetBytes(_encryptionKey);
			aes.IV = array2;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			using ICryptoTransform cryptoTransform = aes.CreateDecryptor();
			byte[] bytes = cryptoTransform.TransformFinalBlock(array3, 0, array3.Length);
			return Encoding.UTF8.GetString(bytes);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"解密数据失败: {ex.Message}");
			throw new CryptographicException("数据解密失败", ex);
		}
	}

	public string GenerateSignature(string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			return string.Empty;
		}
		try
		{
			using HMACSHA256 hMACSHA = new HMACSHA256(Encoding.UTF8.GetBytes(_signatureKey));
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			return Convert.ToBase64String(hMACSHA.ComputeHash(bytes));
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"生成签名失败: {ex.Message}");
			throw new CryptographicException("签名生成失败", ex);
		}
	}

	public bool VerifySignature(string data, string signature)
	{
		if (string.IsNullOrEmpty(data) || string.IsNullOrEmpty(signature))
		{
			return false;
		}
		try
		{
			string a = GenerateSignature(data);
			return SecureStringCompare(a, signature);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"验证签名失败: {ex.Message}");
			return false;
		}
	}

	public string HashMachineCode(string machineCode)
	{
		if (string.IsNullOrEmpty(machineCode))
		{
			return string.Empty;
		}
		try
		{
			string s = machineCode + _hashSalt;
			using SHA256 sHA = SHA256.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			return BitConverter.ToString(sHA.ComputeHash(bytes)).Replace("-", "").ToLower();
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"哈希机器码失败: {ex.Message}");
			throw new CryptographicException("机器码哈希失败", ex);
		}
	}

	public static string GenerateRandomKey(int length)
	{
		byte[] array = new byte[length];
		using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
		{
			randomNumberGenerator.GetBytes(array);
		}
		char[] array2 = new char[length];
		for (int i = 0; i < length; i++)
		{
			array2[i] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=[]{}|;:,.<>?"[array[i] % "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=[]{}|;:,.<>?".Length];
		}
		return new string(array2);
	}

	public string EncryptActivationCache(string machineCode, DateTime expireDate, bool isValid)
	{
		try
		{
			string plainText = JsonConvert.SerializeObject(new
			{
				MachineCode = machineCode,
				ExpireDate = expireDate.ToString("yyyy-MM-dd HH:mm:ss"),
				IsValid = isValid,
				CacheTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
				Version = "1.0"
			});
			return EncryptData(plainText);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"加密激活缓存失败: {ex.Message}");
			return string.Empty;
		}
	}

	public (string MachineCode, DateTime ExpireDate, bool IsValid, DateTime CacheTime) DecryptActivationCache(string encryptedCache)
	{
		try
		{
			dynamic val = JsonConvert.DeserializeObject(DecryptData(encryptedCache));
			return (MachineCode: (string)val.MachineCode, ExpireDate: DateTime.Parse((string)val.ExpireDate), IsValid: (bool)val.IsValid, CacheTime: DateTime.Parse((string)val.CacheTime));
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"解密激活缓存失败: {ex.Message}");
			return (MachineCode: string.Empty, ExpireDate: DateTime.MinValue, IsValid: false, CacheTime: DateTime.MinValue);
		}
	}

	private bool SecureStringCompare(string a, string b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Length != b.Length)
		{
			return false;
		}
		uint num = 0u;
		for (int i = 0; i < a.Length; i++)
		{
			num |= (uint)(a[i] ^ b[i]);
		}
		return num == 0;
	}

	private string PadOrTruncate(string str, int length)
	{
		if (str.Length == length)
		{
			return str;
		}
		if (str.Length > length)
		{
			return str.Substring(0, length);
		}
		return str.PadRight(length, '0');
	}

	public string ComputeFileHash(string filePath)
	{
		try
		{
			using SHA256 sHA = SHA256.Create();
			using FileStream inputStream = File.OpenRead(filePath);
			return BitConverter.ToString(sHA.ComputeHash(inputStream)).Replace("-", "").ToLower();
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"计算文件哈希失败: {ex.Message}");
			return string.Empty;
		}
	}

	public bool VerifyDataIntegrity(string data, string expectedHash)
	{
		try
		{
			using SHA256 sHA = SHA256.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			string a = BitConverter.ToString(sHA.ComputeHash(bytes)).Replace("-", "").ToLower();
			return SecureStringCompare(a, expectedHash.ToLower());
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"验证数据完整性失败: {ex.Message}");
			return false;
		}
	}
}
