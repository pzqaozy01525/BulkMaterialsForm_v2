// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PARAM
{
	public int nWaittime;

	public int nConnectTime;

	public int nConnectTryNum;

	public int nSubConnectSpaceTime;

	public int nGetDevInfoTime;

	public int nConnectBufSize;

	public int nGetConnInfoTime;

	public int nSearchRecordTime;

	public int nsubDisconnetTime;

	public byte byNetType;

	public byte byPlaybackBufSize;

	public byte bDetectDisconnTime;

	public byte bKeepLifeInterval;

	public int nPicBufSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved;
}
