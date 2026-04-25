// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_videotape

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_videotape")]
public class tb_videotape
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string IP { get; set; }

	[SugarColumn(IsNullable = true)]
	public string doccode { get; set; }

	[SugarColumn(IsNullable = true)]
	public string pass { get; set; }

	[SugarColumn(IsNullable = true)]
	public int ChannelID { get; set; }

	[SugarColumn(IsNullable = true)]
	public int snapNumber { get; set; }

	[SugarColumn(IsNullable = true)]
	public string type { get; set; }
}
