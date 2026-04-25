// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_vehicleInfo

using System;
using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_vehicleInfo")]
public class tb_vehicleInfo
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string vehicleNo { get; set; }

	[SugarColumn(IsNullable = true)]
	public string licenseColor { get; set; }

	[SugarColumn(IsNullable = true)]
	public string vehicleType { get; set; }

	[SugarColumn(IsNullable = true)]
	public string vin { get; set; }

	[SugarColumn(IsNullable = true)]
	public string fueltype { get; set; }

	[SugarColumn(IsNullable = true)]
	public int enterpriseId { get; set; }

	[SugarColumn(IsNullable = true)]
	public string useCharacter { get; set; }

	[SugarColumn(IsNullable = true)]
	public string engineNo { get; set; }

	[SugarColumn(IsNullable = true)]
	public string onwer { get; set; }

	[SugarColumn(IsNullable = true)]
	public string address { get; set; }

	[SugarColumn(IsNullable = true)]
	public string model { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime registerDate { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime issueDate { get; set; }

	[SugarColumn(IsNullable = true)]
	public string emissionStandard { get; set; }

	[SugarColumn(IsNullable = true)]
	public string drivingLicenseImg { get; set; }

	[SugarColumn(IsNullable = true)]
	public string drivingLicenseImgAbsolute { get; set; }

	[SugarColumn(IsNullable = true)]
	public string drivingLicenseImg2 { get; set; }

	[SugarColumn(IsNullable = true)]
	public string drivingLicenseImg2Absolute { get; set; }

	[SugarColumn(IsNullable = true)]
	public string xzdw { get; set; }
}
