// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SIG_CARWAY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SIG_CARWAY_INFO
{
	public short snSpeed;

	public short snCarLength;

	public float fRedTime;

	public float fCapTime;

	public byte bSigSequence;

	public byte bType;

	public byte bDirection;

	public byte bLightColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] bSnapFlag;
}
