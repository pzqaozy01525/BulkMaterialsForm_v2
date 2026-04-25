// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.FormActivate

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BulkMaterialsForm.API;
using BulkMaterialsForm.Help;

namespace BulkMaterialsForm.View;

public class FormActivate : Form
{
	private IContainer components;

	private GroupBox groupBoxEnterprise;

	private Label lblCompanyName;

	private TextBox txtCompanyName;

	private Label lblCreditCode;

	private TextBox txtCreditCode;

	private Label lblPollutionPermit;

	private TextBox txtPollutionPermit;

	private Label lblContact;

	private TextBox txtContact;

	private Label lblPhone;

	private TextBox txtPhone;

	private GroupBox groupBoxSystem;

	private Label lblMachineCode;

	private TextBox txtMachineCode;

	private Label lblClientId;

	private TextBox txtClientId;

	private GroupBox groupBoxActivation;

	private Label lblActivationCode;

	private TextBox txtActivationCode;

	private Button btnOnlineActivate;

	private Button btnOfflineActivate;

	private Button btnTrial;

	private Button btnExportInfo;

	private Button btnImportLicense;

	private Label labelTrialInfo;

	public FormActivate()
	{
		InitializeComponent();
		base.Load += FormActivate_Load;
	}

	private void FormActivate_Load(object sender, EventArgs e)
	{
		try
		{
			txtMachineCode.Text = Activation.softAuthorize.GetInfo();
			UpdateTrialInfo();
			UpdateClientId();
			RefreshSupportInfo();
		}
		catch (Exception ex)
		{
			MessageBox.Show("初始化激活信息失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			LogSave.SaveExeLog("FormActivate_Load 异常: " + ex.Message);
		}
	}

	private async void RefreshSupportInfo()
	{
		try
		{
			HybridActivationAPI instance = HybridActivationAPI.Instance;
			instance.Initialize();
			string info = Activation.softAuthorize.GetInfo();
			ActivationResult activationResult = await instance.VerifyActivationAsync(info);
			if (!string.IsNullOrWhiteSpace(activationResult.SupportName))
			{
				New_IniFile.WriteContentValue("窗体框架配制", "SupportName", activationResult.SupportName, MainData.Spath);
			}
			if (!string.IsNullOrWhiteSpace(activationResult.SupportPhone))
			{
				New_IniFile.WriteContentValue("窗体框架配制", "SupportPhone", activationResult.SupportPhone, MainData.Spath);
			}
			if (!string.IsNullOrWhiteSpace(activationResult.SupportCompany))
			{
				New_IniFile.WriteContentValue("窗体框架配制", "SupportCompany", activationResult.SupportCompany, MainData.Spath);
			}
			if (!string.IsNullOrWhiteSpace(activationResult.SupportPhone))
			{
				LogSave.SaveExeLog("技术支持信息已刷新: " + activationResult.SupportCompany + " " + activationResult.SupportName + " " + activationResult.SupportPhone);
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("RefreshSupportInfo失败: " + ex.Message);
		}
	}

	private void UpdateTrialInfo()
	{
		try
		{
			if (Activation.IsActivate)
			{
				labelTrialInfo.Text = "软件已正式激活";
				labelTrialInfo.ForeColor = Color.Green;
				btnTrial.Enabled = false;
			}
			else if (Activation.IsTrialActive())
			{
				int trialRemainingDays = Activation.GetTrialRemainingDays();
				labelTrialInfo.Text = $"试用期剩余：{trialRemainingDays} 天";
				labelTrialInfo.ForeColor = ((trialRemainingDays > 3) ? Color.Blue : Color.Orange);
				btnTrial.Enabled = false;
			}
			else if (Activation.HasTrialExpired())
			{
				labelTrialInfo.Text = "试用期已过期，请激活软件";
				labelTrialInfo.ForeColor = Color.Red;
				btnTrial.Enabled = false;
			}
			else
			{
				labelTrialInfo.Text = "可以开始15天免费试用";
				labelTrialInfo.ForeColor = Color.Blue;
				btnTrial.Enabled = true;
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("UpdateTrialInfo失败: " + ex.Message);
			labelTrialInfo.Text = "可以开始15天免费试用";
			labelTrialInfo.ForeColor = Color.Blue;
			btnTrial.Enabled = true;
		}
	}

	private void txtCompanyInfo_TextChanged(object sender, EventArgs e)
	{
		UpdateClientId();
	}

	private void UpdateClientId()
	{
		if (!string.IsNullOrWhiteSpace(txtCompanyName.Text) && !string.IsNullOrWhiteSpace(txtCreditCode.Text))
		{
			string text = GenerateClientId();
			txtClientId.Text = text;
		}
	}

	private string GenerateClientId()
	{
		string text = txtCompanyName.Text.Trim();
		string text2 = txtCreditCode.Text.Trim();
		string text3 = txtMachineCode.Text.Trim();
		string input = text2 + "_" + text + "_" + text3;
		return GetMD5Hash(input).Substring(0, 16).ToUpper();
	}

	private string GetMD5Hash(string input)
	{
		using MD5 mD = MD5.Create();
		byte[] bytes = Encoding.UTF8.GetBytes(input);
		byte[] array = mD.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("X2"));
		}
		return stringBuilder.ToString();
	}

	private bool ValidateInput()
	{
		if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
		{
			MessageBox.Show("请输入企业名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtCompanyName.Focus();
			return false;
		}
		if (string.IsNullOrWhiteSpace(txtCreditCode.Text))
		{
			MessageBox.Show("请输入统一社会信用代码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtCreditCode.Focus();
			return false;
		}
		if (string.IsNullOrWhiteSpace(txtPollutionPermit.Text))
		{
			MessageBox.Show("请输入排污许可证编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtPollutionPermit.Focus();
			return false;
		}
		if (string.IsNullOrWhiteSpace(txtContact.Text))
		{
			MessageBox.Show("请输入联系人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtContact.Focus();
			return false;
		}
		if (string.IsNullOrWhiteSpace(txtPhone.Text))
		{
			MessageBox.Show("请输入联系电话！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtPhone.Focus();
			return false;
		}
		if (!Regex.IsMatch(txtPhone.Text, "^1[3-9]\\d{9}$|^0\\d{2,3}-?\\d{7,8}$"))
		{
			MessageBox.Show("请输入正确的联系电话！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtPhone.Focus();
			return false;
		}
		return true;
	}

	private void SyncToSystemSettings(string creditCode, string pollutionPermit)
	{
		try
		{
			switch (New_IniFile.ReadContentValue("窗体框架配制", "platFormType", MainData.Spath))
			{
			case "腾跃":
				New_IniFile.WriteContentValue("窗体框架配制", "腾跃信用代码", creditCode, MainData.Spath);
				break;
			case "安车":
				New_IniFile.WriteContentValue("窗体框架配制", "安车编码标识", creditCode, MainData.Spath);
				New_IniFile.WriteContentValue("窗体框架配制", "安车排污许可证编号", pollutionPermit, MainData.Spath);
				break;
			case "天地人车":
				New_IniFile.WriteContentValue("窗体框架配制", "天地人车企业编码", creditCode, MainData.Spath);
				New_IniFile.WriteContentValue("窗体框架配制", "天地人车排污许可证编号", pollutionPermit, MainData.Spath);
				break;
			case "信阳":
				New_IniFile.WriteContentValue("窗体框架配制", "信阳企业编码", creditCode, MainData.Spath);
				break;
			}
			New_IniFile.WriteContentValue("窗体框架配制", "客户端ID", txtClientId.Text, MainData.Spath);
			New_IniFile.WriteContentValue("企业信息", "企业名称", txtCompanyName.Text, MainData.Spath);
			New_IniFile.WriteContentValue("企业信息", "统一社会信用代码", creditCode, MainData.Spath);
			New_IniFile.WriteContentValue("企业信息", "排污许可证编号", pollutionPermit, MainData.Spath);
			New_IniFile.WriteContentValue("企业信息", "联系人", txtContact.Text, MainData.Spath);
			New_IniFile.WriteContentValue("企业信息", "联系电话", txtPhone.Text, MainData.Spath);
		}
		catch (Exception ex)
		{
			MessageBox.Show("同步到系统设置失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private async void btnOnlineActivate_Click(object sender, EventArgs e)
	{
		if (!ValidateInput())
		{
			return;
		}
		btnOnlineActivate.Enabled = false;
		btnOnlineActivate.Text = "提交中...";
		try
		{
			ActivationRequest request = new ActivationRequest
			{
				CompanyName = txtCompanyName.Text.Trim(),
				CreditCode = txtCreditCode.Text.Trim(),
				PollutionPermit = txtPollutionPermit.Text.Trim(),
				Contact = txtContact.Text.Trim(),
				Phone = txtPhone.Text.Trim(),
				MachineCode = txtMachineCode.Text.Trim(),
				ClientId = txtClientId.Text.Trim()
			};
			HybridActivationAPI instance = HybridActivationAPI.Instance;
			instance.Initialize();
			ActivationRequestResult activationRequestResult = await instance.SubmitActivationRequestAsync(request);
			if (activationRequestResult.Success)
			{
				SyncToSystemSettings(txtCreditCode.Text.Trim(), txtPollutionPermit.Text.Trim());
				if (activationRequestResult.IsActive)
				{
					string text = ((!string.IsNullOrEmpty(activationRequestResult.AdminPassword) && activationRequestResult.AdminPassword != "******") ? activationRequestResult.AdminPassword : (txtPhone.Text.Trim() + "@147"));
					MessageBox.Show("企业激活成功！\n\n企业名称: " + (activationRequestResult.CompanyName ?? txtCompanyName.Text.Trim()) + "\n统一社会信用代码: " + (activationRequestResult.CreditCode ?? txtCreditCode.Text.Trim()) + "\n联系人: " + (activationRequestResult.Contact ?? txtContact.Text.Trim()) + "\n联系电话: " + (activationRequestResult.Phone ?? txtPhone.Text.Trim()) + "\n\n=== 企业管理账号 ===\n用户名: " + (activationRequestResult.AdminUsername ?? txtPhone.Text.Trim()) + "\n默认密码: " + text + "\n\n授权到期: " + (activationRequestResult.ExpireDate.HasValue ? activationRequestResult.ExpireDate.Value.ToString("yyyy-MM-dd") : "未设置") + "\n\n请妥善保管账号信息，用于登录管理后台。", "激活成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					LogSave.SaveExeLog($"企业激活成功: {activationRequestResult.CompanyName}, 管理员: {activationRequestResult.AdminUsername}, 到期: {activationRequestResult.ExpireDate}");
				}
				else if (!string.IsNullOrEmpty(activationRequestResult.ActivationCode))
				{
					txtActivationCode.Text = activationRequestResult.ActivationCode;
					MessageBox.Show("激活请求提交成功！\n\n请求ID: " + (activationRequestResult.RequestId ?? "-") + "\n激活码: " + activationRequestResult.ActivationCode + "\n\n请使用激活码完成激活。", "提交成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("激活请求已提交，请等待审核。\n\n请求ID: " + (activationRequestResult.RequestId ?? "-"), "提交成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			else
			{
				MessageBox.Show("激活请求提交失败：" + activationRequestResult.Message, "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("在线激活失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			btnOnlineActivate.Enabled = true;
			btnOnlineActivate.Text = "在线激活";
		}
	}

	private async void btnSoftwareActivate_Click(object sender, EventArgs e)
	{
		if (!ValidateInput())
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(txtActivationCode.Text))
		{
			MessageBox.Show("请输入激活码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtActivationCode.Focus();
			return;
		}
		btnOfflineActivate.Enabled = false;
		btnOfflineActivate.Text = "验证中...";
		try
		{
			string text = txtActivationCode.Text.Trim();
			string text2 = SecureActivationStore.DesDecrypt(text);
			if (string.IsNullOrEmpty(text2) || !text2.Contains("|"))
			{
				MessageBox.Show("激活码格式无效！", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string[] array = text2.Split('|');
			if (array.Length < 3)
			{
				MessageBox.Show("激活码数据不完整！", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string text3 = array[0];
			string info = Activation.softAuthorize.GetInfo();
			DateTime expiryDate;
			if (text3 != info)
			{
				MessageBox.Show("激活码与当前机器不匹配！\n\n激活码对应机器: " + text3.Substring(0, Math.Min(8, text3.Length)) + "...\n当前机器: " + info.Substring(0, Math.Min(8, info.Length)) + "...", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (!DateTime.TryParse(array[2], out expiryDate))
			{
				MessageBox.Show("激活码过期日期格式无效！", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (expiryDate <= DateTime.Now)
			{
				MessageBox.Show($"激活码已过期！到期时间: {expiryDate:yyyy-MM-dd}", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (!Activation.SaveActivation(text))
			{
				MessageBox.Show("激活失败！无法保存激活信息。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				SyncToSystemSettings(txtCreditCode.Text, txtPollutionPermit.Text);
				Activation.MarkAsActivated("软件激活-激活码验证");
				New_IniFile.WriteContentValue("窗体框架配制", "激活码", text, MainData.Spath);
				MainData.RefreshExpTime();
				HybridActivationAPI instance = HybridActivationAPI.Instance;
				instance.Initialize();
				LogSave.SaveExeLog("软件激活成功，后台同步: " + ((await instance.SyncActivationAsync(info, text, expiryDate)) ? "成功" : "失败"));
				MessageBox.Show($"激活成功！软件已成功激活。\n\n授权到期: {expiryDate:yyyy-MM-dd}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("软件激活异常: " + ex.Message);
			MessageBox.Show("软件激活失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			btnOfflineActivate.Enabled = true;
			btnOfflineActivate.Text = "软件激活";
		}
	}

	private void btnTrial_Click(object sender, EventArgs e)
	{
		try
		{
			if (Activation.StartTrial())
			{
				MessageBox.Show("试用已开始！您可以免费使用软件15天。", "试用开始", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				UpdateTrialInfo();
				base.DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show("无法启动试用！可能您已经使用过试用期。", "试用失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("启动试用失败：" + ex.Message, "试用失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnExportInfo_Click(object sender, EventArgs e)
	{
		if (!ValidateInput())
		{
			return;
		}
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("=== 激活请求信息 ===");
			stringBuilder.AppendLine("企业名称: " + txtCompanyName.Text);
			stringBuilder.AppendLine("统一社会信用代码: " + txtCreditCode.Text);
			stringBuilder.AppendLine("排污许可证编号: " + txtPollutionPermit.Text);
			stringBuilder.AppendLine("联系人: " + txtContact.Text);
			stringBuilder.AppendLine("联系电话: " + txtPhone.Text);
			stringBuilder.AppendLine("机器码: " + txtMachineCode.Text);
			stringBuilder.AppendLine("客户端ID: " + txtClientId.Text);
			stringBuilder.AppendLine($"生成时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
			using SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "导出激活请求";
			saveFileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
			saveFileDialog.FileName = $"activation_request_{DateTime.Now:yyyyMMdd}.txt";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(saveFileDialog.FileName, stringBuilder.ToString(), Encoding.UTF8);
				MessageBox.Show("激活请求已导出！请将此文件发送给软件供应商获取激活码。", "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("导出失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private async void btnImportLicense_Click(object sender, EventArgs e)
	{
		try
		{
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "导入许可证文件";
			openFileDialog.Filter = "许可证文件|*.lic;*.txt|所有文件|*.*";
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string text = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8).Trim();
			if (string.IsNullOrWhiteSpace(text))
			{
				MessageBox.Show("文件内容为空！", "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string info = Activation.softAuthorize.GetInfo();
			if (text.TrimStart().StartsWith("{"))
			{
				if (!LicenseStore.TryParseAndSaveLicense(text, out var message))
				{
					MessageBox.Show("授权验证失败：" + message, "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (!LicenseStore.TryParsePayload(text, out var payload, out var message2))
				{
					MessageBox.Show("授权信息解析失败：" + message2, "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (!string.Equals(payload.MachineFingerprint, info, StringComparison.OrdinalIgnoreCase))
				{
					MessageBox.Show("机器指纹不匹配！\n\n授权文件对应机器:\n" + payload.MachineFingerprint + "\n\n当前机器:\n" + info, "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				LogSave.SaveExeLog("[导入] 准备保存激活码, currentMachineCode=" + info);
				DateTime? dateTime = ((payload.ExpireAtUtc > DateTime.MinValue) ? new DateTime?(payload.ExpireAtUtc) : payload.ExpiryDate);
				LogSave.SaveExeLog("[导入] effectiveExpiry=" + (dateTime?.ToString() ?? "null"));
				if (!dateTime.HasValue || !(dateTime.Value > DateTime.Now))
				{
					MessageBox.Show("授权已过期！到期时间: " + (dateTime.HasValue ? dateTime.Value.ToString("yyyy-MM-dd") : "未知"), "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				string activationDate = ((payload.IssuedAt > DateTime.MinValue) ? payload.IssuedAt : ((payload.IssuedAtUtc > DateTime.MinValue) ? payload.IssuedAtUtc : DateTime.Now)).ToString("yyyy-MM-dd HH:mm:ss");
				string expiryDate = dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
				if (!SecureActivationStore.SaveActivationCode(info, activationDate, expiryDate))
				{
					MessageBox.Show("保存授权信息失败！", "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				MainData.SaveExpTime(dateTime.Value);
				Activation.MarkAsActivated("离线授权文件导入");
				MessageBox.Show("离线授权成功导入！\n\n" + $"授权到期: {dateTime.Value:yyyy-MM-dd}\n" + "客户: " + (payload.CustomerName ?? "-") + "\n项目: " + (payload.ProjectName ?? "-"), "导入成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else if (!LicenseStore.SaveLicenseContent(text))
			{
				MessageBox.Show("保存许可证失败！", "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (Activation.InitActivate())
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("许可证导入成功，但激活验证失败。", "激活验证失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				base.DialogResult = DialogResult.Cancel;
			}
			TrySyncCustomerInfoToCloud();
			Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show("导入失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private async void TrySyncCustomerInfoToCloud()
	{
		try
		{
			string text = New_IniFile.ReadContentValue("企业信息", "企业名称", MainData.Spath);
			string text2 = New_IniFile.ReadContentValue("企业信息", "统一社会信用代码", MainData.Spath);
			if (!string.IsNullOrWhiteSpace(text) || !string.IsNullOrWhiteSpace(text2))
			{
				CustomerInfo customerInfo = new CustomerInfo
				{
					CompanyName = text,
					CreditCode = text2,
					PollutionPermit = New_IniFile.ReadContentValue("企业信息", "排污许可证编号", MainData.Spath),
					Contact = New_IniFile.ReadContentValue("企业信息", "联系人", MainData.Spath),
					Phone = New_IniFile.ReadContentValue("企业信息", "联系电话", MainData.Spath),
					MachineCode = (Activation.softAuthorize?.GetInfo() ?? ""),
					ClientId = New_IniFile.ReadContentValue("窗体框架配制", "客户端ID", MainData.Spath)
				};
				HybridActivationAPI instance = HybridActivationAPI.Instance;
				instance.Initialize();
				LogSave.SaveExeLog("导入许可证后自动同步客户信息: " + ((await instance.SyncCustomerInfoAsync(customerInfo)) ? "成功" : "失败（网络不可用，已缓存）"));
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("TrySyncCustomerInfoToCloud异常: " + ex.Message);
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
		base.SuspendLayout();
		this.Text = "环保门禁系统 - 软件激活";
		base.ClientSize = new System.Drawing.Size(560, 640);
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
		System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
		panel.Location = new System.Drawing.Point(0, 0);
		panel.Size = new System.Drawing.Size(560, 80);
		panel.BackColor = System.Drawing.Color.FromArgb(24, 144, 255);
		System.Windows.Forms.Label label = new System.Windows.Forms.Label();
		label.Text = "环保门禁管理系统";
		label.Location = new System.Drawing.Point(0, 15);
		label.Size = new System.Drawing.Size(560, 35);
		label.Font = new System.Drawing.Font("微软雅黑", 18f, System.Drawing.FontStyle.Bold);
		label.ForeColor = System.Drawing.Color.White;
		label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label.BackColor = System.Drawing.Color.Transparent;
		panel.Controls.Add(label);
		System.Windows.Forms.Label label2 = new System.Windows.Forms.Label();
		label2.Text = "SOFTWARE ACTIVATION";
		label2.Location = new System.Drawing.Point(0, 48);
		label2.Size = new System.Drawing.Size(560, 20);
		label2.Font = new System.Drawing.Font("Segoe UI", 9f);
		label2.ForeColor = System.Drawing.Color.FromArgb(200, 255, 255, 255);
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label2.BackColor = System.Drawing.Color.Transparent;
		panel.Controls.Add(label2);
		this.groupBoxEnterprise = new System.Windows.Forms.GroupBox();
		this.groupBoxEnterprise.Text = " ① 企业信息登记 ";
		this.groupBoxEnterprise.Location = new System.Drawing.Point(22, 80);
		this.groupBoxEnterprise.Size = new System.Drawing.Size(496, 210);
		this.groupBoxEnterprise.Font = new System.Drawing.Font("微软雅黑", 10f, System.Drawing.FontStyle.Bold);
		this.groupBoxEnterprise.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
		int num = 90;
		int num2 = 350;
		int num3 = 20;
		int num4 = 30;
		int num5 = 32;
		this.lblCompanyName = new System.Windows.Forms.Label();
		this.lblCompanyName.Text = "企业名称:";
		this.lblCompanyName.Location = new System.Drawing.Point(num3, num4);
		this.lblCompanyName.Size = new System.Drawing.Size(num, 25);
		this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblCompanyName.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtCompanyName = new System.Windows.Forms.TextBox();
		this.txtCompanyName.Location = new System.Drawing.Point(num3 + num + 5, num4);
		this.txtCompanyName.Size = new System.Drawing.Size(num2, 26);
		this.txtCompanyName.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtCompanyName.TextChanged += new System.EventHandler(txtCompanyInfo_TextChanged);
		this.lblCreditCode = new System.Windows.Forms.Label();
		this.lblCreditCode.Text = "信用代码:";
		this.lblCreditCode.Location = new System.Drawing.Point(num3, num4 + num5);
		this.lblCreditCode.Size = new System.Drawing.Size(num, 25);
		this.lblCreditCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblCreditCode.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtCreditCode = new System.Windows.Forms.TextBox();
		this.txtCreditCode.Location = new System.Drawing.Point(num3 + num + 5, num4 + num5);
		this.txtCreditCode.Size = new System.Drawing.Size(num2, 26);
		this.txtCreditCode.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtCreditCode.MaxLength = 18;
		this.txtCreditCode.TextChanged += new System.EventHandler(txtCompanyInfo_TextChanged);
		this.lblPollutionPermit = new System.Windows.Forms.Label();
		this.lblPollutionPermit.Text = "排污编号:";
		this.lblPollutionPermit.Location = new System.Drawing.Point(num3, num4 + num5 * 2);
		this.lblPollutionPermit.Size = new System.Drawing.Size(num, 25);
		this.lblPollutionPermit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblPollutionPermit.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtPollutionPermit = new System.Windows.Forms.TextBox();
		this.txtPollutionPermit.Location = new System.Drawing.Point(num3 + num + 5, num4 + num5 * 2);
		this.txtPollutionPermit.Size = new System.Drawing.Size(num2, 26);
		this.txtPollutionPermit.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblContact = new System.Windows.Forms.Label();
		this.lblContact.Text = "联 系 人:";
		this.lblContact.Location = new System.Drawing.Point(num3, num4 + num5 * 3);
		this.lblContact.Size = new System.Drawing.Size(num, 25);
		this.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblContact.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtContact = new System.Windows.Forms.TextBox();
		this.txtContact.Location = new System.Drawing.Point(num3 + num + 5, num4 + num5 * 3);
		this.txtContact.Size = new System.Drawing.Size(num2, 26);
		this.txtContact.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.lblPhone = new System.Windows.Forms.Label();
		this.lblPhone.Text = "联系电话:";
		this.lblPhone.Location = new System.Drawing.Point(num3, num4 + num5 * 4);
		this.lblPhone.Size = new System.Drawing.Size(num, 25);
		this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblPhone.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtPhone = new System.Windows.Forms.TextBox();
		this.txtPhone.Location = new System.Drawing.Point(num3 + num + 5, num4 + num5 * 4);
		this.txtPhone.Size = new System.Drawing.Size(num2, 26);
		this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtPhone.MaxLength = 11;
		this.groupBoxEnterprise.Controls.Add(this.lblCompanyName);
		this.groupBoxEnterprise.Controls.Add(this.txtCompanyName);
		this.groupBoxEnterprise.Controls.Add(this.lblCreditCode);
		this.groupBoxEnterprise.Controls.Add(this.txtCreditCode);
		this.groupBoxEnterprise.Controls.Add(this.lblPollutionPermit);
		this.groupBoxEnterprise.Controls.Add(this.txtPollutionPermit);
		this.groupBoxEnterprise.Controls.Add(this.lblContact);
		this.groupBoxEnterprise.Controls.Add(this.txtContact);
		this.groupBoxEnterprise.Controls.Add(this.lblPhone);
		this.groupBoxEnterprise.Controls.Add(this.txtPhone);
		this.groupBoxSystem = new System.Windows.Forms.GroupBox();
		this.groupBoxSystem.Text = " ② 系统信息 ";
		this.groupBoxSystem.Location = new System.Drawing.Point(22, 296);
		this.groupBoxSystem.Size = new System.Drawing.Size(496, 100);
		this.groupBoxSystem.Font = new System.Drawing.Font("微软雅黑", 10f, System.Drawing.FontStyle.Bold);
		this.groupBoxSystem.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
		this.lblMachineCode = new System.Windows.Forms.Label();
		this.lblMachineCode.Text = "机 器 码:";
		this.lblMachineCode.Location = new System.Drawing.Point(num3, 25);
		this.lblMachineCode.Size = new System.Drawing.Size(num, 25);
		this.lblMachineCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblMachineCode.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtMachineCode = new System.Windows.Forms.TextBox();
		this.txtMachineCode.Location = new System.Drawing.Point(num3 + num + 5, 25);
		this.txtMachineCode.Size = new System.Drawing.Size(num2, 26);
		this.txtMachineCode.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtMachineCode.ReadOnly = true;
		this.txtMachineCode.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
		this.lblClientId = new System.Windows.Forms.Label();
		this.lblClientId.Text = "客户端ID:";
		this.lblClientId.Location = new System.Drawing.Point(num3, 57);
		this.lblClientId.Size = new System.Drawing.Size(num, 25);
		this.lblClientId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblClientId.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtClientId = new System.Windows.Forms.TextBox();
		this.txtClientId.Location = new System.Drawing.Point(num3 + num + 5, 57);
		this.txtClientId.Size = new System.Drawing.Size(num2, 26);
		this.txtClientId.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtClientId.ReadOnly = true;
		this.txtClientId.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
		this.groupBoxSystem.Controls.Add(this.lblMachineCode);
		this.groupBoxSystem.Controls.Add(this.txtMachineCode);
		this.groupBoxSystem.Controls.Add(this.lblClientId);
		this.groupBoxSystem.Controls.Add(this.txtClientId);
		this.groupBoxActivation = new System.Windows.Forms.GroupBox();
		this.groupBoxActivation.Text = " ③ 软件激活（可选） ";
		this.groupBoxActivation.Location = new System.Drawing.Point(22, 402);
		this.groupBoxActivation.Size = new System.Drawing.Size(496, 70);
		this.groupBoxActivation.Font = new System.Drawing.Font("微软雅黑", 10f, System.Drawing.FontStyle.Bold);
		this.groupBoxActivation.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
		this.lblActivationCode = new System.Windows.Forms.Label();
		this.lblActivationCode.Text = "激 活 码:";
		this.lblActivationCode.Location = new System.Drawing.Point(num3, 30);
		this.lblActivationCode.Size = new System.Drawing.Size(num, 25);
		this.lblActivationCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblActivationCode.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.txtActivationCode = new System.Windows.Forms.TextBox();
		this.txtActivationCode.Location = new System.Drawing.Point(num3 + num + 5, 28);
		this.txtActivationCode.Size = new System.Drawing.Size(num2, 26);
		this.txtActivationCode.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.groupBoxActivation.Controls.Add(this.lblActivationCode);
		this.groupBoxActivation.Controls.Add(this.txtActivationCode);
		int num6 = 488;
		int num7 = 92;
		int num8 = 38;
		this.btnOnlineActivate = new System.Windows.Forms.Button();
		this.btnOnlineActivate.Text = "在线激活";
		this.btnOnlineActivate.Location = new System.Drawing.Point(30, num6);
		this.btnOnlineActivate.Size = new System.Drawing.Size(num7, num8);
		this.btnOnlineActivate.Font = new System.Drawing.Font("微软雅黑", 10f, System.Drawing.FontStyle.Bold);
		this.btnOnlineActivate.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
		this.btnOnlineActivate.ForeColor = System.Drawing.Color.White;
		this.btnOnlineActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOnlineActivate.FlatAppearance.BorderSize = 0;
		this.btnOnlineActivate.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnOnlineActivate.Click += new System.EventHandler(btnOnlineActivate_Click);
		this.btnOfflineActivate = new System.Windows.Forms.Button();
		this.btnOfflineActivate.Text = "软件激活";
		this.btnOfflineActivate.Location = new System.Drawing.Point(128, num6);
		this.btnOfflineActivate.Size = new System.Drawing.Size(num7, num8);
		this.btnOfflineActivate.Font = new System.Drawing.Font("微软雅黑", 10f, System.Drawing.FontStyle.Bold);
		this.btnOfflineActivate.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
		this.btnOfflineActivate.ForeColor = System.Drawing.Color.White;
		this.btnOfflineActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOfflineActivate.FlatAppearance.BorderSize = 0;
		this.btnOfflineActivate.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnOfflineActivate.Click += new System.EventHandler(btnSoftwareActivate_Click);
		this.btnTrial = new System.Windows.Forms.Button();
		this.btnTrial.Text = "15天试用";
		this.btnTrial.Location = new System.Drawing.Point(226, num6);
		this.btnTrial.Size = new System.Drawing.Size(num7, num8);
		this.btnTrial.Font = new System.Drawing.Font("微软雅黑", 10f, System.Drawing.FontStyle.Bold);
		this.btnTrial.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
		this.btnTrial.ForeColor = System.Drawing.Color.White;
		this.btnTrial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTrial.FlatAppearance.BorderSize = 0;
		this.btnTrial.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnTrial.Click += new System.EventHandler(btnTrial_Click);
		this.btnExportInfo = new System.Windows.Forms.Button();
		this.btnExportInfo.Text = "导出信息";
		this.btnExportInfo.Location = new System.Drawing.Point(324, num6);
		this.btnExportInfo.Size = new System.Drawing.Size(num7, num8);
		this.btnExportInfo.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.btnExportInfo.BackColor = System.Drawing.Color.FromArgb(96, 125, 139);
		this.btnExportInfo.ForeColor = System.Drawing.Color.White;
		this.btnExportInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExportInfo.FlatAppearance.BorderSize = 0;
		this.btnExportInfo.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnExportInfo.Click += new System.EventHandler(btnExportInfo_Click);
		this.btnImportLicense = new System.Windows.Forms.Button();
		this.btnImportLicense.Text = "导入许可";
		this.btnImportLicense.Location = new System.Drawing.Point(422, num6);
		this.btnImportLicense.Size = new System.Drawing.Size(num7, num8);
		this.btnImportLicense.Font = new System.Drawing.Font("微软雅黑", 10f);
		this.btnImportLicense.BackColor = System.Drawing.Color.FromArgb(121, 85, 72);
		this.btnImportLicense.ForeColor = System.Drawing.Color.White;
		this.btnImportLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnImportLicense.FlatAppearance.BorderSize = 0;
		this.btnImportLicense.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnImportLicense.Click += new System.EventHandler(btnImportLicense_Click);
		this.labelTrialInfo = new System.Windows.Forms.Label();
		this.labelTrialInfo.Location = new System.Drawing.Point(22, 540);
		this.labelTrialInfo.Size = new System.Drawing.Size(496, 30);
		this.labelTrialInfo.Font = new System.Drawing.Font("微软雅黑", 11f);
		this.labelTrialInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.labelTrialInfo.Text = "可以开始15天免费试用";
		this.labelTrialInfo.ForeColor = System.Drawing.Color.Blue;
		this.labelTrialInfo.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
		this.labelTrialInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.Label label3 = new System.Windows.Forms.Label();
		label3.Text = "技术支持：请联系软件供应商";
		label3.Location = new System.Drawing.Point(0, 580);
		label3.Size = new System.Drawing.Size(540, 30);
		label3.Font = new System.Drawing.Font("微软雅黑", 9f);
		label3.ForeColor = System.Drawing.Color.FromArgb(158, 158, 158);
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		base.Controls.Add(panel);
		base.Controls.Add(this.groupBoxEnterprise);
		base.Controls.Add(this.groupBoxSystem);
		base.Controls.Add(this.groupBoxActivation);
		base.Controls.Add(this.btnOnlineActivate);
		base.Controls.Add(this.btnOfflineActivate);
		base.Controls.Add(this.btnTrial);
		base.Controls.Add(this.btnExportInfo);
		base.Controls.Add(this.btnImportLicense);
		base.Controls.Add(this.labelTrialInfo);
		base.Controls.Add(label3);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
