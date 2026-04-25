// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_nonRoad

using System;
using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_nonRoad")]
public class tb_nonRoad
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string hbdjh { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime jxscrq { get; set; }

	[SugarColumn(IsNullable = true)]
	public string car_no { get; set; }

	[SugarColumn(IsNullable = true)]
	public string pfjd { get; set; }

	[SugarColumn(IsNullable = true)]
	public string ryxl { get; set; }

	[SugarColumn(IsNullable = true)]
	public string jxzl { get; set; }

	[SugarColumn(IsNullable = true)]
	public string pin { get; set; }

	[SugarColumn(IsNullable = true)]
	public string jxxh { get; set; }

	[SugarColumn(IsNullable = true)]
	public string fdjxh { get; set; }

	[SugarColumn(IsNullable = true)]
	public string fdjcs { get; set; }

	[SugarColumn(IsNullable = true)]
	public string fdjbh { get; set; }

	[SugarColumn(IsNullable = true)]
	public string shr { get; set; }
}
