// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GPS_STATUS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_GPS_STATUS_INFO
{
	public NET_TIME revTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
	public string DvrSerial;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public byte[] byRserved1;

	public double longitude;

	public double latidude;

	public double height;

	public double angle;

	public double speed;

	public ushort starCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byRserved2;

	public EM_A_NET_THREE_STATUS_BOOL antennaState;

	public EM_A_NET_THREE_STATUS_BOOL orientationState;

	public int workStae;

	public int nAlarmCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] nAlarmState;

	public byte bOffline;

	public byte bSNR;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byRserved3;

	public EM_DATA_SOURCE emDateSource;

	public int nSignalStrength;

	public float fHdop;

	public float fPdop;

	public int nMileage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
	public byte[] byRserved;
}
