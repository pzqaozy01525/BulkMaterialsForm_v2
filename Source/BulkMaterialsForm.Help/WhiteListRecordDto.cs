// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.WhiteListRecordDto

using System;

namespace BulkMaterialsForm.Help;

public class WhiteListRecordDto
{
	public int Id { get; set; }

	public string Type { get; set; }

	public string License { get; set; }

	public string LicenseColor { get; set; }

	public string Owner { get; set; }

	public string Vin { get; set; }

	public string FuelType { get; set; }

	public string EmissionStandard { get; set; }

	public DateTime CreatedAtUtc { get; set; }
}
