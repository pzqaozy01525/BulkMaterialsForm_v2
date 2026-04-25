// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_DOWNLOAD_BY_DATA_TYPE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_DOWNLOAD_BY_DATA_TYPE
{
	public uint dwSize;

	public int nChannelID;

	public EM_QUERY_RECORD_TYPE emRecordType;

	public IntPtr szSavedFileName;

	public NET_TIME stStartTime;

	public NET_TIME stStopTime;

	public fTimeDownLoadPosCallBack cbDownLoadPos;

	public IntPtr dwPosUser;

	public fDataCallBack fDownLoadDataCallBack;

	public EM_REAL_DATA_TYPE emDataType;

	public IntPtr dwDataUser;

	public EM_AUDIO_DATA_TYPE emAudioType;
}
