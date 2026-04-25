// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TIME_EX

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TIME_EX
{
	public uint dwYear;

	public uint dwMonth;

	public uint dwDay;

	public uint dwHour;

	public uint dwMinute;

	public uint dwSecond;

	public uint dwMillisecond;

	public uint dwUTC;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	public uint[] dwReserved;

	public override string ToString()
	{
		return string.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", dwYear.ToString("D4"), dwMonth.ToString("D2"), dwDay.ToString("D2"), dwHour.ToString("D2"), dwMinute.ToString("D2"), dwSecond.ToString("D2"), dwMillisecond.ToString("D3"));
	}

	public string ToShortString()
	{
		return string.Format("{0}-{1}-{2} {3}:{4}:{5}", dwYear.ToString("D4"), dwMonth.ToString("D2"), dwDay.ToString("D2"), dwHour.ToString("D2"), dwMinute.ToString("D2"), dwSecond.ToString("D2"));
	}

	public DateTime ToDateTime()
	{
		try
		{
			return new DateTime((int)dwYear, (int)dwMonth, (int)dwDay, (int)dwHour, (int)dwMinute, (int)dwSecond, (int)dwMillisecond);
		}
		catch
		{
			return DateTime.Now;
		}
	}

	public static NET_TIME_EX FromDateTime(DateTime dateTime)
	{
		try
		{
			return new NET_TIME_EX
			{
				dwYear = (uint)dateTime.Year,
				dwMonth = (uint)dateTime.Month,
				dwDay = (uint)dateTime.Day,
				dwHour = (uint)dateTime.Hour,
				dwMinute = (uint)dateTime.Minute,
				dwSecond = (uint)dateTime.Second,
				dwMillisecond = (uint)dateTime.Millisecond,
				dwUTC = (uint)dateTime.ToFileTime()
			};
		}
		catch
		{
			return default(NET_TIME_EX);
		}
	}
}
