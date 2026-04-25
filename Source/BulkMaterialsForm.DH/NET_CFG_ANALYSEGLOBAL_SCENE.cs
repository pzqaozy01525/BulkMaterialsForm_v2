// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ANALYSEGLOBAL_SCENE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ANALYSEGLOBAL_SCENE
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSceneType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 167645)]
	public byte[] szScene;

	public EM_DEPTH_TYPE emDepthType;

	public int nPtzPresetId;

	public int nSceneListCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public SCENE_TYPE_LIST_ARRAY[] sceneTypeList;

	public NET_CFG_INTELLI_UNIFORM_SCENE stuUniformScene;

	public bool bSceneTypeListEx;

	public int nSceneListCountEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public SCENE_TYPE_LIST_EX_ARRAY[] szSceneTypeListEx;

	public IntPtr pstuDetectRegionsInfo;

	public int nMaxDetectRegions;

	public int nDetectRegionsNum;
}
