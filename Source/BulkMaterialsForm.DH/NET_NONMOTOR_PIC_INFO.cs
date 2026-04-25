// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_NONMOTOR_PIC_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_NONMOTOR_PIC_INFO
{
	public uint uOffset;

	public uint uLength;

	public uint uWidth;

	public uint uHeight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;

	public uint nIndexInData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
	public byte[] byReserved;
}
