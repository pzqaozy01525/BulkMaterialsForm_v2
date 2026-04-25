// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_REALPLAY_BY_DATA_TYPE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_REALPLAY_BY_DATA_TYPE
{
	public uint dwSize;

	public int nChannelID;

	public IntPtr hWnd;

	public EM_RealPlayType rType;

	public fRealDataCallBackEx cbRealData;

	public EM_REAL_DATA_TYPE emDataType;

	public IntPtr dwUser;

	public IntPtr szSaveFileName;

	public fRealDataCallBackEx2 cbRealDataEx;

	public EM_AUDIO_DATA_TYPE emAudioType;

	public fDataCallBackEx cbRealDataEx2;
}
