// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_nonRoadRecord

using System;
using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_nonRoadRecord")]
internal class tb_nonRoadRecord
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public int nonRoadId { get; set; }

	[SugarColumn(IsNullable = true)]
	public DateTime addtime { get; set; }

	[SugarColumn(IsNullable = true)]
	public string outType { get; set; }
}
