// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CTRL_DELIVERY_FILE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CTRL_DELIVERY_FILE
{
	public uint dwSize;

	public int nPort;

	public EM_VIDEO_PLAY_MODE_TYPE emPlayMode;

	public NET_TIME stuStartPlayTime;

	public NET_TIME stuStopPlayTime;

	public int nFileCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_DELIVERY_FILE_INFO[] stuFileInfo;

	public EM_VIDEO_PLAY_OPERATE_TYPE emOperateType;

	public int nFileCountEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_DELIVERY_FILE_INFOEX[] stuFileInfoEx;

	public int nNumber;

	public NET_CFG_TIME_SCHEDULE stuTimeSection;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;
}
