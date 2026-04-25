// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.csForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Model.View;
using Newtonsoft.Json;

namespace BulkMaterialsForm.View;

public class csForm : Form
{
	private IContainer components;

	private Label label1;

	private TextBox textBox1;

	private TextBox textBox2;

	private Label label2;

	private RichTextBox richTextBox1;

	private Button button1;

	public csForm()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		string msg = "";
		VehicleNoInfoView vehicleNoInfoView = new VehicleNoInfoView();
		if (CommonHelper.GLVerify1(textBox1.Text, textBox2.Text, MainData.GLEnterPort, ref msg, ref vehicleNoInfoView))
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("license", textBox1.Text);
			dictionary.Add("inOutType", "in");
			dictionary.Add("gateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			dictionary.Add("licensImg", "");
			dictionary.Add("vehImg", "");
			Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(CommonHelper.GetGLResultModel(MainData.GLIISUrl + ":" + MainData.GLEnterPort + "/PassData/Send", dictionary));
			if (dictionary2 != null && dictionary2["result"].ToString().Equals("success"))
			{
				MessageBox.Show("上传成功");
			}
			else
			{
				MessageBox.Show(dictionary2["err"].ToString());
			}
		}
		richTextBox1.Text = msg;
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
		this.label1 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.richTextBox1 = new System.Windows.Forms.RichTextBox();
		this.button1 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(97, 67);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(29, 12);
		this.label1.TabIndex = 0;
		this.label1.Text = "车牌";
		this.textBox1.Location = new System.Drawing.Point(155, 64);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(254, 21);
		this.textBox1.TabIndex = 1;
		this.textBox2.Location = new System.Drawing.Point(155, 114);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(254, 21);
		this.textBox2.TabIndex = 3;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(97, 117);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(29, 12);
		this.label2.TabIndex = 2;
		this.label2.Text = "颜色";
		this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.richTextBox1.Location = new System.Drawing.Point(0, 178);
		this.richTextBox1.Name = "richTextBox1";
		this.richTextBox1.Size = new System.Drawing.Size(800, 272);
		this.richTextBox1.TabIndex = 4;
		this.richTextBox1.Text = "";
		this.button1.Location = new System.Drawing.Point(471, 105);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 5;
		this.button1.Text = "button1";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.richTextBox1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label1);
		base.Name = "csForm";
		this.Text = "csForm";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
