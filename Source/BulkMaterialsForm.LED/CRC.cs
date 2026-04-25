// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.LED
// Type: BulkMaterialsForm.LED.CRC

using System;
using System.Text;

namespace BulkMaterialsForm.LED;

public class CRC
{
	public static byte[] CRC16(byte[] data)
	{
		int num = data.Length;
		if (num > 0)
		{
			ushort num2 = ushort.MaxValue;
			for (int i = 0; i < num; i++)
			{
				num2 ^= data[i];
				for (int j = 0; j < 8; j++)
				{
					num2 = (((num2 & 1) != 0) ? ((ushort)((num2 >> 1) ^ 0xA001)) : ((ushort)(num2 >> 1)));
				}
			}
			byte b = (byte)((num2 & 0xFF00) >> 8);
			byte b2 = (byte)(num2 & 0xFF);
			return new byte[2] { b, b2 };
		}
		return new byte[2];
	}

	public static string ToCRC16(string content)
	{
		return ToCRC16(content, Encoding.UTF8);
	}

	public static string ToCRC16(string content, bool isReverse)
	{
		return ToCRC16(content, Encoding.UTF8, isReverse);
	}

	public static string ToCRC16(string content, Encoding encoding)
	{
		return ByteToString(CRC16(encoding.GetBytes(content)), isReverse: true);
	}

	public static string ToCRC16(string content, Encoding encoding, bool isReverse)
	{
		return ByteToString(CRC16(encoding.GetBytes(content)), isReverse);
	}

	public static string ToCRC16(byte[] data)
	{
		return ByteToString(CRC16(data), isReverse: true);
	}

	public static string ToCRC16(byte[] data, bool isReverse)
	{
		return ByteToString(CRC16(data), isReverse);
	}

	public static string ToModbusCRC16(string s)
	{
		return ToModbusCRC16(s, isReverse: true);
	}

	public static string ToModbusCRC16(string s, bool isReverse)
	{
		return ByteToString(CRC16(StringToHexByte(s)), isReverse);
	}

	public static string ToModbusCRC16(byte[] data)
	{
		return ToModbusCRC16(data, isReverse: true);
	}

	public static string ToModbusCRC16(byte[] data, bool isReverse)
	{
		return ByteToString(CRC16(data), isReverse);
	}

	public static string ByteToString(byte[] arr, bool isReverse)
	{
		try
		{
			byte b = arr[0];
			byte b2 = arr[1];
			return Convert.ToString(isReverse ? (b + b2 * 256) : (b * 256 + b2), 16).ToUpper().PadLeft(4, '0');
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public static string ByteToString(byte[] arr)
	{
		try
		{
			return ByteToString(arr, isReverse: true);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public static string StringToHexString(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		char[] array = str.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(((short)array[i]).ToString("X4"));
		}
		return stringBuilder.ToString();
	}

	private static string ConvertChinese(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		char[] array = str.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			short num = (short)array[i];
			if (num <= 0 || num >= 127)
			{
				stringBuilder.Append(num.ToString("X4"));
			}
			else
			{
				stringBuilder.Append((char)num);
			}
		}
		return stringBuilder.ToString();
	}

	private static string FilterChinese(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		char[] array = str.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			short num = (short)array[i];
			if (num > 0 && num < 127)
			{
				stringBuilder.Append((char)num);
			}
		}
		return stringBuilder.ToString();
	}

	public static byte[] StringToHexByte(string str)
	{
		return StringToHexByte(str, isFilterChinese: false);
	}

	public static byte[] StringToHexByte(string str, bool isFilterChinese)
	{
		string text = (isFilterChinese ? FilterChinese(str) : ConvertChinese(str));
		text = text.Replace(" ", "");
		text += ((text.Length % 2 != 0) ? "0" : "");
		byte[] array = new byte[text.Length / 2];
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			array[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
		}
		return array;
	}
}
