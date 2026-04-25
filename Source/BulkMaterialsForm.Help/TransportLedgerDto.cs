// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.TransportLedgerDto

using System;

namespace BulkMaterialsForm.Help;

public class TransportLedgerDto
{
	public int Id { get; set; }

	public string LedgerNo { get; set; }

	public string VehicleNo { get; set; }

	public string TransportType { get; set; }

	public string InCargoName { get; set; }

	public decimal? InCargoWeight { get; set; }

	public DateTime? InTime { get; set; }

	public string OutCargoName { get; set; }

	public decimal? OutCargoWeight { get; set; }

	public DateTime? OutTime { get; set; }

	public DateTime CreatedAtUtc { get; set; }
}
