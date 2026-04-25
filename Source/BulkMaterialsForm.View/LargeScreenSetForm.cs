// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.LargeScreenSetForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;
using BulkMaterialsForm.Properties;
using BulkMaterialsForm.SDK;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class LargeScreenSetForm : Form
{
	public int id;

	public int type;

	public tb_large_screen tb_Large_Screen;

	private List<tb_large_screen_detaile> tb_Large_Screen_Detailes;

	public bool isSave;

	private IContainer components;

	private Label label1;

	private TextBox textBoxlargeWidth;

	private TextBox textBoxlargeHeight;

	private Label label2;

	private Panel panel1;

	private BarManager barManager1;

	private Bar bar2;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem4;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControl1;

	private DataGridView dataGridView1;

	private Button button1;

	private Button button2;

	private Button button3;

	private TextBox textBoxlargeName;

	private Label label4;

	private TextBox textBoxIP;

	private Label label3;

	private TableLayoutPanel tableLayoutPanel1;

	private BarButtonItem barButtonItem2;

	public LargeScreenSetForm()
	{
		InitializeComponent();
		base.Load += LargeScreenSetForm_Load;
		base.FormClosed += LargeScreenSetForm_FormClosed;
	}

	private void LargeScreenSetForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (!isSave && type == 0)
		{
			new DataServerContext<tb_large_screen>().Current.Delete((tb_large_screen it) => it.id == id);
		}
	}

	private void LargeScreenSetForm_Load(object sender, EventArgs e)
	{
		if (type == 1)
		{
			InitData();
			InitDetalie();
			return;
		}
		tb_Large_Screen = new tb_large_screen();
		tb_Large_Screen_Detailes = new List<tb_large_screen_detaile>();
		textBoxlargeWidth.Text = "256";
		textBoxlargeHeight.Text = "64";
		DataServerContext<tb_large_screen> dataServerContext = new DataServerContext<tb_large_screen>();
		id = dataServerContext.Current.AddReturnIdentity(tb_Large_Screen);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		LargeScreenSetDetaileForm largeScreenSetDetaileForm = new LargeScreenSetDetaileForm();
		largeScreenSetDetaileForm.largeId = id;
		largeScreenSetDetaileForm.ShowDialog();
		if (largeScreenSetDetaileForm.isSave)
		{
			InitDetalie();
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (int.Parse(dataGridView1.Rows.Count.ToString()) == 0)
		{
			MessageBox.Show("请选择一行数据！");
			return;
		}
		int num = int.Parse(dataGridView1.CurrentRow.Index.ToString());
		if (num >= 0)
		{
			int num2 = Convert.ToInt32(dataGridView1.Rows[num].Cells["id"].Value);
			LargeScreenSetDetaileForm largeScreenSetDetaileForm = new LargeScreenSetDetaileForm();
			largeScreenSetDetaileForm.largeId = id;
			largeScreenSetDetaileForm.id = num2;
			largeScreenSetDetaileForm.type = 1;
			largeScreenSetDetaileForm.ShowDialog();
			if (largeScreenSetDetaileForm.isSave)
			{
				InitDetalie();
			}
		}
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBoxIP.Text))
		{
			MessageBox.Show("IP不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBoxlargeName.Text))
		{
			MessageBox.Show("大屏名称不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBoxlargeWidth.Text))
		{
			MessageBox.Show("宽不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBoxlargeHeight.Text))
		{
			MessageBox.Show("高不能为空");
		}
		else if (type == 0)
		{
			if (new DataServerContext<tb_large_screen>().Current.Modify((tb_large_screen p) => new tb_large_screen
			{
				IP = textBoxIP.Text,
				largeName = textBoxlargeName.Text,
				largeHeight = Convert.ToInt32(textBoxlargeHeight.Text),
				largeWidth = Convert.ToInt32(textBoxlargeWidth.Text)
			}, (tb_large_screen p) => p.id == id))
			{
				isSave = true;
				MessageBox.Show("新增成功");
				Close();
			}
			else
			{
				MessageBox.Show("新增失败");
			}
		}
		else if (new DataServerContext<tb_large_screen>().Current.Modify((tb_large_screen p) => new tb_large_screen
		{
			IP = textBoxIP.Text,
			largeName = textBoxlargeName.Text,
			largeHeight = Convert.ToInt32(textBoxlargeHeight.Text),
			largeWidth = Convert.ToInt32(textBoxlargeWidth.Text)
		}, (tb_large_screen p) => p.id == id))
		{
			isSave = true;
			MessageBox.Show("修改成功");
			Close();
		}
		else
		{
			MessageBox.Show("修改失败");
		}
	}

	private void button3_Click(object sender, EventArgs e)
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
		if (MessageBox.Show("确认删除该大屏详细信息？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			if (new DataServerContext<tb_large_screen_detaile>().Current.Delete((tb_large_screen_detaile it) => it.id == id))
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

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
		{
			e.Handled = true;
		}
	}

	private void textBoxlargeWidth_TextChanged(object sender, EventArgs e)
	{
		panel1.Width = Convert.ToInt32(textBoxlargeWidth.Text);
	}

	private void textBoxlargeHeight_TextChanged(object sender, EventArgs e)
	{
		panel1.Height = Convert.ToInt32(textBoxlargeHeight.Text);
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	public void InitData()
	{
		DataServerContext<tb_large_screen> dataServerContext = new DataServerContext<tb_large_screen>();
		tb_Large_Screen = dataServerContext.Current.GetList((tb_large_screen it) => it.id == id).FirstOrDefault();
		if (tb_Large_Screen != null)
		{
			textBoxIP.Text = tb_Large_Screen.IP;
			textBoxlargeName.Text = tb_Large_Screen.largeName;
			textBoxlargeWidth.Text = tb_Large_Screen.largeWidth.ToString();
			textBoxlargeHeight.Text = tb_Large_Screen.largeHeight.ToString();
		}
		else
		{
			MessageBox.Show("查询失败");
		}
	}

	public void InitDetalie()
	{
		DataServerContext<tb_large_screen_detaile> dataServerContext = new DataServerContext<tb_large_screen_detaile>();
		tb_Large_Screen_Detailes = dataServerContext.Current.GetList((tb_large_screen_detaile it) => it.largeId == id);
		if (tb_Large_Screen_Detailes != null)
		{
			dataGridView1.DataSource = tb_Large_Screen_Detailes;
			dataGridView1.Columns["x"].HeaderText = "x";
			dataGridView1.Columns["y"].HeaderText = "y";
			dataGridView1.Columns["Width"].HeaderText = "宽";
			dataGridView1.Columns["Height"].HeaderText = "高";
			dataGridView1.Columns["xstx"].HeaderText = "显示特效";
			dataGridView1.Columns["yxsd"].HeaderText = "运行速度";
			dataGridView1.Columns["tlsj"].HeaderText = "停留时间";
			dataGridView1.Columns["customText"].HeaderText = "自定义内容";
			dataGridView1.Columns["id"].Visible = false;
			dataGridView1.Columns["largeId"].Visible = false;
			RefreshVoid();
		}
	}

	public void RefreshVoid()
	{
		panel1.Controls.Clear();
		foreach (tb_large_screen_detaile tb_Large_Screen_Detaile in tb_Large_Screen_Detailes)
		{
			Label label = new Label();
			label.Text = tb_Large_Screen_Detaile.customText;
			label.Location = new Point(tb_Large_Screen_Detaile.x, tb_Large_Screen_Detaile.y);
			label.Size = new Size(tb_Large_Screen_Detaile.Width, tb_Large_Screen_Detaile.Height);
			panel1.Controls.Add(label);
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		VehicleNoInfoView vehicleNoInfoView = new VehicleNoInfoView();
		vehicleNoInfoView.VehicleNo = "豫A12345";
		vehicleNoInfoView.emissionStandard = "国5";
		vehicleNoInfoView.fuelType = "汽油";
		vehicleNoInfoView.TrafficStatus = "允许通行";
		YB_SDK.YBLedGDSendMes(tb_Large_Screen, vehicleNoInfoView, isOpen: true);
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
		this.label1 = new System.Windows.Forms.Label();
		this.textBoxlargeWidth = new System.Windows.Forms.TextBox();
		this.textBoxlargeHeight = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.bar2 = new DevExpress.XtraBars.Bar();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.textBoxIP = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.textBoxlargeName = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		this.tableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(45, 165);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(46, 21);
		this.label1.TabIndex = 0;
		this.label1.Text = "屏宽:";
		this.textBoxlargeWidth.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBoxlargeWidth.Location = new System.Drawing.Point(97, 162);
		this.textBoxlargeWidth.Name = "textBoxlargeWidth";
		this.textBoxlargeWidth.Size = new System.Drawing.Size(102, 29);
		this.textBoxlargeWidth.TabIndex = 1;
		this.textBoxlargeWidth.TextChanged += new System.EventHandler(textBoxlargeWidth_TextChanged);
		this.textBoxlargeWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.textBoxlargeHeight.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBoxlargeHeight.Location = new System.Drawing.Point(275, 164);
		this.textBoxlargeHeight.Name = "textBoxlargeHeight";
		this.textBoxlargeHeight.Size = new System.Drawing.Size(102, 29);
		this.textBoxlargeHeight.TabIndex = 3;
		this.textBoxlargeHeight.TextChanged += new System.EventHandler(textBoxlargeHeight_TextChanged);
		this.textBoxlargeHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(223, 167);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(46, 21);
		this.label2.TabIndex = 2;
		this.label2.Text = "屏高:";
		this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel1.Location = new System.Drawing.Point(170, 97);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(256, 64);
		this.panel1.TabIndex = 4;
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[3] { this.barButtonItem1, this.barButtonItem4, this.barButtonItem2 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 100;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[3]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.bar2.OptionsBar.MultiLine = true;
		this.bar2.OptionsBar.UseWholeRow = true;
		this.bar2.Text = "Main menu";
		this.barButtonItem1.Caption = "保存";
		this.barButtonItem1.Id = 94;
		this.barButtonItem1.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.ide_32x32;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "发送固定节目";
		this.barButtonItem2.Id = 99;
		this.barButtonItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.convert_32x321;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem4.Caption = "关闭";
		this.barButtonItem4.Id = 98;
		this.barButtonItem4.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.cancel_32x32;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(1348, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 791);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(1348, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 751);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(1348, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 751);
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.dataGridView1.Location = new System.Drawing.Point(0, 317);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowTemplate.Height = 26;
		this.dataGridView1.Size = new System.Drawing.Size(1348, 474);
		this.dataGridView1.TabIndex = 9;
		this.button1.Location = new System.Drawing.Point(30, 268);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(104, 36);
		this.button1.TabIndex = 10;
		this.button1.Text = "添加";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.Location = new System.Drawing.Point(156, 268);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(104, 36);
		this.button2.TabIndex = 11;
		this.button2.Text = "修改";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button3.Location = new System.Drawing.Point(285, 268);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(104, 36);
		this.button3.TabIndex = 12;
		this.button3.Text = "删除";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.textBoxIP.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBoxIP.Location = new System.Drawing.Point(97, 59);
		this.textBoxIP.Name = "textBoxIP";
		this.textBoxIP.Size = new System.Drawing.Size(280, 29);
		this.textBoxIP.TabIndex = 18;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.Location = new System.Drawing.Point(62, 62);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(29, 21);
		this.label3.TabIndex = 17;
		this.label3.Text = "IP:";
		this.textBoxlargeName.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBoxlargeName.Location = new System.Drawing.Point(97, 108);
		this.textBoxlargeName.Name = "textBoxlargeName";
		this.textBoxlargeName.Size = new System.Drawing.Size(280, 29);
		this.textBoxlargeName.TabIndex = 20;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.Location = new System.Drawing.Point(15, 111);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(78, 21);
		this.label4.TabIndex = 19;
		this.label4.Text = "大屏名称:";
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
		this.tableLayoutPanel1.Location = new System.Drawing.Point(602, 46);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 1;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 258);
		this.tableLayoutPanel1.TabIndex = 25;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1348, 791);
		base.Controls.Add(this.textBoxlargeName);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.textBoxIP);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.dataGridView1);
		base.Controls.Add(this.textBoxlargeHeight);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.textBoxlargeWidth);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "LargeScreenSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "大屏设置";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		this.tableLayoutPanel1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
