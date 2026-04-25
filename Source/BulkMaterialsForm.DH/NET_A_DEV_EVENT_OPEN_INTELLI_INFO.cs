// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_OPEN_INTELLI_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_OPEN_INTELLI_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szOpenCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szOpenName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRuleType;

	public IntPtr pstuOpenData;

	public int nObjectNums;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_OPEN_INTELLI_OBJECT_INFO[] stuObjects;

	public NET_OPEN_INTELLI_USER_DATA_INFO stuUserData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
