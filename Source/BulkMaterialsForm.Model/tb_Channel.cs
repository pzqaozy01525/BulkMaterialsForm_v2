// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_Channel

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_Channel")]
public class tb_Channel
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string ChannelName { get; set; }

	[SugarColumn(IsNullable = true)]
	public string ChannelType { get; set; }

	[SugarColumn(IsNullable = true)]
	public string ChannelPort { get; set; }

	[SugarColumn(IsNullable = true)]
	public string guid { get; set; }
}
