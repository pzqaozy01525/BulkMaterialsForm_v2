// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.LicensePayload

using System;

namespace BulkMaterialsForm.Help;

public sealed class LicensePayload
{
	public string LicenseId { get; set; } = string.Empty;

	public string LicenseCode { get; set; } = string.Empty;

	public string MachineFingerprint { get; set; } = string.Empty;

	public DateTime IssuedAt { get; set; }

	public DateTime? ExpiryDate { get; set; }

	public DateTime IssuedAtUtc { get; set; }

	public DateTime ExpireAtUtc { get; set; }

	public string KeyId { get; set; } = string.Empty;

	public string ProjectName { get; set; } = string.Empty;

	public string CustomerName { get; set; } = string.Empty;

	public string LastKnownIp { get; set; } = string.Empty;

	public DateTime? GetEffectiveExpiryDate()
	{
		if (ExpiryDate.HasValue)
		{
			return ExpiryDate;
		}
		if (ExpireAtUtc > DateTime.MinValue)
		{
			return ExpireAtUtc;
		}
		return null;
	}
}
