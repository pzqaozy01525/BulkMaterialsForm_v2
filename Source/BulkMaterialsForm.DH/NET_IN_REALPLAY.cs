// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_REALPLAY

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_REALPLAY
{
	public uint dwSize;

	public int nChannelID;

	public EM_RealPlayType rType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] szReserved;

	public IntPtr hWnd;

	public fRealDataCallBackEx2 cbRealData;

	public fOriginalRealDataCallBack pOriginalRealDataCallBack;

	public fEncryptRealDataCallBackEx pEncryptRealDataCallBackEx;

	public fRealPlayDisConnectCallBack cbDisconnect;

	public fVKInfoCallBack pVKInfoCallBack;

	public IntPtr dwUser;
}
