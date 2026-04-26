// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.LargeScreenForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class LargeScreenForm : Form
{
	private IContainer components;

	private BarManager barManager1;

	private Bar bar2;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControl1;

	private DataGridView dataGridView1;

	private Label labelEmpty;

	public LargeScreenForm()
	{
		InitializeComponent();
		base.Load += LargeScreenForm_Load;
	}

	private void LargeScreenForm_Load(object sender, EventArgs e)
	{
		InitData();
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		LargeScreenSetForm largeScreenSetForm = new LargeScreenSetForm();
		largeScreenSetForm.ShowDialog();
		if (largeScreenSetForm.isSave)
		{
			InitData();
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (int.Parse(dataGridView1.Rows.Count.ToString()) == 0)
		{
			MessageBox.Show("请选择一行数据！");
			return;
		}
		int num = int.Parse(dataGridView1.CurrentRow.Index.ToString());
		if (num >= 0)
		{
			int id = Convert.ToInt32(dataGridView1.Rows[num].Cells["id"].Value);
			LargeScreenSetForm largeScreenSetForm = new LargeScreenSetForm();
			largeScreenSetForm.type = 1;
			largeScreenSetForm.id = id;
			largeScreenSetForm.ShowDialog();
			InitData();
		}
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (int.Parse(dataGridView1.Rows.Count.ToString()) == 0)
		{
			MessageBox.Show("请选择一行数据！");
			return;
		}
		int num = int.Parse(dataGridView1.CurrentRow.Index.ToString());
		if (num < 0)
		{
			return;
		}
		int id = Convert.ToInt32(dataGridView1.Rows[num].Cells["id"].Value);
		if (MessageBox.Show("确认删除该大屏配置？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			if (new DataServerContext<tb_large_screen>().Current.Delete((tb_large_screen it) => it.id == id))
			{
				MessageBox.Show("删除成功！");
				InitData();
			}
			else
			{
				MessageBox.Show("删除失败！");
				InitData();
			}
		}
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	public void InitData()
	{
		List<tb_large_screen> list = new DataServerContext<tb_large_screen>().Current.GetList();
		if (list != null)
		{
			dataGridView1.DataSource = list;
			dataGridView1.Columns["IP"].HeaderText = "IP地址";
			dataGridView1.Columns["largeName"].HeaderText = "大屏名称";
			dataGridView1.Columns["largeWidth"].HeaderText = "大屏宽度";
			dataGridView1.Columns["largeHeight"].HeaderText = "大屏高度";
			dataGridView1.Columns["id"].Visible = false;
			labelEmpty.Visible = list.Count == 0;
		}
		else
		{
			labelEmpty.Visible = true;
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
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[4] { this.barButtonItem1, this.barButtonItem2, this.barButtonItem3, this.barButtonItem4 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 99;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[4]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.bar2.OptionsBar.MultiLine = true;
		this.bar2.OptionsBar.UseWholeRow = true;
		this.bar2.Text = "Main menu";
		this.barButtonItem1.Caption = "新增";
		this.barButtonItem1.Id = 94;
		this.barButtonItem1.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.ide_32x32;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "修改";
		this.barButtonItem2.Id = 96;
		this.barButtonItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.convert_32x321;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "删除";
		this.barButtonItem3.Id = 97;
		this.barButtonItem3.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.remove_32x32;
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
		this.barDockControlTop.Size = new System.Drawing.Size(904, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 559);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(904, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 519);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(904, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 519);
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dataGridView1.Location = new System.Drawing.Point(0, 40);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowTemplate.Height = 26;
		this.dataGridView1.Size = new System.Drawing.Size(904, 519);
		this.dataGridView1.TabIndex = 10;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(904, 559);
		this.labelEmpty = new System.Windows.Forms.Label();
		this.labelEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
		this.labelEmpty.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.labelEmpty.ForeColor = System.Drawing.Color.Gray;
		this.labelEmpty.Location = new System.Drawing.Point(0, 40);
		this.labelEmpty.Name = "labelEmpty";
		this.labelEmpty.Size = new System.Drawing.Size(904, 519);
		this.labelEmpty.TabIndex = 11;
		this.labelEmpty.Text = "暂无数据，请先新增记录";
		this.labelEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.labelEmpty.Visible = false;
		base.Controls.Add(this.labelEmpty);
		base.Controls.Add(this.dataGridView1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "LargeScreenForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "大屏管理";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
