// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_MONITORWALL_SCENE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_MONITORWALL_SCENE
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szControlID;

	public NET_MONITORWALL stuMonitorWall;

	public IntPtr pstuSplitScene;

	public int nMaxSplitSceneCount;

	public int nRetSplitSceneCount;
}
