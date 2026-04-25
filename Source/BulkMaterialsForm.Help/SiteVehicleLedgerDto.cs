// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.SiteVehicleLedgerDto

using System;

namespace BulkMaterialsForm.Help;

public class SiteVehicleLedgerDto
{
	public int Id { get; set; }

	public string LedgerNo { get; set; }

	public string VehicleNo { get; set; }

	public string LicenseColor { get; set; }

	public string VehicleType { get; set; }

	public string Owner { get; set; }

	public DateTime CreatedAtUtc { get; set; }
}
