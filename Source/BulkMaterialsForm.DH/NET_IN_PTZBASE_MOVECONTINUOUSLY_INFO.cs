// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PTZBASE_MOVECONTINUOUSLY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PTZBASE_MOVECONTINUOUSLY_INFO
{
	public uint dwSize;

	public int nSpeedX;

	public int nSpeedY;

	public int nZoom;

	public int nMoveTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
