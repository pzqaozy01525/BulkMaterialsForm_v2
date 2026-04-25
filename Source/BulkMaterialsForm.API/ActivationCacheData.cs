// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.ActivationCacheData

using System;

namespace BulkMaterialsForm.API;

internal class ActivationCacheData
{
	public string MachineCode { get; set; }

	public bool IsValid { get; set; }

	public DateTime ExpireDate { get; set; }

	public DateTime LastVerifyTime { get; set; }

	public DateTime LastOnlineCheckTime { get; set; }

	public string CacheVersion { get; set; }

	public string Message { get; set; }

	public string Status { get; set; } = "Active";
}
