// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VT_TALK_PARAM

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VT_TALK_PARAM
{
	public uint dwSize;

	public int nValidFlag;

	public fVtEventCallBack pfEventCb;

	public IntPtr dwUser;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szPeerMidNum;

	public EM_NEWCALL_ACTION emAction;

	public int nWaitTime;

	public IntPtr hVideoWnd;

	public bool bClient;

	public NET_DEV_TALKDECODE_INFO stAudioEncode;
}
