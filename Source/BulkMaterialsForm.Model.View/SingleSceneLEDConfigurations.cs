// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model.View
// Type: BulkMaterialsForm.Model.View.SingleSceneLEDConfigurations

using System.Collections.Generic;

namespace BulkMaterialsForm.Model.View;

public class SingleSceneLEDConfigurations
{
	public List<LEDConfigurationList> LEDConfigurationList = new List<LEDConfigurationList>();

	public int sid = 1;

	public string mode = "passingVehicle";

	public bool showFreeEnabled = true;

	public int displayTime = 60;

	public bool vehicleDisplayEnabled;
}
