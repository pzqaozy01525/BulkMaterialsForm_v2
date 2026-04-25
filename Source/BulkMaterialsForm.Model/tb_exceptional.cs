// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_exceptional

using System;
using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_exceptional")]
public class tb_exceptional
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string car_no { get; set; }

	[SugarColumn(IsNullable = true)]
	public string gateName { get; set; }

	[SugarColumn(IsNullable = true)]
	public string ChannelType { get; set; }

	[SugarColumn(IsNullable = true)]
	public int CameraId { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime add_time { get; set; }

	[SugarColumn(IsNullable = true)]
	public string OpeningType { get; set; }

	[SugarColumn(IsNullable = true)]
	public string SnapImagePath1 { get; set; }

	[SugarColumn(IsNullable = true)]
	public string SnapImagePath2 { get; set; }

	[SugarColumn(IsNullable = true)]
	public string SnapImagePath3 { get; set; }

	[SugarColumn(IsNullable = true)]
	public string SnapVideoPath { get; set; }
}
