// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.whiteListForm

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BST.Ticket;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;
using SqlSugar;

namespace BulkMaterialsForm.View;

public class whiteListForm : Form
{
	private bool ischeck;

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

	private TableLayoutPanel tableLayoutPanel1;

	private DataGridView dataGridView1;

	private DataGridViewCheckBoxColumn Column1;

	private TableLayoutPanel tableLayoutPanel2;

	private Label label3;

	private TextBox textBox2;

	private Label label2;

	private TextBox textBox1;

	private Label label4;

	private TextBox textBox3;

	private Label label5;

	private ComboBox comboBoxValidStatus;

	private Pager pager1;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem6;

	private BarButtonItem barButtonItem7;

	private BarButtonItem barButtonItem8;

	public whiteListForm()
	{
		InitializeComponent();
		base.Load += WhiteListForm_Load;
	}

	private void WhiteListForm_Load(object sender, EventArgs e)
	{
		pager1.PageCurrent = 1;
		pager1.Bind();
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (ischeck)
		{
			ischeck = false;
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = false;
			}
		}
		else
		{
			ischeck = true;
			for (int j = 0; j < dataGridView1.Rows.Count; j++)
			{
				dataGridView1.Rows[j].Cells[0].Value = true;
			}
		}
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
		pager1.PageCurrent = 1;
		pager1.Bind();
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		new WhiteListSetForm().ShowDialog();
		pager1.PageCurrent = 1;
		pager1.Bind();
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
			WhiteListSetForm whiteListSetForm = new WhiteListSetForm();
			whiteListSetForm.type = 1;
			whiteListSetForm.id = id;
			whiteListSetForm.ShowDialog();
			pager1.PageCurrent = 1;
			pager1.Bind();
		}
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		List<int> list = GetIds();
		if (list.Count == 0)
		{
			MessageBox.Show("请选择要删除的数据");
		}
		else if (MessageBox.Show($"确认删除选中的 {list.Count} 条白名单记录？\n\n此操作不可恢复。", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes && new DataServerContext<tb_car_info>().Current.Delete((tb_car_info it) => list.Contains(it.id)))
		{
			MessageBox.Show($"删除成功，共删除 {list.Count} 条记录", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			pager1.Bind();
		}
	}

	private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = "C:\\";
		openFileDialog.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx|Excel 97-2003 (*.xls)|*.xls|Excel 2007+ (*.xlsx)|*.xlsx";
		openFileDialog.FilterIndex = 1;
		openFileDialog.RestoreDirectory = true;
		string filePath = "";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			filePath = openFileDialog.FileName;
		}
		if (string.IsNullOrEmpty(filePath))
		{
			MessageBox.Show("您还没有选择文件！");
			return;
		}
		Task.Run(delegate
		{
			ImportExcelAsync(filePath);
		});
	}

	private void ImportExcelAsync(string filePath)
	{
		try
		{
			DataSet dataSet = ExcelToDataSet(filePath);
			if (dataSet == null || dataSet.Tables.Count == 0)
			{
				ShowMessage("数据为空！");
				return;
			}
			DataTable dataTable = dataSet.Tables[0].DefaultView.ToTable();
			if (dataTable.Columns.Count < 4)
			{
				ShowMessage("Excel文件列数不足，至少需要：车牌号、名称、手机号、备注");
				return;
			}
			string[] array = new string[4] { "车牌号", "名称", "手机号", "备注" };
			foreach (string text in array)
			{
				if (!dataTable.Columns.Contains(text))
				{
					ShowMessage("缺少必需列：" + text);
					return;
				}
			}
			DataServerContext<tb_car_info> dataServerContext = new DataServerContext<tb_car_info>();
			int num = 0;
			int num2 = 0;
			List<string> list = new List<string>();
			int num3 = 20;
			HashSet<string> hashSet = (from x in dataServerContext.Current.GetList()
				select x.car_no).ToHashSet(StringComparer.OrdinalIgnoreCase);
			Regex regex = new Regex("^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使][A-Z][A-Z0-9]{5,6}$", RegexOptions.Compiled);
			Regex regex2 = new Regex("^1[3-9]\\d{9}$", RegexOptions.Compiled);
			_ = dataTable.Rows.Count;
			foreach (DataRow row in dataTable.Rows)
			{
				string text2 = row["车牌号"]?.ToString()?.Trim() ?? "";
				if (string.IsNullOrEmpty(text2))
				{
					num2++;
					if (list.Count < num3)
					{
						list.Add("车牌号为空，已跳过");
					}
					continue;
				}
				string text3 = text2.ToUpper();
				if (!regex.IsMatch(text3))
				{
					num2++;
					if (list.Count < num3)
					{
						list.Add("'" + text2 + "' 格式不正确");
					}
					continue;
				}
				if (hashSet.Contains(text3))
				{
					num2++;
					if (list.Count < num3)
					{
						list.Add("'" + text3 + "' 车牌已存在");
					}
					continue;
				}
				string text4 = row["手机号"]?.ToString()?.Trim() ?? "";
				if (!string.IsNullOrEmpty(text4) && !regex2.IsMatch(text4))
				{
					num2++;
					if (list.Count < num3)
					{
						list.Add("'" + text3 + "' 手机号格式不正确: " + text4);
					}
					continue;
				}
				tb_car_info model = new tb_car_info
				{
					car_no = text3,
					name = (row["名称"]?.ToString()?.Trim() ?? ""),
					phone = text4,
					bz = (row["备注"]?.ToString()?.Trim() ?? ""),
					startTime = DateTime.Now,
					endTime = DateTime.Now.AddYears(1)
				};
				if (dataServerContext.Current.Add(model))
				{
					num++;
					continue;
				}
				num2++;
				if (list.Count < num3)
				{
					list.Add("'" + text3 + "' 保存失败");
				}
			}
			string text5 = $"导入完成：成功 {num} 条，失败 {num2} 条";
			if (list.Count > 0)
			{
				text5 = text5 + "\n失败原因：\n" + string.Join("\n", list);
				if (num2 > num3)
				{
					text5 += $"\n...（共 {num2} 条失败，以上显示前 {num3} 条）";
				}
			}
			ShowMessage(text5);
			Invoke((Action)delegate
			{
				pager1.PageCurrent = 1;
				pager1.Bind();
			});
		}
		catch (Exception ex)
		{
			ShowMessage("导入失败：" + ex.Message);
		}
	}

	private DataSet ExcelToDataSet(string filePath)
	{
		string text = Path.GetExtension(filePath).ToLowerInvariant();
		string[] array = new string[4] { "Microsoft.ACE.OLEDB.16.0", "Microsoft.ACE.OLEDB.15.0", "Microsoft.ACE.OLEDB.12.0", "Microsoft.Jet.OLEDB.4.0" };
		string[] array2 = ((!(text == ".xlsx")) ? new string[1] { "Excel 12.0;HDR=YES;IMEX=1" } : new string[2] { "Excel 12.0 Xml;HDR=YES;IMEX=1", "Excel 12.0;HDR=YES;IMEX=1" });
		string text2 = "";
		string[] array3 = array;
		foreach (string text3 in array3)
		{
			string[] array4 = array2;
			foreach (string text4 in array4)
			{
				string connStr = "Provider=" + text3 + ";Data Source=" + filePath + ";Extended Properties=\"" + text4 + "\"";
				try
				{
					return ReadExcelWithProvider(connStr);
				}
				catch (OleDbException ex)
				{
					text2 = ex.Message;
					if (ex.HResult == -2147467259 || ex.Message.Contains("未注册") || ex.Message.Contains("not registered"))
					{
						continue;
					}
					throw;
				}
				catch (InvalidOperationException)
				{
				}
			}
		}
		throw new InvalidOperationException("无法读取 Excel 文件。\n\n可能原因：系统未安装 Access Database Engine（数据库引擎）。\n\n解决方法：\n1. 下载并安装 AccessDatabaseEngine（64位系统）:\n   https://www.microsoft.com/zh-cn/download/details.aspx?id=54920\n\n2. 安装后重启程序再试。\n\n原始错误: " + text2);
	}

	private DataSet ReadExcelWithProvider(string connStr)
	{
		using OleDbConnection oleDbConnection = new OleDbConnection(connStr);
		oleDbConnection.Open();
		DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[4] { null, null, null, "TABLE" });
		oleDbConnection.Close();
		if (oleDbSchemaTable == null || oleDbSchemaTable.Rows.Count == 0)
		{
			throw new Exception("无法读取Excel工作表");
		}
		string text = oleDbSchemaTable.Rows[0]["TABLE_NAME"].ToString();
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM [" + text + "]", connStr);
		DataSet dataSet = new DataSet();
		oleDbDataAdapter.Fill(dataSet, "Table1");
		return dataSet;
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

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && dataGridView1.CurrentCell != null)
		{
			dataGridView1.Rows[e.RowIndex].Selected = true;
			if (e.ColumnIndex == 0)
			{
				bool flag = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
				dataGridView1.Rows[e.RowIndex].Cells[0].Value = !flag;
			}
		}
	}

	private int BindDGV()
	{
		ischeck = false;
		DataServerContext<tb_car_info> dataServerContext = new DataServerContext<tb_car_info>();
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
		if (!string.IsNullOrWhiteSpace(textBox2.Text))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "name",
				ConditionalType = ConditionalType.Like,
				FieldValue = textBox2.Text
			});
		}
		if (!string.IsNullOrWhiteSpace(textBox3.Text))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "phone",
				ConditionalType = ConditionalType.Like,
				FieldValue = textBox3.Text
			});
		}
		if (comboBoxValidStatus.SelectedIndex == 1)
		{
			list.Add(new ConditionalModel
			{
				FieldName = "endTime",
				ConditionalType = ConditionalType.GreaterThan,
				FieldValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
			});
		}
		else if (comboBoxValidStatus.SelectedIndex == 2)
		{
			list.Add(new ConditionalModel
			{
				FieldName = "endTime",
				ConditionalType = ConditionalType.LessThanOrEqual,
				FieldValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
			});
		}
		PageModel pageModel = new PageModel
		{
			PageIndex = pager1.PageCurrent,
			PageSize = pager1.PageSize
		};
		List<tb_car_info> pageList = dataServerContext.Current.GetPageList(list, pageModel);
		if (pageList != null)
		{
			dataGridView1.DataSource = pageList;
			dataGridView1.Columns["car_no"].HeaderText = "车牌号";
			dataGridView1.Columns["name"].HeaderText = "用户名称";
			dataGridView1.Columns["phone"].HeaderText = "用户手机号";
			dataGridView1.Columns["dep"].HeaderText = "部门";
			dataGridView1.Columns["bz"].HeaderText = "备注";
			dataGridView1.Columns["startTime"].HeaderText = "有效开始时间";
			dataGridView1.Columns["endTime"].HeaderText = "有效结束时间";
			dataGridView1.Columns["id"].Visible = false;
			pager1.bindingSource.DataSource = pageList;
			pager1.bindingNavigator.BindingSource = pager1.bindingSource;
			return pageModel.TotalCount;
		}
		return 0;
	}

	private List<int> GetIds()
	{
		List<int> list = new List<int>();
		foreach (DataGridViewRow item in (IEnumerable)dataGridView1.Rows)
		{
			if (Convert.ToBoolean(item.Cells[0].Value))
			{
				list.Add(Convert.ToInt32(item.Cells["id"].Value));
			}
		}
		return list;
	}

	private int pager1_EventPaging(EventPagingArg e)
	{
		return BindDGV();
	}

	private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
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
		saveFileDialog.Title = "导出名单";
		saveFileDialog.FileName = "白名单记录_" + DateTime.Now.ToString("yyyyMMddHHmmss");
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			string filePath = saveFileDialog.FileName;
			Thread thread = new Thread((ThreadStart)delegate
			{
				ExportAsync(filePath);
			});
			thread.IsBackground = true;
			thread.Start();
		}
	}

	private void ExportAsync(string filePath)
	{
		try
		{
			List<tb_car_info> list = new DataServerContext<tb_car_info>().Current.GetList();
			if (list == null || list.Count == 0)
			{
				ShowMessage("无数据可导出");
				return;
			}
			string[] value = new string[7] { "车牌号", "名称", "部门", "手机号", "开始时间", "结束时间", "备注" };
			Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
			using (StreamWriter streamWriter = new StreamWriter(filePath, append: false, encoding))
			{
				streamWriter.WriteLine(string.Join("\t", value));
				foreach (tb_car_info item in list)
				{
					string[] value2 = new string[7]
					{
						item.car_no ?? "",
						item.name ?? "",
						item.dep ?? "",
						item.phone ?? "",
						item.startTime.ToString("yyyy-MM-dd HH:mm:ss"),
						item.endTime.ToString("yyyy-MM-dd HH:mm:ss"),
						item.bz ?? ""
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
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.label3 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.comboBoxValidStatus = new System.Windows.Forms.ComboBox();
		this.pager1 = new BST.Ticket.Pager();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		this.tableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		this.tableLayoutPanel2.SuspendLayout();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[8] { this.barButtonItem1, this.barButtonItem2, this.barButtonItem3, this.barButtonItem4, this.barButtonItem5, this.barButtonItem6, this.barButtonItem7, this.barButtonItem8 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 103;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[8]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem5, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem6, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem8, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem7, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.bar2.OptionsBar.MultiLine = true;
		this.bar2.OptionsBar.UseWholeRow = true;
		this.bar2.Text = "Main menu";
		this.barButtonItem5.Caption = "全选";
		this.barButtonItem5.Id = 99;
		this.barButtonItem5.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.apply_32x325;
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.barButtonItem6.Caption = "查询";
		this.barButtonItem6.Id = 100;
		this.barButtonItem6.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.zoom_32x321;
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barButtonItem1.Caption = "新增";
		this.barButtonItem1.Id = 94;
		this.barButtonItem1.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.add_32x32;
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
		this.barButtonItem8.Caption = "导出";
		this.barButtonItem8.Id = 102;
		this.barButtonItem8.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.open2_32x32;
		this.barButtonItem8.Name = "barButtonItem8";
		this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem8_ItemClick);
		this.barButtonItem7.Caption = "导入";
		this.barButtonItem7.Id = 101;
		this.barButtonItem7.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.open2_32x321;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem7_ItemClick);
		this.barButtonItem4.Caption = "关闭";
		this.barButtonItem4.Id = 98;
		this.barButtonItem4.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.cancel_32x32;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(1138, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 698);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(1138, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 658);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(1138, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 658);
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.pager1, 0, 2);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 3;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(1138, 658);
		this.tableLayoutPanel1.TabIndex = 5;
		this.dataGridView1.AllowUserToAddRows = false;
		this.dataGridView1.AllowUserToDeleteRows = false;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Columns.AddRange(this.Column1);
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dataGridView1.Location = new System.Drawing.Point(3, 55);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowTemplate.Height = 26;
		this.dataGridView1.Size = new System.Drawing.Size(1132, 553);
		this.dataGridView1.TabIndex = 1;
		this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellClick);
		this.Column1.HeaderText = "";
		this.Column1.Name = "Column1";
		this.Column1.ReadOnly = true;
		this.tableLayoutPanel2.ColumnCount = 4;
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
		this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
		this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
		this.tableLayoutPanel2.Controls.Add(this.textBox2, 3, 0);
		this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
		this.tableLayoutPanel2.Controls.Add(this.textBox3, 1, 1);
		this.tableLayoutPanel2.Controls.Add(this.label5, 2, 1);
		this.tableLayoutPanel2.Controls.Add(this.comboBoxValidStatus, 3, 1);
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 2;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(1132, 60);
		this.tableLayoutPanel2.TabIndex = 2;
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.ForeColor = System.Drawing.Color.Black;
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(72, 20);
		this.label2.TabIndex = 39;
		this.label2.Text = "车牌号：";
		this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(220, 29);
		this.textBox1.TabIndex = 38;
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(60, 20);
		this.label3.TabIndex = 42;
		this.label3.Text = "名称：";
		this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(220, 29);
		this.textBox2.TabIndex = 41;
		this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(84, 20);
		this.label4.TabIndex = 43;
		this.label4.Text = "手机号：";
		this.textBox3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(220, 29);
		this.textBox3.TabIndex = 44;
		this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label5.ForeColor = System.Drawing.Color.Black;
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(84, 20);
		this.label5.TabIndex = 45;
		this.label5.Text = "有效状态：";
		this.comboBoxValidStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxValidStatus.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.comboBoxValidStatus.FormattingEnabled = true;
		this.comboBoxValidStatus.Items.AddRange(new object[3] { "全部", "有效期内", "已过期" });
		this.comboBoxValidStatus.Name = "comboBoxValidStatus";
		this.comboBoxValidStatus.SelectedIndex = 0;
		this.comboBoxValidStatus.Size = new System.Drawing.Size(220, 29);
		this.comboBoxValidStatus.TabIndex = 46;
		this.pager1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pager1.Location = new System.Drawing.Point(3, 614);
		this.pager1.Name = "pager1";
		this.pager1.NMax = 0;
		this.pager1.PageCount = 0;
		this.pager1.PageCurrent = 0;
		this.pager1.PageSize = 20;
		this.pager1.Size = new System.Drawing.Size(1132, 41);
		this.pager1.TabIndex = 3;
		this.pager1.EventPaging += new BST.Ticket.EventPagingHandler(pager1_EventPaging);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1138, 698);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "whiteListForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "车牌管理";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.tableLayoutPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
