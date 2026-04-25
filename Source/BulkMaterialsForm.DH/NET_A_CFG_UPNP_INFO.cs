// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_UPNP_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_UPNP_INFO
{
	public bool bEnable;

	public bool bStartDeviceDiscover;

	public EM_CONFIGURATION_MODE emMode;

	public int nMaxTable;

	public int nReturnTable;

	public IntPtr pstuMapTable;
}
