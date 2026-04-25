// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_MULTIFACE_DETECT_STATE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_MULTIFACE_DETECT_STATE
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved;

	public fMultiFaceDetectState cbMultiFaceDetectState;

	public IntPtr dwUser;

	public fMultiFaceDetectStateEx cbMultiFaceDetectStateEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public uint[] nTokens;

	public int nTokensNum;
}
