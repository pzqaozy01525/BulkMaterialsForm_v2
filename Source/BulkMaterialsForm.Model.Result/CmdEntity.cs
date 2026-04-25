// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model.Result
// Type: BulkMaterialsForm.Model.Result.CmdEntity

namespace BulkMaterialsForm.Model.Result;

public class CmdEntity
{
	public int cmdType { get; set; }

	public int cmdStatus { get; set; }

	public string dataId { get; set; }

	public string ClientCode { get; set; }

	public long? EnterpriseId { get; set; }

	public object vehicleEntity { get; set; }

	public string licenseColorId { get; set; }

	public string vehicleTypeId { get; set; }

	public string useCharacterId { get; set; }

	public string emissionStandardId { get; set; }

	public string fuelTypeId { get; set; }
}
