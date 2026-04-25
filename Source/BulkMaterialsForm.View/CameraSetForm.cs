// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.CameraSetForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class CameraSetForm : Form
{
	public int id;

	public int type;

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

	private ComboBox comboBox1;

	private TextBox textBox1;

	private Label label1;

	private Label label8;

	private Label label3;

	private TextBox textBox2;

	private Label label2;

	private ComboBox comboBox2;

	private ComboBox comboBox3;

	private Label label4;

	private ComboBox comboBox4;

	private Label label5;

	private ComboBox comboBox5;

	private Label label6;

	private ComboBox comboBox6;

	private Label label7;

	private Label label9;

	private TextBox textBox3;

	private ComboBox comboBox7;

	private Label label10;

	private TextBox textBox4;

	private Label label11;

	public CameraSetForm()
	{
		InitializeComponent();
		base.Load += CameraSetForm_Load;
	}

	private void CameraSetForm_Load(object sender, EventArgs e)
	{
		if (type == 1)
		{
			InitData();
			tb_Device tb_Device2 = new DataServerContext<tb_Device>().Current.GetList((tb_Device it) => it.id == id).FirstOrDefault();
			if (tb_Device2 != null)
			{
				comboBox1.SelectedItem = tb_Device2.CameraBrand;
				comboBox2.SelectedValue = Convert.ToInt32(tb_Device2.OpeningMethod);
				comboBox3.SelectedItem = tb_Device2.CameraType;
				comboBox4.SelectedItem = tb_Device2.motherboardType;
				comboBox5.SelectedValue = tb_Device2.ChannelNo;
				comboBox6.SelectedValue = tb_Device2.SnapId;
				comboBox7.SelectedValue = tb_Device2.bigScreenId;
				textBox1.Text = tb_Device2.CameraName;
				textBox2.Text = tb_Device2.CameraIP;
				textBox3.Text = tb_Device2.IOIP;
				textBox4.Text = tb_Device2.bjip;
			}
		}
		else
		{
			InitData();
		}
	}

	public void InitData()
	{
		List<tb_Device> list = new DataServerContext<tb_Device>().Current.GetList();
		tb_Device tb_Device2 = new tb_Device();
		tb_Device2.id = 0;
		tb_Device2.CameraName = "自身";
		list.Insert(0, tb_Device2);
		comboBox2.ValueMember = "id";
		comboBox2.DisplayMember = "CameraName";
		comboBox2.DataSource = list;
		comboBox2.SelectedIndex = 0;
		List<tb_Channel> list2 = new DataServerContext<tb_Channel>().Current.GetList();
		comboBox5.ValueMember = "id";
		comboBox5.DisplayMember = "ChannelName";
		comboBox5.DataSource = list2;
		if (list2.Count > 0)
		{
			comboBox5.SelectedIndex = 0;
		}
		List<tb_videotape> list3 = new DataServerContext<tb_videotape>().Current.GetList();
		comboBox6.ValueMember = "id";
		comboBox6.DisplayMember = "IP";
		comboBox6.DataSource = list3;
		if (list3.Count > 0)
		{
			comboBox6.SelectedIndex = 0;
		}
		List<tb_large_screen> list4 = new DataServerContext<tb_large_screen>().Current.GetList();
		comboBox7.ValueMember = "id";
		comboBox7.DisplayMember = "IP";
		comboBox7.DataSource = list4;
		if (list4.Count > 0)
		{
			comboBox7.SelectedIndex = 0;
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("相机名称不能为空");
			return;
		}
		if (comboBox2.SelectedItem == null)
		{
			MessageBox.Show("开闸方式不能为空");
			return;
		}
		if (comboBox1.SelectedItem == null)
		{
			MessageBox.Show("相机型号不能为空");
			return;
		}
		if (comboBox3.SelectedItem == null)
		{
			MessageBox.Show("相机类型不能为空");
			return;
		}
		if (string.IsNullOrWhiteSpace(textBox2.Text))
		{
			MessageBox.Show("相机IP不能为空");
			return;
		}
		if (comboBox5.SelectedItem == null)
		{
			MessageBox.Show("相机通道不能为空");
			return;
		}
		int bigScreenId = 0;
		if (comboBox7.SelectedItem != null)
		{
			bigScreenId = Convert.ToInt32(comboBox7.SelectedValue);
		}
		int SnapId = 0;
		if (comboBox6.SelectedItem != null)
		{
			SnapId = Convert.ToInt32(comboBox6.SelectedValue);
		}
		DataServerContext<tb_Device> dataServerContext = new DataServerContext<tb_Device>();
		if (type == 1)
		{
			if (dataServerContext.Current.Modify((tb_Device p) => new tb_Device
			{
				CameraName = textBox1.Text,
				CameraBrand = comboBox1.SelectedItem.ToString(),
				OpeningMethod = comboBox2.SelectedValue.ToString(),
				CameraType = comboBox3.SelectedItem.ToString(),
				motherboardType = comboBox4.SelectedItem.ToString(),
				ChannelNo = Convert.ToInt32(comboBox5.SelectedValue),
				CameraIP = textBox2.Text,
				SnapId = SnapId,
				IOIP = textBox3.Text,
				bigScreenId = bigScreenId,
				bjip = textBox4.Text
			}, (tb_Device p) => p.id == id))
			{
				MessageBox.Show("修改成功");
				Close();
			}
			else
			{
				MessageBox.Show("修改失败");
			}
			return;
		}
		tb_Device tb_Device2 = new tb_Device();
		tb_Device2.CameraBrand = comboBox1.SelectedItem.ToString();
		tb_Device2.CameraName = textBox1.Text;
		tb_Device2.CameraIP = textBox2.Text;
		tb_Device2.ChannelNo = Convert.ToInt32(comboBox5.SelectedValue);
		tb_Device2.OpeningMethod = comboBox2.SelectedValue.ToString();
		tb_Device2.CameraType = comboBox3.SelectedItem.ToString();
		tb_Device2.motherboardType = comboBox4.SelectedItem.ToString();
		tb_Device2.SnapId = SnapId;
		tb_Device2.IOIP = textBox3.Text;
		tb_Device2.bigScreenId = bigScreenId;
		tb_Device2.bjip = textBox4.Text;
		if (dataServerContext.Current.AddReturnIdentity(tb_Device2) > 0)
		{
			MessageBox.Show("保存成功");
			Close();
		}
		else
		{
			MessageBox.Show("保存失败");
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
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.comboBox3 = new System.Windows.Forms.ComboBox();
		this.label4 = new System.Windows.Forms.Label();
		this.comboBox4 = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
		this.label6 = new System.Windows.Forms.Label();
		this.comboBox6 = new System.Windows.Forms.ComboBox();
		this.label7 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.comboBox7 = new System.Windows.Forms.ComboBox();
		this.label10 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label11 = new System.Windows.Forms.Label();
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
		this.barDockControlTop.Size = new System.Drawing.Size(784, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 413);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(784, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 373);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(784, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 373);
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 15f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[5] { "QY", "HX", "ZS", "HK", "DH" });
		this.comboBox1.Location = new System.Drawing.Point(123, 143);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(248, 35);
		this.comboBox1.TabIndex = 41;
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Location = new System.Drawing.Point(123, 90);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(248, 34);
		this.textBox1.TabIndex = 40;
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(25, 146);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(92, 27);
		this.label1.TabIndex = 39;
		this.label1.Text = "相机型号";
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(25, 93);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(92, 27);
		this.label8.TabIndex = 38;
		this.label8.Text = "相机名称";
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(123, 198);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(248, 34);
		this.textBox2.TabIndex = 43;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(25, 201);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(72, 27);
		this.label2.TabIndex = 42;
		this.label2.Text = "相机IP";
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.Location = new System.Drawing.Point(405, 96);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(92, 27);
		this.label3.TabIndex = 42;
		this.label3.Text = "开闸方式";
		this.comboBox2.Font = new System.Drawing.Font("微软雅黑", 15f);
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Location = new System.Drawing.Point(503, 93);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(248, 35);
		this.comboBox2.TabIndex = 44;
		this.comboBox3.Font = new System.Drawing.Font("微软雅黑", 15f);
		this.comboBox3.FormattingEnabled = true;
		this.comboBox3.Items.AddRange(new object[2] { "标准相机", "监控相机" });
		this.comboBox3.Location = new System.Drawing.Point(503, 147);
		this.comboBox3.Name = "comboBox3";
		this.comboBox3.Size = new System.Drawing.Size(248, 35);
		this.comboBox3.TabIndex = 46;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.Location = new System.Drawing.Point(405, 150);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(92, 27);
		this.label4.TabIndex = 45;
		this.label4.Text = "相机类型";
		this.comboBox4.Font = new System.Drawing.Font("微软雅黑", 15f);
		this.comboBox4.FormattingEnabled = true;
		this.comboBox4.Items.AddRange(new object[7] { "KF", "FK", "DH-2竖屏", "DH-4横屏", "HK-2", "HK-4", "空" });
		this.comboBox4.Location = new System.Drawing.Point(503, 201);
		this.comboBox4.Name = "comboBox4";
		this.comboBox4.Size = new System.Drawing.Size(248, 35);
		this.comboBox4.TabIndex = 48;
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label5.Location = new System.Drawing.Point(405, 204);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(90, 27);
		this.label5.TabIndex = 47;
		this.label5.Text = "LED类型";
		this.comboBox5.Font = new System.Drawing.Font("微软雅黑", 15f);
		this.comboBox5.FormattingEnabled = true;
		this.comboBox5.Location = new System.Drawing.Point(123, 255);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(248, 35);
		this.comboBox5.TabIndex = 50;
		this.label6.AutoSize = true;
		this.label6.BackColor = System.Drawing.Color.Transparent;
		this.label6.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label6.Location = new System.Drawing.Point(25, 258);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(92, 27);
		this.label6.TabIndex = 49;
		this.label6.Text = "相机通道";
		this.comboBox6.Font = new System.Drawing.Font("微软雅黑", 15f);
		this.comboBox6.FormattingEnabled = true;
		this.comboBox6.Items.AddRange(new object[7] { "KF", "FK", "DH-2竖屏", "DH-4横屏", "HK-2", "HK-4", "空" });
		this.comboBox6.Location = new System.Drawing.Point(503, 258);
		this.comboBox6.Name = "comboBox6";
		this.comboBox6.Size = new System.Drawing.Size(248, 35);
		this.comboBox6.TabIndex = 56;
		this.label7.AutoSize = true;
		this.label7.BackColor = System.Drawing.Color.Transparent;
		this.label7.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label7.Location = new System.Drawing.Point(405, 261);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(92, 27);
		this.label7.TabIndex = 55;
		this.label7.Text = "抓拍相机";
		this.label9.AutoSize = true;
		this.label9.BackColor = System.Drawing.Color.Transparent;
		this.label9.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label9.Location = new System.Drawing.Point(6, 320);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(112, 27);
		this.label9.TabIndex = 61;
		this.label9.Text = "报警设备IP";
		this.textBox3.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox3.Location = new System.Drawing.Point(123, 317);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(248, 34);
		this.textBox3.TabIndex = 62;
		this.comboBox7.Font = new System.Drawing.Font("微软雅黑", 15f);
		this.comboBox7.FormattingEnabled = true;
		this.comboBox7.Items.AddRange(new object[7] { "KF", "FK", "DH-2竖屏", "DH-4横屏", "HK-2", "HK-4", "空" });
		this.comboBox7.Location = new System.Drawing.Point(503, 312);
		this.comboBox7.Name = "comboBox7";
		this.comboBox7.Size = new System.Drawing.Size(248, 35);
		this.comboBox7.TabIndex = 68;
		this.label10.AutoSize = true;
		this.label10.BackColor = System.Drawing.Color.Transparent;
		this.label10.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label10.Location = new System.Drawing.Point(405, 315);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(90, 27);
		this.label10.TabIndex = 67;
		this.label10.Text = "大屏LED";
		this.textBox4.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox4.Location = new System.Drawing.Point(123, 367);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(248, 34);
		this.textBox4.TabIndex = 74;
		this.label11.AutoSize = true;
		this.label11.BackColor = System.Drawing.Color.Transparent;
		this.label11.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label11.Location = new System.Drawing.Point(12, 370);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(95, 27);
		this.label11.TabIndex = 73;
		this.label11.Text = "IO硬件IP";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(784, 413);
		base.Controls.Add(this.textBox4);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.comboBox7);
		base.Controls.Add(this.textBox3);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.comboBox6);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.comboBox5);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.comboBox4);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.comboBox3);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.comboBox2);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.comboBox1);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "CameraSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "相机设置";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
