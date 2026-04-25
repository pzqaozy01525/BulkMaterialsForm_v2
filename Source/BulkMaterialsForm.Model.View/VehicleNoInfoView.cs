// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model.View
// Type: BulkMaterialsForm.Model.View.VehicleNoInfoView

using System;

namespace BulkMaterialsForm.Model.View;

public class VehicleNoInfoView
{
	public string VehicleNo { get; set; }

	public string licenseColor { get; set; }

	public string TrafficStatus { get; set; }

	public DateTime AddTime { get; set; }

	public string ChannelName { get; set; }

	public string DeviceName { get; set; }

	public string ChannelType { get; set; }

	public string ExeLog { get; set; }

	public string ImagePath { get; set; }

	public string fuelType { get; set; }

	public string emissionStandard { get; set; }

	public string serialNum { get; set; }

	public int id { get; set; }

	public tb_Channel channel { get; set; }

	public int largeId { get; set; }

	public bool IsRelease { get; set; }

	public int ChannelId { get; set; }

	public int devId { get; set; }
}
