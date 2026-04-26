// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.RecordList

using System;
using System.Collections;
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

public class RecordList : Form
{
	private bool ischeck;

	private IContainer components;

	private BarManager barManager1;

	private Bar bar2;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarButtonItem barButtonItem6;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

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

	private BarButtonItem barButtonItem7;

	private BarButtonItem barButtonItem8;

	private Label label6;

	private ComboBox comboBox3;

	private Label label7;

	private ComboBox comboBox4;

	private Label label8;

	private Label label5;

	private TextBox textBox2;

	private ComboBox comboBox2;

	private Label label9;

	private ComboBox comboBox5;

	private BarButtonItem barButtonItem9;

	private BarButtonItem barButtonItem10;

	public RecordList()
	{
		InitializeComponent();
		base.Load += RecordList_Load;
	}

	private void RecordList_Load(object sender, EventArgs e)
	{
		if (MainData.DJPT == "中科九州" || MainData.DJPT == "安车")
		{
			barButtonItem7.Visibility = BarItemVisibility.Always;
		}
		InitCombox();
		comboBox1.SelectedItem = "全部";
		comboBox2.SelectedItem = "全部";
		pager1.PageCurrent = 1;
		pager1.Bind();
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (ischeck)
		{
			ischeck = false;
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = false;
			}
			barButtonItem1.Caption = "全选";
		}
		else
		{
			barButtonItem1.Caption = "反选";
			ischeck = true;
			for (int j = 0; j < dataGridView1.Rows.Count; j++)
			{
				dataGridView1.Rows[j].Cells[0].Value = true;
			}
		}
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		pager1.PageCurrent = 1;
		pager1.Bind();
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		List<int> list = GetIds();
		if (list.Count == 0)
		{
			MessageBox.Show("请选择数据");
			return;
		}
		DataServerContext<tb_CarRecord> dataServerContext = new DataServerContext<tb_CarRecord>();
		List<tb_CarRecord> list2 = dataServerContext.Current.GetList((tb_CarRecord it) => list.Contains(it.id));
		if (MessageBox.Show($"确认删除选中的 {list.Count} 条车辆进出记录？\n\n此操作不可恢复。", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
		{
			return;
		}
		if (dataServerContext.Current.Delete((tb_CarRecord it) => list.Contains(it.id)))
		{
			foreach (tb_CarRecord item in list2)
			{
				if (File.Exists(item.car_image))
				{
					File.Delete(item.car_image);
				}
				if (File.Exists(item.front_image))
				{
					File.Delete(item.front_image);
				}
				List<tb_ImageDetaile> list3 = new DataServerContext<tb_ImageDetaile>().Current.GetList((tb_ImageDetaile it) => it.detaileID == item.id);
				if (list3 == null)
				{
					continue;
				}
				foreach (tb_ImageDetaile item2 in list3)
				{
					if (File.Exists(item2.ImagePath))
					{
						File.Delete(item2.ImagePath);
					}
				}
			}
			MessageBox.Show("删除成功");
			pager1.Bind();
		}
		else
		{
			MessageBox.Show("删除失败");
			pager1.Bind();
		}
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		List<int> list = GetIds();
		if (list.Count == 0)
		{
			MessageBox.Show("请选择数据");
			return;
		}
		List<string> list2 = new List<string>();
		List<tb_ImageDetaile> list3 = new DataServerContext<tb_ImageDetaile>().Current.GetList((tb_ImageDetaile it) => list.Contains(it.detaileID));
		List<tb_CarRecord> source = (List<tb_CarRecord>)dataGridView1.DataSource;
		foreach (int item in list)
		{
			tb_CarRecord tb_CarRecord2 = source.FirstOrDefault((tb_CarRecord it) => it.id == item);
			if (tb_CarRecord2 != null)
			{
				if (File.Exists(tb_CarRecord2.car_image))
				{
					list2.Add(tb_CarRecord2.car_image);
				}
				if (File.Exists(tb_CarRecord2.front_image))
				{
					list2.Add(tb_CarRecord2.front_image);
				}
			}
			List<tb_ImageDetaile> list4 = list3.Where((tb_ImageDetaile it) => it.detaileID == item).ToList();
			if (list4 == null)
			{
				continue;
			}
			foreach (tb_ImageDetaile item2 in list4)
			{
				if (File.Exists(item2.ImagePath))
				{
					list2.Add(item2.ImagePath);
				}
			}
		}
		ImageView imageView = new ImageView();
		imageView.ListImage = list2;
		imageView.ShowDialog();
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
		saveFileDialog.CreatePrompt = true;
		saveFileDialog.Title = "导出当前页记录";
		saveFileDialog.FileName = "进出日志_当前页_" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
				FormHelper.ShowMessage(this, "无数据可导出");
				return;
			}
			var headers = dataGridView1.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText ?? "").ToArray();
			FormHelper.ExportToTsv(dataGridView1, filePath, headers);
			FormHelper.ShowMessage(this, $"成功导出 {list.Count} 条记录到：\n{filePath}");
		}
		catch (Exception ex)
		{
			FormHelper.ShowError(this, "导出失败：" + ex.Message);
		}
	}

	private void ShowMessage(string msg)
	{
		FormHelper.ShowMessage(this, msg);
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (int.Parse(dataGridView1.Rows.Count.ToString()) == 0)
		{
			MessageBox.Show("请选择一行数据！");
			return;
		}
		int num = int.Parse(dataGridView1.CurrentRow.Index.ToString());
		if (num >= 0)
		{
			if (dataGridView1.Rows[num].Cells["cargoName"].Value != null && !string.IsNullOrWhiteSpace(dataGridView1.Rows[num].Cells["cargoName"].Value.ToString()))
			{
				MessageBox.Show("货物已上传不可重复上传！");
				return;
			}
			GoodsSetForm goodsSetForm = new GoodsSetForm();
			goodsSetForm.serialNum = dataGridView1.Rows[num].Cells["serialNum"].Value.ToString();
			goodsSetForm.license = dataGridView1.Rows[num].Cells["car_no"].Value.ToString();
			goodsSetForm.licenseColor = dataGridView1.Rows[num].Cells["car_color"].Value.ToString();
			goodsSetForm.gateCode = dataGridView1.Rows[num].Cells["ChannelPort"].Value.ToString();
			goodsSetForm.id = Convert.ToInt32(dataGridView1.Rows[num].Cells["id"].Value);
			goodsSetForm.ShowDialog();
			pager1.PageCurrent = pager1.PageCurrent;
			pager1.Bind();
		}
	}

	private string GetUserItemIds()
	{
		string text = "";
		foreach (DataGridViewRow item in (IEnumerable)dataGridView1.Rows)
		{
			if (Convert.ToBoolean(item.Cells[0].Value))
			{
				text = text + item.Cells["id"].Value.ToString() + ",";
			}
		}
		return text = ((text == "") ? "" : text.Substring(0, text.Length - 1));
	}

	private List<int> GetIds() => FormHelper.GetSelectedIds(dataGridView1);

	private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (dataGridView1.CurrentCell != null)
		{
			dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
			bool flag = Convert.ToBoolean(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
			dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value = !flag;
		}
	}

	private int pager1_EventPaging(EventPagingArg e)
	{
		return BindDGV();
	}

	private int BindDGV()
	{
		ischeck = false;
		DataServerContext<tb_CarRecord> dataServerContext = new DataServerContext<tb_CarRecord>();
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
				FieldName = "out_type",
				ConditionalType = ConditionalType.In,
				FieldValue = comboBox1.SelectedItem.ToString()
			});
		}
		list.Add(new ConditionalModel
		{
			FieldName = "add_time",
			ConditionalType = ConditionalType.GreaterThanOrEqual,
			FieldValue = dateStart.Value.Date.ToString()
		});
		list.Add(new ConditionalModel
		{
			FieldName = "add_time",
			ConditionalType = ConditionalType.LessThanOrEqual,
			FieldValue = dateEnd.Value.AddDays(1.0).Date.AddSeconds(-1.0).ToString()
		});
		if (!string.IsNullOrWhiteSpace(comboBox3.SelectedItem.ToString()) && !comboBox3.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "fuelType",
				ConditionalType = ConditionalType.Equal,
				FieldValue = comboBox3.SelectedItem.ToString()
			});
		}
		if (!string.IsNullOrWhiteSpace(comboBox4.SelectedItem.ToString()) && !comboBox4.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "emissionStandard",
				ConditionalType = ConditionalType.Equal,
				FieldValue = comboBox4.SelectedItem.ToString()
			});
		}
		if (!string.IsNullOrWhiteSpace(comboBox2.SelectedItem.ToString()) && !comboBox2.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "gateSignal",
				ConditionalType = ConditionalType.Equal,
				FieldValue = comboBox2.SelectedItem.ToString()
			});
		}
		if (!string.IsNullOrWhiteSpace(comboBox5.SelectedItem.ToString()) && !comboBox5.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "car_color",
				ConditionalType = ConditionalType.Equal,
				FieldValue = comboBox5.SelectedItem.ToString()
			});
		}
		if (!string.IsNullOrWhiteSpace(textBox2.Text))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "ChannelPort",
				ConditionalType = ConditionalType.Like,
				FieldValue = textBox2.Text
			});
		}
		PageModel pageModel = new PageModel
		{
			PageIndex = pager1.PageCurrent,
			PageSize = pager1.PageSize
		};
		List<tb_CarRecord> pageList = dataServerContext.Current.GetPageList(list, pageModel, (tb_CarRecord it) => it.add_time, OrderByType.Desc);
		if (pageList != null)
		{
			dataGridView1.DataSource = pageList;
		dataGridView1.Columns["serialNum"].HeaderText = "记录编号";
		dataGridView1.Columns["ChannelPort"].HeaderText = "通道编号";
		dataGridView1.Columns["car_no"].HeaderText = "车牌号码";
		dataGridView1.Columns["add_time"].HeaderText = "通行时间";
		dataGridView1.Columns["out_type"].HeaderText = "通行方向";
		dataGridView1.Columns["car_color"].HeaderText = "颜色";
		dataGridView1.Columns["car_image"].HeaderText = "车牌图";
		dataGridView1.Columns["front_image"].HeaderText = "车身图";
		dataGridView1.Columns["upload_status"].HeaderText = "状态";
		dataGridView1.Columns["upload_number"].HeaderText = "重试次数";
		dataGridView1.Columns["fuelType"].HeaderText = "燃料";
		dataGridView1.Columns["emissionStandard"].HeaderText = "排放标准";
		dataGridView1.Columns["gateSignal"].HeaderText = "通行结果";
		dataGridView1.Columns["cargoName"].HeaderText = "货物";
		dataGridView1.Columns["cargoWeight"].HeaderText = "重量(吨)";
		dataGridView1.Columns["platform_status"].HeaderText = "平台响应";
			dataGridView1.Columns["id"].Visible = false;
			dataGridView1.Columns["car_image"].Visible = false;
			dataGridView1.Columns["front_image"].Visible = false;
			pager1.bindingSource.DataSource = pageList;
			pager1.bindingNavigator.BindingSource = pager1.bindingSource;
			return pageModel.TotalCount;
		}
		return 0;
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
		saveFileDialog.Title = "导出全部记录";
		saveFileDialog.FileName = "进出日志_全部_" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
			DataServerContext<tb_CarRecord> dataServerContext = new DataServerContext<tb_CarRecord>();
			List<IConditionalModel> conditionalList = BuildConditions();
			PageModel page = new PageModel
			{
				PageIndex = 0,
				PageSize = 100000
			};
			List<tb_CarRecord> pageList = dataServerContext.Current.GetPageList(conditionalList, page, (tb_CarRecord it) => it.add_time);
			if (pageList == null || pageList.Count == 0)
			{
				FormHelper.ShowMessage(this, "无数据可导出");
				return;
			}
			string[] headers = { "车牌号码", "通行时间", "通行方向", "颜色", "车牌图", "车身图", "状态", "重试次数", "燃料", "排放标准", "通行结果", "货物", "重量(吨)" };
			FormHelper.ExportToTsv(pageList, filePath, item => new[]
			{
				item.car_no ?? "",
				item.add_time.ToString("yyyy-MM-dd HH:mm:ss"),
				item.out_type ?? "",
				item.car_color ?? "",
				item.car_image ?? "",
				item.front_image ?? "",
				item.upload_status ?? "",
				item.upload_number.ToString(),
				item.fuelType ?? "",
				item.emissionStandard ?? "",
				item.gateSignal ?? "",
				item.cargoName ?? "",
				item.cargoWeight ?? ""
			}, headers);
			FormHelper.ShowMessage(this, $"成功导出 {pageList.Count} 条记录到：\n{filePath}");
		}
		catch (Exception ex)
		{
			FormHelper.ShowError(this, "导出失败：" + ex.Message);
		}
		finally
		{
			Invoke((Action)delegate
			{
				BindDGV();
			});
		}
	}

	private List<IConditionalModel> BuildConditions()
	{
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
		if (!string.IsNullOrWhiteSpace(comboBox1.SelectedItem?.ToString()) && !comboBox1.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "out_type",
				ConditionalType = ConditionalType.In,
				FieldValue = comboBox1.SelectedItem.ToString()
			});
		}
		list.Add(new ConditionalModel
		{
			FieldName = "add_time",
			ConditionalType = ConditionalType.GreaterThanOrEqual,
			FieldValue = dateStart.Value.Date.ToString()
		});
		list.Add(new ConditionalModel
		{
			FieldName = "add_time",
			ConditionalType = ConditionalType.LessThanOrEqual,
			FieldValue = dateEnd.Value.AddDays(1.0).Date.AddSeconds(-1.0).ToString()
		});
		if (!string.IsNullOrWhiteSpace(comboBox3.SelectedItem?.ToString()) && !comboBox3.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "fuelType",
				ConditionalType = ConditionalType.Equal,
				FieldValue = comboBox3.SelectedItem.ToString()
			});
		}
		if (!string.IsNullOrWhiteSpace(comboBox4.SelectedItem?.ToString()) && !comboBox4.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "emissionStandard",
				ConditionalType = ConditionalType.Equal,
				FieldValue = comboBox4.SelectedItem.ToString()
			});
		}
		if (!string.IsNullOrWhiteSpace(comboBox2.SelectedItem?.ToString()) && !comboBox2.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "gateSignal",
				ConditionalType = ConditionalType.Equal,
				FieldValue = comboBox2.SelectedItem.ToString()
			});
		}
		if (!string.IsNullOrWhiteSpace(comboBox5.SelectedItem?.ToString()) && !comboBox5.SelectedItem.ToString().Equals("全部"))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "car_color",
				ConditionalType = ConditionalType.Equal,
				FieldValue = comboBox5.SelectedItem.ToString()
			});
		}
		if (!string.IsNullOrWhiteSpace(textBox2.Text))
		{
			list.Add(new ConditionalModel
			{
				FieldName = "ChannelPort",
				ConditionalType = ConditionalType.Like,
				FieldValue = textBox2.Text
			});
		}
		return list;
	}

	public void InitCombox()
	{
		List<string> list = new List<string>();
		list.Add("全部");
		list.Add("国0");
		list.Add("国1");
		list.Add("国2");
		list.Add("国3");
		list.Add("国4");
		list.Add("国5");
		list.Add("国6");
		list.Add("国7");
		list.Add("电动");
		list.Add("无排放阶段");
		list.Add("未知");
		comboBox4.DataSource = list;
		comboBox4.SelectedIndex = 0;
		list = new List<string>();
		list.Add("全部");
		list.Add("汽油");
		list.Add("柴油");
		list.Add("电");
		list.Add("混合油");
		list.Add("天然气");
		list.Add("液化石油气");
		list.Add("甲醇");
		list.Add("乙醇");
		list.Add("太阳能");
		list.Add("混合动力");
		list.Add("氢");
		list.Add("生物燃料");
		list.Add("无");
		list.Add("其它");
		comboBox3.DataSource = list;
		comboBox3.SelectedIndex = 0;
		list = new List<string>();
		list.Add("全部");
		list.Add("蓝色");
		list.Add("黄色");
		list.Add("白色");
		list.Add("黑色");
		list.Add("绿色");
		list.Add("黄绿");
		list.Add("其它");
		comboBox5.DataSource = list;
		comboBox5.SelectedIndex = 0;
	}

	private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
	{
		new ChartForm().ShowDialog();
	}

	private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
	{
		textBox1.Text = "";
		textBox2.Text = "";
		comboBox1.SelectedItem = "全部";
		comboBox2.SelectedItem = "全部";
		comboBox3.SelectedItem = "全部";
		comboBox4.SelectedItem = "全部";
		comboBox5.SelectedItem = "全部";
		dateStart.Value = DateTime.Now.Date;
		dateEnd.Value = DateTime.Now.Date;
		pager1.PageCurrent = 1;
		pager1.Bind();
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
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.label8 = new System.Windows.Forms.Label();
		this.dateEnd = new System.Windows.Forms.DateTimePicker();
		this.label2 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.dateStart = new System.Windows.Forms.DateTimePicker();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label6 = new System.Windows.Forms.Label();
		this.comboBox3 = new System.Windows.Forms.ComboBox();
		this.label7 = new System.Windows.Forms.Label();
		this.comboBox4 = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
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
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[10] { this.barButtonItem1, this.barButtonItem2, this.barButtonItem3, this.barButtonItem4, this.barButtonItem5, this.barButtonItem6, this.barButtonItem7, this.barButtonItem8, this.barButtonItem9, this.barButtonItem10 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 104;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[10]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem5, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem9, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem10, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem7, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem6, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem8, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.bar2.OptionsBar.MultiLine = true;
		this.bar2.OptionsBar.UseWholeRow = true;
		this.bar2.Text = "Main menu";
		this.barButtonItem1.Caption = "全选";
		this.barButtonItem1.Id = 94;
		this.barButtonItem1.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.apply_32x324;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem5.Caption = "查询";
		this.barButtonItem5.Id = 98;
		this.barButtonItem5.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.zoom_32x32;
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.barButtonItem2.Caption = "删除";
		this.barButtonItem2.Id = 95;
		this.barButtonItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.remove_32x321;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem9.Caption = "统计";
		this.barButtonItem9.Id = 102;
		this.barButtonItem9.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.tableofcontent_32x32;
		this.barButtonItem9.Name = "barButtonItem9";
		this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem9_ItemClick);
		this.barButtonItem10.Caption = "重置";
		this.barButtonItem10.Id = 103;
		this.barButtonItem10.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.backward_32x32;
		this.barButtonItem10.Name = "barButtonItem10";
		this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem10_ItemClick);
		this.barButtonItem7.Caption = "上传货物信息";
		this.barButtonItem7.Id = 100;
		this.barButtonItem7.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.paste_32x32;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem7_ItemClick);
		this.barButtonItem3.Caption = "查看图片";
		this.barButtonItem3.Id = 96;
		this.barButtonItem3.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.show_32x32;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
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
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(1294, 40);
		this.barDockControlTop.TabIndex = 0;
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 730);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(1294, 0);
		this.barDockControlBottom.TabIndex = 0;
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 690);
		this.barDockControlLeft.TabIndex = 0;
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(1294, 40);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 690);
		this.barDockControlRight.TabIndex = 0;
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.pager1, 0, 2);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 3;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.11765f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882353f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(1294, 690);
		this.tableLayoutPanel1.TabIndex = 0;
		this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Columns.AddRange(this.Column1);
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dataGridView1.Location = new System.Drawing.Point(3, 123);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowTemplate.Height = 26;
		this.dataGridView1.Size = new System.Drawing.Size(1288, 530);
		this.dataGridView1.TabIndex = 20;
		this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellClick);
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
		this.tableLayoutPanel2.Controls.Add(this.label8, 4, 0);
		this.tableLayoutPanel2.Controls.Add(this.dateEnd, 3, 1);
		this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
		this.tableLayoutPanel2.Controls.Add(this.label4, 2, 1);
		this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
		this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
		this.tableLayoutPanel2.Controls.Add(this.dateStart, 1, 1);
		this.tableLayoutPanel2.Controls.Add(this.comboBox1, 3, 0);
		this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
		this.tableLayoutPanel2.Controls.Add(this.comboBox3, 1, 2);
		this.tableLayoutPanel2.Controls.Add(this.label7, 2, 2);
		this.tableLayoutPanel2.Controls.Add(this.comboBox4, 3, 2);
		this.tableLayoutPanel2.Controls.Add(this.label5, 4, 1);
		this.tableLayoutPanel2.Controls.Add(this.comboBox2, 5, 1);
		this.tableLayoutPanel2.Controls.Add(this.textBox2, 5, 0);
		this.tableLayoutPanel2.Controls.Add(this.label9, 4, 2);
		this.tableLayoutPanel2.Controls.Add(this.comboBox5, 5, 2);
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 3;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(1288, 114);
		this.tableLayoutPanel2.TabIndex = 10;
		this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.ForeColor = System.Drawing.Color.Black;
		this.label8.Location = new System.Drawing.Point(805, 8);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(90, 21);
		this.label8.TabIndex = 58;
		this.label8.Text = "通道编号：";
		this.dateEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dateEnd.CalendarFont = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.dateEnd.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.dateEnd.Location = new System.Drawing.Point(516, 42);
		this.dateEnd.Name = "dateEnd";
		this.dateEnd.Size = new System.Drawing.Size(251, 29);
		this.dateEnd.TabIndex = 45;
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label2.ForeColor = System.Drawing.Color.Black;
		this.label2.Location = new System.Drawing.Point(51, 8);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(74, 21);
		this.label2.TabIndex = 38;
		this.label2.Text = "车牌号：";
		this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(420, 46);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(90, 21);
		this.label4.TabIndex = 44;
		this.label4.Text = "结束时间：";
		this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox1.Location = new System.Drawing.Point(131, 4);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(251, 29);
		this.textBox1.TabIndex = 37;
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label1.ForeColor = System.Drawing.Color.Black;
		this.label1.Location = new System.Drawing.Point(420, 8);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(90, 21);
		this.label1.TabIndex = 40;
		this.label1.Text = "进出类型：";
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(35, 46);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(90, 21);
		this.label3.TabIndex = 42;
		this.label3.Text = "开始时间：";
		this.dateStart.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dateStart.CalendarFont = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.dateStart.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.dateStart.Location = new System.Drawing.Point(131, 42);
		this.dateStart.Name = "dateStart";
		this.dateStart.Size = new System.Drawing.Size(251, 29);
		this.dateStart.TabIndex = 43;
		this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[3] { "全部", "入口", "出口" });
		this.comboBox1.Location = new System.Drawing.Point(516, 4);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(251, 29);
		this.comboBox1.TabIndex = 39;
		this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label6.AutoSize = true;
		this.label6.BackColor = System.Drawing.Color.Transparent;
		this.label6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label6.ForeColor = System.Drawing.Color.Black;
		this.label6.Location = new System.Drawing.Point(35, 84);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(90, 21);
		this.label6.TabIndex = 51;
		this.label6.Text = "燃油类型：";
		this.comboBox3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.comboBox3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.comboBox3.FormattingEnabled = true;
		this.comboBox3.Location = new System.Drawing.Point(131, 80);
		this.comboBox3.Name = "comboBox3";
		this.comboBox3.Size = new System.Drawing.Size(251, 29);
		this.comboBox3.TabIndex = 52;
		this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label7.AutoSize = true;
		this.label7.BackColor = System.Drawing.Color.Transparent;
		this.label7.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label7.ForeColor = System.Drawing.Color.Black;
		this.label7.Location = new System.Drawing.Point(420, 84);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(90, 21);
		this.label7.TabIndex = 53;
		this.label7.Text = "排放阶段：";
		this.comboBox4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.comboBox4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.comboBox4.FormattingEnabled = true;
		this.comboBox4.Location = new System.Drawing.Point(516, 80);
		this.comboBox4.Name = "comboBox4";
		this.comboBox4.Size = new System.Drawing.Size(251, 29);
		this.comboBox4.TabIndex = 54;
		this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label5.ForeColor = System.Drawing.Color.Black;
		this.label5.Location = new System.Drawing.Point(805, 46);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(90, 21);
		this.label5.TabIndex = 55;
		this.label5.Text = "道闸信号：";
		this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.comboBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Items.AddRange(new object[3] { "全部", "未摆杆", "摆杆通行" });
		this.comboBox2.Location = new System.Drawing.Point(901, 42);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(251, 29);
		this.comboBox2.TabIndex = 56;
		this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(901, 4);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(251, 29);
		this.textBox2.TabIndex = 57;
		this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label9.AutoSize = true;
		this.label9.BackColor = System.Drawing.Color.Transparent;
		this.label9.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label9.ForeColor = System.Drawing.Color.Black;
		this.label9.Location = new System.Drawing.Point(805, 84);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(90, 21);
		this.label9.TabIndex = 59;
		this.label9.Text = "车牌颜色：";
		this.comboBox5.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.comboBox5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.comboBox5.FormattingEnabled = true;
		this.comboBox5.Location = new System.Drawing.Point(901, 80);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(251, 29);
		this.comboBox5.TabIndex = 60;
		this.pager1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pager1.Location = new System.Drawing.Point(3, 659);
		this.pager1.Name = "pager1";
		this.pager1.NMax = 0;
		this.pager1.PageCount = 0;
		this.pager1.PageCurrent = 0;
		this.pager1.PageSize = 20;
		this.pager1.Size = new System.Drawing.Size(1288, 28);
		this.pager1.TabIndex = 30;
		this.pager1.EventPaging += new BST.Ticket.EventPagingHandler(pager1_EventPaging);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1294, 730);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "RecordList";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "记录查询";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.tableLayoutPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
