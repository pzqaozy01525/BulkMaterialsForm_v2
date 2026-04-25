// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_large_screen

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_large_screen")]
public class tb_large_screen
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string IP { get; set; }

	[SugarColumn(IsNullable = true)]
	public string largeName { get; set; }

	[SugarColumn(IsNullable = true)]
	public int largeWidth { get; set; }

	[SugarColumn(IsNullable = true)]
	public int largeHeight { get; set; }
}
