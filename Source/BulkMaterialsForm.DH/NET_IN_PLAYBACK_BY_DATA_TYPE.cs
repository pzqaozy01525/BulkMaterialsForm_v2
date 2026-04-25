// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PLAYBACK_BY_DATA_TYPE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PLAYBACK_BY_DATA_TYPE
{
	public uint dwSize;

	public int nChannelID;

	public NET_TIME stStartTime;

	public NET_TIME stStopTime;

	public IntPtr hWnd;

	public fDownLoadPosCallBack cbDownLoadPos;

	public IntPtr dwPosUser;

	public fDataCallBack fDownLoadDataCallBack;

	public EM_REAL_DATA_TYPE emDataType;

	public IntPtr dwDataUser;

	public int nPlayDirection;

	public EM_AUDIO_DATA_TYPE emAudioType;

	public fDataCallBackEx fDownLoadDataCallBackEx;
}
