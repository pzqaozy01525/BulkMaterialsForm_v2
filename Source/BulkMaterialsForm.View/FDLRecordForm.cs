// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.FDLRecordForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BST.Ticket;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;
using SqlSugar;

namespace BulkMaterialsForm.View;

public class FDLRecordForm : Form
{
	private IContainer components;

	private BarManager barManager1;

	private Bar bar2;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem4;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControl1;

	private TableLayoutPanel tableLayoutPanel1;

	private DataGridView dataGridView1;

	private DataGridViewCheckBoxColumn Column1;

	private TableLayoutPanel tableLayoutPanel2;

	private DateTimePicker dateEnd;

	private Label label2;

	private Label label4;

	private TextBox textBox1;

	private Label label1;

	private Label label3;

	private DateTimePicker dateStart;

	private ComboBox comboBox1;

	private Pager pager1;

	private BindingNavigator bindingNavigator;

	public FDLRecordForm()
	{
		InitializeComponent();
		base.Load += FDLRecordForm_Load;
	}

	private void FDLRecordForm_Load(object sender, EventArgs e)
	{
		comboBox1.SelectedItem = "全部";
		pager1.PageCurrent = 1;
		pager1.Bind();
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		new FDLRecordSetForm().ShowDialog();
		pager1.Bind();
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
		if (MessageBox.Show("确认删除该非道路移动机械通行记录？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			if (new DataServerContext<tb_nonRoadRecord>().Current.Delete((tb_nonRoadRecord it) => it.id == id))
			{
				MessageBox.Show("删除成功！");
				pager1.Bind();
			}
			else
			{
				MessageBox.Show("删除失败！");
				pager1.Bind();
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
		saveFileDialog.Title = "导出非道路移动机械进出记录";
		saveFileDialog.FileName = "非道路移动机械进出记录_" + DateTime.Now.ToString("yyyyMMddHHmmss");
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			string filePath = saveFileDialog.FileName;
			Thread thread = new Thread((ThreadStart)delegate
			{
				ExportCurrentPageAsync(filePath);
			});
			thread.IsBackground = true;
			thread.Start();
		}
	}

	private void ExportCurrentPageAsync(string filePath)
	{
		try
		{
			List<DataGridViewRow> list = dataGridView1.Rows.Cast<DataGridViewRow>().ToList();
			if (list.Count == 0)
			{
				ShowMessage("无数据可导出");
				return;
			}
			Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
			using (StreamWriter streamWriter = new StreamWriter(filePath, append: false, encoding))
			{
				List<string> values = (from DataGridViewColumn c in dataGridView1.Columns
					select c.HeaderText ?? "").ToList();
				streamWriter.WriteLine(string.Join("\t", values));
				foreach (DataGridViewRow row in list)
				{
					List<string> values2 = (from i in Enumerable.Range(0, dataGridView1.ColumnCount)
						select row.Cells[i].Value?.ToString() ?? "" into v
						select v.Replace("\t", " ").Replace("\r", "").Replace("\n", " ")).ToList();
					streamWriter.WriteLine(string.Join("\t", values2));
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
		if (base.InvokeRequired)
		{
			Invoke((Action)delegate
			{
				MessageBox.Show(msg);
			});
		}
		else
		{
			MessageBox.Show(msg);
		}
	}

	private int BindDGV()
	{
		DataServerContext<NonRoadRecord> dataServerContext = new DataServerContext<NonRoadRecord>();
		List<IConditionalModel> list = new List<IConditionalModel>();
		if (!string.IsNullOrWhiteSpace(textBox1.Text))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "car_no",
				ConditionalType = ConditionalType.Like,
				FieldValue = textBox1.Text
			});
		}
		if (!string.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()) && !comboBox1.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "outType",
				ConditionalType = ConditionalType.Equal,
				FieldValue = comboBox1.SelectedItem.ToString()
			});
		}
		list.Add(new ConditionalModel
		{
			FieldName = "addtime",
			ConditionalType = ConditionalType.GreaterThanOrEqual,
			FieldValue = dateStart.Value.Date.ToString()
		});
		list.Add(new ConditionalModel
		{
			FieldName = "addtime",
			ConditionalType = ConditionalType.LessThanOrEqual,
			FieldValue = dateEnd.Value.AddDays(1.0).Date.AddSeconds(-1.0).ToString()
		});
		int totalNumber = 0;
		PageModel pageModel = new PageModel
		{
			PageIndex = pager1.PageCurrent,
			PageSize = pager1.PageSize
		};
		List<NonRoadRecord> list2 = dataServerContext.Current.DbContext().Queryable((tb_nonRoadRecord a, tb_nonRoad b) => new object[2]
		{
			JoinType.Left,
			a.nonRoadId == b.id
		}).Where(list)
			.Select((tb_nonRoadRecord a, tb_nonRoad b) => new NonRoadRecord
			{
				hbdjh = b.hbdjh,
				jxscrq = b.jxscrq,
				car_no = b.car_no,
				pfjd = b.pfjd,
				ryxl = b.ryxl,
				jxzl = b.jxzl,
				pin = b.pin,
				jxxh = b.jxxh,
				fdjxh = b.fdjxh,
				fdjcs = b.fdjcs,
				fdjbh = b.fdjbh,
				shr = b.shr,
				addtime = a.addtime,
				outType = a.outType,
				id = a.id
			})
			.MergeTable()
			.ToPageList(pageModel.PageIndex, pageModel.PageSize, ref totalNumber)
			.ToList();
		if (list2 != null)
		{
			dataGridView1.DataSource = list2;
			dataGridView1.Columns["hbdjh"].HeaderText = "环保登记号";
			dataGridView1.Columns["jxscrq"].HeaderText = "机械生产日期";
			dataGridView1.Columns["car_no"].HeaderText = "车牌编号";
			dataGridView1.Columns["pfjd"].HeaderText = "排放阶段";
			dataGridView1.Columns["ryxl"].HeaderText = "燃油类型";
			dataGridView1.Columns["jxzl"].HeaderText = "机械种类";
			dataGridView1.Columns["pin"].HeaderText = "pin";
			dataGridView1.Columns["jxxh"].HeaderText = "机械型号";
			dataGridView1.Columns["fdjxh"].HeaderText = "发动机型号";
			dataGridView1.Columns["fdjcs"].HeaderText = "发动机厂商";
			dataGridView1.Columns["fdjbh"].HeaderText = "发动机编号";
			dataGridView1.Columns["shr"].HeaderText = "所属人";
			dataGridView1.Columns["addtime"].HeaderText = "进出时间";
			dataGridView1.Columns["outType"].HeaderText = "进出类型";
			dataGridView1.Columns["id"].Visible = false;
			pager1.bindingSource.DataSource = list2;
			pager1.bindingNavigator.BindingSource = pager1.bindingSource;
			return totalNumber;
		}
		return 0;
	}

	private int pager1_EventPaging(EventPagingArg e)
	{
		return BindDGV();
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
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.dateEnd = new System.Windows.Forms.DateTimePicker();
		this.label2 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.dateStart = new System.Windows.Forms.DateTimePicker();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.pager1 = new BST.Ticket.Pager();
		this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		this.tableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		this.tableLayoutPanel2.SuspendLayout();
		this.pager1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.bindingNavigator).BeginInit();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[4] { this.barButtonItem1, this.barButtonItem3, this.barButtonItem4, this.barButtonItem5 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 101;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[4]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
		this.barDockControlTop.Size = new System.Drawing.Size(1386, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 674);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(1386, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 634);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(1386, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 634);
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.pager1, 0, 2);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 3;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(1386, 634);
		this.tableLayoutPanel1.TabIndex = 5;
		this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Columns.AddRange(this.Column1);
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dataGridView1.Location = new System.Drawing.Point(3, 98);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowTemplate.Height = 26;
		this.dataGridView1.Size = new System.Drawing.Size(1380, 501);
		this.dataGridView1.TabIndex = 1;
		this.Column1.HeaderText = "";
		this.Column1.Name = "Column1";
		this.Column1.ReadOnly = true;
		this.tableLayoutPanel2.ColumnCount = 7;
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel2.Controls.Add(this.dateEnd, 3, 1);
		this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
		this.tableLayoutPanel2.Controls.Add(this.label4, 2, 1);
		this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
		this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
		this.tableLayoutPanel2.Controls.Add(this.dateStart, 1, 1);
		this.tableLayoutPanel2.Controls.Add(this.comboBox1, 3, 0);
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 2;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(1380, 89);
		this.tableLayoutPanel2.TabIndex = 2;
		this.dateEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dateEnd.CalendarFont = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.dateEnd.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.dateEnd.Location = new System.Drawing.Point(588, 49);
		this.dateEnd.Name = "dateEnd";
		this.dateEnd.Size = new System.Drawing.Size(203, 34);
		this.dateEnd.TabIndex = 45;
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.ForeColor = System.Drawing.Color.Black;
		this.label2.Location = new System.Drawing.Point(61, 11);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(74, 21);
		this.label2.TabIndex = 39;
		this.label2.Text = "车牌号：";
		this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(459, 56);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(90, 21);
		this.label4.TabIndex = 44;
		this.label4.Text = "结束时间：";
		this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Location = new System.Drawing.Point(174, 5);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(203, 34);
		this.textBox1.TabIndex = 38;
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.ForeColor = System.Drawing.Color.Black;
		this.label1.Location = new System.Drawing.Point(459, 11);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(90, 21);
		this.label1.TabIndex = 41;
		this.label1.Text = "进出类型：";
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(45, 56);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(90, 21);
		this.label3.TabIndex = 42;
		this.label3.Text = "开始时间：";
		this.dateStart.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dateStart.CalendarFont = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.dateStart.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.dateStart.Location = new System.Drawing.Point(174, 49);
		this.dateStart.Name = "dateStart";
		this.dateStart.Size = new System.Drawing.Size(203, 34);
		this.dateStart.TabIndex = 43;
		this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 15f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[3] { "全部", "入口", "出口" });
		this.comboBox1.Location = new System.Drawing.Point(588, 4);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(203, 35);
		this.comboBox1.TabIndex = 46;
		this.pager1.Controls.Add(this.bindingNavigator);
		this.pager1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pager1.Location = new System.Drawing.Point(3, 605);
		this.pager1.Name = "pager1";
		this.pager1.NMax = 0;
		this.pager1.PageCount = 0;
		this.pager1.PageCurrent = 0;
		this.pager1.PageSize = 20;
		this.pager1.Size = new System.Drawing.Size(1380, 26);
		this.pager1.TabIndex = 3;
		this.pager1.EventPaging += new BST.Ticket.EventPagingHandler(pager1_EventPaging);
		this.bindingNavigator.AddNewItem = null;
		this.bindingNavigator.CountItem = null;
		this.bindingNavigator.DeleteItem = null;
		this.bindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
		this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
		this.bindingNavigator.MoveFirstItem = null;
		this.bindingNavigator.MoveLastItem = null;
		this.bindingNavigator.MoveNextItem = null;
		this.bindingNavigator.MovePreviousItem = null;
		this.bindingNavigator.Name = "bindingNavigator";
		this.bindingNavigator.PositionItem = null;
		this.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		this.bindingNavigator.Size = new System.Drawing.Size(1380, 26);
		this.bindingNavigator.TabIndex = 0;
		this.bindingNavigator.Text = "bindingNavigator1";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1386, 674);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "FDLRecordForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "非道路移动机械记录";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.tableLayoutPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		this.pager1.ResumeLayout(false);
		this.pager1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.bindingNavigator).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
