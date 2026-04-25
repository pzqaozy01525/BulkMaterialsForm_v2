// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_tempVehicle

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_tempVehicle")]
public class tb_tempVehicle
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string vehicleNo { get; set; }

	[SugarColumn(IsNullable = true)]
	public string cdmc { get; set; }

	[SugarColumn(IsNullable = true)]
	public string vin { get; set; }

	[SugarColumn(IsNullable = true)]
	public string registerDate { get; set; }

	[SugarColumn(IsNullable = true)]
	public string model { get; set; }

	[SugarColumn(IsNullable = true)]
	public string fuelType { get; set; }

	[SugarColumn(IsNullable = true)]
	public string emissionStandard { get; set; }

	[SugarColumn(IsNullable = true)]
	public string useCharacter { get; set; }

	[SugarColumn(IsNullable = true)]
	public string drivingLicenseImg2 { get; set; }

	[SugarColumn(IsNullable = true)]
	public string drivingLicenseImg { get; set; }
}
