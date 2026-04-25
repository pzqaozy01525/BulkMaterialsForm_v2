// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.GoodsSetForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class GoodsSetForm : Form
{
	public string serialNum = "";

	public string license = "";

	public string licenseColor = "";

	public string gateCode = "";

	public int id;

	private IContainer components;

	private BarManager barManager1;

	private Bar bar2;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControl1;

	private TextBox textBox1;

	private Label label8;

	private TextBox textBox2;

	private Label label2;

	private Label label1;

	private DateTimePicker dateTimePicker1;

	private Label label3;

	private Label label4;

	private ComboBox comboBox1;

	public GoodsSetForm()
	{
		InitializeComponent();
		base.Load += CameraSetForm_Load;
	}

	private void CameraSetForm_Load(object sender, EventArgs e)
	{
		dateTimePicker1.Value = DateTime.Now;
		label3.Text = "车牌号：" + license;
		comboBox1.SelectedItem = "吨T";
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("货物名称不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBox2.Text))
		{
			MessageBox.Show("货物吨数不能为空");
		}
		else if (MainData.DJPT == "中科九州")
		{
			if (!CommonHelper.GetKangFengV1Token())
			{
				return;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("serialNum", serialNum);
			dictionary.Add("companyCode", MainData.companyCodeV1);
			dictionary.Add("gateCode", gateCode);
			dictionary.Add("license", license);
			dictionary.Add("licenseColor", CommonHelper.GetKaiFenglicenseColor(licenseColor));
			dictionary.Add("cargoName", textBox1.Text);
			dictionary.Add("cargoWeight", textBox2.Text);
			dictionary.Add("cargoRecordTime", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
			Dictionary<string, object> kaiFengV1ResultModel = CommonHelper.GetKaiFengV1ResultModel(MainData.KFV1ServerIP + "/transport/record/cargo", dictionary, MainData.KFV1Token);
			if (kaiFengV1ResultModel != null && kaiFengV1ResultModel.ContainsKey("success"))
			{
				if (Convert.ToBoolean(kaiFengV1ResultModel["success"]) && kaiFengV1ResultModel["code"].ToString().Equals("200"))
				{
					if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
					{
						cargoWeight = textBox2.Text,
						cargoName = textBox1.Text
					}, (tb_CarRecord p) => p.id == id))
					{
						MessageBox.Show("上传成功");
						Close();
					}
					else
					{
						MessageBox.Show("保存失败");
						Close();
					}
				}
				else
				{
					MessageBox.Show(kaiFengV1ResultModel["message"].ToString());
				}
			}
			else
			{
				MessageBox.Show("服务器异常");
			}
		}
		else
		{
			if (!(MainData.DJPT == "安车"))
			{
				return;
			}
			DateTime now = DateTime.Now;
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			dictionary2.Add("organ", MainData.ACorgan);
			dictionary2.Add("ipctype", "shareGoodsRecord");
			dictionary2.Add("access_token", MainData.ACToken);
			Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
			dictionary3.Add("lsh", serialNum);
			dictionary3.Add("qybh", MainData.ACEnterpriseID);
			dictionary3.Add("qymc", MainData.XMMC);
			dictionary3.Add("dzbh", gateCode);
			dictionary3.Add("cphm", license);
			dictionary3.Add("cpys", CommonHelper.GetKaiFenglicenseColor(licenseColor));
			dictionary3.Add("djsj", now.ToString("yyyy-MM-dd HH:mm:ss"));
			dictionary3.Add("serialNum", serialNum);
			dictionary3.Add("enterpriseID", MainData.ACEnterpriseID);
			dictionary3.Add("companyName", MainData.XMMC);
			dictionary3.Add("gateCodeB", gateCode);
			dictionary3.Add("license", license);
			dictionary3.Add("licenseColor", CommonHelper.GetKaiFenglicenseColor(licenseColor));
			dictionary3.Add("hwmc", textBox1.Text);
			dictionary3.Add("ysl", textBox2.Text);
			if (comboBox1.SelectedItem.ToString().Equals("吨T"))
			{
				dictionary3.Add("ysldw", "t");
			}
			else
			{
				dictionary3.Add("ysldw", "L");
			}
			dictionary3.Add("registerTime", now.ToString("yyyy-MM-dd HH:mm:ss"));
			dictionary2.Add("value", dictionary3);
			Dictionary<string, object> anCheV1ResultModel = CommonHelper.GetAnCheV1ResultModel(MainData.ACServerUrl + "/restapi/transportControl/put_data", dictionary2);
			if (anCheV1ResultModel != null)
			{
				if (anCheV1ResultModel.ContainsKey("code") && anCheV1ResultModel["code"].ToString().Equals("200"))
				{
					if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
					{
						cargoWeight = textBox2.Text,
						cargoName = textBox1.Text
					}, (tb_CarRecord p) => p.id == id))
					{
						MessageBox.Show("上传成功");
						Close();
					}
					else
					{
						MessageBox.Show("保存失败");
						Close();
					}
				}
				else
				{
					MessageBox.Show(anCheV1ResultModel["status"].ToString());
				}
			}
			else
			{
				MessageBox.Show("环保局平台异常，请联系环保局！");
			}
		}
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.bar2 = new DevExpress.XtraBars.Bar();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[3] { this.barButtonItem2, this.barButtonItem3, this.barButtonItem4 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 99;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[3]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.bar2.OptionsBar.MultiLine = true;
		this.bar2.OptionsBar.UseWholeRow = true;
		this.bar2.Text = "Main menu";
		this.barButtonItem2.Caption = "保存";
		this.barButtonItem2.Id = 96;
		this.barButtonItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.apply_32x322;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "取消";
		this.barButtonItem3.Id = 97;
		this.barButtonItem3.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.left_32x32;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem4.Caption = "关闭";
		this.barButtonItem4.Id = 98;
		this.barButtonItem4.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.cancel_32x32;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(526, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 348);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(526, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 308);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(526, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 308);
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Location = new System.Drawing.Point(181, 116);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(248, 34);
		this.textBox1.TabIndex = 40;
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(83, 119);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(92, 27);
		this.label8.TabIndex = 38;
		this.label8.Text = "货物名称";
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(181, 176);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(248, 34);
		this.textBox2.TabIndex = 43;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(83, 179);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(92, 27);
		this.label2.TabIndex = 42;
		this.label2.Text = "货物重量";
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(83, 281);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(92, 27);
		this.label1.TabIndex = 55;
		this.label1.Text = "上传时间";
		this.dateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 15f);
		this.dateTimePicker1.Location = new System.Drawing.Point(181, 278);
		this.dateTimePicker1.Name = "dateTimePicker1";
		this.dateTimePicker1.Size = new System.Drawing.Size(248, 34);
		this.dateTimePicker1.TabIndex = 56;
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.Location = new System.Drawing.Point(83, 66);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(92, 27);
		this.label3.TabIndex = 61;
		this.label3.Text = "车牌号：";
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.Location = new System.Drawing.Point(123, 228);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(52, 27);
		this.label4.TabIndex = 66;
		this.label4.Text = "单位";
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[2] { "吨T", "升L" });
		this.comboBox1.Location = new System.Drawing.Point(181, 225);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(248, 35);
		this.comboBox1.TabIndex = 67;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(526, 348);
		base.Controls.Add(this.comboBox1);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.dateTimePicker1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "GoodsSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "相机设置";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
