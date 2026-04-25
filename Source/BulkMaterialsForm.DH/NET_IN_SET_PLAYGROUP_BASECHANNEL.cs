// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SET_PLAYGROUP_BASECHANNEL

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SET_PLAYGROUP_BASECHANNEL
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public IntPtr lPlayGroupHandle;

	public IntPtr lPlayHandle;
}
