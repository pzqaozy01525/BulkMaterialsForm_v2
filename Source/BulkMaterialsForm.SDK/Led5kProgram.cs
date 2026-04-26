// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.Led5kProgram

using System;
using System.Collections.Generic;
using System.Text;

namespace BulkMaterialsForm.SDK;

public class Led5kProgram
{
	public string name;

	public bool overwrite;

	public ushort DisplayType;

	public byte PlayTimes;

	public bool IsValidAlways;

	public ushort StartYear;

	public byte StartMonth;

	public byte StartDay;

	public ushort EndYear;

	public byte EndMonth;

	public byte EndDay;

	public byte ProgramWeek;

	public bool IsPlayOnTime;

	public byte StartHour;

	public byte StartMinute;

	public byte StartSecond;

	public byte EndHour;

	public byte EndMinute;

	public byte EndSecond;

	public byte AreaNum;

	public List<Led5kstaticArea> m_arealist = new List<Led5kstaticArea>();

	public static byte byte2bcd(byte num)
	{
		return (byte)(num / 10 * 16 + num % 10);
	}

	public static byte bcd2byte(byte num)
	{
		return (byte)(num / 16 * 10 + num % 16);
	}

	public static byte[] short2bcd(ushort num)
	{
		byte num2 = (byte)(num / 100);
		byte num3 = (byte)(num % 100);
		return new byte[2]
		{
			byte2bcd(num3),
			byte2bcd(num2)
		};
	}

	public int SendProgram(uint hand)
	{
		int num = 0;
		foreach (Led5kstaticArea item in m_arealist)
		{
			num += item.getAreaLen();
		}
		byte[] array = new byte[num];
		int num2 = 0;
		foreach (Led5kstaticArea item2 in m_arealist)
		{
			byte[] array2 = item2.AreaToByteArray();
			array2.CopyTo(array, num2);
			num2 += array2.Length;
		}
		int areaDataListLen = num;
		byte[] array3;
		if (IsValidAlways)
		{
			array3 = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
		}
		else
		{
			array3 = new byte[8];
			byte[] array4 = short2bcd(StartYear);
			array3[0] = array4[0];
			array3[1] = array4[1];
			array3[2] = byte2bcd(StartMonth);
			array3[3] = byte2bcd(StartDay);
			byte[] array5 = short2bcd(EndYear);
			array3[4] = array5[0];
			array3[5] = array5[1];
			array3[6] = byte2bcd(EndMonth);
			array3[7] = byte2bcd(EndDay);
		}
		byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(name);
		byte[] period = ((!IsPlayOnTime) ? null : new byte[7]
		{
			byte2bcd(StartHour),
			byte2bcd(StartMinute),
			byte2bcd(StartSecond),
			byte2bcd(EndHour),
			byte2bcd(EndMinute),
			byte2bcd(EndSecond),
			0
		});
		byte programTime = Convert.ToByte(IsPlayOnTime ? 1 : 0);
		return Led5kSDK.OFS_SendFileData(hand, 1, bytes, DisplayType, PlayTimes, array3, ProgramWeek, programTime, period, AreaNum, array, areaDataListLen);
	}
}
