// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.exeRecordForm

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
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;
using SqlSugar;

namespace BulkMaterialsForm.View;

public class exeRecordForm : Form
{
	private List<tb_exceptional> tb_Exceptionals;

	private IContainer components;

	private BarManager barManager1;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem7;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem6;

	private BarButtonItem barButtonItem8;

	private BarButtonItem barButtonItem4;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControl1;

	private BarDockControl barDockControlRight;

	private TableLayoutPanel tableLayoutPanel1;

	private DataGridView dataGridView1;

	private TableLayoutPanel tableLayoutPanel2;

	private DateTimePicker dateEnd;

	private Label label4;

	private Label label3;

	private DateTimePicker dateStart;

	private Pager pager1;

	private BindingNavigator bindingNavigator;

	private BarDockControl barDockControl4;

	private BarManager barManager2;

	private Bar bar1;

	private BarButtonItem barButtonItem10;

	private BarButtonItem barButtonItem13;

	private BarButtonItem barButtonItem15;

	private BarButtonItem barButtonItem16;

	private BarDockControl barDockControl2;

	private BarDockControl barDockControl3;

	private BarDockControl barDockControl5;

	private Bar bar2;

	public exeRecordForm()
	{
		InitializeComponent();
		base.Load += ExeRecordForm_Load;
	}

	private void ExeRecordForm_Load(object sender, EventArgs e)
	{
		pager1.PageCurrent = 1;
		pager1.Bind();
	}

	private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
	{
		pager1.PageCurrent = 1;
		pager1.Bind();
	}

	private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
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
		List<string> list = new List<string>();
		int id = Convert.ToInt32(dataGridView1.Rows[num].Cells["id"].Value);
		tb_exceptional tb_exceptional2 = tb_Exceptionals.FirstOrDefault((tb_exceptional it) => it.id == id);
		if (tb_exceptional2 != null)
		{
			if (tb_exceptional2.SnapImagePath1 != null && !string.IsNullOrWhiteSpace(tb_exceptional2.SnapImagePath1))
			{
				list.Add(tb_exceptional2.SnapImagePath1);
			}
			if (tb_exceptional2.SnapImagePath2 != null && !string.IsNullOrWhiteSpace(tb_exceptional2.SnapImagePath2))
			{
				list.Add(tb_exceptional2.SnapImagePath2);
			}
			if (tb_exceptional2.SnapImagePath3 != null && !string.IsNullOrWhiteSpace(tb_exceptional2.SnapImagePath3))
			{
				list.Add(tb_exceptional2.SnapImagePath3);
			}
			ImageView imageView = new ImageView();
			imageView.ListImage = list;
			imageView.ShowDialog();
		}
	}

	private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
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
		tb_exceptional tb_exceptional2 = tb_Exceptionals.FirstOrDefault((tb_exceptional it) => it.id == id);
		if (tb_exceptional2 == null)
		{
			return;
		}
		if (tb_exceptional2.SnapVideoPath != null && !string.IsNullOrWhiteSpace(tb_exceptional2.SnapVideoPath))
		{
			if (File.Exists(tb_exceptional2.SnapVideoPath))
			{
				videoPlayForm obj = new videoPlayForm();
				obj.path = tb_exceptional2.SnapVideoPath;
				obj.ShowDialog();
			}
			else
			{
				MessageBox.Show("视频不存在");
			}
		}
		else
		{
			MessageBox.Show("视频不存在");
		}
	}

	private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (dataGridView1.CurrentCell != null)
		{
			dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
		}
	}

	public int InitData()
	{
		DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
		List<IConditionalModel> list = new List<IConditionalModel>();
		ConditionalModel conditionalModel = new ConditionalModel();
		conditionalModel.FieldName = "add_time";
		conditionalModel.ConditionalType = ConditionalType.GreaterThanOrEqual;
		conditionalModel.FieldValue = dateStart.Value.Date.ToString();
		list.Add(conditionalModel);
		ConditionalModel conditionalModel2 = new ConditionalModel();
		conditionalModel2.FieldName = "add_time";
		conditionalModel2.ConditionalType = ConditionalType.LessThanOrEqual;
		conditionalModel2.FieldValue = dateEnd.Value.AddDays(1.0).Date.AddSeconds(-1.0).ToString();
		list.Add(conditionalModel2);
		try
		{
			PageModel pageModel = new PageModel();
			pageModel.PageIndex = pager1.PageCurrent;
			pageModel.PageSize = pager1.PageSize;
			tb_Exceptionals = dataServerContext.Current.GetPageList(list, pageModel, (tb_exceptional it) => it.add_time, OrderByType.Desc);
			if (tb_Exceptionals != null)
			{
				dataGridView1.DataSource = tb_Exceptionals;
				dataGridView1.Columns["add_time"].HeaderText = "警报时间";
				dataGridView1.Columns["gateName"].HeaderText = "设备名称";
				dataGridView1.Columns["ChannelType"].HeaderText = "进出方向";
				dataGridView1.Columns["car_no"].HeaderText = "车牌号";
				dataGridView1.Columns["OpeningType"].HeaderText = "操作类型";
				dataGridView1.Columns["SnapImagePath1"].HeaderText = "抓怕图片";
				dataGridView1.Columns["SnapImagePath2"].HeaderText = "抓怕图片";
				dataGridView1.Columns["SnapImagePath3"].HeaderText = "抓怕图片";
				dataGridView1.Columns["SnapVideoPath"].HeaderText = "抓拍视频";
				dataGridView1.Columns["id"].Visible = false;
				dataGridView1.Columns["CameraId"].Visible = false;
				dataGridView1.Columns["gateName"].Visible = false;
				dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				dataGridView1.Columns[0].FillWeight = 2f;
				dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				pager1.bindingSource.DataSource = tb_Exceptionals;
				pager1.bindingNavigator.BindingSource = pager1.bindingSource;
				return pageModel.TotalCount;
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("道闸记录查询异常: " + ex.Message);
		}
		return 0;
	}

	private int pager1_EventPaging(EventPagingArg e)
	{
		return InitData();
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
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
		saveFileDialog.Title = "导出异常记录（当前页）";
		saveFileDialog.FileName = "道闸抬杆记录_当前页_" + DateTime.Now.ToString("yyyyMMddHHmmss");
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

	private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "制表符分隔文件 (*.txt)|*.txt|Excel 97-2003 (*.xls)|*.xls";
		saveFileDialog.FilterIndex = 1;
		saveFileDialog.RestoreDirectory = true;
		saveFileDialog.CreatePrompt = false;
		saveFileDialog.Title = "导出全部异常记录";
		saveFileDialog.FileName = "道闸抬杆记录_全部_" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
					where c.Visible
					select c.HeaderText ?? "").ToList();
				streamWriter.WriteLine(string.Join("\t", values));
				foreach (DataGridViewRow row in list)
				{
					if (row.Visible)
					{
						List<string> values2 = (from i in Enumerable.Range(0, dataGridView1.ColumnCount)
							where dataGridView1.Columns[i].Visible
							select row.Cells[i].Value?.ToString() ?? "" into v
							select v.Replace("\t", " ").Replace("\r", "").Replace("\n", " ")).ToList();
						streamWriter.WriteLine(string.Join("\t", values2));
					}
				}
			}
			ShowMessage($"成功导出 {list.Count} 条记录到：\n{filePath}");
		}
		catch (Exception ex)
		{
			ShowMessage("导出失败：" + ex.Message);
		}
	}

	private void ExportAllAsync(string filePath)
	{
		try
		{
			DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
			List<IConditionalModel> conditionalList = new List<IConditionalModel>
			{
				new ConditionalModel
				{
					FieldName = "add_time",
					ConditionalType = ConditionalType.GreaterThanOrEqual,
					FieldValue = dateStart.Value.Date.ToString()
				},
				new ConditionalModel
				{
					FieldName = "add_time",
					ConditionalType = ConditionalType.LessThanOrEqual,
					FieldValue = dateEnd.Value.AddDays(1.0).Date.AddSeconds(-1.0).ToString()
				}
			};
			PageModel page = new PageModel
			{
				PageIndex = 0,
				PageSize = 10000000
			};
			List<tb_exceptional> pageList = dataServerContext.Current.GetPageList(conditionalList, page, (tb_exceptional it) => it.add_time, OrderByType.Desc);
			if (pageList == null || pageList.Count == 0)
			{
				ShowMessage("无数据可导出");
				return;
			}
			string[] value = new string[9] { "警报时间", "设备名称", "进出方向", "车牌号", "警报操作", "抓拍图片1", "抓拍图片2", "抓拍图片3", "抓拍视频" };
			Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
			using (StreamWriter streamWriter = new StreamWriter(filePath, append: false, encoding))
			{
				streamWriter.WriteLine(string.Join("\t", value));
				foreach (tb_exceptional item in pageList)
				{
					string[] value2 = new string[9]
					{
						item.add_time.ToString("yyyy-MM-dd HH:mm:ss"),
						item.gateName ?? "",
						item.ChannelType ?? "",
						item.car_no ?? "",
						item.OpeningType ?? "",
						item.SnapImagePath1 ?? "",
						item.SnapImagePath2 ?? "",
						item.SnapImagePath3 ?? "",
						item.SnapVideoPath ?? ""
					};
					streamWriter.WriteLine(string.Join("\t", value2));
				}
			}
			ShowMessage($"成功导出 {pageList.Count} 条记录到：\n{filePath}");
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
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.label3 = new System.Windows.Forms.Label();
		this.dateStart = new System.Windows.Forms.DateTimePicker();
		this.label4 = new System.Windows.Forms.Label();
		this.dateEnd = new System.Windows.Forms.DateTimePicker();
		this.pager1 = new BST.Ticket.Pager();
		this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
		this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
		this.bar1 = new DevExpress.XtraBars.Bar();
		this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
		this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
		this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
		this.bar2 = new DevExpress.XtraBars.Bar();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		this.tableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		this.tableLayoutPanel2.SuspendLayout();
		this.pager1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.bindingNavigator).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barManager2).BeginInit();
		base.SuspendLayout();
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[8] { this.barButtonItem1, this.barButtonItem5, this.barButtonItem2, this.barButtonItem7, this.barButtonItem3, this.barButtonItem6, this.barButtonItem8, this.barButtonItem4 });
		this.barManager1.MaxItemId = 0;
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 40);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(1338, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 850);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(1338, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 810);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(1338, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 810);
		this.barButtonItem1.Caption = "全选";
		this.barButtonItem1.Id = 94;
		this.barButtonItem1.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.apply_32x324;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem5.Caption = "查询";
		this.barButtonItem5.Id = 98;
		this.barButtonItem5.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.zoom_32x32;
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem2.Caption = "删除";
		this.barButtonItem2.Id = 95;
		this.barButtonItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.remove_32x321;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem7.Caption = "上传货物信息";
		this.barButtonItem7.Id = 100;
		this.barButtonItem7.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.paste_32x32;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem3.Caption = "查看图片";
		this.barButtonItem3.Id = 96;
		this.barButtonItem3.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.show_32x32;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem6.Caption = "导出";
		this.barButtonItem6.Id = 99;
		this.barButtonItem6.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.open2_32x32;
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barButtonItem8.Caption = "导出全部";
		this.barButtonItem8.Id = 101;
		this.barButtonItem8.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.openhyperlink_32x32;
		this.barButtonItem8.Name = "barButtonItem8";
		this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem8_ItemClick);
		this.barButtonItem4.Caption = "关闭";
		this.barButtonItem4.Id = 97;
		this.barButtonItem4.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.cancel_32x322;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(1338, 40);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 810);
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.pager1, 0, 2);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 3;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.11765f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882353f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(1338, 810);
		this.tableLayoutPanel1.TabIndex = 8;
		this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dataGridView1.Location = new System.Drawing.Point(3, 73);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowTemplate.Height = 26;
		this.dataGridView1.Size = new System.Drawing.Size(1332, 690);
		this.dataGridView1.TabIndex = 1;
		this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellClick);
		this.tableLayoutPanel2.ColumnCount = 7;
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
		this.tableLayoutPanel2.Controls.Add(this.dateStart, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
		this.tableLayoutPanel2.Controls.Add(this.dateEnd, 3, 0);
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64f));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(1332, 64);
		this.tableLayoutPanel2.TabIndex = 2;
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(18, 18);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(112, 27);
		this.label3.TabIndex = 42;
		this.label3.Text = "开始时间：";
		this.dateStart.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dateStart.CalendarFont = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.dateStart.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.dateStart.Location = new System.Drawing.Point(140, 15);
		this.dateStart.Name = "dateStart";
		this.dateStart.Size = new System.Drawing.Size(251, 34);
		this.dateStart.TabIndex = 43;
		this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(417, 18);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(112, 27);
		this.label4.TabIndex = 44;
		this.label4.Text = "结束时间：";
		this.dateEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dateEnd.CalendarFont = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.dateEnd.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.dateEnd.Location = new System.Drawing.Point(539, 15);
		this.dateEnd.Name = "dateEnd";
		this.dateEnd.Size = new System.Drawing.Size(251, 34);
		this.dateEnd.TabIndex = 45;
		this.pager1.Controls.Add(this.bindingNavigator);
		this.pager1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pager1.Location = new System.Drawing.Point(3, 769);
		this.pager1.Name = "pager1";
		this.pager1.NMax = 0;
		this.pager1.PageCount = 0;
		this.pager1.PageCurrent = 0;
		this.pager1.PageSize = 20;
		this.pager1.Size = new System.Drawing.Size(1332, 38);
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
		this.bindingNavigator.Size = new System.Drawing.Size(1332, 38);
		this.bindingNavigator.TabIndex = 0;
		this.bindingNavigator.Text = "bindingNavigator1";
		this.barButtonItem13.Caption = "查看图片";
		this.barButtonItem13.Id = 96;
		this.barButtonItem13.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.show_32x32;
		this.barButtonItem13.Name = "barButtonItem13";
		this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem13_ItemClick);
		this.barButtonItem16.Caption = "关闭";
		this.barButtonItem16.Id = 97;
		this.barButtonItem16.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.cancel_32x322;
		this.barButtonItem16.Name = "barButtonItem16";
		this.barButtonItem16.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem16_ItemClick);
		this.barButtonItem10.Caption = "查询";
		this.barButtonItem10.Id = 98;
		this.barButtonItem10.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.zoom_32x32;
		this.barButtonItem10.Name = "barButtonItem10";
		this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem10_ItemClick);
		this.barButtonItem15.Caption = "查看视频";
		this.barButtonItem15.Id = 101;
		this.barButtonItem15.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.transit_32x32;
		this.barButtonItem15.Name = "barButtonItem15";
		this.barButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem15_ItemClick);
		this.bar1.BarName = "Main menu";
		this.bar1.DockCol = 0;
		this.bar1.DockRow = 0;
		this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[4]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem10, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem13, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem15, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem16, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.bar1.OptionsBar.MultiLine = true;
		this.bar1.OptionsBar.UseWholeRow = true;
		this.bar1.Text = "Main menu";
		this.barDockControl2.CausesValidation = false;
		this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControl2.Location = new System.Drawing.Point(0, 0);
		this.barDockControl2.Manager = this.barManager2;
		this.barDockControl2.Size = new System.Drawing.Size(1338, 40);
		this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar1 });
		this.barManager2.DockControls.Add(this.barDockControl2);
		this.barManager2.DockControls.Add(this.barDockControl3);
		this.barManager2.DockControls.Add(this.barDockControl4);
		this.barManager2.DockControls.Add(this.barDockControl5);
		this.barManager2.Form = this;
		this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[4] { this.barButtonItem13, this.barButtonItem16, this.barButtonItem10, this.barButtonItem15 });
		this.barManager2.MainMenu = this.bar1;
		this.barManager2.MaxItemId = 102;
		this.barDockControl3.CausesValidation = false;
		this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControl3.Location = new System.Drawing.Point(0, 850);
		this.barDockControl3.Manager = this.barManager2;
		this.barDockControl3.Size = new System.Drawing.Size(1338, 0);
		this.barDockControl4.CausesValidation = false;
		this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControl4.Location = new System.Drawing.Point(0, 40);
		this.barDockControl4.Manager = this.barManager2;
		this.barDockControl4.Size = new System.Drawing.Size(0, 810);
		this.barDockControl5.CausesValidation = false;
		this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl5.Location = new System.Drawing.Point(1338, 40);
		this.barDockControl5.Manager = this.barManager2;
		this.barDockControl5.Size = new System.Drawing.Size(0, 810);
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[8]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem5, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem7, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem6, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem8, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.bar2.OptionsBar.MultiLine = true;
		this.bar2.OptionsBar.UseWholeRow = true;
		this.bar2.Text = "Main menu";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1338, 850);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Controls.Add(this.barDockControl4);
		base.Controls.Add(this.barDockControl5);
		base.Controls.Add(this.barDockControl3);
		base.Controls.Add(this.barDockControl2);
		base.Name = "exeRecordForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "通行记录";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.tableLayoutPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		this.pager1.ResumeLayout(false);
		this.pager1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.bindingNavigator).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barManager2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
