// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.LED
// Type: BulkMaterialsForm.LED.LED

using System;
using System.Collections.Generic;
using System.Text;

namespace BulkMaterialsForm.LED;

public class LED
{
	private static byte[] KeFa_CRCHi = new byte[256]
	{
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
		128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
		129, 64, 1, 192, 128, 65, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
		129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
		129, 64, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
		128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
		129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64
	};

	private static byte[] KeFa_CRCLo = new byte[256]
	{
		0, 192, 193, 1, 195, 3, 2, 194, 198, 6,
		7, 199, 5, 197, 196, 4, 204, 12, 13, 205,
		15, 207, 206, 14, 10, 202, 203, 11, 201, 9,
		8, 200, 216, 24, 25, 217, 27, 219, 218, 26,
		30, 222, 223, 31, 221, 29, 28, 220, 20, 212,
		213, 21, 215, 23, 22, 214, 210, 18, 19, 211,
		17, 209, 208, 16, 240, 48, 49, 241, 51, 243,
		242, 50, 54, 246, 247, 55, 245, 53, 52, 244,
		60, 252, 253, 61, 255, 63, 62, 254, 250, 58,
		59, 251, 57, 249, 248, 56, 40, 232, 233, 41,
		235, 43, 42, 234, 238, 46, 47, 239, 45, 237,
		236, 44, 228, 36, 37, 229, 39, 231, 230, 38,
		34, 226, 227, 35, 225, 33, 32, 224, 160, 96,
		97, 161, 99, 163, 162, 98, 102, 166, 167, 103,
		165, 101, 100, 164, 108, 172, 173, 109, 175, 111,
		110, 174, 170, 106, 107, 171, 105, 169, 168, 104,
		120, 184, 185, 121, 187, 123, 122, 186, 190, 126,
		127, 191, 125, 189, 188, 124, 180, 116, 117, 181,
		119, 183, 182, 118, 114, 178, 179, 115, 177, 113,
		112, 176, 80, 144, 145, 81, 147, 83, 82, 146,
		150, 86, 87, 151, 85, 149, 148, 84, 156, 92,
		93, 157, 95, 159, 158, 94, 90, 154, 155, 91,
		153, 89, 88, 152, 136, 72, 73, 137, 75, 139,
		138, 74, 78, 142, 143, 79, 141, 77, 76, 140,
		68, 132, 133, 69, 135, 71, 70, 134, 130, 66,
		67, 131, 65, 129, 128, 64
	};

	public static byte[] FangKongStandardVoiceByte(string car_no, List<int> cmd = null)
	{
		byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(car_no);
		byte[] array = new byte[bytes.Length + cmd.Count];
		Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
		for (int i = 0; i < cmd.Count; i++)
		{
			array[array.Length - (i + 1)] = (byte)cmd[i];
		}
		byte[] bytes2 = BitConverter.GetBytes((short)array.Length);
		int num = BitConverter.ToInt16(bytes2, 0);
		byte[] array2 = new byte[6]
		{
			0,
			100,
			0,
			34,
			bytes2[1],
			bytes2[0]
		};
		byte[] array3 = new byte[num + 8];
		Buffer.BlockCopy(array2, 0, array3, 0, array2.Length);
		Buffer.BlockCopy(array, 0, array3, array2.Length, array.Length);
		array3[array3.Length - 2] = 0;
		array3[array3.Length - 1] = 0;
		byte[] array4 = CRC.CRC16(array3);
		byte[] array5 = new byte[array3.Length + 3];
		array5[0] = 170;
		array5[1] = 85;
		Buffer.BlockCopy(array3, 0, array5, 2, array3.Length - 2);
		Buffer.BlockCopy(array4, 0, array5, array3.Length, array4.Length);
		array5[array5.Length - 1] = 175;
		string text = "";
		byte[] array6 = array5;
		foreach (byte b in array6)
		{
			text += b.ToString("X2");
		}
		return array5;
	}

	public static byte[] GetLedTextByte(string text, int index)
	{
		byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(text);
		byte[] bytes2 = BitConverter.GetBytes((short)bytes.Length + 4);
		int num = BitConverter.ToInt16(bytes2, 0) - 4;
		byte[] obj = new byte[10] { 0, 100, 0, 39, 0, 0, 0, 60, 1, 0 };
		obj[4] = bytes2[1];
		obj[5] = bytes2[0];
		obj[6] = (byte)index;
		byte[] array = obj;
		byte[] array2 = new byte[num + 12];
		Buffer.BlockCopy(array, 0, array2, 0, array.Length);
		Buffer.BlockCopy(bytes, 0, array2, array.Length, bytes.Length);
		array2[array2.Length - 2] = 0;
		array2[array2.Length - 1] = 0;
		byte[] array3 = CRC.CRC16(array2);
		byte[] array4 = new byte[array2.Length + 3];
		array4[0] = 170;
		array4[1] = 85;
		Buffer.BlockCopy(array2, 0, array4, 2, array2.Length - 2);
		Buffer.BlockCopy(array3, 0, array4, array2.Length, array3.Length);
		array4[array4.Length - 1] = 175;
		return array4;
	}

	public static byte[] KeFa_SoundPlay(byte Address, string SoundText)
	{
		try
		{
			byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(SoundText);
			int num = bytes.Length;
			if (num > 254)
			{
				num = 254;
			}
			byte[] array = new byte[num + 9];
			array[0] = Address;
			array[1] = 100;
			array[2] = byte.MaxValue;
			array[3] = byte.MaxValue;
			array[4] = 48;
			array[5] = (byte)(num + 1);
			array[6] = 2;
			bytes.CopyTo(array, 7);
			GetKaFaDataCRC(array, 2).CopyTo(array, num + 7);
			return array;
		}
		catch
		{
			return null;
		}
	}

	public static byte[] ShowKeFa1TextByID(byte TextID, string ShowText, byte Address, byte ShowTimes)
	{
		try
		{
			byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(ShowText);
			int num = bytes.Length;
			if (num > 200)
			{
				num = 200;
			}
			byte[] array = new byte[num + 27];
			array[0] = Address;
			array[1] = 100;
			array[2] = byte.MaxValue;
			array[3] = byte.MaxValue;
			array[4] = 98;
			array[5] = (byte)(num + 19);
			array[6] = TextID;
			array[7] = 0;
			array[8] = 2;
			if (num > 8)
			{
				array[7] = 21;
				array[10] = 1;
				int num2 = (int)Math.Round(0.2 * (double)num / 10.0, 0);
				if (num2 < 3)
				{
					num2 = 3;
				}
				num2++;
				array[14] = ShowTimes;
				if (array[14] == 0)
				{
					array[14] = 1;
				}
			}
			else
			{
				array[7] = 0;
				array[10] = ShowTimes;
				array[14] = 1;
			}
			array[9] = 0;
			array[11] = 0;
			array[12] = 1;
			array[13] = 3;
			array[15] = byte.MaxValue;
			array[16] = 0;
			array[17] = 0;
			array[18] = 0;
			array[19] = 0;
			array[20] = 0;
			array[21] = 0;
			array[22] = 0;
			array[23] = (byte)num;
			array[24] = 0;
			bytes.CopyTo(array, 25);
			GetKaFaDataCRC(array, 2).CopyTo(array, num + 25);
			return array;
		}
		catch
		{
			return new byte[0];
		}
	}

	private static byte[] GetKaFaDataCRC(byte[] CRCDataByte, byte UnSumNum)
	{
		byte[] array = new byte[CRCDataByte.Length - UnSumNum];
		Array.Copy(CRCDataByte, 0, array, 0, CRCDataByte.Length - UnSumNum);
		return GetKeFa_CRC16(array, array.Length);
	}

	public static byte[] GetKeFa_CRC16(byte[] puchMsg, int usDataLen)
	{
		byte b = byte.MaxValue;
		byte b2 = byte.MaxValue;
		for (int i = 0; i < usDataLen; i++)
		{
			int num = b ^ puchMsg[i];
			b = (byte)(b2 ^ KeFa_CRCHi[num]);
			b2 = KeFa_CRCLo[num];
		}
		return BitConverter.GetBytes((ushort)((b2 << 8) | b));
	}

	public static byte[] KeFa_LedLampLan(byte Address)
	{
		try
		{
			byte[] obj = new byte[6] { 0, 0, 0, 0, 0, 10 };
			int num = obj.Length;
			byte[] array = new byte[num + 9];
			array[0] = Address;
			array[1] = 100;
			array[2] = byte.MaxValue;
			array[3] = byte.MaxValue;
			array[4] = 15;
			array[5] = (byte)(num + 1);
			array[6] = 2;
			obj.CopyTo(array, 7);
			GetKaFaDataCRC(array, 2).CopyTo(array, num + 7);
			return array;
		}
		catch
		{
			return null;
		}
	}

	public static byte[] KeFa_LedLampLv(byte Address)
	{
		try
		{
			byte[] obj = new byte[5] { 0, 1, 0, 0, 10 };
			int num = obj.Length;
			byte[] array = new byte[num + 8];
			array[0] = Address;
			array[1] = 100;
			array[2] = byte.MaxValue;
			array[3] = byte.MaxValue;
			array[4] = 15;
			array[5] = (byte)num;
			obj.CopyTo(array, 6);
			GetKaFaDataCRC(array, 2).CopyTo(array, num + 6);
			return array;
		}
		catch
		{
			return null;
		}
	}
}
