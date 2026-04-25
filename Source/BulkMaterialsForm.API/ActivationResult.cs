// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.ActivationResult

using System;

namespace BulkMaterialsForm.API;

public class ActivationResult
{
	public bool IsSuccess { get; set; }

	public bool IsValid { get; set; }

	public DateTime ExpireDate { get; set; }

	public string Message { get; set; }

	public DateTime LastVerifyTime { get; set; }

	public string SupportName { get; set; } = "";

	public string SupportPhone { get; set; } = "";

	public string SupportCompany { get; set; } = "";

	public string Status { get; set; } = "Active";
}
