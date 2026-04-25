// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.WhiteListSetForm

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

public class WhiteListSetForm : Form
{
	public int id;

	public int type;

	public string car_no = "";

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

	private TextBox textBox3;

	private Label label2;

	private TextBox textBox2;

	private Label label1;

	private TextBox textBox1;

	private Label label8;

	private Label label3;

	private ComboBox comboBox1;

	private Label label5;

	private Label label4;

	private DateTimePicker dateTimePicker1;

	private DateTimePicker dateTimePicker2;

	private TextBox textBox4;

	private Label label6;

	private Button button1;

	private Button button2;

	private Button button3;

	private Button button4;

	public WhiteListSetForm()
	{
		InitializeComponent();
		base.Load += WhiteListSetForm_Load;
	}

	private void WhiteListSetForm_Load(object sender, EventArgs e)
	{
		if (type == 1)
		{
			tb_car_info tb_car_info2 = new DataServerContext<tb_car_info>().Current.GetList((tb_car_info it) => it.id == id).FirstOrDefault();
			if (tb_car_info2 != null)
			{
				textBox2.Text = tb_car_info2.car_no;
				textBox1.Text = tb_car_info2.name;
				textBox3.Text = tb_car_info2.phone;
				comboBox1.SelectedItem = tb_car_info2.bz;
				car_no = tb_car_info2.car_no;
				if (tb_car_info2.startTime >= new DateTime(1997, 1, 1))
				{
					dateTimePicker1.Value = tb_car_info2.startTime;
				}
				else
				{
					dateTimePicker1.Value = DateTime.Now;
				}
				if (tb_car_info2.endTime >= new DateTime(1997, 1, 1))
				{
					dateTimePicker2.Value = tb_car_info2.endTime;
				}
				else
				{
					dateTimePicker2.Value = DateTime.Now.AddYears(1);
				}
				textBox4.Text = tb_car_info2.dep;
			}
		}
		else
		{
			dateTimePicker1.Value = DateTime.Now;
			dateTimePicker2.Value = DateTime.Now.AddYears(1);
			comboBox1.SelectedIndex = 1;
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		DataServerContext<tb_car_info> dataServerContext = new DataServerContext<tb_car_info>();
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("名称不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBox2.Text))
		{
			MessageBox.Show("车牌不能为空");
		}
		else if (type == 0)
		{
			tb_car_info tb_car_info2 = dataServerContext.Current.GetList((tb_car_info it) => it.car_no == textBox2.Text.ToUpper()).FirstOrDefault();
			if (tb_car_info2 != null)
			{
				MessageBox.Show("车牌已经存在");
				return;
			}
			tb_car_info2 = new tb_car_info();
			tb_car_info2.car_no = textBox2.Text.ToUpper();
			tb_car_info2.name = textBox1.Text;
			tb_car_info2.phone = textBox3.Text;
			tb_car_info2.bz = comboBox1.SelectedItem.ToString();
			tb_car_info2.dep = textBox4.Text;
			tb_car_info2.startTime = dateTimePicker1.Value.Date;
			tb_car_info2.endTime = dateTimePicker2.Value.AddDays(1.0).Date.AddMilliseconds(-1.0);
			if (dataServerContext.Current.Add(tb_car_info2))
			{
				MessageBox.Show("保存成功");
				Close();
			}
			else
			{
				MessageBox.Show("保存失败");
			}
		}
		else if (!car_no.Equals(textBox2.Text) && dataServerContext.Current.GetList((tb_car_info it) => it.car_no == textBox2.Text.ToUpper()).FirstOrDefault() != null)
		{
			MessageBox.Show("车牌已经存在");
			Close();
		}
		else
		{
			DateTime start = dateTimePicker1.Value.Date;
			DateTime end = dateTimePicker2.Value.AddDays(1.0).Date.AddMilliseconds(-1.0);
			if (dataServerContext.Current.Modify((tb_car_info p) => new tb_car_info
			{
				name = textBox1.Text,
				car_no = textBox2.Text.ToUpper(),
				phone = textBox3.Text,
				bz = comboBox1.SelectedItem.ToString(),
				dep = textBox4.Text,
				startTime = start,
				endTime = end
			}, (tb_car_info p) => p.id == id))
			{
				MessageBox.Show("修改成功");
				Close();
			}
			else
			{
				MessageBox.Show("修改失败");
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

	private void button4_Click(object sender, EventArgs e)
	{
		dateTimePicker2.Value = DateTime.Now.AddYears(99);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		dateTimePicker2.Value = DateTime.Now.AddMonths(1);
	}

	private void button2_Click(object sender, EventArgs e)
	{
		dateTimePicker2.Value = DateTime.Now.AddMonths(3);
	}

	private void button3_Click(object sender, EventArgs e)
	{
		dateTimePicker2.Value = DateTime.Now.AddMonths(12);
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
		this.label3 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.button4 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[2] { this.barButtonItem2, this.barButtonItem4 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 99;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[2]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
		this.barButtonItem4.Caption = "关闭";
		this.barButtonItem4.Id = 98;
		this.barButtonItem4.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.cancel_32x32;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(531, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 457);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(531, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 417);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(531, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 417);
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Location = new System.Drawing.Point(190, 69);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(248, 34);
		this.textBox1.TabIndex = 42;
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(92, 72);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(52, 17);
		this.label8.TabIndex = 41;
		this.label8.Text = "名称 *";
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(190, 117);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(248, 34);
		this.textBox2.TabIndex = 44;
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(92, 120);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(72, 17);
		this.label1.TabIndex = 43;
		this.label1.Text = "车牌号 *";
		this.textBox3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox3.Location = new System.Drawing.Point(190, 165);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(248, 34);
		this.textBox3.TabIndex = 46;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(92, 168);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(72, 27);
		this.label2.TabIndex = 45;
		this.label2.Text = "手机号";
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.Location = new System.Drawing.Point(72, 260);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(92, 27);
		this.label3.TabIndex = 51;
		this.label3.Text = "车牌类型";
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[2] { "黑名单", "白名单" });
		this.comboBox1.Location = new System.Drawing.Point(190, 257);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(248, 35);
		this.comboBox1.TabIndex = 57;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.Location = new System.Drawing.Point(52, 312);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(112, 27);
		this.label4.TabIndex = 62;
		this.label4.Text = "有效期开始";
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label5.Location = new System.Drawing.Point(52, 367);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(112, 27);
		this.label5.TabIndex = 63;
		this.label5.Text = "有效期结束";
		this.dateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.dateTimePicker1.Location = new System.Drawing.Point(190, 306);
		this.dateTimePicker1.Name = "dateTimePicker1";
		this.dateTimePicker1.Size = new System.Drawing.Size(248, 34);
		this.dateTimePicker1.TabIndex = 64;
		this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.dateTimePicker2.Location = new System.Drawing.Point(190, 360);
		this.dateTimePicker2.Name = "dateTimePicker2";
		this.dateTimePicker2.Size = new System.Drawing.Size(248, 34);
		this.dateTimePicker2.TabIndex = 65;
		this.textBox4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox4.Location = new System.Drawing.Point(190, 209);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(248, 34);
		this.textBox4.TabIndex = 67;
		this.label6.AutoSize = true;
		this.label6.BackColor = System.Drawing.Color.Transparent;
		this.label6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label6.Location = new System.Drawing.Point(92, 212);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(52, 27);
		this.label6.TabIndex = 66;
		this.label6.Text = "部门";
		this.button1.Location = new System.Drawing.Point(190, 411);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(70, 28);
		this.button1.TabIndex = 72;
		this.button1.Text = "1个月";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.Location = new System.Drawing.Point(266, 411);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(70, 28);
		this.button2.TabIndex = 73;
		this.button2.Text = "3个月";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button3.Location = new System.Drawing.Point(342, 411);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(70, 28);
		this.button3.TabIndex = 74;
		this.button3.Text = "1年";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.button4.Location = new System.Drawing.Point(418, 411);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(70, 28);
		this.button4.TabIndex = 75;
		this.button4.Text = "永久";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(531, 457);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.textBox4);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.dateTimePicker2);
		base.Controls.Add(this.dateTimePicker1);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.comboBox1);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.textBox3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "WhiteListSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "车牌管理";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
