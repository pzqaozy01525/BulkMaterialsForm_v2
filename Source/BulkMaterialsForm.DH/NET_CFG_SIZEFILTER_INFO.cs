// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_SIZEFILTER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_SIZEFILTER_INFO
{
	public int nCalibrateBoxNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_CALIBRATEBOX_INFO[] stuCalibrateBoxs;

	public byte bMeasureModeEnable;

	public byte bMeasureMode;

	public byte bFilterTypeEnable;

	public byte bFilterType;

	public byte bFilterMinSizeEnable;

	public byte bFilterMaxSizeEnable;

	public byte abByArea;

	public byte abMinArea;

	public byte abMaxArea;

	public byte abMinAreaSize;

	public byte abMaxAreaSize;

	public byte bByArea;

	public NET_CFG_SIZE stuFilterMinSize;

	public NET_CFG_SIZE stuFilterMaxSize;

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

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved1;

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

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 518)]
	public byte[] bReserved;
}
