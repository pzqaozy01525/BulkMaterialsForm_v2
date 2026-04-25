// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_CONSTANT_LAMP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_CONSTANT_LAMP_INFO
{
	public uint nTrafficLampNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_TRAFFIC_CONSTATE_LAMP_CONFIG[] stuTrafficLamp;
}
