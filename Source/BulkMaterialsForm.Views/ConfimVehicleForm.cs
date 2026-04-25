// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Views
// Type: BulkMaterialsForm.Views.ConfimVehicleForm

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BulkMaterialsForm.Model.View;

namespace BulkMaterialsForm.Views;

public class ConfimVehicleForm : Form
{
	public VehicleNoInfoView vehicleNoInfoView;

	public bool isSave;

	private IContainer components;

	private GroupBox groupBox1;

	private PictureBox pictureBox1;

	private Label label1;

	private Label label2;

	private Button button1;

	private Button button2;

	private TextBox textBox2;

	private ComboBox comboBox1;

	public ConfimVehicleForm()
	{
		InitializeComponent();
		pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		base.Load += ConfimVehicleForm_Load;
		base.FormClosing += ConfimVehicleForm_FormClosing;
	}

	private void ConfimVehicleForm_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	private void ConfimVehicleForm_Load(object sender, EventArgs e)
	{
		textBox2.Text = vehicleNoInfoView.VehicleNo;
		if (vehicleNoInfoView.ChannelType == "1")
		{
			Text = "进口车牌确认弹窗";
		}
		else if (vehicleNoInfoView.ChannelType == "2")
		{
			Text = "出口车牌确认弹窗";
		}
		comboBox1.SelectedItem = vehicleNoInfoView.licenseColor;
		if (comboBox1.SelectedItem == null)
		{
			comboBox1.SelectedItem = "蓝色";
		}
		if (File.Exists(vehicleNoInfoView.ImagePath))
		{
			Image image = Image.FromFile(vehicleNoInfoView.ImagePath);
			Image image2 = new Bitmap(image);
			image.Dispose();
			pictureBox1.Image = image2;
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		vehicleNoInfoView.VehicleNo = textBox2.Text;
		vehicleNoInfoView.licenseColor = comboBox1.SelectedItem.ToString();
		isSave = true;
		Close();
	}

	private void button2_Click(object sender, EventArgs e)
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
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.pictureBox1);
		this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.groupBox1.Location = new System.Drawing.Point(12, 12);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(477, 362);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "抓拍图片";
		this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureBox1.Location = new System.Drawing.Point(3, 25);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(471, 334);
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(501, 296);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(58, 21);
		this.label1.TabIndex = 62;
		this.label1.Text = "车牌号";
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.Location = new System.Drawing.Point(501, 341);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(74, 21);
		this.label2.TabIndex = 64;
		this.label2.Text = "车牌颜色";
		this.button1.BackColor = System.Drawing.Color.White;
		this.button1.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.button1.ForeColor = System.Drawing.Color.Lime;
		this.button1.Location = new System.Drawing.Point(671, 407);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(155, 42);
		this.button1.TabIndex = 75;
		this.button1.Text = "验证平台";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.BackColor = System.Drawing.Color.White;
		this.button2.Font = new System.Drawing.Font("微软雅黑", 14.25f);
		this.button2.ForeColor = System.Drawing.Color.Red;
		this.button2.Location = new System.Drawing.Point(480, 407);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(155, 42);
		this.button2.TabIndex = 76;
		this.button2.Text = "禁止通行";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.textBox2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox2.Location = new System.Drawing.Point(578, 296);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(248, 29);
		this.textBox2.TabIndex = 77;
		this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[6] { "蓝色", "黄色", "白色", "黑色", "绿色", "黄绿色" });
		this.comboBox1.Location = new System.Drawing.Point(578, 341);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(248, 29);
		this.comboBox1.TabIndex = 78;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(857, 461);
		base.Controls.Add(this.comboBox1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.groupBox1);
		base.Name = "ConfimVehicleForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "车牌确认弹窗";
		base.TopMost = true;
		this.groupBox1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
