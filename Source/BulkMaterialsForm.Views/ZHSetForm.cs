// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Views
// Type: BulkMaterialsForm.Views.ZHSetForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using BulkMaterialsForm.View;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.Views;

public class ZHSetForm : Form
{
	public bool isSave;

	public int id;

	public int type;

	public tb_large_screen_detaile ledDetaile;

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

	private Label label1;

	private Label label2;

	private TextBox textBox2;

	private Button button1;

	private Label label3;

	private ComboBox comboBox1;

	public ZHSetForm()
	{
		InitializeComponent();
		base.Load += ZHSetForm_Load;
	}

	private void ZHSetForm_Load(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		list.Add("红色");
		list.Add("绿色");
		list.Add("黄色");
		list.Add("蓝色");
		list.Add("紫色");
		list.Add("青色");
		list.Add("白色");
		comboBox1.DataSource = list;
		if (ledDetaile != null)
		{
			textBox1.Text = ledDetaile.charId;
			textBox2.Text = ledDetaile.customText;
			comboBox1.SelectedItem = ledDetaile.fontColor;
		}
		else
		{
			comboBox1.SelectedIndex = 0;
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("字符id不能为空");
		}
		else if (type == 0)
		{
			tb_large_screen_detaile tb_large_screen_detaile2 = new tb_large_screen_detaile();
			tb_large_screen_detaile2.charId = textBox1.Text;
			tb_large_screen_detaile2.customText = textBox2.Text;
			tb_large_screen_detaile2.x = 0;
			tb_large_screen_detaile2.y = 0;
			tb_large_screen_detaile2.Width = 0;
			tb_large_screen_detaile2.Height = 0;
			tb_large_screen_detaile2.xstx = "";
			tb_large_screen_detaile2.yxsd = 0;
			tb_large_screen_detaile2.tlsj = 0;
			tb_large_screen_detaile2.largeId = id;
			tb_large_screen_detaile2.fontColor = comboBox1.SelectedItem.ToString();
			if (new DataServerContext<tb_large_screen_detaile>().Current.Add(tb_large_screen_detaile2))
			{
				isSave = true;
				MessageBox.Show("保存成功");
				Close();
			}
			else
			{
				MessageBox.Show("保存失败");
			}
		}
		else
		{
			ledDetaile.charId = textBox1.Text;
			ledDetaile.customText = textBox2.Text;
			ledDetaile.fontColor = comboBox1.SelectedItem.ToString();
			if (new DataServerContext<tb_large_screen_detaile>().Current.Modify(ledDetaile))
			{
				isSave = true;
				MessageBox.Show("保存成功");
				Close();
			}
			else
			{
				MessageBox.Show("保存失败");
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

	private void button1_Click(object sender, EventArgs e)
	{
		ValueForm valueForm = new ValueForm();
		valueForm.ShowDialog();
		if (valueForm.isSave)
		{
			textBox2.Text += valueForm.text;
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkMaterialsForm.Views.ZHSetForm));
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
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
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
		this.barManager1.MaxItemId = 100;
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
		this.barButtonItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.apply_32x32;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "取消";
		this.barButtonItem3.Id = 97;
		this.barButtonItem3.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.left_32x32;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem4.Caption = "关闭";
		this.barButtonItem4.Id = 98;
		this.barButtonItem4.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.cancel_32x321;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(574, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 271);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(574, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 231);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(574, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 231);
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Location = new System.Drawing.Point(110, 89);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(288, 29);
		this.textBox1.TabIndex = 59;
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(36, 92);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(59, 21);
		this.label8.TabIndex = 58;
		this.label8.Text = "字符ID";
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.label1.ForeColor = System.Drawing.Color.Red;
		this.label1.Location = new System.Drawing.Point(404, 92);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(124, 21);
		this.label1.TabIndex = 75;
		this.label1.Text = "范围值0~65535";
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(12, 149);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(90, 21);
		this.label2.TabIndex = 80;
		this.label2.Text = "自定义内容";
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(110, 146);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(288, 29);
		this.textBox2.TabIndex = 81;
		this.button1.Location = new System.Drawing.Point(409, 148);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(88, 28);
		this.button1.TabIndex = 82;
		this.button1.Text = "插入字段";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.Location = new System.Drawing.Point(21, 205);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(74, 21);
		this.label3.TabIndex = 87;
		this.label3.Text = "字体颜色";
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Location = new System.Drawing.Point(110, 205);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(288, 29);
		this.comboBox1.TabIndex = 88;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(574, 271);
		base.Controls.Add(this.comboBox1);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "ZHSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "大屏设置";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
