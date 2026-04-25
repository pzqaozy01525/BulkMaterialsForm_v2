// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Views
// Type: BulkMaterialsForm.Views.LargeScreenSetForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.Views;

public class LargeScreenSetForm : Form
{
	public int type;

	public int id;

	public bool isSave;

	public List<tb_large_screen_detaile> ledDetailes;

	private tb_large_screen tb_LedInfo;

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

	private TextBox textBox2;

	private Label label1;

	private Button button3;

	private Button button1;

	private DataGridView dataGridView1;

	private Button button2;

	public LargeScreenSetForm()
	{
		InitializeComponent();
		base.FormClosed += LargeScreenSetForm_FormClosed;
		base.Load += LargeScreenSetForm_Load;
	}

	private void LargeScreenSetForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (!isSave && type == 0)
		{
			new DataServerContext<tb_large_screen>().Current.Delete((tb_large_screen it) => it.id == id);
			new DataServerContext<tb_large_screen_detaile>().Current.Delete((tb_large_screen_detaile it) => it.largeId == id);
		}
	}

	private void LargeScreenSetForm_Load(object sender, EventArgs e)
	{
		if (type == 1)
		{
			DataServerContext<tb_large_screen> dataServerContext = new DataServerContext<tb_large_screen>();
			tb_LedInfo = dataServerContext.Current.GetList((tb_large_screen it) => it.id == id).FirstOrDefault();
			if (tb_LedInfo != null)
			{
				textBox2.Text = tb_LedInfo.IP;
				textBox1.Text = tb_LedInfo.largeName;
			}
			DataColumns();
		}
		else
		{
			DataServerContext<tb_large_screen> dataServerContext2 = new DataServerContext<tb_large_screen>();
			tb_LedInfo = new tb_large_screen();
			id = dataServerContext2.Current.AddReturnIdentity(tb_LedInfo);
			tb_LedInfo.id = id;
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("名称不能为空");
			return;
		}
		if (string.IsNullOrWhiteSpace(textBox2.Text))
		{
			MessageBox.Show("IP不能为空");
			return;
		}
		DataServerContext<tb_large_screen> dataServerContext = new DataServerContext<tb_large_screen>();
		tb_LedInfo.IP = textBox2.Text;
		tb_LedInfo.largeName = textBox1.Text;
		if (dataServerContext.Current.Modify(tb_LedInfo))
		{
			isSave = true;
			MessageBox.Show("保存成功");
			Close();
		}
		else
		{
			MessageBox.Show("保存失败");
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

	private void button1_Click(object sender, EventArgs e)
	{
		ZHSetForm zHSetForm = new ZHSetForm();
		zHSetForm.id = tb_LedInfo.id;
		zHSetForm.ShowDialog();
		if (zHSetForm.isSave)
		{
			DataColumns();
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		if (int.Parse(dataGridView1.Rows.Count.ToString()) == 0)
		{
			MessageBox.Show("请选择一行数据！");
		}
		else if (dataGridView1.CurrentRow == null)
		{
			MessageBox.Show("请选择一行数据！");
		}
		else if (int.Parse(dataGridView1.CurrentRow.Index.ToString()) >= 0)
		{
			tb_large_screen_detaile tb_LedDetaile = dataGridView1.CurrentRow.DataBoundItem as tb_large_screen_detaile;
			if (MessageBox.Show("确认删除该大屏详细信息？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes && new DataServerContext<tb_large_screen_detaile>().Current.Delete((tb_large_screen_detaile it) => it.id == tb_LedDetaile.id))
			{
				DataColumns();
			}
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (int.Parse(dataGridView1.Rows.Count.ToString()) == 0)
		{
			MessageBox.Show("请选择一行数据！");
		}
		else if (int.Parse(dataGridView1.CurrentRow.Index.ToString()) >= 0)
		{
			tb_large_screen_detaile ledDetaile = dataGridView1.CurrentRow.DataBoundItem as tb_large_screen_detaile;
			ZHSetForm zHSetForm = new ZHSetForm();
			zHSetForm.type = 1;
			zHSetForm.ledDetaile = ledDetaile;
			zHSetForm.ShowDialog();
			DataColumns();
		}
	}

	public void DataColumns()
	{
		ledDetailes = new DataServerContext<tb_large_screen_detaile>().Current.GetList((tb_large_screen_detaile it) => it.largeId == id);
		dataGridView1.DataSource = ledDetailes;
		dataGridView1.Columns["charId"].HeaderText = "字符ID";
		dataGridView1.Columns["customText"].HeaderText = "自定义内容";
		dataGridView1.Columns["fontColor"].HeaderText = "字体颜色";
		dataGridView1.Columns["x"].Visible = false;
		dataGridView1.Columns["y"].Visible = false;
		dataGridView1.Columns["Width"].Visible = false;
		dataGridView1.Columns["Height"].Visible = false;
		dataGridView1.Columns["xstx"].Visible = false;
		dataGridView1.Columns["yxsd"].Visible = false;
		dataGridView1.Columns["tlsj"].Visible = false;
		dataGridView1.Columns["largeId"].Visible = false;
		dataGridView1.Columns["id"].Visible = false;
		dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkMaterialsForm.Views.LargeScreenSetForm));
		this.barManager1 = new DevExpress.XtraBars.BarManager();
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
		this.button3 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.button2 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[3] { this.barButtonItem2, this.barButtonItem3, this.barButtonItem4 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 100;
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
		this.barButtonItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.apply_32x32;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "取消";
		this.barButtonItem3.Id = 97;
		this.barButtonItem3.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.left_32x32;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem4.Caption = "关闭";
		this.barButtonItem4.Id = 98;
		this.barButtonItem4.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.cancel_32x321;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(771, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 474);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(771, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 434);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(771, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 434);
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Location = new System.Drawing.Point(93, 79);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(248, 29);
		this.textBox1.TabIndex = 59;
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(36, 82);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(42, 21);
		this.label8.TabIndex = 58;
		this.label8.Text = "名称";
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(442, 79);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(248, 29);
		this.textBox2.TabIndex = 76;
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(402, 82);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(25, 21);
		this.label1.TabIndex = 75;
		this.label1.Text = "IP";
		this.button3.Location = new System.Drawing.Point(281, 144);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(104, 36);
		this.button3.TabIndex = 79;
		this.button3.Text = "删除";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.button1.Location = new System.Drawing.Point(50, 144);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(104, 36);
		this.button1.TabIndex = 77;
		this.button1.Text = "添加";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.dataGridView1.AllowUserToAddRows = false;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.dataGridView1.Location = new System.Drawing.Point(0, 206);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowTemplate.Height = 23;
		this.dataGridView1.Size = new System.Drawing.Size(771, 268);
		this.dataGridView1.TabIndex = 80;
		this.button2.Location = new System.Drawing.Point(164, 144);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(104, 36);
		this.button2.TabIndex = 85;
		this.button2.Text = "修改";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(771, 474);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.dataGridView1);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "LargeScreenSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "大屏管理";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
