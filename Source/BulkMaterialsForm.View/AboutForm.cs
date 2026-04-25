// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.AboutForm

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using BulkMaterialsForm.Help;

namespace BulkMaterialsForm.View;

public class AboutForm : Form
{
	private IContainer components;

	private Panel topPanel;

	private Label lblTitle;

	private Label lblSubTitle;

	private GroupBox groupBoxSystem;

	private GroupBox groupBoxSupport;

	private Button btnActivate;

	private Button btnOK;

	private Label lblVersionLabel;

	private Label lblVersionValue;

	private Label lblProjectLabel;

	private Label lblProjectValue;

	private Label lblExpireLabel;

	private Label lblExpireValue;

	private Label lblStatusLabel;

	private Label lblStatusValue;

	private Label lblCompanyLabel;

	private Label lblCompanyValue;

	private Label lblPhoneLabel;

	private Label lblPhoneValue;

	private Label lblEmailLabel;

	private Label lblEmailValue;

	private Label lblWebsiteLabel;

	private Label lblWebsiteValue;

	public AboutForm()
	{
		InitializeComponent();
		LoadAboutInfo();
	}

	private void LoadAboutInfo()
	{
		try
		{
			lblVersionValue.Text = "V2.0.1 Build 20250118";
			string text = MainData.XMMC ?? "未设置项目名称";
			lblProjectValue.Text = text;
			DateTime dateTime = MainData.ExpTime;
			if (dateTime == default(DateTime))
			{
				dateTime = DateTime.Now.AddDays(365.0);
			}
			lblExpireValue.Text = dateTime.ToString("yyyy年MM月dd日");
			if (Activation.IsActivate)
			{
				lblStatusValue.Text = "已激活";
				lblStatusValue.ForeColor = Color.FromArgb(76, 175, 80);
				btnActivate.Text = "重新激活";
			}
			else if (Activation.IsTrialActive())
			{
				int trialRemainingDays = Activation.GetTrialRemainingDays();
				lblStatusValue.Text = $"试用期剩余 {trialRemainingDays} 天";
				lblStatusValue.ForeColor = Color.FromArgb(255, 152, 0);
				btnActivate.Text = "立即激活";
			}
			else
			{
				lblStatusValue.Text = "未激活";
				lblStatusValue.ForeColor = Color.FromArgb(244, 67, 54);
				btnActivate.Text = "立即激活";
			}
			string maintenanceCompany = GetMaintenanceCompany();
			lblCompanyValue.Text = maintenanceCompany;
			string maintenancePhone = GetMaintenancePhone();
			lblPhoneValue.Text = maintenancePhone;
			lblEmailValue.Text = "support@envgate.com";
			lblWebsiteValue.Text = "www.envgate.com";
		}
		catch (Exception ex)
		{
			lblVersionValue.Text = "V2.0.1";
			lblProjectValue.Text = "系统信息加载失败";
			lblExpireValue.Text = DateTime.Now.AddDays(30.0).ToString("yyyy年MM月dd日");
			lblStatusValue.Text = "未知";
			lblStatusValue.ForeColor = Color.Gray;
			lblCompanyValue.Text = "默认运维公司";
			lblPhoneValue.Text = "400-888-8888";
			Console.WriteLine("AboutForm加载信息失败: " + ex.Message);
		}
	}

	private string GetMaintenanceCompany()
	{
		try
		{
			string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "API", "MaintenanceInfo.config");
			if (File.Exists(text))
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(text);
				XmlNode xmlNode = xmlDocument.SelectSingleNode("//maintenanceInfo/company");
				if (xmlNode != null && !string.IsNullOrWhiteSpace(xmlNode.InnerText))
				{
					return xmlNode.InnerText.Trim();
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("读取运维公司信息失败: " + ex.Message);
		}
		return "环保科技有限公司";
	}

	private string GetMaintenancePhone()
	{
		try
		{
			string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "API", "MaintenanceInfo.config");
			if (File.Exists(text))
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(text);
				XmlNode xmlNode = xmlDocument.SelectSingleNode("//maintenanceInfo/phone");
				if (xmlNode != null && !string.IsNullOrWhiteSpace(xmlNode.InnerText))
				{
					return xmlNode.InnerText.Trim();
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("读取运维电话信息失败: " + ex.Message);
		}
		return "400-888-8888";
	}

	private void BtnActivate_Click(object sender, EventArgs e)
	{
		try
		{
			if (new FormActivate().ShowDialog(this) == DialogResult.OK)
			{
				LoadAboutInfo();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("打开激活窗口失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void BtnOK_Click(object sender, EventArgs e)
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
		base.SuspendLayout();
		this.Text = "关于 - 环保运输门禁系统";
		base.ClientSize = new System.Drawing.Size(520, 480);
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
		this.topPanel = new System.Windows.Forms.Panel();
		this.topPanel.Location = new System.Drawing.Point(0, 0);
		this.topPanel.Size = new System.Drawing.Size(520, 100);
		this.topPanel.BackColor = System.Drawing.Color.FromArgb(24, 144, 255);
		this.lblTitle = new System.Windows.Forms.Label();
		this.lblTitle.Text = "环保运输门禁系统";
		this.lblTitle.Location = new System.Drawing.Point(0, 25);
		this.lblTitle.Size = new System.Drawing.Size(520, 35);
		this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 20f, System.Drawing.FontStyle.Bold);
		this.lblTitle.ForeColor = System.Drawing.Color.White;
		this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lblTitle.BackColor = System.Drawing.Color.Transparent;
		this.topPanel.Controls.Add(this.lblTitle);
		this.lblSubTitle = new System.Windows.Forms.Label();
		this.lblSubTitle.Text = "ENVIRONMENTAL PROTECTION GATE SYSTEM";
		this.lblSubTitle.Location = new System.Drawing.Point(0, 60);
		this.lblSubTitle.Size = new System.Drawing.Size(520, 20);
		this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9f);
		this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(200, 255, 255, 255);
		this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
		this.topPanel.Controls.Add(this.lblSubTitle);
		this.groupBoxSystem = new System.Windows.Forms.GroupBox();
		this.groupBoxSystem.Text = " 系统信息 ";
		this.groupBoxSystem.Location = new System.Drawing.Point(20, 115);
		this.groupBoxSystem.Size = new System.Drawing.Size(480, 160);
		this.groupBoxSystem.Font = new System.Drawing.Font("微软雅黑", 10f, System.Drawing.FontStyle.Bold);
		this.groupBoxSystem.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
		int num = 30;
		int num2 = 120;
		int num3 = 30;
		int num4 = 30;
		this.lblVersionLabel = new System.Windows.Forms.Label();
		this.lblVersionLabel.Text = "软件版本：";
		this.lblVersionLabel.Location = new System.Drawing.Point(num, num3);
		this.lblVersionLabel.Size = new System.Drawing.Size(80, 25);
		this.lblVersionLabel.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblVersionLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.lblVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblVersionValue = new System.Windows.Forms.Label();
		this.lblVersionValue.Text = "V2.0.1";
		this.lblVersionValue.Location = new System.Drawing.Point(num2, num3);
		this.lblVersionValue.Size = new System.Drawing.Size(320, 25);
		this.lblVersionValue.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblVersionValue.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
		this.lblVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblProjectLabel = new System.Windows.Forms.Label();
		this.lblProjectLabel.Text = "项目名称：";
		this.lblProjectLabel.Location = new System.Drawing.Point(num, num3 + num4);
		this.lblProjectLabel.Size = new System.Drawing.Size(80, 25);
		this.lblProjectLabel.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblProjectLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.lblProjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblProjectValue = new System.Windows.Forms.Label();
		this.lblProjectValue.Text = "项目名称";
		this.lblProjectValue.Location = new System.Drawing.Point(num2, num3 + num4);
		this.lblProjectValue.Size = new System.Drawing.Size(320, 25);
		this.lblProjectValue.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblProjectValue.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
		this.lblProjectValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblExpireLabel = new System.Windows.Forms.Label();
		this.lblExpireLabel.Text = "到期日期：";
		this.lblExpireLabel.Location = new System.Drawing.Point(num, num3 + num4 * 2);
		this.lblExpireLabel.Size = new System.Drawing.Size(80, 25);
		this.lblExpireLabel.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblExpireLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.lblExpireLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblExpireValue = new System.Windows.Forms.Label();
		this.lblExpireValue.Text = "2025年12月31日";
		this.lblExpireValue.Location = new System.Drawing.Point(num2, num3 + num4 * 2);
		this.lblExpireValue.Size = new System.Drawing.Size(320, 25);
		this.lblExpireValue.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblExpireValue.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
		this.lblExpireValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStatusLabel = new System.Windows.Forms.Label();
		this.lblStatusLabel.Text = "激活状态：";
		this.lblStatusLabel.Location = new System.Drawing.Point(num, num3 + num4 * 3);
		this.lblStatusLabel.Size = new System.Drawing.Size(80, 25);
		this.lblStatusLabel.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.lblStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStatusValue = new System.Windows.Forms.Label();
		this.lblStatusValue.Text = "已激活";
		this.lblStatusValue.Location = new System.Drawing.Point(num2, num3 + num4 * 3);
		this.lblStatusValue.Size = new System.Drawing.Size(200, 25);
		this.lblStatusValue.Font = new System.Drawing.Font("微软雅黑", 10f, System.Drawing.FontStyle.Bold);
		this.lblStatusValue.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
		this.lblStatusValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnActivate = new System.Windows.Forms.Button();
		this.btnActivate.Text = "立即激活";
		this.btnActivate.Location = new System.Drawing.Point(350, num3 + num4 * 3 - 2);
		this.btnActivate.Size = new System.Drawing.Size(90, 30);
		this.btnActivate.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.btnActivate.BackColor = System.Drawing.Color.FromArgb(24, 144, 255);
		this.btnActivate.ForeColor = System.Drawing.Color.White;
		this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnActivate.FlatAppearance.BorderSize = 0;
		this.btnActivate.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnActivate.Click += new System.EventHandler(BtnActivate_Click);
		this.groupBoxSystem.Controls.Add(this.lblVersionLabel);
		this.groupBoxSystem.Controls.Add(this.lblVersionValue);
		this.groupBoxSystem.Controls.Add(this.lblProjectLabel);
		this.groupBoxSystem.Controls.Add(this.lblProjectValue);
		this.groupBoxSystem.Controls.Add(this.lblExpireLabel);
		this.groupBoxSystem.Controls.Add(this.lblExpireValue);
		this.groupBoxSystem.Controls.Add(this.lblStatusLabel);
		this.groupBoxSystem.Controls.Add(this.lblStatusValue);
		this.groupBoxSystem.Controls.Add(this.btnActivate);
		this.groupBoxSupport = new System.Windows.Forms.GroupBox();
		this.groupBoxSupport.Text = " 技术支持 ";
		this.groupBoxSupport.Location = new System.Drawing.Point(20, 285);
		this.groupBoxSupport.Size = new System.Drawing.Size(480, 130);
		this.groupBoxSupport.Font = new System.Drawing.Font("微软雅黑", 10f, System.Drawing.FontStyle.Bold);
		this.groupBoxSupport.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
		this.lblCompanyLabel = new System.Windows.Forms.Label();
		this.lblCompanyLabel.Text = "运维公司：";
		this.lblCompanyLabel.Location = new System.Drawing.Point(num, 30);
		this.lblCompanyLabel.Size = new System.Drawing.Size(80, 25);
		this.lblCompanyLabel.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblCompanyLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.lblCompanyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblCompanyValue = new System.Windows.Forms.Label();
		this.lblCompanyValue.Text = "环保科技有限公司";
		this.lblCompanyValue.Location = new System.Drawing.Point(num2, 30);
		this.lblCompanyValue.Size = new System.Drawing.Size(320, 25);
		this.lblCompanyValue.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblCompanyValue.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
		this.lblCompanyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblPhoneLabel = new System.Windows.Forms.Label();
		this.lblPhoneLabel.Text = "服务热线：";
		this.lblPhoneLabel.Location = new System.Drawing.Point(num, 55);
		this.lblPhoneLabel.Size = new System.Drawing.Size(80, 25);
		this.lblPhoneLabel.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblPhoneLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.lblPhoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblPhoneValue = new System.Windows.Forms.Label();
		this.lblPhoneValue.Text = "400-888-8888";
		this.lblPhoneValue.Location = new System.Drawing.Point(num2, 55);
		this.lblPhoneValue.Size = new System.Drawing.Size(320, 25);
		this.lblPhoneValue.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblPhoneValue.ForeColor = System.Drawing.Color.FromArgb(24, 144, 255);
		this.lblPhoneValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblPhoneValue.Cursor = System.Windows.Forms.Cursors.Hand;
		this.lblEmailLabel = new System.Windows.Forms.Label();
		this.lblEmailLabel.Text = "电子邮箱：";
		this.lblEmailLabel.Location = new System.Drawing.Point(num, 80);
		this.lblEmailLabel.Size = new System.Drawing.Size(80, 25);
		this.lblEmailLabel.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblEmailLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.lblEmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblEmailValue = new System.Windows.Forms.Label();
		this.lblEmailValue.Text = "support@envgate.com";
		this.lblEmailValue.Location = new System.Drawing.Point(num2, 80);
		this.lblEmailValue.Size = new System.Drawing.Size(150, 25);
		this.lblEmailValue.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblEmailValue.ForeColor = System.Drawing.Color.FromArgb(24, 144, 255);
		this.lblEmailValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblEmailValue.Cursor = System.Windows.Forms.Cursors.Hand;
		this.lblWebsiteLabel = new System.Windows.Forms.Label();
		this.lblWebsiteLabel.Text = "官方网站：";
		this.lblWebsiteLabel.Location = new System.Drawing.Point(280, 80);
		this.lblWebsiteLabel.Size = new System.Drawing.Size(80, 25);
		this.lblWebsiteLabel.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblWebsiteLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.lblWebsiteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblWebsiteValue = new System.Windows.Forms.Label();
		this.lblWebsiteValue.Text = "www.envgate.com";
		this.lblWebsiteValue.Location = new System.Drawing.Point(360, 80);
		this.lblWebsiteValue.Size = new System.Drawing.Size(110, 25);
		this.lblWebsiteValue.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblWebsiteValue.ForeColor = System.Drawing.Color.FromArgb(24, 144, 255);
		this.lblWebsiteValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblWebsiteValue.Cursor = System.Windows.Forms.Cursors.Hand;
		this.groupBoxSupport.Controls.Add(this.lblCompanyLabel);
		this.groupBoxSupport.Controls.Add(this.lblCompanyValue);
		this.groupBoxSupport.Controls.Add(this.lblPhoneLabel);
		this.groupBoxSupport.Controls.Add(this.lblPhoneValue);
		this.groupBoxSupport.Controls.Add(this.lblEmailLabel);
		this.groupBoxSupport.Controls.Add(this.lblEmailValue);
		this.groupBoxSupport.Controls.Add(this.lblWebsiteLabel);
		this.groupBoxSupport.Controls.Add(this.lblWebsiteValue);
		this.btnOK = new System.Windows.Forms.Button();
		this.btnOK.Text = "确 定";
		this.btnOK.Location = new System.Drawing.Point(215, 430);
		this.btnOK.Size = new System.Drawing.Size(90, 35);
		this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.btnOK.BackColor = System.Drawing.Color.FromArgb(96, 125, 139);
		this.btnOK.ForeColor = System.Drawing.Color.White;
		this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOK.FlatAppearance.BorderSize = 0;
		this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnOK.Click += new System.EventHandler(BtnOK_Click);
		System.Windows.Forms.Label label = new System.Windows.Forms.Label();
		label.Text = "© 2025 环保科技有限公司 版权所有";
		label.Location = new System.Drawing.Point(0, 455);
		label.Size = new System.Drawing.Size(520, 20);
		label.Font = new System.Drawing.Font("微软雅黑", 8f);
		label.ForeColor = System.Drawing.Color.FromArgb(158, 158, 158);
		label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label.BackColor = System.Drawing.Color.Transparent;
		base.Controls.Add(this.topPanel);
		base.Controls.Add(this.groupBoxSystem);
		base.Controls.Add(this.groupBoxSupport);
		base.Controls.Add(this.btnOK);
		base.Controls.Add(label);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
