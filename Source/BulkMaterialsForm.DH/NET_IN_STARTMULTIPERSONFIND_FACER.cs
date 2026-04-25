// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_STARTMULTIPERSONFIND_FACER

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_STARTMULTIPERSONFIND_FACER
{
	public uint dwSize;

	public NET_FACE_FILTER_CONDTION stFilterInfo;

	public IntPtr pChannelID;

	public int nChannelCount;

	public int nTaskIdCount;

	public IntPtr pTaskId;

	public NET_FACERECOGNITION_PERSON_INFOEX stPerson;

	public NET_FACE_MATCH_OPTIONS stMatchOptions;

	public int nSmallPicIDNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nSmallPicID;

	public EM_OBJECT_TYPE emObjectType;

	public int nBufferLen;

	public IntPtr pBuffer;
}
