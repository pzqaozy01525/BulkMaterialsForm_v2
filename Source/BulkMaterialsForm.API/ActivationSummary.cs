// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.ActivationSummary

using System;

namespace BulkMaterialsForm.API;

public class ActivationSummary
{
	public string MachineCode { get; set; }

	public bool IsActivated { get; set; }

	public DateTime ExpireDate { get; set; }

	public int RemainingDays { get; set; }

	public DateTime LastSyncTime { get; set; }

	public bool IsOnline { get; set; }
}
