// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_CarRecord

using System;
using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_CarRecord")]
public class tb_CarRecord
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string car_no { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime add_time { get; set; }

	[SugarColumn(IsNullable = true)]
	public string out_type { get; set; }

	[SugarColumn(IsNullable = true)]
	public string car_color { get; set; }

	[SugarColumn(IsNullable = true)]
	public string platform_status { get; set; }

	[SugarColumn(IsNullable = true)]
	public string car_image { get; set; }

	[SugarColumn(IsNullable = true)]
	public string front_image { get; set; }

	[SugarColumn(IsNullable = true)]
	public string upload_status { get; set; }

	[SugarColumn(IsNullable = true)]
	public int upload_number { get; set; }

	[SugarColumn(IsNullable = true)]
	public string ChannelPort { get; set; }

	[SugarColumn(IsNullable = true)]
	public string serialNum { get; set; }

	[SugarColumn(IsNullable = true)]
	public string gateSignal { get; set; }

	[SugarColumn(IsNullable = true)]
	public string fuelType { get; set; }

	[SugarColumn(IsNullable = true)]
	public string emissionStandard { get; set; }

	[SugarColumn(IsNullable = true)]
	public string cargoName { get; set; }

	[SugarColumn(IsNullable = true)]
	public string cargoWeight { get; set; }
}
