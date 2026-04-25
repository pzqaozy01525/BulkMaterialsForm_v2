// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_HEATIMG_TEMPER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_HEATIMG_TEMPER_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public int nAlarmId;

	public int nResult;

	public int nAlarmContion;

	public float fTemperatureValue;

	public int nTemperatureUnit;

	public NET_POINT stCoordinate;

	public int nPresetID;

	public int nChannel;

	public int nAction;

	public NET_POLY_POINTS stuAlarmCoordinates;

	public double dTemperatureMaxValue;

	public double dTemperatureMinValue;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 140)]
	public string reserved;
}
