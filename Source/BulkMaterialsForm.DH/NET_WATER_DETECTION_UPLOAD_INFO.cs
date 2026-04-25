// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WATER_DETECTION_UPLOAD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WATER_DETECTION_UPLOAD_INFO
{
	public float fPH;

	public float fNTU;

	public float fNH3_N;

	public float fTN;

	public float fSD;

	public float fCOD;

	public float fNN;

	public float fDO;

	public float fChl_a;

	public float fTP;

	public float fCODMn;

	public float fSS;

	public float fBOD_5;

	public float fNO3_N;

	public float fTSI;

	public EM_SMELLY_LEVEL emSmellyLevel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szReserved;
}
