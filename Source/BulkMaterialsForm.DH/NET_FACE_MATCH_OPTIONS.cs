// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_MATCH_OPTIONS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_MATCH_OPTIONS
{
	public uint dwSize;

	public uint nMatchImportant;

	public EM_FACE_COMPARE_MODE emMode;

	public int nAreaNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public EM_FACE_AREA_TYPE[] szAreas;

	public int nAccuracy;

	public int nSimilarity;

	public int nMaxCandidate;

	public EM_FINDPIC_QUERY_MODE emQueryMode;

	public EM_FINDPIC_QUERY_ORDERED emOrdered;
}
