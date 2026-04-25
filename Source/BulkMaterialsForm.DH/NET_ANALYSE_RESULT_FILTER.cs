// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANALYSE_RESULT_FILTER

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANALYSE_RESULT_FILTER
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public uint[] dwAlarmTypes;

	public uint nEventNum;

	public int nImageDataFlag;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	public int nImageTypeNum;

	public IntPtr pImageType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1004)]
	public byte[] byReserved;
}
