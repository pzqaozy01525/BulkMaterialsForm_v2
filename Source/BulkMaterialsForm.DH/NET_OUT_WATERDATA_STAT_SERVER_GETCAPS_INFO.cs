// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_WATERDATA_STAT_SERVER_GETCAPS_INFO

namespace BulkMaterialsForm.DH;

public struct NET_OUT_WATERDATA_STAT_SERVER_GETCAPS_INFO
{
	public uint dwSize;

	public EM_WATERDATA_STAT_SERVER_SUPPORT emSupport;

	public EM_SUPPORT_LOCALDATA_STORE emSupportLocalDataStore;
}
