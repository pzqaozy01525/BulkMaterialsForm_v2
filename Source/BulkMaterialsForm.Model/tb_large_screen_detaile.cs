// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_large_screen_detaile

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_large_screen_detaile")]
public class tb_large_screen_detaile
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public int x { get; set; }

	[SugarColumn(IsNullable = true)]
	public int y { get; set; }

	[SugarColumn(IsNullable = true)]
	public int Width { get; set; }

	[SugarColumn(IsNullable = true)]
	public int Height { get; set; }

	[SugarColumn(IsNullable = true)]
	public string xstx { get; set; }

	[SugarColumn(IsNullable = true)]
	public int yxsd { get; set; }

	[SugarColumn(IsNullable = true)]
	public int tlsj { get; set; }

	[SugarColumn(IsNullable = true)]
	public string customText { get; set; }

	[SugarColumn(IsNullable = true)]
	public int largeId { get; set; }

	[SugarColumn(IsNullable = true)]
	public string charId { get; set; }

	[SugarColumn(IsNullable = true)]
	public string fontColor { get; set; }
}
