// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CUSTOM_WORKER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CUSTOM_WORKER_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szSex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRole;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szProjNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szProjName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szBuilderName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szBuilderID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szBuilderType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szBuliderTypeID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPictureID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szContractID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szWorkerTypeID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szWorkerTypeName;

	public bool bPersonStatus;

	public bool bProjNameEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szProjNameEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1388)]
	public byte[] bReserved;
}
