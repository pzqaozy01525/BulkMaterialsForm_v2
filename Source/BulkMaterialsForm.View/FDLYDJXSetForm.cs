// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.FDLYDJXSetForm

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class FDLYDJXSetForm : Form
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

	private TableLayoutPanel tableLayoutPanel1;

	private Label label1;

	private TextBox textBox1;

	private TextBox textBox2;

	private Label label2;

	private Label label3;

	private Label label4;

	private Label label5;

	private Label label6;

	private Label label7;

	private Label label8;

	private Label label9;

	private Label label10;

	private Label label11;

	private Label label12;

	private TextBox textBox3;

	private TextBox textBox4;

	private TextBox textBox5;

	private TextBox textBox6;

	private TextBox textBox7;

	private TextBox textBox8;

	private TextBox textBox9;

	private ComboBox comboBox1;

	private ComboBox comboBox2;

	private DateTimePicker dateTimePicker1;

	public FDLYDJXSetForm()
	{
		InitializeComponent();
		base.Load += FDLYDJXSetForm_Load;
	}

	private void FDLYDJXSetForm_Load(object sender, EventArgs e)
	{
		if (type == 0)
		{
			dateTimePicker1.Value = DateTime.Now;
			return;
		}
		tb_nonRoad tb_nonRoad2 = new DataServerContext<tb_nonRoad>().Current.GetList((tb_nonRoad it) => it.id == id).FirstOrDefault();
		if (tb_nonRoad2 != null)
		{
			textBox1.Text = tb_nonRoad2.hbdjh;
			dateTimePicker1.Value = tb_nonRoad2.jxscrq;
			textBox2.Text = tb_nonRoad2.car_no;
			comboBox1.SelectedItem = tb_nonRoad2.pfjd;
			comboBox2.SelectedItem = tb_nonRoad2.ryxl;
			textBox3.Text = tb_nonRoad2.jxzl;
			textBox4.Text = tb_nonRoad2.pin;
			textBox5.Text = tb_nonRoad2.jxxh;
			textBox6.Text = tb_nonRoad2.fdjxh;
			textBox7.Text = tb_nonRoad2.fdjcs;
			textBox8.Text = tb_nonRoad2.fdjbh;
			textBox9.Text = tb_nonRoad2.shr;
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("环保登记号码不能为空");
			return;
		}
		string pfjd = "";
		if (comboBox1.SelectedItem != null)
		{
			pfjd = comboBox1.SelectedItem.ToString();
		}
		string ryxl = "";
		if (comboBox2.SelectedItem != null)
		{
			ryxl = comboBox2.SelectedItem.ToString();
		}
		DataServerContext<tb_nonRoad> dataServerContext = new DataServerContext<tb_nonRoad>();
		if (type == 0)
		{
			tb_nonRoad tb_nonRoad2 = new tb_nonRoad();
			tb_nonRoad2.hbdjh = textBox1.Text;
			tb_nonRoad2.jxscrq = Convert.ToDateTime(dateTimePicker1.Value);
			tb_nonRoad2.car_no = textBox2.Text;
			tb_nonRoad2.pfjd = pfjd;
			tb_nonRoad2.ryxl = ryxl;
			tb_nonRoad2.jxzl = textBox3.Text;
			tb_nonRoad2.pin = textBox4.Text;
			tb_nonRoad2.jxxh = textBox5.Text;
			tb_nonRoad2.fdjxh = textBox6.Text;
			tb_nonRoad2.fdjcs = textBox7.Text;
			tb_nonRoad2.fdjbh = textBox8.Text;
			tb_nonRoad2.shr = textBox9.Text;
			if (dataServerContext.Current.AddReturnIdentity(tb_nonRoad2) > 0)
			{
				MessageBox.Show("保存成功");
				Close();
			}
			else
			{
				MessageBox.Show("保存失败");
			}
		}
		else if (dataServerContext.Current.Modify((tb_nonRoad p) => new tb_nonRoad
		{
			hbdjh = textBox1.Text,
			jxscrq = Convert.ToDateTime(dateTimePicker1.Value),
			car_no = textBox2.Text,
			pfjd = pfjd,
			ryxl = ryxl,
			jxzl = textBox3.Text,
			pin = textBox4.Text,
			jxxh = textBox5.Text,
			fdjxh = textBox6.Text,
			fdjcs = textBox7.Text,
			fdjbh = textBox8.Text,
			shr = textBox9.Text
		}, (tb_nonRoad p) => p.id == id))
		{
			MessageBox.Show("修改成功");
			Close();
		}
		else
		{
			MessageBox.Show("修改失败");
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
		this.components = new System.ComponentModel.Container();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.bar2 = new DevExpress.XtraBars.Bar();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.textBox6 = new System.Windows.Forms.TextBox();
		this.textBox7 = new System.Windows.Forms.TextBox();
		this.textBox8 = new System.Windows.Forms.TextBox();
		this.textBox9 = new System.Windows.Forms.TextBox();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		this.tableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[3] { this.barButtonItem2, this.barButtonItem3, this.barButtonItem4 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 99;
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
		this.barButtonItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.apply_32x322;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
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
		this.barDockControlTop.Size = new System.Drawing.Size(815, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 519);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(815, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 479);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(815, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 479);
		this.tableLayoutPanel1.ColumnCount = 5;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81f));
		this.tableLayoutPanel1.Controls.Add(this.textBox2, 3, 0);
		this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
		this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
		this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
		this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
		this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
		this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
		this.tableLayoutPanel1.Controls.Add(this.label8, 2, 3);
		this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
		this.tableLayoutPanel1.Controls.Add(this.label10, 2, 4);
		this.tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
		this.tableLayoutPanel1.Controls.Add(this.label12, 2, 5);
		this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
		this.tableLayoutPanel1.Controls.Add(this.textBox4, 3, 2);
		this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 3);
		this.tableLayoutPanel1.Controls.Add(this.textBox6, 3, 3);
		this.tableLayoutPanel1.Controls.Add(this.textBox7, 1, 4);
		this.tableLayoutPanel1.Controls.Add(this.textBox8, 3, 4);
		this.tableLayoutPanel1.Controls.Add(this.textBox9, 1, 5);
		this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 1);
		this.tableLayoutPanel1.Controls.Add(this.comboBox2, 3, 1);
		this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 3, 5);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 6;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(815, 479);
		this.tableLayoutPanel1.TabIndex = 4;
		this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox2.Location = new System.Drawing.Point(490, 25);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(241, 29);
		this.textBox2.TabIndex = 3;
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(370, 29);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(114, 21);
		this.label2.TabIndex = 2;
		this.label2.Text = "车牌号";
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(3, 29);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(114, 21);
		this.label1.TabIndex = 0;
		this.label1.Text = "环保登记号码";
		this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox1.Location = new System.Drawing.Point(123, 25);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(241, 29);
		this.textBox1.TabIndex = 1;
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.Location = new System.Drawing.Point(3, 108);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(114, 21);
		this.label3.TabIndex = 4;
		this.label3.Text = "排放阶段";
		this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.Location = new System.Drawing.Point(370, 108);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(114, 21);
		this.label4.TabIndex = 5;
		this.label4.Text = "燃油类型";
		this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label5.Location = new System.Drawing.Point(3, 187);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(114, 21);
		this.label5.TabIndex = 6;
		this.label5.Text = "机械种类";
		this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label6.Location = new System.Drawing.Point(370, 187);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(114, 21);
		this.label6.TabIndex = 7;
		this.label6.Text = "PIN";
		this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label7.Location = new System.Drawing.Point(3, 266);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(114, 21);
		this.label7.TabIndex = 8;
		this.label7.Text = "机械型号";
		this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(370, 266);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(114, 21);
		this.label8.TabIndex = 9;
		this.label8.Text = "发动机型号";
		this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label9.Location = new System.Drawing.Point(3, 345);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(114, 21);
		this.label9.TabIndex = 10;
		this.label9.Text = "发动机厂商";
		this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label10.AutoSize = true;
		this.label10.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label10.Location = new System.Drawing.Point(370, 345);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(114, 21);
		this.label10.TabIndex = 11;
		this.label10.Text = "发动机编号";
		this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label11.Location = new System.Drawing.Point(3, 426);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(114, 21);
		this.label11.TabIndex = 12;
		this.label11.Text = "所属人";
		this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label12.AutoSize = true;
		this.label12.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label12.Location = new System.Drawing.Point(370, 426);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(114, 21);
		this.label12.TabIndex = 13;
		this.label12.Text = "机械生产日期";
		this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox3.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox3.Location = new System.Drawing.Point(123, 183);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(241, 29);
		this.textBox3.TabIndex = 14;
		this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox4.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox4.Location = new System.Drawing.Point(490, 183);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(241, 29);
		this.textBox4.TabIndex = 15;
		this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox5.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox5.Location = new System.Drawing.Point(123, 262);
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(241, 29);
		this.textBox5.TabIndex = 16;
		this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox6.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox6.Location = new System.Drawing.Point(490, 262);
		this.textBox6.Name = "textBox6";
		this.textBox6.Size = new System.Drawing.Size(241, 29);
		this.textBox6.TabIndex = 17;
		this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox7.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox7.Location = new System.Drawing.Point(123, 341);
		this.textBox7.Name = "textBox7";
		this.textBox7.Size = new System.Drawing.Size(241, 29);
		this.textBox7.TabIndex = 18;
		this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox8.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox8.Location = new System.Drawing.Point(490, 341);
		this.textBox8.Name = "textBox8";
		this.textBox8.Size = new System.Drawing.Size(241, 29);
		this.textBox8.TabIndex = 19;
		this.textBox9.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox9.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox9.Location = new System.Drawing.Point(123, 422);
		this.textBox9.Name = "textBox9";
		this.textBox9.Size = new System.Drawing.Size(241, 29);
		this.textBox9.TabIndex = 20;
		this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[10] { "国0", "国1", "国2", "国3", "国4", "国5", "国6", "国7", "电动", "无" });
		this.comboBox1.Location = new System.Drawing.Point(123, 104);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(241, 29);
		this.comboBox1.TabIndex = 21;
		this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.comboBox2.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Items.AddRange(new object[14]
		{
			"汽油", "柴油", "电", "混合油", "天然气", "液化石油气", "甲醇", "乙醇", "太阳能", "混合动力",
			"氢", "生物燃料", "无", "其他"
		});
		this.comboBox2.Location = new System.Drawing.Point(490, 104);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(241, 29);
		this.comboBox2.TabIndex = 22;
		this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.dateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.dateTimePicker1.Location = new System.Drawing.Point(490, 422);
		this.dateTimePicker1.Name = "dateTimePicker1";
		this.dateTimePicker1.Size = new System.Drawing.Size(241, 29);
		this.dateTimePicker1.TabIndex = 23;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(815, 519);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "FDLYDJXSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "非道路移动机械登记";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
