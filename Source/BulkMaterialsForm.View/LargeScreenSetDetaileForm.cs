// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.LargeScreenSetDetaileForm

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

public class LargeScreenSetDetaileForm : Form
{
	public bool isSave;

	public tb_large_screen_detaile tb_Large_Screen_Detaile;

	public int type;

	public int id;

	public int largeId;

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

	private Label label8;

	private TextBox textBox6;

	private Label label5;

	private Label label4;

	private TextBox textBox4;

	private Label label3;

	private TextBox textBox3;

	private Label label2;

	private TextBox textBox2;

	private Label label1;

	private TableLayoutPanel tableLayoutPanel1;

	private Label label6;

	private TextBox textBox7;

	private Label label7;

	private TextBox textBox8;

	private Button button1;

	private Label label9;

	private Label label10;

	private ComboBox comboBox1;

	private Label label11;

	private ComboBox comboBox2;

	public LargeScreenSetDetaileForm()
	{
		InitializeComponent();
		base.Load += LargeScreenSetDetaileForm_Load;
	}

	private void LargeScreenSetDetaileForm_Load(object sender, EventArgs e)
	{
		if (type == 0)
		{
			tb_Large_Screen_Detaile = new tb_large_screen_detaile();
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "16";
			textBox6.Text = "1";
			textBox7.Text = "60";
			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			return;
		}
		DataServerContext<tb_large_screen_detaile> dataServerContext = new DataServerContext<tb_large_screen_detaile>();
		tb_Large_Screen_Detaile = dataServerContext.Current.GetList((tb_large_screen_detaile it) => it.id == id).FirstOrDefault();
		if (tb_Large_Screen_Detaile != null)
		{
			textBox1.Text = tb_Large_Screen_Detaile.x.ToString();
			textBox2.Text = tb_Large_Screen_Detaile.y.ToString();
			textBox3.Text = tb_Large_Screen_Detaile.Width.ToString();
			textBox4.Text = tb_Large_Screen_Detaile.Height.ToString();
			comboBox1.SelectedItem = tb_Large_Screen_Detaile.xstx;
			textBox6.Text = tb_Large_Screen_Detaile.yxsd.ToString();
			textBox7.Text = tb_Large_Screen_Detaile.tlsj.ToString();
			textBox8.Text = tb_Large_Screen_Detaile.customText;
			comboBox2.SelectedItem = tb_Large_Screen_Detaile.fontColor;
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		ValueForm valueForm = new ValueForm();
		valueForm.ShowDialog();
		if (valueForm.isSave)
		{
			textBox8.Text += valueForm.text;
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("X不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBox2.Text))
		{
			MessageBox.Show("Y不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBox3.Text))
		{
			MessageBox.Show("宽不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBox4.Text))
		{
			MessageBox.Show("高不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBox6.Text))
		{
			MessageBox.Show("运行速度不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBox7.Text))
		{
			MessageBox.Show("停留时间不能为空");
		}
		else if (comboBox1.SelectedItem == null)
		{
			MessageBox.Show("显示特效不能为空");
		}
		else if (type == 0)
		{
			tb_Large_Screen_Detaile.x = Convert.ToInt32(textBox1.Text);
			tb_Large_Screen_Detaile.y = Convert.ToInt32(textBox2.Text);
			tb_Large_Screen_Detaile.Width = Convert.ToInt32(textBox3.Text);
			tb_Large_Screen_Detaile.Height = Convert.ToInt32(textBox4.Text);
			tb_Large_Screen_Detaile.xstx = comboBox1.SelectedItem.ToString();
			tb_Large_Screen_Detaile.yxsd = Convert.ToInt32(textBox6.Text);
			tb_Large_Screen_Detaile.tlsj = Convert.ToInt32(textBox7.Text);
			tb_Large_Screen_Detaile.customText = textBox8.Text;
			tb_Large_Screen_Detaile.largeId = largeId;
			tb_Large_Screen_Detaile.fontColor = comboBox2.SelectedItem.ToString();
			if (new DataServerContext<tb_large_screen_detaile>().Current.Add(tb_Large_Screen_Detaile))
			{
				MessageBox.Show("保存成功");
				isSave = true;
				Close();
			}
		}
		else if (new DataServerContext<tb_large_screen_detaile>().Current.Modify((tb_large_screen_detaile p) => new tb_large_screen_detaile
		{
			x = Convert.ToInt32(textBox1.Text),
			y = Convert.ToInt32(textBox2.Text),
			Width = Convert.ToInt32(textBox3.Text),
			Height = Convert.ToInt32(textBox4.Text),
			xstx = comboBox1.SelectedItem.ToString(),
			yxsd = Convert.ToInt32(textBox6.Text),
			tlsj = Convert.ToInt32(textBox7.Text),
			customText = textBox8.Text,
			fontColor = comboBox2.SelectedItem.ToString()
		}, (tb_large_screen_detaile p) => p.id == id))
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
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.textBox6 = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.label7 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.textBox7 = new System.Windows.Forms.TextBox();
		this.textBox8 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label11 = new System.Windows.Forms.Label();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
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
		this.barDockControlTop.Size = new System.Drawing.Size(617, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(617, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 410);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(617, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 410);
		this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Location = new System.Drawing.Point(170, 5);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(329, 34);
		this.textBox1.TabIndex = 42;
		this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(138, 9);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(26, 27);
		this.label8.TabIndex = 41;
		this.label8.Text = "X";
		this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(170, 50);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(329, 34);
		this.textBox2.TabIndex = 44;
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(139, 54);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(25, 27);
		this.label1.TabIndex = 43;
		this.label1.Text = "Y";
		this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.textBox3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox3.Location = new System.Drawing.Point(170, 95);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(329, 34);
		this.textBox3.TabIndex = 46;
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(132, 99);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(32, 27);
		this.label2.TabIndex = 45;
		this.label2.Text = "宽";
		this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.textBox4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox4.Location = new System.Drawing.Point(170, 140);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(329, 34);
		this.textBox4.TabIndex = 48;
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.Location = new System.Drawing.Point(132, 144);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(32, 27);
		this.label3.TabIndex = 47;
		this.label3.Text = "高";
		this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.Location = new System.Drawing.Point(72, 189);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(92, 27);
		this.label4.TabIndex = 49;
		this.label4.Text = "显示特效";
		this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.textBox6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox6.Location = new System.Drawing.Point(170, 230);
		this.textBox6.Name = "textBox6";
		this.textBox6.Size = new System.Drawing.Size(329, 34);
		this.textBox6.TabIndex = 52;
		this.textBox6.Text = "1";
		this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label5.Location = new System.Drawing.Point(72, 234);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(92, 27);
		this.label5.TabIndex = 51;
		this.label5.Text = "运行速度";
		this.tableLayoutPanel1.ColumnCount = 3;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114f));
		this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
		this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.textBox6, 1, 5);
		this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
		this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
		this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
		this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
		this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 3);
		this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
		this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
		this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
		this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
		this.tableLayoutPanel1.Controls.Add(this.textBox7, 1, 6);
		this.tableLayoutPanel1.Controls.Add(this.textBox8, 1, 7);
		this.tableLayoutPanel1.Controls.Add(this.button1, 2, 7);
		this.tableLayoutPanel1.Controls.Add(this.label9, 2, 5);
		this.tableLayoutPanel1.Controls.Add(this.label10, 2, 6);
		this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 4);
		this.tableLayoutPanel1.Controls.Add(this.label11, 0, 8);
		this.tableLayoutPanel1.Controls.Add(this.comboBox2, 1, 8);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 9;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(617, 410);
		this.tableLayoutPanel1.TabIndex = 53;
		this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label7.AutoSize = true;
		this.label7.BackColor = System.Drawing.Color.Transparent;
		this.label7.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label7.Location = new System.Drawing.Point(52, 324);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(112, 27);
		this.label7.TabIndex = 55;
		this.label7.Text = "自定义内容";
		this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label6.AutoSize = true;
		this.label6.BackColor = System.Drawing.Color.Transparent;
		this.label6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label6.Location = new System.Drawing.Point(72, 279);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(92, 27);
		this.label6.TabIndex = 53;
		this.label6.Text = "停留时间";
		this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.textBox7.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox7.Location = new System.Drawing.Point(170, 275);
		this.textBox7.Name = "textBox7";
		this.textBox7.Size = new System.Drawing.Size(329, 34);
		this.textBox7.TabIndex = 54;
		this.textBox7.Text = "10";
		this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.textBox8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox8.Location = new System.Drawing.Point(170, 320);
		this.textBox8.Name = "textBox8";
		this.textBox8.Size = new System.Drawing.Size(329, 34);
		this.textBox8.TabIndex = 56;
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.button1.Location = new System.Drawing.Point(515, 323);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(88, 28);
		this.button1.TabIndex = 57;
		this.button1.Text = "插入字段";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold);
		this.label9.Location = new System.Drawing.Point(505, 234);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(63, 27);
		this.label9.TabIndex = 58;
		this.label9.Text = "1~24";
		this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.label10.AutoSize = true;
		this.label10.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold);
		this.label10.Location = new System.Drawing.Point(505, 279);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(32, 27);
		this.label10.TabIndex = 59;
		this.label10.Text = "秒";
		this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[6] { "静止显示", "快速打出", "向左移动", "向右移动", "向上移动", "向下移动" });
		this.comboBox1.Location = new System.Drawing.Point(170, 183);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(329, 35);
		this.comboBox1.TabIndex = 60;
		this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.label11.AutoSize = true;
		this.label11.BackColor = System.Drawing.Color.Transparent;
		this.label11.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label11.Location = new System.Drawing.Point(72, 371);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(92, 27);
		this.label11.TabIndex = 61;
		this.label11.Text = "字体颜色";
		this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.comboBox2.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Items.AddRange(new object[3] { "红色", "绿色", "黄色" });
		this.comboBox2.Location = new System.Drawing.Point(170, 370);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(329, 29);
		this.comboBox2.TabIndex = 89;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(617, 450);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "LargeScreenSetDetaileForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "文字管理";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
