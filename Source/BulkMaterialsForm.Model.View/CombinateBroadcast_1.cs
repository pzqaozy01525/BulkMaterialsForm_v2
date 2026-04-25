// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model.View
// Type: BulkMaterialsForm.Model.View.CombinateBroadcast

using System.Collections.Generic;

namespace BulkMaterialsForm.Model.View;

public class CombinateBroadcast
{
	public int volume = 5;

	public bool volumeTimeEnabled;

	public bool vehicleBroadcastEnabled = true;

	public bool allowListBroadcastEnabled;

	public bool blockListBroadcastEnabled;

	public bool temporaryListBroadcastEnabled;

	public string ctrlMode = "cameraAndplatform";

	public List<BroadcastInfoList> BroadcastInfoList = new List<BroadcastInfoList>();
}
