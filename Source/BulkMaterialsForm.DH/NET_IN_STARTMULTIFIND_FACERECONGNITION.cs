// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_STARTMULTIFIND_FACERECONGNITION

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_STARTMULTIFIND_FACERECONGNITION
{
	public uint dwSize;

	public IntPtr pChannelID;

	public int nChannelCount;

	public bool bPersonEnable;

	public NET_FACERECOGNITION_PERSON_INFO stPerson;

	public NET_FACE_MATCH_OPTIONS stMatchOptions;

	public NET_FACE_FILTER_CONDTION stFilterInfo;

	public IntPtr pBuffer;

	public int nBufferLen;

	public bool bPersonExEnable;

	public NET_FACERECOGNITION_PERSON_INFOEX stPersonInfoEx;

	public EM_OBJECT_TYPE emObjectType;
}
