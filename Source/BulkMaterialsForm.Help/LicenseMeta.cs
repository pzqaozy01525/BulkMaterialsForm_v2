// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.LicenseMeta

using System;

namespace BulkMaterialsForm.Help;

public sealed class LicenseMeta
{
	public DateTime? LastCloudCheckUtc { get; set; }

	public DateTime? LastUpdatedUtc { get; set; }

	public int ConsecutiveFailures { get; set; }
}
