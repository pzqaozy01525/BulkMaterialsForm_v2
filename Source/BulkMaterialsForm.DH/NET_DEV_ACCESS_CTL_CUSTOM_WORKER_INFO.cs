// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_ACCESS_CTL_CUSTOM_WORKER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_ACCESS_CTL_CUSTOM_WORKER_INFO
{
	public NET_ACCESSCTLCARD_SEX emSex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRole;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szProjectNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szProjectName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szBuilderName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szBuilderID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szBuilderType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szBuilderTypeID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPictureID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szContractID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szWorkerTypeID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szWorkerTypeName;

	public bool bPersonStatus;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
