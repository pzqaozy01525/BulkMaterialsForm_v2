// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model
// Type: BulkMaterialsForm.Model.tb_Device

using SqlSugar;

namespace BulkMaterialsForm.Model;

[SugarTable("tb_Device")]
public class tb_Device
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
	public int id { get; set; }

	[SugarColumn(IsNullable = true)]
	public string CameraName { get; set; }

	[SugarColumn(IsNullable = true)]
	public int ChannelNo { get; set; }

	[SugarColumn(IsNullable = true)]
	public string CameraBrand { get; set; }

	[SugarColumn(IsNullable = true)]
	public string CameraIP { get; set; }

	[SugarColumn(IsNullable = true)]
	public string OpeningMethod { get; set; }

	[SugarColumn(IsNullable = true)]
	public string CameraType { get; set; }

	[SugarColumn(IsNullable = true)]
	public string motherboardType { get; set; }

	[SugarColumn(IsNullable = true)]
	public string deviceId { get; set; }

	[SugarColumn(IsNullable = false, DefaultValue = "0")]
	public int SnapId { get; set; }

	[SugarColumn(IsNullable = true)]
	public string IOIP { get; set; }

	[SugarColumn(IsNullable = true)]
	public string bjip { get; set; }

	[SugarColumn(IsNullable = false, DefaultValue = "0")]
	public int bigScreenId { get; set; }

	[SugarColumn(IsNullable = true, DefaultValue = "0")]
	public string ChannelID { get; set; }
}
