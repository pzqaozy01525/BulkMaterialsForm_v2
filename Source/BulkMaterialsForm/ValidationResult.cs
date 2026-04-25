// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm
// Type: BulkMaterialsForm.ValidationResult

using System;

namespace BulkMaterialsForm;

public class ValidationResult
{
	public bool IsValid { get; set; }

	public bool FingerprintValid { get; set; }

	public bool ActivationValid { get; set; }

	public bool TimeValid { get; set; }

	public string FailureReason { get; set; }

	public DateTime ValidationTime { get; set; }
}
