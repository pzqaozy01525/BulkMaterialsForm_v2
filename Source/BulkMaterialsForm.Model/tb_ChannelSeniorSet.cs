// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_ChannelSeniorSet

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_ChannelSeniorSet")]
public class tb_ChannelSeniorSet
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public int ChannelId { get; set; }

	[SugarColumn(IsNullable = true)]
	public bool platformOpen { get; set; }

	[SugarColumn(IsNullable = true)]
	public string transitColour { get; set; }

	[SugarColumn(IsNullable = true)]
	public string ColourWhiteList { get; set; }
}
