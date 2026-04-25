// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_TempCarInfo

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_TempCarInfo")]
public class tb_TempCarInfo
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string car_no { get; set; }

	[SugarColumn(IsNullable = true)]
	public string licenseColor { get; set; }

	[SugarColumn(IsNullable = true)]
	public string standard { get; set; }

	[SugarColumn(IsNullable = true)]
	public string fuelType { get; set; }

	[SugarColumn(IsNullable = true)]
	public string passMessage { get; set; }

	[SugarColumn(IsNullable = true)]
	public string isPass { get; set; }

	[SugarColumn(IsNullable = true)]
	public string add_time { get; set; }
}
