// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SET_MARK_FILE_BY_TIME

namespace BulkMaterialsForm.DH;

public struct NET_IN_SET_MARK_FILE_BY_TIME
{
	public uint dwSize;

	public int nChannel;

	public NET_TIME_EX stuStartTime;

	public NET_TIME_EX stuEndTime;

	public bool bFlag;

	public bool bLockTimeFlag;

	public uint nLockTime;
}
