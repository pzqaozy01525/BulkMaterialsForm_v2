// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_PAN_GROUP_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_PAN_GROUP_PARAM
{
	public uint dwSize;

	public int nRetNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_PAN_GROUP_INFO[] stuPanGroupInfo;
}
