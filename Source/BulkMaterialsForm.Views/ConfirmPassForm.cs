// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Views
// Type: BulkMaterialsForm.Views.ConfirmPassForm

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BulkMaterialsForm.Help;

namespace BulkMaterialsForm.Views;

public class ConfirmPassForm : Form
{
	public bool isSvae;

	private IContainer components;

	private Button button4;

	private TextBox textBox1;

	private Label label11;

	public ConfirmPassForm()
	{
		InitializeComponent();
	}

	private void button4_Click(object sender, EventArgs e)
	{
		if (textBox1.Text == MainData.ACpassword)
		{
			isSvae = true;
			Close();
		}
		else
		{
			MessageBox.Show("密码错误");
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
		this.button4 = new System.Windows.Forms.Button();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label11 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.button4.Location = new System.Drawing.Point(141, 116);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(108, 34);
		this.button4.TabIndex = 43;
		this.button4.Text = "确认";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.textBox1.Location = new System.Drawing.Point(129, 46);
		this.textBox1.Name = "textBox1";
		this.textBox1.PasswordChar = '*';
		this.textBox1.Size = new System.Drawing.Size(228, 29);
		this.textBox1.TabIndex = 45;
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label11.Location = new System.Drawing.Point(66, 49);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(46, 21);
		this.label11.TabIndex = 44;
		this.label11.Text = "密码:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(393, 179);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.button4);
		base.Name = "ConfirmPassForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "密码确认";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
