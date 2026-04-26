// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.FDLYDJXForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class FDLYDJXForm : Form
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

	private BarButtonItem barButtonItem5;

	public FDLYDJXForm()
	{
		InitializeComponent();
		base.Load += FDLYDJXForm_Load;
	}

	private void FDLYDJXForm_Load(object sender, EventArgs e)
	{
		InitData();
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		new FDLYDJXSetForm().ShowDialog();
		InitData();
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
			FDLYDJXSetForm fDLYDJXSetForm = new FDLYDJXSetForm();
			fDLYDJXSetForm.type = 1;
			fDLYDJXSetForm.id = id;
			fDLYDJXSetForm.ShowDialog();
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
		if (MessageBox.Show("确认删除该非道路移动机械登记信息？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			if (new DataServerContext<tb_nonRoad>().Current.Delete((tb_nonRoad it) => it.id == id))
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

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (dataGridView1.Rows.Count == 0)
		{
			MessageBox.Show("请您检查是否有数据导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "制表符分隔文件 (*.txt)|*.txt|Excel 97-2003 (*.xls)|*.xls";
		saveFileDialog.FilterIndex = 1;
		saveFileDialog.RestoreDirectory = true;
		saveFileDialog.CreatePrompt = false;
		saveFileDialog.Title = "导出非道路移动机械信息";
		saveFileDialog.FileName = "非道路移动机械信息_" + DateTime.Now.ToString("yyyyMMddHHmmss");
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			string filePath = saveFileDialog.FileName;
			Thread thread = new Thread((ThreadStart)delegate
			{
				ExportAllAsync(filePath);
			});
			thread.IsBackground = true;
			thread.Start();
		}
	}

	private void ExportAllAsync(string filePath)
	{
		try
		{
			List<tb_nonRoad> list = new DataServerContext<tb_nonRoad>().Current.GetList();
			if (list == null || list.Count == 0)
			{
				ShowMessage("无数据可导出");
				return;
			}
			string[] value = new string[12]
			{
				"环保登记号", "机械生产日期", "车牌号", "排放阶段", "燃油类型", "机械种类", "品牌", "机械型号", "发动机型号", "发动机厂商",
				"发动机编号", "所属人"
			};
			Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
			using (StreamWriter streamWriter = new StreamWriter(filePath, append: false, encoding))
			{
				streamWriter.WriteLine(string.Join("\t", value));
				foreach (tb_nonRoad item in list)
				{
					string[] value2 = new string[12]
					{
						item.hbdjh ?? "",
						item.jxscrq.ToString("yyyy-MM-dd"),
						item.car_no ?? "",
						item.pfjd ?? "",
						item.ryxl ?? "",
						item.jxzl ?? "",
						item.pin ?? "",
						item.jxxh ?? "",
						item.fdjxh ?? "",
						item.fdjcs ?? "",
						item.fdjbh ?? "",
						item.shr ?? ""
					};
					streamWriter.WriteLine(string.Join("\t", value2));
				}
			}
			ShowMessage($"成功导出 {list.Count} 条记录到：\n{filePath}");
		}
		catch (Exception ex)
		{
			ShowMessage("导出失败：" + ex.Message);
		}
	}

	private void ShowMessage(string msg)
	{
		FormHelper.ShowMessage(this, msg);
	}

	public void InitData()
	{
		List<tb_nonRoad> list = new DataServerContext<tb_nonRoad>().Current.GetList();
		if (list != null)
		{
			dataGridView1.DataSource = list;
			dataGridView1.Columns["hbdjh"].HeaderText = "环保登记号";
			dataGridView1.Columns["jxscrq"].HeaderText = "机械生产日期";
			dataGridView1.Columns["car_no"].HeaderText = "车牌号";
			dataGridView1.Columns["pfjd"].HeaderText = "排放阶段";
			dataGridView1.Columns["ryxl"].HeaderText = "燃油类型";
			dataGridView1.Columns["jxzl"].HeaderText = "机械种类";
			dataGridView1.Columns["pin"].HeaderText = "pin";
			dataGridView1.Columns["jxxh"].HeaderText = "机械型号";
			dataGridView1.Columns["fdjxh"].HeaderText = "发动机型号";
			dataGridView1.Columns["fdjcs"].HeaderText = "发动机厂商";
			dataGridView1.Columns["fdjbh"].HeaderText = "发动机编号";
			dataGridView1.Columns["shr"].HeaderText = "所属人";
			dataGridView1.Columns["id"].Visible = false;
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
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
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
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[5] { this.barButtonItem1, this.barButtonItem2, this.barButtonItem3, this.barButtonItem4, this.barButtonItem5 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 101;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[5]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem5, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
		this.barButtonItem5.Caption = "导出";
		this.barButtonItem5.Id = 100;
		this.barButtonItem5.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.open2_32x322;
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.barButtonItem4.Caption = "关闭";
		this.barButtonItem4.Id = 98;
		this.barButtonItem4.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.cancel_32x32;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(1212, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 635);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(1212, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 595);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(1212, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 595);
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dataGridView1.Location = new System.Drawing.Point(0, 40);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowTemplate.Height = 26;
		this.dataGridView1.Size = new System.Drawing.Size(1212, 595);
		this.dataGridView1.TabIndex = 5;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1212, 635);
		base.Controls.Add(this.dataGridView1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "FDLYDJXForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "非道路移动机械登记";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
