// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_vehicleInfoV2

using System;
using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_vehicleInfoV2")]
public class tb_vehicleInfoV2
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
	public string fuelType { get; set; }

	[SugarColumn(IsNullable = true)]
	public string emissionStandard { get; set; }

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
	public string hdzzl { get; set; }

	[SugarColumn(IsNullable = true)]
	public string fzdw { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime registerDate { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime issueDate { get; set; }

	[SugarColumn(IsNullable = true)]
	public string drivingFrontLicenseImg { get; set; }

	[SugarColumn(IsNullable = true)]
	public string drivingBackLicenseImg { get; set; }

	[SugarColumn(IsNullable = true)]
	public string AccompanyingVehicleImg { get; set; }

	[SugarColumn(IsNullable = true)]
	public string frameImg { get; set; }

	[SugarColumn(IsNullable = true)]
	public string xzdw { get; set; }

	[SugarColumn(IsNullable = true)]
	public int isApprove { get; set; }

	[SugarColumn(IsNullable = true)]
	public string hdzrs { get; set; }

	[SugarColumn(IsNullable = true)]
	public string zzl { get; set; }

	[SugarColumn(IsNullable = true)]
	public string zbzl { get; set; }

	[SugarColumn(IsNullable = true)]
	public string wkcc { get; set; }

	[SugarColumn(IsNullable = true)]
	public string jyjl { get; set; }

	[SugarColumn(IsNullable = true)]
	public string cdmc { get; set; }

	[SugarColumn(IsNullable = true)]
	public string Remark { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime addTime { get; set; }
}
