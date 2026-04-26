// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.SnapSetForm

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BulkMaterialsForm.DH;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Properties;
using BulkMaterialsForm.SDK;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class SnapSetForm : Form
{
	public int id;

	public int type;

	public bool isSave;

	private tb_videotape tb_Videotape;

	private IContainer components;

	private TextBox textBox1;

	private Label label8;

	private TextBox textBox2;

	private Label label1;

	private TextBox textBox3;

	private Label label2;

	private BarManager barManager1;

	private Bar bar2;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControl1;

	private BarButtonItem barButtonItem1;

	private TextBox textBox4;

	private Label label3;

	private TextBox textBox5;

	private Label label4;

	private Label label5;

	private ComboBox comboBox1;

	private Label label6;

	public SnapSetForm()
	{
		InitializeComponent();
		base.Load += SnapSetForm_Load;
	}

	private void SnapSetForm_Load(object sender, EventArgs e)
	{
		if (type == 1)
		{
			DataServerContext<tb_videotape> dataServerContext = new DataServerContext<tb_videotape>();
			tb_Videotape = dataServerContext.Current.GetList((tb_videotape it) => it.id == id).FirstOrDefault();
			if (tb_Videotape != null)
			{
				textBox1.Text = tb_Videotape.IP;
				textBox2.Text = tb_Videotape.doccode;
				textBox3.Text = tb_Videotape.pass;
				textBox4.Text = tb_Videotape.ChannelID.ToString();
				textBox5.Text = tb_Videotape.snapNumber.ToString();
				comboBox1.SelectedItem = tb_Videotape.type;
			}
		}
		else
		{
			textBox5.Text = "5";
			comboBox1.SelectedItem = "hk";
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("IP不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBox2.Text))
		{
			MessageBox.Show("账号不能为空");
		}
		else if (string.IsNullOrWhiteSpace(textBox3.Text))
		{
			MessageBox.Show("密码不能为空");
		}
		else if (type == 0)
		{
			tb_videotape tb_videotape2 = new tb_videotape();
			tb_videotape2.IP = textBox1.Text;
			tb_videotape2.doccode = textBox2.Text;
			tb_videotape2.pass = textBox3.Text;
			tb_videotape2.ChannelID = Convert.ToInt32(textBox4.Text);
			tb_videotape2.snapNumber = Convert.ToInt32(textBox5.Text);
			tb_videotape2.type = comboBox1.SelectedItem.ToString();
			if (new DataServerContext<tb_videotape>().Current.Add(tb_videotape2))
			{
				MessageBox.Show("保存成功");
				isSave = true;
				Close();
			}
		}
		else if (new DataServerContext<tb_videotape>().Current.Modify((tb_videotape p) => new tb_videotape
		{
			IP = textBox1.Text,
			doccode = textBox2.Text,
			pass = textBox3.Text,
			ChannelID = Convert.ToInt32(textBox4.Text),
			snapNumber = Convert.ToInt32(textBox5.Text),
			type = comboBox1.SelectedItem.ToString()
		}, (tb_videotape p) => p.id == id))
		{
			MessageBox.Show("修改成功");
			isSave = true;
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

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (comboBox1.SelectedItem.ToString().Equals("hk"))
		{
			MainData.init_Sdk_HaiKang();
			CHCNetSDK.NET_DVR_USER_LOGIN_INFO pLoginInfo = default(CHCNetSDK.NET_DVR_USER_LOGIN_INFO);
			byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(textBox1.Text);
			pLoginInfo.sDeviceAddress = new byte[129];
			bytes.CopyTo(pLoginInfo.sDeviceAddress, 0);
			byte[] bytes2 = Encoding.GetEncoding("GBK").GetBytes(textBox2.Text);
			pLoginInfo.sUserName = new byte[64];
			bytes2.CopyTo(pLoginInfo.sUserName, 0);
			byte[] bytes3 = Encoding.GetEncoding("GBK").GetBytes(textBox3.Text);
			pLoginInfo.sPassword = new byte[64];
			bytes3.CopyTo(pLoginInfo.sPassword, 0);
			pLoginInfo.wPort = 8000;
			pLoginInfo.bUseAsynLogin = false;
			CHCNetSDK.NET_DVR_DEVICEINFO_V40 lpDeviceInfo = default(CHCNetSDK.NET_DVR_DEVICEINFO_V40);
			int num = CHCNetSDK.NET_DVR_Login_V40(ref pLoginInfo, ref lpDeviceInfo);
			if (num < 0)
			{
				MessageBox.Show("账号或密码错误");
				return;
			}
			CHCNetSDK.NET_DVR_Logout(num);
			MessageBox.Show("连接成功");
		}
		else
		{
			string text = "";
			MainData.init_Sdk_DH();
			NET_DEVICEINFO_Ex deviceInfo = default(NET_DEVICEINFO_Ex);
			IntPtr intPtr = NETClient.LoginWithHighLevelSecurity(textBox1.Text, 37777, textBox2.Text, textBox3.Text, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);
			if (intPtr != IntPtr.Zero)
			{
				NETClient.Logout(intPtr);
				MessageBox.Show("连接成功");
			}
			else
			{
				text = NETClient.GetLastError();
				MessageBox.Show("连接失败！原因：" + text);
			}
		}
	}

	private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
		{
			e.Handled = true;
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
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.bar2 = new DevExpress.XtraBars.Bar();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		base.SuspendLayout();
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox1.Location = new System.Drawing.Point(141, 125);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(248, 34);
		this.textBox1.TabIndex = 42;
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(83, 128);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(68, 17);
		this.label8.TabIndex = 41;
		this.label8.Text = "IP *";
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(141, 176);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(248, 34);
		this.textBox2.TabIndex = 44;
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(83, 179);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(56, 17);
		this.label1.TabIndex = 43;
		this.label1.Text = "账号 *";
		this.textBox3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox3.Location = new System.Drawing.Point(141, 236);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(248, 34);
		this.textBox3.TabIndex = 46;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(83, 239);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(56, 17);
		this.label2.TabIndex = 45;
		this.label2.Text = "密码 *";
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[4] { this.barButtonItem2, this.barButtonItem3, this.barButtonItem4, this.barButtonItem1 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 100;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[4]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
		this.barButtonItem1.Caption = "测试连接";
		this.barButtonItem1.Id = 99;
		this.barButtonItem1.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.convert_32x322;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
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
		this.barDockControlTop.Size = new System.Drawing.Size(504, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 423);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(504, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 383);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(504, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 383);
		this.textBox4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox4.Location = new System.Drawing.Point(141, 294);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(248, 34);
		this.textBox4.TabIndex = 52;
		this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox4_KeyPress);
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.Location = new System.Drawing.Point(61, 297);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(75, 27);
		this.label3.TabIndex = 51;
		this.label3.Text = "通道ID";
		this.textBox5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox5.Location = new System.Drawing.Point(141, 352);
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(248, 34);
		this.textBox5.TabIndex = 58;
		this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox4_KeyPress);
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label4.Location = new System.Drawing.Point(44, 355);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(92, 27);
		this.label4.TabIndex = 57;
		this.label4.Text = "抓拍间隔";
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label5.Location = new System.Drawing.Point(395, 355);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(32, 27);
		this.label5.TabIndex = 59;
		this.label5.Text = "秒";
		this.label6.AutoSize = true;
		this.label6.BackColor = System.Drawing.Color.Transparent;
		this.label6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label6.Location = new System.Drawing.Point(83, 72);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(52, 27);
		this.label6.TabIndex = 64;
		this.label6.Text = "类型";
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[2] { "hk", "dh" });
		this.comboBox1.Location = new System.Drawing.Point(141, 72);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(248, 35);
		this.comboBox1.TabIndex = 65;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(504, 423);
		base.Controls.Add(this.comboBox1);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.textBox5);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.textBox4);
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
		base.Name = "SnapSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "录像机设置";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
