// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TIME

using System;

namespace BulkMaterialsForm.DH;

public struct NET_TIME
{
	public uint dwYear;

	public uint dwMonth;

	public uint dwDay;

	public uint dwHour;

	public uint dwMinute;

	public uint dwSecond;

	public static NET_TIME FromDateTime(DateTime dateTime)
	{
		try
		{
			return new NET_TIME
			{
				dwYear = (uint)dateTime.Year,
				dwMonth = (uint)dateTime.Month,
				dwDay = (uint)dateTime.Day,
				dwHour = (uint)dateTime.Hour,
				dwMinute = (uint)dateTime.Minute,
				dwSecond = (uint)dateTime.Second
			};
		}
		catch
		{
			return default(NET_TIME);
		}
	}

	public DateTime ToDateTime()
	{
		try
		{
			return new DateTime((int)dwYear, (int)dwMonth, (int)dwDay, (int)dwHour, (int)dwMinute, (int)dwSecond);
		}
		catch
		{
			return DateTime.Now;
		}
	}

	public override string ToString()
	{
		return string.Format("{0}-{1}-{2} {3}:{4}:{5}", dwYear.ToString("D4"), dwMonth.ToString("D2"), dwDay.ToString("D2"), dwHour.ToString("D2"), dwMinute.ToString("D2"), dwSecond.ToString("D2"));
	}
}
