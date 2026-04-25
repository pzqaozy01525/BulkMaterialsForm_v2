// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.ChannelSetForm

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using BulkMaterialsForm.Views;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class ChannelSetForm : Form
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

	private TextBox textBox1;

	private Label label1;

	private Label label8;

	private ComboBox comboBox1;

	private TextBox textBox2;

	private Label label2;

	private BarButtonItem barButtonItem1;

	public ChannelSetForm()
	{
		InitializeComponent();
		base.Load += ChannelSetForm_Load;
	}

	private void ChannelSetForm_Load(object sender, EventArgs e)
	{
		if (type == 1)
		{
			tb_Channel tb_Channel2 = new DataServerContext<tb_Channel>().Current.GetList((tb_Channel it) => it.id == id).FirstOrDefault();
			if (tb_Channel2 != null)
			{
				comboBox1.SelectedItem = tb_Channel2.ChannelType;
				textBox1.Text = tb_Channel2.ChannelName;
				textBox2.Text = tb_Channel2.ChannelPort;
			}
		}
		else
		{
			comboBox1.SelectedItem = "入口";
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (comboBox1.SelectedItem == null)
		{
			MessageBox.Show("通道标识不能为空");
			return;
		}
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("通道名称不能为空");
			return;
		}
		DataServerContext<tb_Channel> dataServerContext = new DataServerContext<tb_Channel>();
		if (type == 1)
		{
			if (dataServerContext.Current.Modify((tb_Channel p) => new tb_Channel
			{
				ChannelName = textBox1.Text,
				ChannelPort = textBox2.Text,
				ChannelType = comboBox1.SelectedItem.ToString()
			}, (tb_Channel p) => p.id == id))
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
		tb_Channel tb_Channel2 = new tb_Channel();
		tb_Channel2.ChannelName = textBox1.Text;
		tb_Channel2.ChannelType = comboBox1.SelectedItem.ToString();
		tb_Channel2.ChannelPort = textBox2.Text;
		tb_Channel2.guid = Guid.NewGuid().ToString("N");
		if (dataServerContext.Current.AddReturnIdentity(tb_Channel2) > 0)
		{
			MessageBox.Show("新增成功");
			Close();
		}
		else
		{
			MessageBox.Show("新增失败");
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

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (id == 0)
		{
			MessageBox.Show("请先保存通道");
			return;
		}
		ConfirmPassForm confirmPassForm = new ConfirmPassForm();
		confirmPassForm.ShowDialog();
		if (confirmPassForm.isSvae)
		{
			ChannelSeniorSetForm channelSeniorSetForm = new ChannelSeniorSetForm();
			channelSeniorSetForm.id = id;
			channelSeniorSetForm.ShowDialog();
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
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.bar2 = new DevExpress.XtraBars.Bar();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.label8 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[4] { this.barButtonItem2, this.barButtonItem3, this.barButtonItem4, this.barButtonItem1 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 100;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[4]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
		this.barButtonItem1.Caption = "高级设置";
		this.barButtonItem1.Id = 99;
		this.barButtonItem1.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.properties_32x32;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
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
		this.barDockControlTop.Size = new System.Drawing.Size(545, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 316);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(545, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 276);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(545, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 276);
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(47, 80);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(84, 17);
		this.label8.TabIndex = 33;
		this.label8.Text = "通道名称 *";
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Location = new System.Drawing.Point(145, 77);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(310, 22);
		this.textBox1.TabIndex = 36;
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(47, 236);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(84, 17);
		this.label1.TabIndex = 35;
		this.label1.Text = "进出标识 *";
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[2] { "出口", "入口" });
		this.comboBox1.Location = new System.Drawing.Point(145, 233);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(310, 22);
		this.comboBox1.TabIndex = 37;
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(145, 153);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(310, 22);
		this.textBox2.TabIndex = 43;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(47, 156);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(68, 17);
		this.label2.TabIndex = 42;
		this.label2.Text = "API端口";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(545, 316);
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
		base.Name = "ChannelSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "通道设置";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
