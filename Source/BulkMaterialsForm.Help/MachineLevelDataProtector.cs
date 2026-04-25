// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.MachineLevelDataProtector

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace BulkMaterialsForm.Help;

internal static class MachineLevelDataProtector
{
	private struct DATA_BLOB
	{
		public int cbData;

		public IntPtr pbData;
	}

	[DllImport("Crypt32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool CryptProtectData(ref DATA_BLOB pDataIn, string szDataDescr, IntPtr pOptionalEntropy, IntPtr pvReserved, IntPtr pPromptStruct, int dwFlags, ref DATA_BLOB pDataOut);

	[DllImport("Crypt32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool CryptUnprotectData(ref DATA_BLOB pDataIn, IntPtr ppszDataDescr, IntPtr pOptionalEntropy, IntPtr pvReserved, IntPtr pPromptStruct, int dwFlags, ref DATA_BLOB pDataOut);

	[DllImport("Kernel32.dll", SetLastError = true)]
	private static extern IntPtr LocalFree(IntPtr hMem);

	public static byte[] Protect(byte[] data)
	{
		DATA_BLOB pDataIn = new DATA_BLOB
		{
			cbData = data.Length,
			pbData = Marshal.AllocHGlobal(data.Length)
		};
		Marshal.Copy(data, 0, pDataIn.pbData, data.Length);
		DATA_BLOB pDataOut = default(DATA_BLOB);
		try
		{
			if (!CryptProtectData(ref pDataIn, null, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0, ref pDataOut))
			{
				throw new CryptographicException("CryptProtectData failed");
			}
			byte[] array = new byte[pDataOut.cbData];
			Marshal.Copy(pDataOut.pbData, array, 0, pDataOut.cbData);
			return array;
		}
		finally
		{
			Marshal.FreeHGlobal(pDataIn.pbData);
			if (pDataOut.pbData != IntPtr.Zero)
			{
				LocalFree(pDataOut.pbData);
			}
		}
	}

	public static byte[] Unprotect(byte[] protectedData)
	{
		DATA_BLOB pDataIn = new DATA_BLOB
		{
			cbData = protectedData.Length,
			pbData = Marshal.AllocHGlobal(protectedData.Length)
		};
		Marshal.Copy(protectedData, 0, pDataIn.pbData, protectedData.Length);
		DATA_BLOB pDataOut = default(DATA_BLOB);
		try
		{
			if (!CryptUnprotectData(ref pDataIn, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0, ref pDataOut))
			{
				LogSave.SaveExeLog("[DPAPI Unprotect] 解密失败（旧版本bug写入的数据无法恢复，需重新激活）");
				return null;
			}
			byte[] array = new byte[pDataOut.cbData];
			Marshal.Copy(pDataOut.pbData, array, 0, pDataOut.cbData);
			return array;
		}
		finally
		{
			Marshal.FreeHGlobal(pDataIn.pbData);
			if (pDataOut.pbData != IntPtr.Zero)
			{
				LocalFree(pDataOut.pbData);
			}
		}
	}
}
