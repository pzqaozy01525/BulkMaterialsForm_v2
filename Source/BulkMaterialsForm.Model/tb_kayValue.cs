// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_kayValue

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_kayValue")]
public class tb_kayValue
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string keyCode { get; set; }

	[SugarColumn(IsNullable = true)]
	public string keyValue { get; set; }

	[SugarColumn(IsNullable = true)]
	public string keyType { get; set; }

	[SugarColumn(IsNullable = true)]
	public int platformId { get; set; }
}
