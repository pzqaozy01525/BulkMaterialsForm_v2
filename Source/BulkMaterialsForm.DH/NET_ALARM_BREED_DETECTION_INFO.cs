// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_BREED_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_BREED_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double dbPTS;

	public NET_TIME_EX stuUTC;

	public uint nEventID;

	public uint nRuleID;

	public uint nSequence;

	public EM_SCENE_CLASS_TYPE emClassType;

	public uint nBreedStallNum;

	public uint nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_VAOBJECT_ANIMAL_INFO[] stuObjects;

	public double dbBreedStallTemp;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] szReserved;
}
