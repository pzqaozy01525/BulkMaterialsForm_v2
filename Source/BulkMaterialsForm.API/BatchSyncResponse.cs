// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.BatchSyncResponse

using System.Collections.Generic;

namespace BulkMaterialsForm.API;

internal class BatchSyncResponse
{
	public int SuccessCount { get; set; }

	public int FailedCount { get; set; }

	public List<string> FailedMachineCodes { get; set; }
}
