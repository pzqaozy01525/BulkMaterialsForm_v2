// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.CloudApiResponse

namespace BulkMaterialsForm.API;

internal class CloudApiResponse
{
	public string Data { get; set; }

	public string Signature { get; set; }

	public bool Success { get; set; }

	public string Message { get; set; }
}
