// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.CarRecordDto

using System;

namespace BulkMaterialsForm.Help;

public class CarRecordDto
{
	public int Id { get; set; }

	public string SerialNum { get; set; }

	public string License { get; set; }

	public string LicenseColor { get; set; }

	public string ChannelName { get; set; }

	public string ChannelType { get; set; }

	public string FuelType { get; set; }

	public string EmissionStandard { get; set; }

	public string CargoName { get; set; }

	public decimal? CargoWeight { get; set; }

	public DateTime AddTime { get; set; }
}
