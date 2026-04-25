// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_ImageDetaile

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_ImageDetaile")]
public class tb_ImageDetaile
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string ImagePath { get; set; }

	[SugarColumn(IsNullable = true)]
	public int detaileID { get; set; }
}
