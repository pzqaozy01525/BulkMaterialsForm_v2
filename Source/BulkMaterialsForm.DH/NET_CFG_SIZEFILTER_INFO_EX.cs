// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_SIZEFILTER_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_SIZEFILTER_INFO_EX
{
	public int nCalibrateBoxNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_CALIBRATEBOX_INFO[] stuCalibrateBoxs;

	public byte bMeasureModeEnable;

	public byte bMeasureMode;

	public byte bFilterTypeEnable;

	public byte bFilterType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved;

	public byte bFilterMinSizeEnable;

	public byte bFilterMaxSizeEnable;

	public NET_CFG_SIZE stuFilterMinSize;

	public NET_CFG_SIZE stuFilterMaxSize;

	public byte abByArea;

	public byte abMinArea;

	public byte abMaxArea;

	public byte abMinAreaSize;

	public byte abMaxAreaSize;

	public byte bByArea;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved1;

	public float nMinArea;

	public float nMaxArea;

	public NET_CFG_SIZE stuMinAreaSize;

	public NET_CFG_SIZE stuMaxAreaSize;

	public byte abByRatio;

	public byte abMinRatio;

	public byte abMaxRatio;

	public byte abMinRatioSize;

	public byte abMaxRatioSize;

	public byte bByRatio;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public byte[] bReserved2;

	public double dMinRatio;

	public double dMaxRatio;

	public NET_CFG_SIZE stuMinRatioSize;

	public NET_CFG_SIZE stuMaxRatioSize;

	public int nAreaCalibrateBoxNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_CALIBRATEBOX_INFO[] stuAreaCalibrateBoxs;

	public int nRatioCalibrateBoxs;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_CALIBRATEBOX_INFO[] stuRatioCalibrateBoxs;

	public byte abBySize;

	public byte bBySize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public byte[] bReserved3;
}
