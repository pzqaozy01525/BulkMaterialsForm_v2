// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_car_info

using System;
using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_car_info")]
public class tb_car_info
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string car_no { get; set; }

	[SugarColumn(IsNullable = true)]
	public string name { get; set; }

	[SugarColumn(IsNullable = true)]
	public string phone { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime startTime { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime endTime { get; set; }

	[SugarColumn(IsNullable = true)]
	public string dep { get; set; }

	[SugarColumn(IsNullable = true)]
	public string bz { get; set; }
}
