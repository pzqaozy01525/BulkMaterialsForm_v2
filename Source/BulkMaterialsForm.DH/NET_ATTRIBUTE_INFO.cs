// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ATTRIBUTE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ATTRIBUTE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSignalName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szUnit;

	public EM_NET_SCADA_POINT_TYPE emPointType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szID;

	public uint nStartDelay;

	public uint nStopDelay;

	public uint nPeriod;

	public float fThreshold;

	public float fAlarmWaveVal;

	public float fAbsoluteVal;

	public float fRelativeVal;

	public EM_ATTRIBUTE_STATUS emStatus;

	public NET_DISPLAY_OPTIONS_INFO stuDisplayOptions;

	public bool bIsValid;

	public uint nDelay;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 120)]
	public string szDescribe;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 136)]
	public byte[] byReserved;
}
