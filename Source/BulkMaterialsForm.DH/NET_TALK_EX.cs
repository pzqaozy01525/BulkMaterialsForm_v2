// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TALK_EX

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TALK_EX
{
	public uint dwSize;

	public int nChannel;

	public int nAudioPort;

	public int nWaitTime;

	public IntPtr hVideoWnd;

	public NET_TALK_VIDEO_FORMAT stuVideoFmt;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	public byte[] szMulticastAddr;

	public ushort wMulticastLocalPort;

	public ushort wMulticastRemotePort;
}
