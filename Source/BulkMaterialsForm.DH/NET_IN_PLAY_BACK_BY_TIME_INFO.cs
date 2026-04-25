// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PLAY_BACK_BY_TIME_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PLAY_BACK_BY_TIME_INFO
{
	public NET_TIME stStartTime;

	public NET_TIME stStopTime;

	public IntPtr hWnd;

	public fDownLoadPosCallBack cbDownLoadPos;

	public IntPtr dwPosUser;

	public fDataCallBack fDownLoadDataCallBack;

	public IntPtr dwDataUser;

	public int nPlayDirection;

	public int nWaittime;

	public IntPtr pstuEventInfo;

	public uint nEventInfoCount;

	public EM_SUBCLASSID_TYPE emSubClass;

	public fVKInfoCallBack pVKInfoCallBack;

	public IntPtr dwVKInfoUser;

	public fOriDataCallBack pOriDataCallBack;

	public IntPtr dwOriDataUser;

	public bool bOnlySupportRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 932)]
	public byte[] bReserved;
}
