// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.CacheInfo

using System;

namespace BulkMaterialsForm.API;

public class CacheInfo
{
	public bool CacheExists { get; set; }

	public DateTime LastOnlineCheckTime { get; set; }

	public bool IsOfflineGraceValid { get; set; }

	public int RemainingGraceDays { get; set; }

	public int GracePeriodDays { get; set; }

	public string CachedMachineCode { get; set; }

	public DateTime CachedExpireDate { get; set; }

	public bool CachedIsValid { get; set; }
}
