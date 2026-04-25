// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_STARTMULTIFIND_FACERECONGNITIONRECORD

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_STARTMULTIFIND_FACERECONGNITIONRECORD
{
	public uint dwSize;

	public NET_TIME stStartTime;

	public NET_TIME stEndTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szMachineAddress;

	public int nAlarmType;

	public bool abPersonInfo;

	public NET_FACERECOGNITION_PERSON_INFO stPersonInfo;

	public IntPtr pChannelID;

	public int nChannelCount;

	public int nGroupIdNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8192)]
	public char[] szGroupId;

	public bool abPersonExInfo;

	public NET_FACERECOGNITION_PERSON_INFOEX stPersonInfoEx;
}
