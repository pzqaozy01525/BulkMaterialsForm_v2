// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model.View
// Type: BulkMaterialsForm.Model.View.LEDConfiguration

using System.Collections.Generic;

namespace BulkMaterialsForm.Model.View;

public class LEDConfiguration
{
	public int id = 1;

	public bool enabled = true;

	public List<ShowInfoList> ShowInfoList = new List<ShowInfoList>();
}
