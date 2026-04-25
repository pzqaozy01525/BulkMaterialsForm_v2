// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MSG_OBJECT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct NET_MSG_OBJECT
{
	public int nObjectID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szObjectType;

	public int nConfidence;

	public int nAction;

	public NET_RECT BoundingBox;

	public NET_POINT Center;

	public int nPolygonNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_POINT[] Contour;

	public uint rgbaMainColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szText;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 62)]
	public byte[] szObjectSubType;

	public ushort wColorLogoIndex;

	public ushort wSubBrand;

	public byte byReserved1;

	public byte bPicEnble;

	public NET_PIC_INFO stPicInfo;

	public byte bShotFrame;

	public byte bColor;

	public byte byReserved2;

	public byte byTimeType;

	public NET_TIME_EX stuCurrentTime;

	public NET_TIME_EX stuStartTime;

	public NET_TIME_EX stuEndTime;

	public NET_RECT stuOriginalBoundingBox;

	public NET_RECT stuSignBoundingBox;

	public uint dwCurrentSequence;

	public uint dwBeginSequence;

	public uint dwEndSequence;

	public long nBeginFileOffset;

	public long nEndFileOffset;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] byColorSimilar;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] byUpperBodyColorSimilar;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] byLowerBodyColorSimilar;

	public int nRelativeID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public byte[] szSubText;

	public ushort wBrandYear;
}
