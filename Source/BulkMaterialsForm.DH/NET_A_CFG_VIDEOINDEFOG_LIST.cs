// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_VIDEOINDEFOG_LIST

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_VIDEOINDEFOG_LIST
{
	public int nVideoInDefogNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public NET_A_CFG_VIDEOINDEFOG[] stVideoInDefog;
}
