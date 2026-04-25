// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_OBJECT_ABNORMAL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_OBJECT_ABNORMAL_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public NET_EVENT_IMAGE_OFFSET_INFO stuSceneImage;

	public EM_CLASS_TYPE emClassType;

	public ushort nAreaID;

	public ushort nPresetID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_OBJECT_INFO[] stuObjectInfo;

	public int nObjectInfoNum;

	public EM_ABNORMAL_OBJECT_TYPE emObjectType;

	public EM_OBJECT_ABNORMAL_TYPE emAbnormalType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] bReserved;
}
