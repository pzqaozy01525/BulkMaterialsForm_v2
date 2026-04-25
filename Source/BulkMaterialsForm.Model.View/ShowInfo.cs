// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model.View
// Type: BulkMaterialsForm.Model.View.ShowInfo

using System.Collections.Generic;

namespace BulkMaterialsForm.Model.View;

public class ShowInfo
{
	public int id = 1;

	public int fontSize = 16;

	public string fontColor = "red";

	public string speedType = "medium";

	public string displayMode = "instant";

	public List<LineInfoList> LineInfoList = new List<LineInfoList>();
}
