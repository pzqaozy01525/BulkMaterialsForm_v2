// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.PendingSyncItem

using System;

namespace BulkMaterialsForm.API;

public class PendingSyncItem
{
	public string MachineCode { get; set; }

	public string ActivationCode { get; set; }

	public DateTime ExpireDate { get; set; }

	public DateTime AddedTime { get; set; }
}
