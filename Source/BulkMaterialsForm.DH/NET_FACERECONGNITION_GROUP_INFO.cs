// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACERECONGNITION_GROUP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACERECONGNITION_GROUP_INFO
{
	public uint dwSize;

	public EM_FACE_DB_TYPE emFaceDBType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szGroupName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szGroupRemarks;

	public int nGroupSize;

	public int nRetSimilarityCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public int[] nSimilarity;

	public int nRetChnCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public int[] nChannel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public uint[] nFeatureState;

	public EM_REGISTER_DB_TYPE emRegisterDbType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	public NET_PASSERBY_DB_CONFIG_INFO stuPasserbyDBConfig;

	public override string ToString()
	{
		return szGroupId;
	}
}
