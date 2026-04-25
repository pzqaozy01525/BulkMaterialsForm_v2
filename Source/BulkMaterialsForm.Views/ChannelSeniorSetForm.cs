// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Views
// Type: BulkMaterialsForm.Views.ChannelSeniorSetForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.Views;

public class ChannelSeniorSetForm : Form
{
	public tb_ChannelSeniorSet tb_ChannelSeniorSet;

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

	private CheckBox checkBox1;

	private GroupBox groupBox1;

	private CheckBox checkBox2;

	private CheckBox checkBox3;

	private CheckBox checkBox4;

	private CheckBox checkBox6;

	private CheckBox checkBox5;

	private GroupBox groupBox2;

	private CheckBox checkBox7;

	private CheckBox checkBox8;

	private CheckBox checkBox9;

	private CheckBox checkBox10;

	private CheckBox checkBox11;

	private CheckBox checkBox13;

	private CheckBox checkBox12;

	public ChannelSeniorSetForm()
	{
		InitializeComponent();
		base.Load += ChannelSeniorSetForm_Load;
	}

	private void ChannelSeniorSetForm_Load(object sender, EventArgs e)
	{
		DataServerContext<tb_ChannelSeniorSet> dataServerContext = new DataServerContext<tb_ChannelSeniorSet>();
		tb_ChannelSeniorSet = dataServerContext.Current.GetModel((tb_ChannelSeniorSet it) => it.ChannelId == id);
		if (tb_ChannelSeniorSet == null)
		{
			return;
		}
		string[] array = tb_ChannelSeniorSet.transitColour.Split(',');
		if (array != null)
		{
			string[] array2 = array;
			for (int num = 0; num < array2.Length; num++)
			{
				switch (array2[num])
				{
				case "蓝色":
					checkBox2.Checked = true;
					break;
				case "绿色":
					checkBox3.Checked = true;
					break;
				case "黄色":
					checkBox4.Checked = true;
					break;
				case "白色":
					checkBox5.Checked = true;
					break;
				case "黑色":
					checkBox6.Checked = true;
					break;
				case "黄绿色":
					checkBox12.Checked = true;
					break;
				}
			}
		}
		string[] array3 = tb_ChannelSeniorSet.ColourWhiteList.Split(',');
		if (array3 != null)
		{
			string[] array4 = array3;
			for (int num2 = 0; num2 < array4.Length; num2++)
			{
				switch (array4[num2])
				{
				case "蓝色":
					checkBox11.Checked = true;
					break;
				case "绿色":
					checkBox10.Checked = true;
					break;
				case "黄色":
					checkBox9.Checked = true;
					break;
				case "白色":
					checkBox8.Checked = true;
					break;
				case "黑色":
					checkBox7.Checked = true;
					break;
				case "黄绿色":
					checkBox13.Checked = true;
					break;
				}
			}
		}
		checkBox1.Checked = tb_ChannelSeniorSet.platformOpen;
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		List<string> list = new List<string>();
		if (checkBox2.Checked)
		{
			list.Add("蓝色");
		}
		if (checkBox3.Checked)
		{
			list.Add("绿色");
		}
		if (checkBox4.Checked)
		{
			list.Add("黄色");
		}
		if (checkBox5.Checked)
		{
			list.Add("白色");
		}
		if (checkBox6.Checked)
		{
			list.Add("黑色");
		}
		if (checkBox12.Checked)
		{
			list.Add("黄绿色");
		}
		List<string> list2 = new List<string>();
		if (checkBox11.Checked)
		{
			list2.Add("蓝色");
		}
		if (checkBox10.Checked)
		{
			list2.Add("绿色");
		}
		if (checkBox9.Checked)
		{
			list2.Add("黄色");
		}
		if (checkBox8.Checked)
		{
			list2.Add("白色");
		}
		if (checkBox7.Checked)
		{
			list2.Add("黑色");
		}
		if (checkBox13.Checked)
		{
			list2.Add("黄绿色");
		}
		if (tb_ChannelSeniorSet == null)
		{
			tb_ChannelSeniorSet = new tb_ChannelSeniorSet();
			tb_ChannelSeniorSet.ChannelId = id;
			tb_ChannelSeniorSet.platformOpen = checkBox1.Checked;
			tb_ChannelSeniorSet.ColourWhiteList = string.Join(",", list2);
			tb_ChannelSeniorSet.transitColour = string.Join(",", list);
			if (new DataServerContext<tb_ChannelSeniorSet>().Current.Add(tb_ChannelSeniorSet))
			{
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
			tb_ChannelSeniorSet.platformOpen = checkBox1.Checked;
			tb_ChannelSeniorSet.ColourWhiteList = string.Join(",", list2);
			tb_ChannelSeniorSet.transitColour = string.Join(",", list);
			if (new DataServerContext<tb_ChannelSeniorSet>().Current.Modify(tb_ChannelSeniorSet))
			{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkMaterialsForm.Views.ChannelSeniorSetForm));
		this.barManager1 = new DevExpress.XtraBars.BarManager();
		this.bar2 = new DevExpress.XtraBars.Bar();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.checkBox6 = new System.Windows.Forms.CheckBox();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.checkBox4 = new System.Windows.Forms.CheckBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.checkBox7 = new System.Windows.Forms.CheckBox();
		this.checkBox8 = new System.Windows.Forms.CheckBox();
		this.checkBox9 = new System.Windows.Forms.CheckBox();
		this.checkBox10 = new System.Windows.Forms.CheckBox();
		this.checkBox11 = new System.Windows.Forms.CheckBox();
		this.checkBox12 = new System.Windows.Forms.CheckBox();
		this.checkBox13 = new System.Windows.Forms.CheckBox();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
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
		this.barButtonItem3.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.backward_32x32;
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
		this.barDockControlTop.Size = new System.Drawing.Size(480, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 441);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(480, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 401);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(480, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 401);
		this.checkBox1.AutoSize = true;
		this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox1.Location = new System.Drawing.Point(42, 71);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(221, 25);
		this.checkBox1.TabIndex = 4;
		this.checkBox1.Text = "电脑弹窗二次确认开闸放行";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.groupBox1.Controls.Add(this.checkBox12);
		this.groupBox1.Controls.Add(this.checkBox6);
		this.groupBox1.Controls.Add(this.checkBox5);
		this.groupBox1.Controls.Add(this.checkBox4);
		this.groupBox1.Controls.Add(this.checkBox3);
		this.groupBox1.Controls.Add(this.checkBox2);
		this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.groupBox1.Location = new System.Drawing.Point(42, 122);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(367, 136);
		this.groupBox1.TabIndex = 5;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "允许通行车牌颜色管理";
		this.checkBox6.AutoSize = true;
		this.checkBox6.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox6.Location = new System.Drawing.Point(89, 85);
		this.checkBox6.Name = "checkBox6";
		this.checkBox6.Size = new System.Drawing.Size(61, 25);
		this.checkBox6.TabIndex = 10;
		this.checkBox6.Text = "黑色";
		this.checkBox6.UseVisualStyleBackColor = true;
		this.checkBox5.AutoSize = true;
		this.checkBox5.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox5.Location = new System.Drawing.Point(6, 85);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(61, 25);
		this.checkBox5.TabIndex = 9;
		this.checkBox5.Text = "白色";
		this.checkBox5.UseVisualStyleBackColor = true;
		this.checkBox4.AutoSize = true;
		this.checkBox4.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox4.Location = new System.Drawing.Point(178, 39);
		this.checkBox4.Name = "checkBox4";
		this.checkBox4.Size = new System.Drawing.Size(61, 25);
		this.checkBox4.TabIndex = 8;
		this.checkBox4.Text = "黄色";
		this.checkBox4.UseVisualStyleBackColor = true;
		this.checkBox3.AutoSize = true;
		this.checkBox3.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox3.Location = new System.Drawing.Point(89, 39);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(61, 25);
		this.checkBox3.TabIndex = 7;
		this.checkBox3.Text = "绿色";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox2.AutoSize = true;
		this.checkBox2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox2.Location = new System.Drawing.Point(6, 39);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(61, 25);
		this.checkBox2.TabIndex = 6;
		this.checkBox2.Text = "蓝色";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.groupBox2.Controls.Add(this.checkBox13);
		this.groupBox2.Controls.Add(this.checkBox7);
		this.groupBox2.Controls.Add(this.checkBox8);
		this.groupBox2.Controls.Add(this.checkBox9);
		this.groupBox2.Controls.Add(this.checkBox10);
		this.groupBox2.Controls.Add(this.checkBox11);
		this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.groupBox2.Location = new System.Drawing.Point(48, 279);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(361, 136);
		this.groupBox2.TabIndex = 11;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "车牌颜色验证白名单管理";
		this.checkBox7.AutoSize = true;
		this.checkBox7.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox7.Location = new System.Drawing.Point(89, 85);
		this.checkBox7.Name = "checkBox7";
		this.checkBox7.Size = new System.Drawing.Size(61, 25);
		this.checkBox7.TabIndex = 10;
		this.checkBox7.Text = "黑色";
		this.checkBox7.UseVisualStyleBackColor = true;
		this.checkBox8.AutoSize = true;
		this.checkBox8.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox8.Location = new System.Drawing.Point(6, 85);
		this.checkBox8.Name = "checkBox8";
		this.checkBox8.Size = new System.Drawing.Size(61, 25);
		this.checkBox8.TabIndex = 9;
		this.checkBox8.Text = "白色";
		this.checkBox8.UseVisualStyleBackColor = true;
		this.checkBox9.AutoSize = true;
		this.checkBox9.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox9.Location = new System.Drawing.Point(178, 39);
		this.checkBox9.Name = "checkBox9";
		this.checkBox9.Size = new System.Drawing.Size(61, 25);
		this.checkBox9.TabIndex = 8;
		this.checkBox9.Text = "黄色";
		this.checkBox9.UseVisualStyleBackColor = true;
		this.checkBox10.AutoSize = true;
		this.checkBox10.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox10.Location = new System.Drawing.Point(89, 39);
		this.checkBox10.Name = "checkBox10";
		this.checkBox10.Size = new System.Drawing.Size(61, 25);
		this.checkBox10.TabIndex = 7;
		this.checkBox10.Text = "绿色";
		this.checkBox10.UseVisualStyleBackColor = true;
		this.checkBox11.AutoSize = true;
		this.checkBox11.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox11.Location = new System.Drawing.Point(6, 39);
		this.checkBox11.Name = "checkBox11";
		this.checkBox11.Size = new System.Drawing.Size(61, 25);
		this.checkBox11.TabIndex = 6;
		this.checkBox11.Text = "蓝色";
		this.checkBox11.UseVisualStyleBackColor = true;
		this.checkBox12.AutoSize = true;
		this.checkBox12.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox12.Location = new System.Drawing.Point(178, 85);
		this.checkBox12.Name = "checkBox12";
		this.checkBox12.Size = new System.Drawing.Size(77, 25);
		this.checkBox12.TabIndex = 11;
		this.checkBox12.Text = "黄绿色";
		this.checkBox12.UseVisualStyleBackColor = true;
		this.checkBox13.AutoSize = true;
		this.checkBox13.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox13.Location = new System.Drawing.Point(178, 85);
		this.checkBox13.Name = "checkBox13";
		this.checkBox13.Size = new System.Drawing.Size(77, 25);
		this.checkBox13.TabIndex = 12;
		this.checkBox13.Text = "黄绿色";
		this.checkBox13.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(480, 441);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.checkBox1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "ChannelSeniorSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "通道设置";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
