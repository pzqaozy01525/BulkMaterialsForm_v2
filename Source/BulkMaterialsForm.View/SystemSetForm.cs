// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.SystemSetForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BulkMaterialsForm.DH;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Properties;
using BulkMaterialsForm.SDK;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json;

namespace BulkMaterialsForm.View;

public class SystemSetForm : Form
{
	private IContainer components;

	private BarManager barManager1;

	private Bar bar2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControl1;

	private CheckBox checkBox1;

	private CheckBox checkBox7;

	private TextBox textBox19;

	private Label label23;

	private CheckBox checkBox6;

	private Label label24;

	private TextBox textBox20;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private Label label15;

	private TextBox textBox8;

	private Label label14;

	private TextBox textBox7;

	private TextBox textBox4;

	private Label label11;

	private TextBox textBox5;

	private Label label12;

	private TextBox textBox6;

	private Label label13;

	private TextBox textBox3;

	private Label label10;

	private TextBox textBox2;

	private Label label5;

	private TextBox textBox1;

	private Label label4;

	private TabPage tabPage2;

	private TextBox textBox10;

	private Label label6;

	private TextBox textBox9;

	private Label label7;

	private TabPage tabPage4;

	private Label label21;

	private TextBox textBox18;

	private Label label22;

	private Label label20;

	private TextBox textBox17;

	private Label label19;

	private TextBox textBox16;

	private Label label18;

	private TextBox textBox15;

	private Label label1;

	private ButtonEdit buttonEdit1;

	private System.Windows.Forms.ComboBox comboBox3;

	private Label label3;

	private System.Windows.Forms.ComboBox comboBox1;

	private Label label2;

	private TabPage tabPage3;

	private TextBox textBox11;

	private Label label8;

	private TextBox textBox12;

	private Label label9;

	private TextBox textBox13;

	private Label label16;

	private CheckBox checkBox2;

	private CheckBox checkBox3;

	private TabPage tabPage5;

	private TextBox textBox22;

	private Label label26;

	private CheckBox checkBox4;

	private TabControl tabControl2;

	private TabPage tabPage6;

	private TabPage tabPage7;

	private Label label27;

	private TextBox textBox23;

	private Label label25;

	private TextBox textBox21;

	private Label label17;

	private TextBox textBox14;

	private Button button1;

	private TextBox textBox25;

	private Label label29;

	private TextBox textBox24;

	private Label label28;

	private TabPage tabPage8;

	private TextBox textBox26;

	private Label label30;

	private TextBox textBox27;

	private Label label31;

	private TextBox textBox28;

	private Label label32;

	private TextBox textBox29;

	private Label label33;

	private TabPage tabPage9;

	private RadioButton radioButton1;

	private RadioButton radioButton2;

	private Label label34;

	private Panel panel1;

	private TextBox textBox34;

	private Label label39;

	private TextBox textBox35;

	private Label label40;

	private TextBox textBox36;

	private Label label41;

	private TextBox textBox32;

	private Label label37;

	private TextBox textBox33;

	private Label label38;

	private TextBox textBox30;

	private Label label35;

	private TextBox textBox31;

	private Label label36;

	private TabPage tabPage10;

	private CheckBox checkBox5;

	private CheckBox checkBox8;

	private Label label42;

	private TextBox textBox37;

	private CheckBox checkBox9;

	private CheckBox checkBox10;

	private CheckBox checkBox11;

	private TabPage tabPage11;

	private TextBox textBox38;

	private Label label43;

	private TextBox textBox39;

	private Label label44;

	private TextBox textBox40;

	private Label label45;

	private TextBox textBox41;

	private Label label46;

	private TextBox textBox42;

	private Label label47;

	private System.Windows.Forms.ComboBox comboBox2;

	private TextBox textBox43;

	private Label label48;

	private Button button2;

	private Label label49;

	private System.Windows.Forms.ComboBox comboBox4;

	private Label label50;

	private Label label51;

	private System.Windows.Forms.ComboBox comboBox5;

	private Label label52;

	private System.Windows.Forms.ComboBox comboBox6;

	private TabPage tabPage12;

	private System.Windows.Forms.ComboBox comboBox7;

	private Label label53;

	private Label label54;

	private TextBox textBox44;

	private Label label55;

	private TextBox textBox45;

	private Label label56;

	private TextBox textBox46;

	private System.Windows.Forms.ComboBox comboBox8;

	private Label label57;

	private Label label58;

	private TextBox textBox47;

	private static bool SafeToBool(string v, bool defaultValue = false)
	{
		if (string.IsNullOrWhiteSpace(v))
		{
			return defaultValue;
		}
		switch (v.Trim().ToLowerInvariant())
		{
		case "1":
		case "yes":
		case "on":
		case "true":
			return true;
		case "0":
		case "off":
		case "no":
		case "false":
			return false;
		default:
			return defaultValue;
		}
	}

	public SystemSetForm()
	{
		InitializeComponent();
		base.Load += SystemSetForm_Load;
	}

	private void SystemSetForm_Load(object sender, EventArgs e)
	{
		InitCombox();
		textBox1.Text = New_IniFile.ReadContentValue("窗体框架配制", "key", MainData.Spath);
		textBox2.Text = New_IniFile.ReadContentValue("窗体框架配制", "secret", MainData.Spath);
		textBox3.Text = New_IniFile.ReadContentValue("窗体框架配制", "disposalsiteId", MainData.Spath);
		textBox4.Text = New_IniFile.ReadContentValue("窗体框架配制", "ftpIP", MainData.Spath);
		textBox5.Text = New_IniFile.ReadContentValue("窗体框架配制", "ftpProt", MainData.Spath);
		textBox6.Text = New_IniFile.ReadContentValue("窗体框架配制", "ftpUser", MainData.Spath);
		textBox7.Text = New_IniFile.ReadContentValue("窗体框架配制", "ftpPass", MainData.Spath);
		textBox8.Text = New_IniFile.ReadContentValue("窗体框架配制", "ftpImageUrl", MainData.Spath);
		comboBox4.SelectedItem = MainData.DPLX;
		textBox9.Text = New_IniFile.ReadContentValue("窗体框架配制", "高凌进口端口", MainData.Spath);
		textBox10.Text = New_IniFile.ReadContentValue("窗体框架配制", "高凌出口端口", MainData.Spath);
		textBox31.Text = MainData.GLcompanyCode;
		textBox33.Text = MainData.GLcompanyName;
		textBox30.Text = MainData.GLcontrolRunTime;
		textBox32.Text = MainData.GLcontrolEndTime;
		textBox34.Text = MainData.GLcontrolStrategy;
		textBox35.Text = MainData.GLresponseLevel;
		textBox36.Text = MainData.GLcontrolLevel;
		textBox15.Text = New_IniFile.ReadContentValue("窗体框架配制", "腾跃信用代码", MainData.Spath);
		textBox16.Text = New_IniFile.ReadContentValue("窗体框架配制", "设备ID", MainData.Spath);
		textBox17.Text = New_IniFile.ReadContentValue("窗体框架配制", "进口通道ID", MainData.Spath);
		textBox18.Text = New_IniFile.ReadContentValue("窗体框架配制", "出口通道ID", MainData.Spath);
		textBox13.Text = New_IniFile.ReadContentValue("窗体框架配制", "开封V1companyCode", MainData.Spath);
		textBox12.Text = New_IniFile.ReadContentValue("窗体框架配制", "开封V1companynum", MainData.Spath);
		textBox11.Text = New_IniFile.ReadContentValue("窗体框架配制", "开封V1companypassword", MainData.Spath);
		checkBox1.Checked = SafeToBool(New_IniFile.ReadContentValue("窗体框架配制", "临时车使能", MainData.Spath));
		checkBox6.Checked = SafeToBool(New_IniFile.ReadContentValue("窗体框架配制", "白名单验证平台", MainData.Spath));
		checkBox7.Checked = SafeToBool(New_IniFile.ReadContentValue("窗体框架配制", "手动开闸", MainData.Spath));
		checkBox4.Checked = SafeToBool(New_IniFile.ReadContentValue("窗体框架配制", "验证台账", MainData.Spath));
		textBox19.Text = New_IniFile.ReadContentValue("窗体框架配制", "项目名称", MainData.Spath);
		textBox20.Text = New_IniFile.ReadContentValue("窗体框架配制", "车位剩余数量", MainData.Spath);
		buttonEdit1.Text = New_IniFile.ReadContentValue("窗体框架配制", "图片保存路径", MainData.Spath);
		checkBox2.Checked = SafeToBool(New_IniFile.ReadContentValue("窗体框架配制", "IO开关", MainData.Spath));
		comboBox3.SelectedItem = MainData.DJPT;
		comboBox1.SelectedItem = MainData.YXMS;
		textBox22.Text = MainData.ACorgan;
		textBox24.Text = MainData.ACusername;
		textBox25.Text = MainData.ACpassword;
		textBox43.Text = MainData.ACEnterpriseID;
		checkBox3.Checked = SafeToBool(New_IniFile.ReadContentValue("窗体框架配制", "开机启动", MainData.Spath));
		textBox14.Text = MainData.jhjIp;
		textBox21.Text = MainData.jhjzh;
		textBox23.Text = MainData.jhjmm;
		comboBox2.SelectedItem = MainData.jhjtype.ToString();
		textBox28.Text = MainData.tdrcOrgan;
		textBox27.Text = MainData.tdrcUsername;
		textBox26.Text = MainData.tdrcPassword;
		textBox29.Text = MainData.tdrcUrl;
		textBox42.Text = MainData.tdrcEnterpriseID;
		textBox41.Text = MainData.xyOrgan;
		textBox40.Text = MainData.xyUsername;
		textBox39.Text = MainData.xyPassword;
		textBox38.Text = MainData.xyUrl;
		if (MainData.ldiody == 1)
		{
			radioButton1.Checked = true;
		}
		else
		{
			radioButton2.Checked = true;
		}
		checkBox5.Checked = MainData.bxtxhw;
		checkBox8.Checked = MainData.scfwq;
		checkBox9.Checked = MainData.dnyybb;
		checkBox10.Checked = MainData.kqsplx;
		checkBox11.Checked = MainData.kqykjbd;
		textBox37.Text = MainData.khdId;
		comboBox5.SelectedItem = MainData.DBDJ;
		comboBox6.SelectedIndex = MainData.gkpf + 1;
		comboBox7.SelectedItem = MainData.cdpfType;
		textBox44.Text = MainData.cdpfUrl;
		textBox45.Text = MainData.cdpfIISImageUrl;
		textBox46.Text = MainData.cdpfQYId;
		textBox47.Text = MainData.cdpfXSZUrl;
		comboBox8.SelectedItem = MainData.cdpfGTBM;
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox19.Text))
		{
			MessageBox.Show("请填写项目名称");
			return;
		}
		MainData.XMMC = textBox19.Text;
		New_IniFile.WriteContentValue("窗体框架配制", "图片保存路径", buttonEdit1.Text, MainData.Spath);
		MainData.strImageDir = buttonEdit1.Text;
		MainData.LSCSN = checkBox1.Checked;
		MainData.BMDSC = checkBox6.Checked;
		MainData.SDZK = checkBox7.Checked;
		string text = comboBox3?.SelectedItem?.ToString() ?? MainData.DJPT ?? string.Empty;
		string text2 = comboBox1?.SelectedItem?.ToString() ?? MainData.YXMS ?? string.Empty;
		string text3 = comboBox4?.SelectedItem?.ToString() ?? MainData.DPLX ?? string.Empty;
		string text4 = comboBox2?.SelectedItem?.ToString() ?? MainData.jhjtype ?? string.Empty;
		string text5 = comboBox5?.SelectedItem?.ToString() ?? MainData.DBDJ ?? string.Empty;
		string text6 = comboBox7?.SelectedItem?.ToString() ?? MainData.cdpfType ?? string.Empty;
		string text7 = comboBox8?.SelectedItem?.ToString() ?? MainData.cdpfGTBM ?? string.Empty;
		MainData.DJPT = text;
		MainData.YXMS = text2;
		MainData.ACorgan = textBox22.Text;
		MainData.YZTZ = checkBox4.Checked;
		New_IniFile.WriteContentValue("窗体框架配制", "临时车使能", checkBox1.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "白名单验证平台", checkBox6.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "手动开闸", checkBox7.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "项目名称", textBox19.Text, MainData.Spath);
		MainData.XMMC = textBox19.Text;
		New_IniFile.WriteContentValue("窗体框架配制", "车位剩余数量", textBox20.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "platFormType", text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "运行模式", text2, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "IO开关", checkBox2.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "验证台账", checkBox4.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "大屏类型", text3, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "管控排放", (comboBox6.SelectedIndex - 1).ToString(), MainData.Spath);
		MainData.DPLX = text3;
		New_IniFile.WriteContentValue("窗体框架配制", "key", textBox1.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "secret", textBox2.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "disposalsiteId", textBox3.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "ftpIP", textBox4.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "ftpProt", textBox5.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "ftpUser", textBox6.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "ftpPass", textBox7.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "ftpImageUrl", textBox8.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "高凌进口端口", textBox9.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "高凌出口端口", textBox10.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "高凌企业编号", textBox31.Text, MainData.Spath);
		MainData.GLcompanyCode = textBox31.Text;
		New_IniFile.WriteContentValue("窗体框架配制", "腾跃信用代码", textBox15.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "设备ID", textBox16.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "进口通道ID", textBox17.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "出口通道ID", textBox18.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "开封V1companyCode", textBox13.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "开封V1companynum", textBox12.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "开封V1companypassword", textBox11.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "安车编码标识", textBox22.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "安车账号", textBox24.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "安车密码", textBox25.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "安车排污许可证编号", textBox43.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "录像机IP", textBox14.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "录像机账号", textBox21.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "录像机密码", textBox23.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "录像机类型", text4, MainData.Spath);
		int ldiody = 0;
		if (radioButton1.Checked)
		{
			ldiody = 1;
		}
		MainData.ldiody = ldiody;
		New_IniFile.WriteContentValue("窗体框架配制", "联动IO定义", ldiody.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "天地人车企业编码", textBox28.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "天地人车账号", textBox27.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "天地人车密码", textBox26.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "天地人车服务地址", textBox29.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "天地人车排污许可证编号", textBox42.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "必须填写货物开闸", checkBox5.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "上传服务器", checkBox8.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "开启电脑语音播报", checkBox9.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "开启视频录像", checkBox10.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "开启遥控警报灯", checkBox11.Checked.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "客户端ID", textBox37.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "信阳企业编码", textBox41.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "信阳账号", textBox40.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "信阳密码", textBox39.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "信阳服务地址", textBox38.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "对接地磅", text5, MainData.Spath);
		MainData.DBDJ = text5;
		MainData.xyPassword = textBox39.Text;
		MainData.xyUsername = textBox40.Text;
		MainData.xyOrgan = textBox41.Text;
		MainData.xyUrl = textBox38.Text;
		MainData.tdrcPassword = textBox26.Text;
		MainData.tdrcUsername = textBox27.Text;
		MainData.tdrcOrgan = textBox28.Text;
		MainData.tdrcUrl = textBox29.Text;
		MainData.tdrcEnterpriseID = textBox42.Text;
		MainData.jhjIp = textBox14.Text;
		MainData.jhjzh = textBox21.Text;
		MainData.jhjmm = textBox23.Text;
		MainData.jhjtype = text4;
		MainData.ACorgan = textBox22.Text;
		MainData.ACusername = textBox24.Text;
		MainData.ACpassword = textBox25.Text;
		MainData.ACEnterpriseID = textBox43.Text;
		MainData.bxtxhw = checkBox5.Checked;
		MainData.scfwq = checkBox8.Checked;
		MainData.dnyybb = checkBox9.Checked;
		MainData.kqsplx = checkBox10.Checked;
		MainData.kqykjbd = checkBox11.Checked;
		MainData.khdId = textBox37.Text;
		MainData.gkpf = comboBox6.SelectedIndex - 1;
		New_IniFile.WriteContentValue("窗体框架配制", "超低排放接口平台", text6, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "超低排放接口地址", textBox44.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "超低排放IIS图片地址", textBox45.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "岗亭编码", text7, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "企业ID", textBox46.Text, MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "行驶证服务地址", textBox47.Text, MainData.Spath);
		MainData.cdpfType = text6;
		MainData.cdpfUrl = textBox44.Text;
		MainData.cdpfIISImageUrl = textBox45.Text;
		MainData.cdpfQYId = textBox46.Text;
		MainData.cdpfXSZUrl = textBox47.Text;
		MainData.cdpfGTBM = text7;
		MessageBox.Show("保存成功");
		Close();
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK || folderBrowserDialog.ShowDialog() == DialogResult.Yes)
		{
			buttonEdit1.Text = folderBrowserDialog.SelectedPath;
		}
	}

	private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox3.Text == "消纳场")
		{
			tabPage1.Parent = tabControl1;
			tabPage2.Parent = null;
			tabPage3.Parent = null;
			tabPage4.Parent = null;
			tabPage5.Parent = null;
			tabPage8.Parent = null;
			tabPage11.Parent = null;
		}
		else if (comboBox3.Text == "高凌")
		{
			tabPage2.Parent = tabControl1;
			tabPage1.Parent = null;
			tabPage4.Parent = null;
			tabPage3.Parent = null;
			tabPage5.Parent = null;
			tabPage8.Parent = null;
			tabPage11.Parent = null;
		}
		else if (comboBox3.Text == "腾跃")
		{
			tabPage1.Parent = null;
			tabPage2.Parent = null;
			tabPage3.Parent = null;
			tabPage5.Parent = null;
			tabPage8.Parent = null;
			tabPage11.Parent = null;
			tabPage4.Parent = tabControl1;
		}
		else if (comboBox3.Text == "安车")
		{
			tabPage1.Parent = null;
			tabPage2.Parent = null;
			tabPage4.Parent = null;
			tabPage3.Parent = null;
			tabPage8.Parent = null;
			tabPage11.Parent = null;
			tabPage5.Parent = tabControl1;
		}
		else if (comboBox3.Text == "中科九州")
		{
			tabPage1.Parent = null;
			tabPage2.Parent = null;
			tabPage5.Parent = null;
			tabPage4.Parent = null;
			tabPage8.Parent = null;
			tabPage11.Parent = null;
			tabPage3.Parent = tabControl1;
		}
		else if (comboBox3.Text == "天地人车")
		{
			tabPage1.Parent = null;
			tabPage2.Parent = null;
			tabPage5.Parent = null;
			tabPage4.Parent = null;
			tabPage8.Parent = tabControl1;
			tabPage3.Parent = null;
			tabPage11.Parent = null;
		}
		else if (comboBox3.Text == "信阳")
		{
			tabPage1.Parent = null;
			tabPage2.Parent = null;
			tabPage5.Parent = null;
			tabPage4.Parent = null;
			tabPage8.Parent = null;
			tabPage3.Parent = null;
			tabPage11.Parent = tabControl1;
		}
	}

	private void checkBox3_Click(object sender, EventArgs e)
	{
		if (checkBox3.Checked)
		{
			New_IniFile.WriteContentValue("窗体框架配制", "开机启动", checkBox3.Checked.ToString(), MainData.Spath);
			Reboot.SetMeAutoStart();
		}
		else
		{
			New_IniFile.WriteContentValue("窗体框架配制", "开机启动", checkBox3.Checked.ToString(), MainData.Spath);
			Reboot.SetMeAutoStart(onOff: false);
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			System.Windows.Forms.ComboBox comboBox = comboBox2;
			if (comboBox != null && comboBox.SelectedItem?.ToString()?.Equals("hk") == true)
			{
				MainData.init_Sdk_HaiKang();
				CHCNetSDK.NET_DVR_USER_LOGIN_INFO pLoginInfo = default(CHCNetSDK.NET_DVR_USER_LOGIN_INFO);
				byte[] bytes = Encoding.Default.GetBytes(textBox14.Text);
				pLoginInfo.sDeviceAddress = new byte[129];
				bytes.CopyTo(pLoginInfo.sDeviceAddress, 0);
				byte[] bytes2 = Encoding.Default.GetBytes(textBox21.Text);
				pLoginInfo.sUserName = new byte[64];
				bytes2.CopyTo(pLoginInfo.sUserName, 0);
				byte[] bytes3 = Encoding.Default.GetBytes(textBox23.Text);
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
				IntPtr intPtr = NETClient.LoginWithHighLevelSecurity(textBox14.Text, 37777, textBox21.Text, textBox23.Text, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);
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
		catch (Exception ex)
		{
			MessageBox.Show("录像机连接失败：" + ex.Message, "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Dictionary<string, object> companyControlInfo = CommonHelper.GetCompanyControlInfo(textBox31.Text);
		if (companyControlInfo != null)
		{
			if (companyControlInfo.ContainsKey("data") && companyControlInfo.ContainsKey("result") && companyControlInfo["result"].ToString().Equals("success"))
			{
				companyControlInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(companyControlInfo["data"].ToString());
				if (companyControlInfo != null)
				{
					MainData.GLcompanyName = companyControlInfo["companyName"].ToString();
					MainData.GLcontrolRunTime = companyControlInfo["controlRunTime"].ToString();
					MainData.GLcontrolEndTime = companyControlInfo["controlEndTime"].ToString();
					MainData.GLcontrolStrategy = CommonHelper.GetControlStrategy(companyControlInfo["controlStrategy"].ToString());
					MainData.GLresponseLevel = CommonHelper.GetResponseLevel(companyControlInfo["responseLevel"].ToString());
					MainData.GLcontrolLevel = CommonHelper.GetControlLevel(companyControlInfo["controlLevel"].ToString());
					MainData.GLcontrolUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					New_IniFile.WriteContentValue("窗体框架配制", "高陵企业名称", MainData.GLcompanyName, MainData.Spath);
					New_IniFile.WriteContentValue("窗体框架配制", "高陵管控开始时间", MainData.GLcontrolRunTime, MainData.Spath);
					New_IniFile.WriteContentValue("窗体框架配制", "高陵管控结束时间", MainData.GLcontrolEndTime, MainData.Spath);
					New_IniFile.WriteContentValue("窗体框架配制", "高陵管控策略", MainData.GLcontrolStrategy, MainData.Spath);
					New_IniFile.WriteContentValue("窗体框架配制", "高陵响应等级", MainData.GLresponseLevel, MainData.Spath);
					New_IniFile.WriteContentValue("窗体框架配制", "高陵预警等级", MainData.GLcontrolLevel, MainData.Spath);
					New_IniFile.WriteContentValue("窗体框架配制", "高陵管控更新时间", MainData.GLcontrolUpdateTime, MainData.Spath);
					textBox33.Text = MainData.GLcompanyName;
					textBox30.Text = MainData.GLcontrolRunTime;
					textBox32.Text = MainData.GLcontrolEndTime;
					textBox34.Text = MainData.GLcontrolStrategy;
					textBox35.Text = MainData.GLresponseLevel;
					textBox36.Text = MainData.GLcontrolLevel;
				}
			}
			else if (companyControlInfo.ContainsKey("err"))
			{
				MessageBox.Show(companyControlInfo["err"].ToString());
			}
		}
		else
		{
			MessageBox.Show("获取失败");
		}
	}

	private void InitCombox()
	{
		List<string> list = new List<string>();
		for (char c = 'A'; c <= 'Z'; c = (char)(c + 1))
		{
			list.Add(c.ToString());
		}
		comboBox8.DataSource = list;
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
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.checkBox7 = new System.Windows.Forms.CheckBox();
		this.textBox19 = new System.Windows.Forms.TextBox();
		this.label23 = new System.Windows.Forms.Label();
		this.checkBox6 = new System.Windows.Forms.CheckBox();
		this.label24 = new System.Windows.Forms.Label();
		this.textBox20 = new System.Windows.Forms.TextBox();
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.label15 = new System.Windows.Forms.Label();
		this.textBox8 = new System.Windows.Forms.TextBox();
		this.label14 = new System.Windows.Forms.Label();
		this.textBox7 = new System.Windows.Forms.TextBox();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label11 = new System.Windows.Forms.Label();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.label12 = new System.Windows.Forms.Label();
		this.textBox6 = new System.Windows.Forms.TextBox();
		this.label13 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label10 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.textBox34 = new System.Windows.Forms.TextBox();
		this.label39 = new System.Windows.Forms.Label();
		this.textBox35 = new System.Windows.Forms.TextBox();
		this.label40 = new System.Windows.Forms.Label();
		this.textBox36 = new System.Windows.Forms.TextBox();
		this.label41 = new System.Windows.Forms.Label();
		this.textBox32 = new System.Windows.Forms.TextBox();
		this.label37 = new System.Windows.Forms.Label();
		this.textBox33 = new System.Windows.Forms.TextBox();
		this.label38 = new System.Windows.Forms.Label();
		this.textBox30 = new System.Windows.Forms.TextBox();
		this.label35 = new System.Windows.Forms.Label();
		this.textBox31 = new System.Windows.Forms.TextBox();
		this.label36 = new System.Windows.Forms.Label();
		this.textBox10 = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.textBox9 = new System.Windows.Forms.TextBox();
		this.label7 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.tabPage4 = new System.Windows.Forms.TabPage();
		this.label21 = new System.Windows.Forms.Label();
		this.textBox18 = new System.Windows.Forms.TextBox();
		this.label22 = new System.Windows.Forms.Label();
		this.label20 = new System.Windows.Forms.Label();
		this.textBox17 = new System.Windows.Forms.TextBox();
		this.label19 = new System.Windows.Forms.Label();
		this.textBox16 = new System.Windows.Forms.TextBox();
		this.label18 = new System.Windows.Forms.Label();
		this.textBox15 = new System.Windows.Forms.TextBox();
		this.tabPage3 = new System.Windows.Forms.TabPage();
		this.textBox11 = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.textBox12 = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.textBox13 = new System.Windows.Forms.TextBox();
		this.label16 = new System.Windows.Forms.Label();
		this.tabPage5 = new System.Windows.Forms.TabPage();
		this.label49 = new System.Windows.Forms.Label();
		this.textBox43 = new System.Windows.Forms.TextBox();
		this.textBox25 = new System.Windows.Forms.TextBox();
		this.label29 = new System.Windows.Forms.Label();
		this.textBox24 = new System.Windows.Forms.TextBox();
		this.label28 = new System.Windows.Forms.Label();
		this.textBox22 = new System.Windows.Forms.TextBox();
		this.label26 = new System.Windows.Forms.Label();
		this.tabPage8 = new System.Windows.Forms.TabPage();
		this.textBox42 = new System.Windows.Forms.TextBox();
		this.label47 = new System.Windows.Forms.Label();
		this.textBox29 = new System.Windows.Forms.TextBox();
		this.label33 = new System.Windows.Forms.Label();
		this.textBox26 = new System.Windows.Forms.TextBox();
		this.label30 = new System.Windows.Forms.Label();
		this.textBox27 = new System.Windows.Forms.TextBox();
		this.label31 = new System.Windows.Forms.Label();
		this.textBox28 = new System.Windows.Forms.TextBox();
		this.label32 = new System.Windows.Forms.Label();
		this.tabPage11 = new System.Windows.Forms.TabPage();
		this.textBox38 = new System.Windows.Forms.TextBox();
		this.label43 = new System.Windows.Forms.Label();
		this.textBox39 = new System.Windows.Forms.TextBox();
		this.label44 = new System.Windows.Forms.Label();
		this.textBox40 = new System.Windows.Forms.TextBox();
		this.label45 = new System.Windows.Forms.Label();
		this.textBox41 = new System.Windows.Forms.TextBox();
		this.label46 = new System.Windows.Forms.Label();
		this.label48 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
		this.comboBox3 = new System.Windows.Forms.ComboBox();
		this.label3 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label2 = new System.Windows.Forms.Label();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.checkBox4 = new System.Windows.Forms.CheckBox();
		this.tabControl2 = new System.Windows.Forms.TabControl();
		this.tabPage6 = new System.Windows.Forms.TabPage();
		this.comboBox6 = new System.Windows.Forms.ComboBox();
		this.label52 = new System.Windows.Forms.Label();
		this.comboBox4 = new System.Windows.Forms.ComboBox();
		this.label50 = new System.Windows.Forms.Label();
		this.tabPage7 = new System.Windows.Forms.TabPage();
		this.button1 = new System.Windows.Forms.Button();
		this.label27 = new System.Windows.Forms.Label();
		this.textBox23 = new System.Windows.Forms.TextBox();
		this.label25 = new System.Windows.Forms.Label();
		this.textBox21 = new System.Windows.Forms.TextBox();
		this.label17 = new System.Windows.Forms.Label();
		this.textBox14 = new System.Windows.Forms.TextBox();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.tabPage9 = new System.Windows.Forms.TabPage();
		this.panel1 = new System.Windows.Forms.Panel();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.label34 = new System.Windows.Forms.Label();
		this.tabPage10 = new System.Windows.Forms.TabPage();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
		this.label51 = new System.Windows.Forms.Label();
		this.checkBox11 = new System.Windows.Forms.CheckBox();
		this.checkBox10 = new System.Windows.Forms.CheckBox();
		this.checkBox9 = new System.Windows.Forms.CheckBox();
		this.label42 = new System.Windows.Forms.Label();
		this.textBox37 = new System.Windows.Forms.TextBox();
		this.checkBox8 = new System.Windows.Forms.CheckBox();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.tabPage12 = new System.Windows.Forms.TabPage();
		this.label58 = new System.Windows.Forms.Label();
		this.textBox47 = new System.Windows.Forms.TextBox();
		this.comboBox8 = new System.Windows.Forms.ComboBox();
		this.label57 = new System.Windows.Forms.Label();
		this.label56 = new System.Windows.Forms.Label();
		this.textBox46 = new System.Windows.Forms.TextBox();
		this.label55 = new System.Windows.Forms.Label();
		this.textBox45 = new System.Windows.Forms.TextBox();
		this.label54 = new System.Windows.Forms.Label();
		this.textBox44 = new System.Windows.Forms.TextBox();
		this.comboBox7 = new System.Windows.Forms.ComboBox();
		this.label53 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.tabPage2.SuspendLayout();
		this.tabPage4.SuspendLayout();
		this.tabPage3.SuspendLayout();
		this.tabPage5.SuspendLayout();
		this.tabPage8.SuspendLayout();
		this.tabPage11.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.buttonEdit1.Properties).BeginInit();
		this.tabControl2.SuspendLayout();
		this.tabPage6.SuspendLayout();
		this.tabPage7.SuspendLayout();
		this.tabPage9.SuspendLayout();
		this.panel1.SuspendLayout();
		this.tabPage10.SuspendLayout();
		this.tabPage12.SuspendLayout();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[2] { this.barButtonItem3, this.barButtonItem4 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 99;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[2]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.bar2.OptionsBar.MultiLine = true;
		this.bar2.OptionsBar.UseWholeRow = true;
		this.bar2.Text = "Main menu";
		this.barButtonItem3.Caption = "保存";
		this.barButtonItem3.Id = 97;
		this.barButtonItem3.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.apply_32x323;
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
		this.barDockControlTop.Size = new System.Drawing.Size(1007, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 609);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(1007, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 569);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(1007, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 569);
		this.checkBox1.AutoSize = true;
		this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox1.Location = new System.Drawing.Point(24, 104);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(201, 35);
		this.checkBox1.TabIndex = 4;
		this.checkBox1.Text = "临时车禁止出入";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox7.AutoSize = true;
		this.checkBox7.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox7.Location = new System.Drawing.Point(231, 104);
		this.checkBox7.Name = "checkBox7";
		this.checkBox7.Size = new System.Drawing.Size(201, 35);
		this.checkBox7.TabIndex = 54;
		this.checkBox7.Text = "临时车手动开闸";
		this.checkBox7.UseVisualStyleBackColor = true;
		this.textBox19.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox19.Location = new System.Drawing.Point(138, 41);
		this.textBox19.Name = "textBox19";
		this.textBox19.Size = new System.Drawing.Size(189, 34);
		this.textBox19.TabIndex = 61;
		this.label23.AutoSize = true;
		this.label23.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label23.Location = new System.Drawing.Point(22, 40);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(110, 31);
		this.label23.TabIndex = 60;
		this.label23.Text = "项目名称";
		this.checkBox6.AutoSize = true;
		this.checkBox6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox6.Location = new System.Drawing.Point(440, 104);
		this.checkBox6.Name = "checkBox6";
		this.checkBox6.Size = new System.Drawing.Size(201, 35);
		this.checkBox6.TabIndex = 62;
		this.checkBox6.Text = "白名单上传平台";
		this.checkBox6.UseVisualStyleBackColor = true;
		this.label24.AutoSize = true;
		this.label24.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label24.Location = new System.Drawing.Point(340, 44);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(158, 31);
		this.label24.TabIndex = 66;
		this.label24.Text = "车位剩余数量";
		this.textBox20.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox20.Location = new System.Drawing.Point(513, 41);
		this.textBox20.Name = "textBox20";
		this.textBox20.Size = new System.Drawing.Size(208, 34);
		this.textBox20.TabIndex = 67;
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Controls.Add(this.tabPage4);
		this.tabControl1.Controls.Add(this.tabPage3);
		this.tabControl1.Controls.Add(this.tabPage5);
		this.tabControl1.Controls.Add(this.tabPage8);
		this.tabControl1.Controls.Add(this.tabPage11);
		this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.tabControl1.Location = new System.Drawing.Point(0, 340);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(1007, 269);
		this.tabControl1.TabIndex = 68;
		this.tabPage1.Controls.Add(this.label15);
		this.tabPage1.Controls.Add(this.textBox8);
		this.tabPage1.Controls.Add(this.label14);
		this.tabPage1.Controls.Add(this.textBox7);
		this.tabPage1.Controls.Add(this.textBox4);
		this.tabPage1.Controls.Add(this.label11);
		this.tabPage1.Controls.Add(this.textBox5);
		this.tabPage1.Controls.Add(this.label12);
		this.tabPage1.Controls.Add(this.textBox6);
		this.tabPage1.Controls.Add(this.label13);
		this.tabPage1.Controls.Add(this.textBox3);
		this.tabPage1.Controls.Add(this.label10);
		this.tabPage1.Controls.Add(this.textBox2);
		this.tabPage1.Controls.Add(this.label5);
		this.tabPage1.Controls.Add(this.textBox1);
		this.tabPage1.Controls.Add(this.label4);
		this.tabPage1.Location = new System.Drawing.Point(4, 30);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(999, 235);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "消纳场平台";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.label15.AutoSize = true;
		this.label15.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label15.Location = new System.Drawing.Point(634, 56);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(94, 31);
		this.label15.TabIndex = 39;
		this.label15.Text = "ftp图片";
		this.textBox8.Location = new System.Drawing.Point(739, 56);
		this.textBox8.Name = "textBox8";
		this.textBox8.Size = new System.Drawing.Size(166, 29);
		this.textBox8.TabIndex = 38;
		this.label14.AutoSize = true;
		this.label14.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label14.Location = new System.Drawing.Point(631, 13);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(94, 31);
		this.label14.TabIndex = 37;
		this.label14.Text = "ftp密码";
		this.textBox7.Location = new System.Drawing.Point(739, 13);
		this.textBox7.Name = "textBox7";
		this.textBox7.PasswordChar = '*';
		this.textBox7.Size = new System.Drawing.Size(166, 29);
		this.textBox7.TabIndex = 36;
		this.textBox4.Location = new System.Drawing.Point(435, 13);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(166, 29);
		this.textBox4.TabIndex = 35;
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label11.Location = new System.Drawing.Point(327, 101);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(94, 31);
		this.label11.TabIndex = 34;
		this.label11.Text = "ftp账号";
		this.textBox5.Location = new System.Drawing.Point(435, 56);
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(166, 29);
		this.textBox5.TabIndex = 33;
		this.label12.AutoSize = true;
		this.label12.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label12.Location = new System.Drawing.Point(329, 58);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(94, 31);
		this.label12.TabIndex = 32;
		this.label12.Text = "ftp端口";
		this.textBox6.Location = new System.Drawing.Point(435, 101);
		this.textBox6.Name = "textBox6";
		this.textBox6.Size = new System.Drawing.Size(166, 29);
		this.textBox6.TabIndex = 31;
		this.label13.AutoSize = true;
		this.label13.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label13.Location = new System.Drawing.Point(346, 13);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(68, 31);
		this.label13.TabIndex = 30;
		this.label13.Text = "ftpIP";
		this.textBox3.Location = new System.Drawing.Point(126, 102);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(166, 29);
		this.textBox3.TabIndex = 29;
		this.label10.AutoSize = true;
		this.label10.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label10.Location = new System.Drawing.Point(6, 101);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(111, 31);
		this.label10.TabIndex = 28;
		this.label10.Text = "消纳场ID";
		this.textBox2.Location = new System.Drawing.Point(126, 58);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(166, 29);
		this.textBox2.TabIndex = 26;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label5.Location = new System.Drawing.Point(38, 58);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(62, 31);
		this.label5.TabIndex = 25;
		this.label5.Text = "私钥";
		this.textBox1.Location = new System.Drawing.Point(126, 13);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(166, 29);
		this.textBox1.TabIndex = 24;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label4.Location = new System.Drawing.Point(38, 13);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(62, 31);
		this.label4.TabIndex = 23;
		this.label4.Text = "秘钥";
		this.tabPage2.Controls.Add(this.textBox34);
		this.tabPage2.Controls.Add(this.label39);
		this.tabPage2.Controls.Add(this.textBox35);
		this.tabPage2.Controls.Add(this.label40);
		this.tabPage2.Controls.Add(this.textBox36);
		this.tabPage2.Controls.Add(this.label41);
		this.tabPage2.Controls.Add(this.textBox32);
		this.tabPage2.Controls.Add(this.label37);
		this.tabPage2.Controls.Add(this.textBox33);
		this.tabPage2.Controls.Add(this.label38);
		this.tabPage2.Controls.Add(this.textBox30);
		this.tabPage2.Controls.Add(this.label35);
		this.tabPage2.Controls.Add(this.textBox31);
		this.tabPage2.Controls.Add(this.label36);
		this.tabPage2.Controls.Add(this.textBox10);
		this.tabPage2.Controls.Add(this.label6);
		this.tabPage2.Controls.Add(this.textBox9);
		this.tabPage2.Controls.Add(this.label7);
		this.tabPage2.Controls.Add(this.button2);
		this.tabPage2.Location = new System.Drawing.Point(4, 30);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(999, 235);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "高凌平台";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.textBox34.Location = new System.Drawing.Point(798, 154);
		this.textBox34.Name = "textBox34";
		this.textBox34.Size = new System.Drawing.Size(166, 29);
		this.textBox34.TabIndex = 45;
		this.label39.AutoSize = true;
		this.label39.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label39.Location = new System.Drawing.Point(656, 151);
		this.label39.Name = "label39";
		this.label39.Size = new System.Drawing.Size(110, 31);
		this.label39.TabIndex = 44;
		this.label39.Text = "管控策略";
		this.textBox35.Location = new System.Drawing.Point(466, 152);
		this.textBox35.Name = "textBox35";
		this.textBox35.Size = new System.Drawing.Size(166, 29);
		this.textBox35.TabIndex = 43;
		this.label40.AutoSize = true;
		this.label40.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label40.Location = new System.Drawing.Point(318, 149);
		this.label40.Name = "label40";
		this.label40.Size = new System.Drawing.Size(110, 31);
		this.label40.TabIndex = 42;
		this.label40.Text = "响应等级";
		this.textBox36.Location = new System.Drawing.Point(134, 150);
		this.textBox36.Name = "textBox36";
		this.textBox36.Size = new System.Drawing.Size(166, 29);
		this.textBox36.TabIndex = 41;
		this.label41.AutoSize = true;
		this.label41.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label41.Location = new System.Drawing.Point(10, 147);
		this.label41.Name = "label41";
		this.label41.Size = new System.Drawing.Size(110, 31);
		this.label41.TabIndex = 40;
		this.label41.Text = "预警等级";
		this.textBox32.Location = new System.Drawing.Point(798, 93);
		this.textBox32.Name = "textBox32";
		this.textBox32.Size = new System.Drawing.Size(166, 29);
		this.textBox32.TabIndex = 39;
		this.label37.AutoSize = true;
		this.label37.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label37.Location = new System.Drawing.Point(638, 89);
		this.label37.Name = "label37";
		this.label37.Size = new System.Drawing.Size(158, 31);
		this.label37.TabIndex = 38;
		this.label37.Text = "管控结束时间";
		this.textBox33.Location = new System.Drawing.Point(798, 32);
		this.textBox33.Name = "textBox33";
		this.textBox33.Size = new System.Drawing.Size(166, 29);
		this.textBox33.TabIndex = 37;
		this.label38.AutoSize = true;
		this.label38.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label38.Location = new System.Drawing.Point(656, 29);
		this.label38.Name = "label38";
		this.label38.Size = new System.Drawing.Size(110, 31);
		this.label38.TabIndex = 36;
		this.label38.Text = "企业名称";
		this.textBox30.Location = new System.Drawing.Point(466, 91);
		this.textBox30.Name = "textBox30";
		this.textBox30.Size = new System.Drawing.Size(166, 29);
		this.textBox30.TabIndex = 35;
		this.label35.AutoSize = true;
		this.label35.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label35.Location = new System.Drawing.Point(304, 88);
		this.label35.Name = "label35";
		this.label35.Size = new System.Drawing.Size(158, 31);
		this.label35.TabIndex = 34;
		this.label35.Text = "管控启动时间";
		this.textBox31.Location = new System.Drawing.Point(466, 30);
		this.textBox31.Name = "textBox31";
		this.textBox31.Size = new System.Drawing.Size(166, 29);
		this.textBox31.TabIndex = 33;
		this.label36.AutoSize = true;
		this.label36.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label36.Location = new System.Drawing.Point(318, 27);
		this.label36.Name = "label36";
		this.label36.Size = new System.Drawing.Size(110, 31);
		this.label36.TabIndex = 32;
		this.label36.Text = "企业编号";
		this.textBox10.Location = new System.Drawing.Point(134, 89);
		this.textBox10.Name = "textBox10";
		this.textBox10.Size = new System.Drawing.Size(166, 29);
		this.textBox10.TabIndex = 31;
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label6.Location = new System.Drawing.Point(10, 86);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(110, 31);
		this.label6.TabIndex = 30;
		this.label6.Text = "出口端口";
		this.textBox9.Location = new System.Drawing.Point(134, 28);
		this.textBox9.Name = "textBox9";
		this.textBox9.Size = new System.Drawing.Size(166, 29);
		this.textBox9.TabIndex = 29;
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label7.Location = new System.Drawing.Point(10, 25);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(110, 31);
		this.label7.TabIndex = 28;
		this.label7.Text = "入口端口";
		this.button2.Location = new System.Drawing.Point(396, 187);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(113, 40);
		this.button2.TabIndex = 46;
		this.button2.Text = "获取信息";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.tabPage4.Controls.Add(this.label21);
		this.tabPage4.Controls.Add(this.textBox18);
		this.tabPage4.Controls.Add(this.label22);
		this.tabPage4.Controls.Add(this.label20);
		this.tabPage4.Controls.Add(this.textBox17);
		this.tabPage4.Controls.Add(this.label19);
		this.tabPage4.Controls.Add(this.textBox16);
		this.tabPage4.Controls.Add(this.label18);
		this.tabPage4.Controls.Add(this.textBox15);
		this.tabPage4.Location = new System.Drawing.Point(4, 30);
		this.tabPage4.Name = "tabPage4";
		this.tabPage4.Size = new System.Drawing.Size(999, 235);
		this.tabPage4.TabIndex = 3;
		this.tabPage4.Text = "腾跃平台";
		this.tabPage4.UseVisualStyleBackColor = true;
		this.label21.AutoSize = true;
		this.label21.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label21.ForeColor = System.Drawing.Color.Red;
		this.label21.Location = new System.Drawing.Point(266, 133);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(292, 27);
		this.label21.TabIndex = 51;
		this.label21.Text = "请把相机分辨率调成1080P以下";
		this.textBox18.Location = new System.Drawing.Point(522, 78);
		this.textBox18.Name = "textBox18";
		this.textBox18.Size = new System.Drawing.Size(166, 29);
		this.textBox18.TabIndex = 50;
		this.label22.AutoSize = true;
		this.label22.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label22.Location = new System.Drawing.Point(374, 78);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(135, 31);
		this.label22.TabIndex = 49;
		this.label22.Text = "出口通道ID";
		this.label20.AutoSize = true;
		this.label20.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label20.Location = new System.Drawing.Point(376, 21);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(135, 31);
		this.label20.TabIndex = 46;
		this.label20.Text = "入口通道ID";
		this.textBox17.Location = new System.Drawing.Point(522, 25);
		this.textBox17.Name = "textBox17";
		this.textBox17.Size = new System.Drawing.Size(166, 29);
		this.textBox17.TabIndex = 45;
		this.label19.AutoSize = true;
		this.label19.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label19.Location = new System.Drawing.Point(24, 73);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(87, 31);
		this.label19.TabIndex = 44;
		this.label19.Text = "设备ID";
		this.textBox16.Location = new System.Drawing.Point(171, 76);
		this.textBox16.Name = "textBox16";
		this.textBox16.Size = new System.Drawing.Size(166, 29);
		this.textBox16.TabIndex = 43;
		this.label18.AutoSize = true;
		this.label18.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label18.Location = new System.Drawing.Point(24, 20);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(110, 31);
		this.label18.TabIndex = 42;
		this.label18.Text = "信用代码";
		this.textBox15.Location = new System.Drawing.Point(171, 23);
		this.textBox15.Name = "textBox15";
		this.textBox15.Size = new System.Drawing.Size(166, 29);
		this.textBox15.TabIndex = 41;
		this.tabPage3.Controls.Add(this.textBox11);
		this.tabPage3.Controls.Add(this.label8);
		this.tabPage3.Controls.Add(this.textBox12);
		this.tabPage3.Controls.Add(this.label9);
		this.tabPage3.Controls.Add(this.textBox13);
		this.tabPage3.Controls.Add(this.label16);
		this.tabPage3.Location = new System.Drawing.Point(4, 30);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Size = new System.Drawing.Size(999, 235);
		this.tabPage3.TabIndex = 4;
		this.tabPage3.Text = "中科九州平台";
		this.tabPage3.UseVisualStyleBackColor = true;
		this.textBox11.Location = new System.Drawing.Point(269, 120);
		this.textBox11.Name = "textBox11";
		this.textBox11.Size = new System.Drawing.Size(166, 29);
		this.textBox11.TabIndex = 35;
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label8.Location = new System.Drawing.Point(152, 119);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(110, 31);
		this.label8.TabIndex = 34;
		this.label8.Text = "上传密码";
		this.textBox12.Location = new System.Drawing.Point(269, 76);
		this.textBox12.Name = "textBox12";
		this.textBox12.Size = new System.Drawing.Size(166, 29);
		this.textBox12.TabIndex = 33;
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label9.Location = new System.Drawing.Point(150, 76);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(110, 31);
		this.label9.TabIndex = 32;
		this.label9.Text = "上传账户";
		this.textBox13.Location = new System.Drawing.Point(269, 31);
		this.textBox13.Name = "textBox13";
		this.textBox13.Size = new System.Drawing.Size(166, 29);
		this.textBox13.TabIndex = 31;
		this.label16.AutoSize = true;
		this.label16.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label16.Location = new System.Drawing.Point(54, 31);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(206, 31);
		this.label16.TabIndex = 30;
		this.label16.Text = "企业唯一编码标识";
		this.tabPage5.Controls.Add(this.label49);
		this.tabPage5.Controls.Add(this.textBox43);
		this.tabPage5.Controls.Add(this.textBox25);
		this.tabPage5.Controls.Add(this.label29);
		this.tabPage5.Controls.Add(this.textBox24);
		this.tabPage5.Controls.Add(this.label28);
		this.tabPage5.Controls.Add(this.textBox22);
		this.tabPage5.Controls.Add(this.label26);
		this.tabPage5.Location = new System.Drawing.Point(4, 30);
		this.tabPage5.Name = "tabPage5";
		this.tabPage5.Size = new System.Drawing.Size(999, 235);
		this.tabPage5.TabIndex = 5;
		this.tabPage5.Text = "安车平台";
		this.tabPage5.UseVisualStyleBackColor = true;
		this.label49.AutoSize = true;
		this.label49.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label49.Location = new System.Drawing.Point(164, 185);
		this.label49.Name = "label49";
		this.label49.Size = new System.Drawing.Size(230, 31);
		this.label49.TabIndex = 44;
		this.label49.Text = "安车排污许可证编号";
		this.textBox43.Location = new System.Drawing.Point(403, 185);
		this.textBox43.Name = "textBox43";
		this.textBox43.Size = new System.Drawing.Size(350, 29);
		this.textBox43.TabIndex = 43;
		this.textBox25.Location = new System.Drawing.Point(403, 136);
		this.textBox25.Name = "textBox25";
		this.textBox25.PasswordChar = '*';
		this.textBox25.Size = new System.Drawing.Size(350, 29);
		this.textBox25.TabIndex = 41;
		this.label29.AutoSize = true;
		this.label29.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label29.Location = new System.Drawing.Point(332, 136);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(62, 31);
		this.label29.TabIndex = 40;
		this.label29.Text = "密码";
		this.textBox24.Location = new System.Drawing.Point(403, 85);
		this.textBox24.Name = "textBox24";
		this.textBox24.Size = new System.Drawing.Size(350, 29);
		this.textBox24.TabIndex = 39;
		this.label28.AutoSize = true;
		this.label28.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label28.Location = new System.Drawing.Point(332, 85);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(62, 31);
		this.label28.TabIndex = 38;
		this.label28.Text = "账号";
		this.textBox22.Location = new System.Drawing.Point(403, 32);
		this.textBox22.Name = "textBox22";
		this.textBox22.Size = new System.Drawing.Size(350, 29);
		this.textBox22.TabIndex = 37;
		this.label26.AutoSize = true;
		this.label26.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label26.Location = new System.Drawing.Point(188, 32);
		this.label26.Name = "label26";
		this.label26.Size = new System.Drawing.Size(206, 31);
		this.label26.TabIndex = 36;
		this.label26.Text = "企业唯一编码标识";
		this.tabPage8.Controls.Add(this.textBox42);
		this.tabPage8.Controls.Add(this.label47);
		this.tabPage8.Controls.Add(this.textBox29);
		this.tabPage8.Controls.Add(this.label33);
		this.tabPage8.Controls.Add(this.textBox26);
		this.tabPage8.Controls.Add(this.label30);
		this.tabPage8.Controls.Add(this.textBox27);
		this.tabPage8.Controls.Add(this.label31);
		this.tabPage8.Controls.Add(this.textBox28);
		this.tabPage8.Controls.Add(this.label32);
		this.tabPage8.Location = new System.Drawing.Point(4, 30);
		this.tabPage8.Name = "tabPage8";
		this.tabPage8.Size = new System.Drawing.Size(999, 235);
		this.tabPage8.TabIndex = 6;
		this.tabPage8.Text = "天地人车平台";
		this.tabPage8.UseVisualStyleBackColor = true;
		this.textBox42.Location = new System.Drawing.Point(652, 21);
		this.textBox42.Name = "textBox42";
		this.textBox42.Size = new System.Drawing.Size(214, 29);
		this.textBox42.TabIndex = 51;
		this.label47.AutoSize = true;
		this.label47.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label47.Location = new System.Drawing.Point(437, 21);
		this.label47.Name = "label47";
		this.label47.Size = new System.Drawing.Size(182, 31);
		this.label47.TabIndex = 50;
		this.label47.Text = "排污许可证编号";
		this.textBox29.Location = new System.Drawing.Point(240, 177);
		this.textBox29.Name = "textBox29";
		this.textBox29.Size = new System.Drawing.Size(166, 29);
		this.textBox29.TabIndex = 49;
		this.label33.AutoSize = true;
		this.label33.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label33.Location = new System.Drawing.Point(101, 174);
		this.label33.Name = "label33";
		this.label33.Size = new System.Drawing.Size(134, 31);
		this.label33.TabIndex = 48;
		this.label33.Text = "服务器地址";
		this.textBox26.Location = new System.Drawing.Point(240, 127);
		this.textBox26.Name = "textBox26";
		this.textBox26.PasswordChar = '*';
		this.textBox26.Size = new System.Drawing.Size(166, 29);
		this.textBox26.TabIndex = 47;
		this.label30.AutoSize = true;
		this.label30.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label30.Location = new System.Drawing.Point(169, 125);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(62, 31);
		this.label30.TabIndex = 46;
		this.label30.Text = "密码";
		this.textBox27.Location = new System.Drawing.Point(240, 76);
		this.textBox27.Name = "textBox27";
		this.textBox27.Size = new System.Drawing.Size(166, 29);
		this.textBox27.TabIndex = 45;
		this.label31.AutoSize = true;
		this.label31.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label31.Location = new System.Drawing.Point(169, 74);
		this.label31.Name = "label31";
		this.label31.Size = new System.Drawing.Size(62, 31);
		this.label31.TabIndex = 44;
		this.label31.Text = "账号";
		this.textBox28.Location = new System.Drawing.Point(240, 21);
		this.textBox28.Name = "textBox28";
		this.textBox28.Size = new System.Drawing.Size(166, 29);
		this.textBox28.TabIndex = 43;
		this.label32.AutoSize = true;
		this.label32.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label32.Location = new System.Drawing.Point(25, 21);
		this.label32.Name = "label32";
		this.label32.Size = new System.Drawing.Size(206, 31);
		this.label32.TabIndex = 42;
		this.label32.Text = "企业唯一编码标识";
		this.tabPage11.Controls.Add(this.textBox38);
		this.tabPage11.Controls.Add(this.label43);
		this.tabPage11.Controls.Add(this.textBox39);
		this.tabPage11.Controls.Add(this.label44);
		this.tabPage11.Controls.Add(this.textBox40);
		this.tabPage11.Controls.Add(this.label45);
		this.tabPage11.Controls.Add(this.textBox41);
		this.tabPage11.Controls.Add(this.label46);
		this.tabPage11.Location = new System.Drawing.Point(4, 30);
		this.tabPage11.Name = "tabPage11";
		this.tabPage11.Size = new System.Drawing.Size(999, 235);
		this.tabPage11.TabIndex = 7;
		this.tabPage11.Text = "信阳平台";
		this.tabPage11.UseVisualStyleBackColor = true;
		this.textBox38.Location = new System.Drawing.Point(231, 178);
		this.textBox38.Name = "textBox38";
		this.textBox38.Size = new System.Drawing.Size(267, 29);
		this.textBox38.TabIndex = 57;
		this.label43.AutoSize = true;
		this.label43.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label43.Location = new System.Drawing.Point(92, 175);
		this.label43.Name = "label43";
		this.label43.Size = new System.Drawing.Size(134, 31);
		this.label43.TabIndex = 56;
		this.label43.Text = "服务器地址";
		this.textBox39.Location = new System.Drawing.Point(231, 128);
		this.textBox39.Name = "textBox39";
		this.textBox39.PasswordChar = '*';
		this.textBox39.Size = new System.Drawing.Size(267, 29);
		this.textBox39.TabIndex = 55;
		this.label44.AutoSize = true;
		this.label44.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label44.Location = new System.Drawing.Point(160, 126);
		this.label44.Name = "label44";
		this.label44.Size = new System.Drawing.Size(62, 31);
		this.label44.TabIndex = 54;
		this.label44.Text = "密码";
		this.textBox40.Location = new System.Drawing.Point(231, 77);
		this.textBox40.Name = "textBox40";
		this.textBox40.Size = new System.Drawing.Size(267, 29);
		this.textBox40.TabIndex = 53;
		this.label45.AutoSize = true;
		this.label45.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label45.Location = new System.Drawing.Point(160, 75);
		this.label45.Name = "label45";
		this.label45.Size = new System.Drawing.Size(62, 31);
		this.label45.TabIndex = 52;
		this.label45.Text = "账号";
		this.textBox41.Location = new System.Drawing.Point(231, 22);
		this.textBox41.Name = "textBox41";
		this.textBox41.Size = new System.Drawing.Size(267, 29);
		this.textBox41.TabIndex = 51;
		this.label46.AutoSize = true;
		this.label46.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label46.Location = new System.Drawing.Point(16, 22);
		this.label46.Name = "label46";
		this.label46.Size = new System.Drawing.Size(206, 31);
		this.label46.TabIndex = 50;
		this.label46.Text = "企业唯一编码标识";
		this.label48.AutoSize = true;
		this.label48.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label48.Location = new System.Drawing.Point(402, 34);
		this.label48.Name = "label48";
		this.label48.Size = new System.Drawing.Size(134, 31);
		this.label48.TabIndex = 42;
		this.label48.Text = "录像机类型";
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label1.Location = new System.Drawing.Point(22, 160);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(158, 31);
		this.label1.TabIndex = 74;
		this.label1.Text = "图片保存路径";
		this.buttonEdit1.Location = new System.Drawing.Point(186, 158);
		this.buttonEdit1.MenuManager = this.barManager1;
		this.buttonEdit1.Name = "buttonEdit1";
		this.buttonEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.buttonEdit1.Properties.Appearance.Options.UseFont = true;
		this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.buttonEdit1.Size = new System.Drawing.Size(208, 36);
		this.buttonEdit1.TabIndex = 75;
		this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(buttonEdit1_ButtonClick);
		this.comboBox3.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox3.FormattingEnabled = true;
		this.comboBox3.Items.AddRange(new object[7] { "消纳场", "高凌", "腾跃", "中科九州", "安车", "天地人车", "信阳" });
		this.comboBox3.Location = new System.Drawing.Point(540, 157);
		this.comboBox3.Name = "comboBox3";
		this.comboBox3.Size = new System.Drawing.Size(134, 39);
		this.comboBox3.TabIndex = 81;
		this.comboBox3.SelectedIndexChanged += new System.EventHandler(comboBox3_SelectedIndexChanged);
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label3.Location = new System.Drawing.Point(423, 161);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(110, 31);
		this.label3.TabIndex = 80;
		this.label3.Text = "对接平台";
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[2] { "标准模式", "急速模式" });
		this.comboBox1.Location = new System.Drawing.Point(775, 102);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(134, 39);
		this.comboBox1.TabIndex = 87;
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label2.Location = new System.Drawing.Point(659, 105);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(110, 31);
		this.label2.TabIndex = 86;
		this.label2.Text = "启用模式";
		this.checkBox2.AutoSize = true;
		this.checkBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox2.Location = new System.Drawing.Point(735, 160);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(108, 35);
		this.checkBox2.TabIndex = 92;
		this.checkBox2.Text = "IO开关";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox3.AutoSize = true;
		this.checkBox3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox3.Location = new System.Drawing.Point(735, 41);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(177, 35);
		this.checkBox3.TabIndex = 97;
		this.checkBox3.Text = "开机自动启动";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox3.Click += new System.EventHandler(checkBox3_Click);
		this.checkBox4.AutoSize = true;
		this.checkBox4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox4.Location = new System.Drawing.Point(28, 222);
		this.checkBox4.Name = "checkBox4";
		this.checkBox4.Size = new System.Drawing.Size(403, 35);
		this.checkBox4.TabIndex = 102;
		this.checkBox4.Text = "是否验证补台账(weiyouyuan接口)";
		this.checkBox4.UseVisualStyleBackColor = true;
		this.tabControl2.Controls.Add(this.tabPage6);
		this.tabControl2.Controls.Add(this.tabPage7);
		this.tabControl2.Controls.Add(this.tabPage9);
		this.tabControl2.Controls.Add(this.tabPage10);
		this.tabControl2.Controls.Add(this.tabPage12);
		this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl2.Location = new System.Drawing.Point(0, 40);
		this.tabControl2.Name = "tabControl2";
		this.tabControl2.SelectedIndex = 0;
		this.tabControl2.Size = new System.Drawing.Size(1007, 300);
		this.tabControl2.TabIndex = 107;
		this.tabPage6.Controls.Add(this.comboBox6);
		this.tabPage6.Controls.Add(this.label52);
		this.tabPage6.Controls.Add(this.comboBox4);
		this.tabPage6.Controls.Add(this.label50);
		this.tabPage6.Controls.Add(this.checkBox6);
		this.tabPage6.Controls.Add(this.checkBox4);
		this.tabPage6.Controls.Add(this.checkBox1);
		this.tabPage6.Controls.Add(this.checkBox3);
		this.tabPage6.Controls.Add(this.checkBox7);
		this.tabPage6.Controls.Add(this.checkBox2);
		this.tabPage6.Controls.Add(this.label23);
		this.tabPage6.Controls.Add(this.comboBox1);
		this.tabPage6.Controls.Add(this.textBox19);
		this.tabPage6.Controls.Add(this.label2);
		this.tabPage6.Controls.Add(this.textBox20);
		this.tabPage6.Controls.Add(this.comboBox3);
		this.tabPage6.Controls.Add(this.label24);
		this.tabPage6.Controls.Add(this.label3);
		this.tabPage6.Controls.Add(this.label1);
		this.tabPage6.Controls.Add(this.buttonEdit1);
		this.tabPage6.Location = new System.Drawing.Point(4, 22);
		this.tabPage6.Name = "tabPage6";
		this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage6.Size = new System.Drawing.Size(999, 274);
		this.tabPage6.TabIndex = 0;
		this.tabPage6.Text = "基本设置";
		this.tabPage6.UseVisualStyleBackColor = true;
		this.comboBox6.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox6.FormattingEnabled = true;
		this.comboBox6.Items.AddRange(new object[9] { "-1 不限", "0 国一", "1 国二", "2 国三", "3 国四", "4 国五", "5 国六", "6 纯电", "7 混动" });
		this.comboBox6.Location = new System.Drawing.Point(795, 220);
		this.comboBox6.Name = "comboBox6";
		this.comboBox6.Size = new System.Drawing.Size(134, 39);
		this.comboBox6.TabIndex = 106;
		this.label52.AutoSize = true;
		this.label52.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label52.Location = new System.Drawing.Point(679, 226);
		this.label52.Name = "label52";
		this.label52.Size = new System.Drawing.Size(110, 31);
		this.label52.TabIndex = 105;
		this.label52.Text = "管控排放";
		this.comboBox4.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox4.FormattingEnabled = true;
		this.comboBox4.Items.AddRange(new object[3] { "ZH", "KFD", "YB" });
		this.comboBox4.Location = new System.Drawing.Point(539, 222);
		this.comboBox4.Name = "comboBox4";
		this.comboBox4.Size = new System.Drawing.Size(134, 39);
		this.comboBox4.TabIndex = 104;
		this.label50.AutoSize = true;
		this.label50.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label50.Location = new System.Drawing.Point(423, 225);
		this.label50.Name = "label50";
		this.label50.Size = new System.Drawing.Size(110, 31);
		this.label50.TabIndex = 103;
		this.label50.Text = "大屏类型";
		this.tabPage7.Controls.Add(this.button1);
		this.tabPage7.Controls.Add(this.label27);
		this.tabPage7.Controls.Add(this.textBox23);
		this.tabPage7.Controls.Add(this.label25);
		this.tabPage7.Controls.Add(this.textBox21);
		this.tabPage7.Controls.Add(this.label17);
		this.tabPage7.Controls.Add(this.textBox14);
		this.tabPage7.Controls.Add(this.label48);
		this.tabPage7.Controls.Add(this.comboBox2);
		this.tabPage7.Location = new System.Drawing.Point(4, 22);
		this.tabPage7.Name = "tabPage7";
		this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage7.Size = new System.Drawing.Size(999, 274);
		this.tabPage7.TabIndex = 1;
		this.tabPage7.Text = "抓拍配置";
		this.tabPage7.UseVisualStyleBackColor = true;
		this.button1.Location = new System.Drawing.Point(105, 216);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(115, 31);
		this.button1.TabIndex = 68;
		this.button1.Text = "测试连接";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label27.AutoSize = true;
		this.label27.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label27.Location = new System.Drawing.Point(25, 152);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(134, 31);
		this.label27.TabIndex = 66;
		this.label27.Text = "录像机密码";
		this.textBox23.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox23.Location = new System.Drawing.Point(161, 153);
		this.textBox23.Name = "textBox23";
		this.textBox23.PasswordChar = '*';
		this.textBox23.Size = new System.Drawing.Size(189, 34);
		this.textBox23.TabIndex = 67;
		this.label25.AutoSize = true;
		this.label25.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label25.Location = new System.Drawing.Point(25, 89);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(134, 31);
		this.label25.TabIndex = 64;
		this.label25.Text = "录像机账号";
		this.textBox21.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox21.Location = new System.Drawing.Point(161, 90);
		this.textBox21.Name = "textBox21";
		this.textBox21.Size = new System.Drawing.Size(189, 34);
		this.textBox21.TabIndex = 65;
		this.label17.AutoSize = true;
		this.label17.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label17.Location = new System.Drawing.Point(25, 30);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(108, 31);
		this.label17.TabIndex = 62;
		this.label17.Text = "录像机IP";
		this.textBox14.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox14.Location = new System.Drawing.Point(161, 31);
		this.textBox14.Name = "textBox14";
		this.textBox14.Size = new System.Drawing.Size(189, 34);
		this.textBox14.TabIndex = 63;
		this.comboBox2.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Items.AddRange(new object[2] { "hk", "dh" });
		this.comboBox2.Location = new System.Drawing.Point(553, 30);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(168, 35);
		this.comboBox2.TabIndex = 70;
		this.tabPage9.Controls.Add(this.panel1);
		this.tabPage9.Controls.Add(this.label34);
		this.tabPage9.Location = new System.Drawing.Point(4, 22);
		this.tabPage9.Name = "tabPage9";
		this.tabPage9.Size = new System.Drawing.Size(999, 274);
		this.tabPage9.TabIndex = 2;
		this.tabPage9.Text = "联动模块配置";
		this.tabPage9.UseVisualStyleBackColor = true;
		this.panel1.Controls.Add(this.radioButton2);
		this.panel1.Controls.Add(this.radioButton1);
		this.panel1.Location = new System.Drawing.Point(198, 24);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(289, 55);
		this.panel1.TabIndex = 62;
		this.radioButton2.AutoSize = true;
		this.radioButton2.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.radioButton2.Location = new System.Drawing.Point(135, 9);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(114, 35);
		this.radioButton2.TabIndex = 1;
		this.radioButton2.Text = "闭合--0";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton1.AutoSize = true;
		this.radioButton1.Checked = true;
		this.radioButton1.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.radioButton1.Location = new System.Drawing.Point(17, 9);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(114, 35);
		this.radioButton1.TabIndex = 0;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "闭合--1";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.label34.AutoSize = true;
		this.label34.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label34.Location = new System.Drawing.Point(10, 36);
		this.label34.Name = "label34";
		this.label34.Size = new System.Drawing.Size(182, 31);
		this.label34.TabIndex = 61;
		this.label34.Text = "开闸信号定义：";
		this.tabPage10.Controls.Add(this.comboBox5);
		this.tabPage10.Controls.Add(this.label51);
		this.tabPage10.Controls.Add(this.checkBox11);
		this.tabPage10.Controls.Add(this.checkBox10);
		this.tabPage10.Controls.Add(this.checkBox9);
		this.tabPage10.Controls.Add(this.label42);
		this.tabPage10.Controls.Add(this.textBox37);
		this.tabPage10.Controls.Add(this.checkBox8);
		this.tabPage10.Controls.Add(this.checkBox5);
		this.tabPage10.Location = new System.Drawing.Point(4, 22);
		this.tabPage10.Name = "tabPage10";
		this.tabPage10.Size = new System.Drawing.Size(999, 274);
		this.tabPage10.TabIndex = 3;
		this.tabPage10.Text = "第三方设置";
		this.tabPage10.UseVisualStyleBackColor = true;
		this.comboBox5.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox5.FormattingEnabled = true;
		this.comboBox5.Items.AddRange(new object[3] { "无", "同欣", "威特" });
		this.comboBox5.Location = new System.Drawing.Point(727, 28);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(178, 35);
		this.comboBox5.TabIndex = 111;
		this.label51.AutoSize = true;
		this.label51.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label51.Location = new System.Drawing.Point(595, 30);
		this.label51.Name = "label51";
		this.label51.Size = new System.Drawing.Size(110, 31);
		this.label51.TabIndex = 110;
		this.label51.Text = "地磅对接";
		this.checkBox11.AutoSize = true;
		this.checkBox11.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox11.Location = new System.Drawing.Point(211, 87);
		this.checkBox11.Name = "checkBox11";
		this.checkBox11.Size = new System.Drawing.Size(201, 35);
		this.checkBox11.TabIndex = 109;
		this.checkBox11.Text = "开启遥控警报灯";
		this.checkBox11.UseVisualStyleBackColor = true;
		this.checkBox10.AutoSize = true;
		this.checkBox10.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox10.Location = new System.Drawing.Point(20, 208);
		this.checkBox10.Name = "checkBox10";
		this.checkBox10.Size = new System.Drawing.Size(177, 35);
		this.checkBox10.TabIndex = 108;
		this.checkBox10.Text = "开启视频录像";
		this.checkBox10.UseVisualStyleBackColor = true;
		this.checkBox9.AutoSize = true;
		this.checkBox9.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox9.Location = new System.Drawing.Point(20, 146);
		this.checkBox9.Name = "checkBox9";
		this.checkBox9.Size = new System.Drawing.Size(225, 35);
		this.checkBox9.TabIndex = 107;
		this.checkBox9.Text = "开启电脑语音播报";
		this.checkBox9.UseVisualStyleBackColor = true;
		this.label42.AutoSize = true;
		this.label42.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label42.Location = new System.Drawing.Point(260, 27);
		this.label42.Name = "label42";
		this.label42.Size = new System.Drawing.Size(111, 31);
		this.label42.TabIndex = 105;
		this.label42.Text = "客户端ID";
		this.textBox37.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox37.Location = new System.Drawing.Point(375, 27);
		this.textBox37.Name = "textBox37";
		this.textBox37.Size = new System.Drawing.Size(189, 34);
		this.textBox37.TabIndex = 106;
		this.checkBox8.AutoSize = true;
		this.checkBox8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox8.Location = new System.Drawing.Point(20, 87);
		this.checkBox8.Name = "checkBox8";
		this.checkBox8.Size = new System.Drawing.Size(153, 35);
		this.checkBox8.TabIndex = 104;
		this.checkBox8.Text = "上传服务器";
		this.checkBox8.UseVisualStyleBackColor = true;
		this.checkBox5.AutoSize = true;
		this.checkBox5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.checkBox5.Location = new System.Drawing.Point(20, 26);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(225, 35);
		this.checkBox5.TabIndex = 103;
		this.checkBox5.Text = "必须填写货物开闸";
		this.checkBox5.UseVisualStyleBackColor = true;
		this.tabPage12.Controls.Add(this.label58);
		this.tabPage12.Controls.Add(this.textBox47);
		this.tabPage12.Controls.Add(this.comboBox8);
		this.tabPage12.Controls.Add(this.label57);
		this.tabPage12.Controls.Add(this.label56);
		this.tabPage12.Controls.Add(this.textBox46);
		this.tabPage12.Controls.Add(this.label55);
		this.tabPage12.Controls.Add(this.textBox45);
		this.tabPage12.Controls.Add(this.label54);
		this.tabPage12.Controls.Add(this.textBox44);
		this.tabPage12.Controls.Add(this.comboBox7);
		this.tabPage12.Controls.Add(this.label53);
		this.tabPage12.Location = new System.Drawing.Point(4, 22);
		this.tabPage12.Name = "tabPage12";
		this.tabPage12.Size = new System.Drawing.Size(999, 274);
		this.tabPage12.TabIndex = 4;
		this.tabPage12.Text = "接口平台管理";
		this.tabPage12.UseVisualStyleBackColor = true;
		this.label58.AutoSize = true;
		this.label58.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label58.Location = new System.Drawing.Point(502, 166);
		this.label58.Name = "label58";
		this.label58.Size = new System.Drawing.Size(182, 31);
		this.label58.TabIndex = 115;
		this.label58.Text = "行驶证服务地址";
		this.textBox47.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox47.Location = new System.Drawing.Point(690, 166);
		this.textBox47.Name = "textBox47";
		this.textBox47.Size = new System.Drawing.Size(229, 34);
		this.textBox47.TabIndex = 116;
		this.comboBox8.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox8.FormattingEnabled = true;
		this.comboBox8.Location = new System.Drawing.Point(690, 94);
		this.comboBox8.Name = "comboBox8";
		this.comboBox8.Size = new System.Drawing.Size(229, 39);
		this.comboBox8.TabIndex = 114;
		this.label57.AutoSize = true;
		this.label57.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label57.Location = new System.Drawing.Point(574, 102);
		this.label57.Name = "label57";
		this.label57.Size = new System.Drawing.Size(110, 31);
		this.label57.TabIndex = 113;
		this.label57.Text = "岗亭编码";
		this.label56.AutoSize = true;
		this.label56.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label56.Location = new System.Drawing.Point(597, 30);
		this.label56.Name = "label56";
		this.label56.Size = new System.Drawing.Size(87, 31);
		this.label56.TabIndex = 111;
		this.label56.Text = "企业ID";
		this.textBox46.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox46.Location = new System.Drawing.Point(690, 31);
		this.textBox46.Name = "textBox46";
		this.textBox46.Size = new System.Drawing.Size(229, 34);
		this.textBox46.TabIndex = 112;
		this.label55.AutoSize = true;
		this.label55.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label55.Location = new System.Drawing.Point(12, 169);
		this.label55.Name = "label55";
		this.label55.Size = new System.Drawing.Size(234, 31);
		this.label55.TabIndex = 109;
		this.label55.Text = "超低排放IIS图片地址";
		this.textBox45.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox45.Location = new System.Drawing.Point(255, 170);
		this.textBox45.Name = "textBox45";
		this.textBox45.Size = new System.Drawing.Size(229, 34);
		this.textBox45.TabIndex = 110;
		this.label54.AutoSize = true;
		this.label54.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label54.Location = new System.Drawing.Point(31, 102);
		this.label54.Name = "label54";
		this.label54.Size = new System.Drawing.Size(206, 31);
		this.label54.TabIndex = 107;
		this.label54.Text = "超低排放接口地址";
		this.textBox44.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.textBox44.Location = new System.Drawing.Point(255, 103);
		this.textBox44.Name = "textBox44";
		this.textBox44.Size = new System.Drawing.Size(229, 34);
		this.textBox44.TabIndex = 108;
		this.comboBox7.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.comboBox7.FormattingEnabled = true;
		this.comboBox7.Items.AddRange(new object[3] { "无", "易玖", "禾美" });
		this.comboBox7.Location = new System.Drawing.Point(259, 31);
		this.comboBox7.Name = "comboBox7";
		this.comboBox7.Size = new System.Drawing.Size(225, 39);
		this.comboBox7.TabIndex = 83;
		this.label53.AutoSize = true;
		this.label53.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label53.Location = new System.Drawing.Point(33, 34);
		this.label53.Name = "label53";
		this.label53.Size = new System.Drawing.Size(206, 31);
		this.label53.TabIndex = 82;
		this.label53.Text = "超低排放接口平台";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1007, 609);
		base.Controls.Add(this.tabControl2);
		base.Controls.Add(this.tabControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "SystemSetForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "系统设置";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage1.PerformLayout();
		this.tabPage2.ResumeLayout(false);
		this.tabPage2.PerformLayout();
		this.tabPage4.ResumeLayout(false);
		this.tabPage4.PerformLayout();
		this.tabPage3.ResumeLayout(false);
		this.tabPage3.PerformLayout();
		this.tabPage5.ResumeLayout(false);
		this.tabPage5.PerformLayout();
		this.tabPage8.ResumeLayout(false);
		this.tabPage8.PerformLayout();
		this.tabPage11.ResumeLayout(false);
		this.tabPage11.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.buttonEdit1.Properties).EndInit();
		this.tabControl2.ResumeLayout(false);
		this.tabPage6.ResumeLayout(false);
		this.tabPage6.PerformLayout();
		this.tabPage7.ResumeLayout(false);
		this.tabPage7.PerformLayout();
		this.tabPage9.ResumeLayout(false);
		this.tabPage9.PerformLayout();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.tabPage10.ResumeLayout(false);
		this.tabPage10.PerformLayout();
		this.tabPage12.ResumeLayout(false);
		this.tabPage12.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
