// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MSG_HANDLE_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MSG_HANDLE_EX
{
	public uint dwActionMask;

	public uint dwActionFlag;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byRelAlarmOut;

	public uint dwDuration;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byRecordChannel;

	public uint dwRecLatch;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] bySnap;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byTour;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_A_PTZ_LINK[] struPtzLink;

	public uint dwEventLatch;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byRelWIAlarmOut;

	public byte bMessageToNet;

	public byte bMMSEn;

	public byte bySnapshotTimes;

	public byte bMatrixEn;

	public uint dwMatrix;

	public byte bLog;

	public byte bSnapshotPeriod;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byTour2;

	public byte byEmailType;

	public byte byEmailMaxLength;

	public byte byEmailMaxTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 475)]
	public byte[] byReserved;
}
