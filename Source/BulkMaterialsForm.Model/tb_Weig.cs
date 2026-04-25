// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_Weig

using System;
using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_Weig")]
public class tb_Weig
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string door_type { get; set; }

	[SugarColumn(IsNullable = true)]
	public string order_id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string goods_type { get; set; }

	[SugarColumn(IsNullable = true)]
	public string material_kind { get; set; }

	[SugarColumn(IsNullable = true)]
	public string goods_name { get; set; }

	[SugarColumn(IsNullable = true)]
	public string material_code { get; set; }

	[SugarColumn(IsNullable = true)]
	public string tare_weight { get; set; }

	[SugarColumn(IsNullable = true)]
	public string gross_weight { get; set; }

	[SugarColumn(IsNullable = true)]
	public string goods_suttle { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime scale_time { get; set; }

	[SugarColumn(IsNullable = true)]
	public string supplier_name { get; set; }

	[SugarColumn(IsNullable = true)]
	public string receiver_name { get; set; }

	[SugarColumn(IsNullable = true)]
	public string vehicleNo { get; set; }
}
