// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_LOG_MESSAGE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_LOG_MESSAGE
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szLogMessage;
}
