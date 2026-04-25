// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_STARTFIND_FACERECONGNITION

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_STARTFIND_FACERECONGNITION
{
	public uint dwSize;

	public bool bPersonEnable;

	public NET_FACERECOGNITION_PERSON_INFO stPerson;

	public NET_FACE_MATCH_OPTIONS stMatchOptions;

	public NET_FACE_FILTER_CONDTION stFilterInfo;

	public IntPtr pBuffer;

	public int nBufferLen;

	public int nChannelID;

	public bool bPersonExEnable;

	public NET_FACERECOGNITION_PERSON_INFOEX stPersonInfoEx;

	public int nSmallPicIDNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nSmallPicID;

	public EM_OBJECT_TYPE emObjectType;
}
