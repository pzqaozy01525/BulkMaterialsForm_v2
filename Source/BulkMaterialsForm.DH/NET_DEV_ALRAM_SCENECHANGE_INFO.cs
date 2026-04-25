// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_ALRAM_SCENECHANGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_ALRAM_SCENECHANGE_INFO
{
	public int nChannelID;

	public int nEventAction;

	public double dbPTS;

	public NET_TIME_EX stuUTC;

	public int nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
