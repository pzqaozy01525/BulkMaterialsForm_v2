// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.ActivationRequestResult

using System;

namespace BulkMaterialsForm.API;

public class ActivationRequestResult
{
	public bool Success { get; set; }

	public string Message { get; set; }

	public string RequestId { get; set; }

	public string ActivationCode { get; set; }

	public DateTime? ExpireDate { get; set; }

	public string CustomerId { get; set; }

	public string TenantId { get; set; }

	public string CompanyName { get; set; }

	public string CreditCode { get; set; }

	public string Phone { get; set; }

	public string Contact { get; set; }

	public string AdminUsername { get; set; }

	public string AdminPassword { get; set; }

	public bool IsActive { get; set; }
}
