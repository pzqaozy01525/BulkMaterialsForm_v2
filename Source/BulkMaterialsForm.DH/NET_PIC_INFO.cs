// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PIC_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PIC_INFO
{
	public uint dwOffSet;

	public uint dwFileLenth;

	public ushort wWidth;

	public ushort wHeight;

	public IntPtr pszFilePath;

	public byte bIsDetected;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved;

	public byte byQulityScore;

	public int nFilePathLen;

	public NET_POINT stuPoint;

	public uint nIndexInData;
}
