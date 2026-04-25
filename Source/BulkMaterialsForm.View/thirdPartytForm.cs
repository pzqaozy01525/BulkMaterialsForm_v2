// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.thirdPartytForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class thirdPartytForm : Form
{
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

	private TabControl tabControl1;

	private TabPage tabPage1;

	private CheckBox checkBox1;

	private TextBox textBox1;

	private Label label1;

	private TextBox textBox3;

	private Label label3;

	private TextBox textBox2;

	private Label label2;

	private Button button1;

	private Button button2;

	private Label label4;

	private TextBox textBox5;

	private Label label6;

	private TextBox textBox4;

	private Label label5;

	private TextBox textBox6;

	private Label label7;

	public thirdPartytForm()
	{
		InitializeComponent();
		base.Load += ThirdPartytForm_Load;
	}

	private void ThirdPartytForm_Load(object sender, EventArgs e)
	{
		textBox1.Text = MainData.TXappKey;
		textBox2.Text = MainData.TXappSecret;
		textBox3.Text = MainData.TXServer;
		checkBox1.Checked = MainData.TXIsOpen;
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		New_IniFile.WriteContentValue("窗体框架配制", "图讯化工园区服务地址", textBox1.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "图讯化工园区appKey", textBox2.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "图讯化工园区appSecret", textBox3.Text, MainData.Spath);
		MainData.TXappKey = textBox2.Text;
		MainData.TXappSecret = textBox3.Text;
		MainData.TXServer = textBox1.Text;
		MainData.TXIsOpen = checkBox1.Checked;
		MessageBox.Show("保存成功,请重启软件！");
		Close();
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
		List<tb_Channel> list = new DataServerContext<tb_Channel>().Current.GetList();
		if (list != null && list.Count > 0)
		{
			CommonHelper.TXHGInOutUpLoad(list[0].guid, DateTime.Now, "豫A12345", list[0].ChannelName, list[0].ChannelType, Application.StartupPath + "\\ceshi.jpg");
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		List<tb_Channel> list = new DataServerContext<tb_Channel>().Current.GetList();
		if (list == null || list.Count <= 0)
		{
			return;
		}
		string text = "";
		foreach (tb_Channel item in list)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("accesscontrolId", item.guid);
			dictionary.Add("chemparkCode", "4102000001");
			dictionary.Add("accesscontrolName", item.ChannelName);
			dictionary.Add("equipType", 4);
			dictionary.Add("longitude", textBox4.Text);
			dictionary.Add("latitude", textBox5.Text);
			dictionary.Add("actived", 1);
			dictionary.Add("creator", textBox6.Text);
			dictionary.Add("createTime", DateTime.Now.ToString("yyyyMMddHHmmss"));
			dictionary.Add("updator", textBox6.Text);
			dictionary.Add("updateTime", DateTime.Now.ToString("yyyyMMddHHmmss"));
			TXHttpResultModel tXHGData = CommonHelper.GetTXHGData(MainData.TXServer + "api/closedmanage/scmaccesscontrol/addOrUpdate", dictionary);
			if (tXHGData != null)
			{
				if (tXHGData.code == 1)
				{
					text = "推送成功";
					continue;
				}
				text = "推送失败原因：" + tXHGData.message;
				break;
			}
			text = "服务异常";
			break;
		}
		MessageBox.Show(text);
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
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.textBox6 = new System.Windows.Forms.TextBox();
		this.label7 = new System.Windows.Forms.Label();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
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
		this.barDockControlTop.Size = new System.Drawing.Size(784, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 413);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(784, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 373);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(784, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 373);
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.tabControl1.Location = new System.Drawing.Point(0, 40);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(784, 373);
		this.tabControl1.TabIndex = 4;
		this.tabPage1.Controls.Add(this.textBox6);
		this.tabPage1.Controls.Add(this.label7);
		this.tabPage1.Controls.Add(this.textBox5);
		this.tabPage1.Controls.Add(this.label6);
		this.tabPage1.Controls.Add(this.textBox4);
		this.tabPage1.Controls.Add(this.label5);
		this.tabPage1.Controls.Add(this.label4);
		this.tabPage1.Controls.Add(this.button2);
		this.tabPage1.Controls.Add(this.button1);
		this.tabPage1.Controls.Add(this.textBox3);
		this.tabPage1.Controls.Add(this.label3);
		this.tabPage1.Controls.Add(this.textBox2);
		this.tabPage1.Controls.Add(this.label2);
		this.tabPage1.Controls.Add(this.textBox1);
		this.tabPage1.Controls.Add(this.label1);
		this.tabPage1.Controls.Add(this.checkBox1);
		this.tabPage1.Location = new System.Drawing.Point(4, 30);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(776, 339);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "开封图讯化工园区管委会";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.textBox6.Location = new System.Drawing.Point(623, 28);
		this.textBox6.Name = "textBox6";
		this.textBox6.Size = new System.Drawing.Size(128, 29);
		this.textBox6.TabIndex = 15;
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(548, 31);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(56, 17);
		this.label7.TabIndex = 14;
		this.label7.Text = "推送人：";
		this.textBox5.Location = new System.Drawing.Point(416, 28);
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(128, 29);
		this.textBox5.TabIndex = 13;
		this.textBox5.Text = "1";
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(352, 31);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(42, 17);
		this.label6.TabIndex = 12;
		this.label6.Text = "纬度：";
		this.textBox4.Location = new System.Drawing.Point(198, 26);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(128, 29);
		this.textBox4.TabIndex = 11;
		this.textBox4.Text = "1";
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(134, 29);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(42, 17);
		this.label5.TabIndex = 10;
		this.label5.Text = "经度：";
		this.label4.AutoSize = true;
		this.label4.ForeColor = System.Drawing.Color.Red;
		this.label4.Location = new System.Drawing.Point(390, 232);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(294, 17);
		this.label4.TabIndex = 9;
		this.label4.Text = "通道呢里录入完毕以后再点击这里的推送通道信息！\r\n";
		this.button2.Location = new System.Drawing.Point(456, 265);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(132, 36);
		this.button2.TabIndex = 8;
		this.button2.Text = "推送通道信息";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button1.Location = new System.Drawing.Point(171, 265);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(132, 36);
		this.button1.TabIndex = 7;
		this.button1.Text = "测试上传记录";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.textBox3.Location = new System.Drawing.Point(133, 187);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(616, 29);
		this.textBox3.TabIndex = 6;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(20, 190);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(84, 17);
		this.label3.TabIndex = 5;
		this.label3.Text = "appSecret：";
		this.textBox2.Location = new System.Drawing.Point(133, 133);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(616, 29);
		this.textBox2.TabIndex = 4;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(37, 136);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(56, 17);
		this.label2.TabIndex = 3;
		this.label2.Text = "appKey：";
		this.textBox1.Location = new System.Drawing.Point(133, 79);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(616, 29);
		this.textBox1.TabIndex = 2;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(37, 82);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(70, 17);
		this.label1.TabIndex = 1;
		this.label1.Text = "服务地址：";
		this.checkBox1.AutoSize = true;
		this.checkBox1.Enabled = false;
		this.checkBox1.Location = new System.Drawing.Point(39, 28);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(93, 25);
		this.checkBox1.TabIndex = 0;
		this.checkBox1.Text = "是否开启";
		this.checkBox1.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(784, 413);
		base.Controls.Add(this.tabControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "thirdPartytForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "第三方对接";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
