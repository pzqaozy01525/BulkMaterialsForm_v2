// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.NonRoadLedgerDto

using System;

namespace BulkMaterialsForm.Help;

public class NonRoadLedgerDto
{
	public int Id { get; set; }

	public string LedgerNo { get; set; }

	public string VehicleNo { get; set; }

	public string EmissionStandard { get; set; }

	public string FuelType { get; set; }

	public string Brand { get; set; }

	public DateTime CreatedAtUtc { get; set; }
}
