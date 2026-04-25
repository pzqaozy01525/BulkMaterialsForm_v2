// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MSG_OBJECT_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct NET_MSG_OBJECT_EX
{
	public uint dwSize;

	public int nObjectID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szObjectType;

	public int nConfidence;

	public int nAction;

	public NET_RECT BoundingBox;

	public NET_POINT Center;

	public int nPolygonNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_POINT[] Contour;

	public uint rgbaMainColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szText;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szObjectSubType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved1;

	public byte bPicEnble;

	public NET_PIC_INFO stPicInfo;

	public byte bShotFrame;

	public byte bColor;

	public byte bLowerBodyColor;

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

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szSubText;

	public int nPersonStature;

	public EM_MSG_OBJ_PERSON_DIRECTION emPersonDirection;

	public uint rgbaLowerBodyColor;
}
