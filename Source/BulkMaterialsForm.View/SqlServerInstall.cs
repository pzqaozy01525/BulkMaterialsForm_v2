// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.SqlServerInstall

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BulkMaterialsForm.View;

public class SqlServerInstall : Form
{
	private IContainer components;

	private Button button3;

	private Button button1;

	private Panel panel2;

	private Panel panel1;

	public SqlServerInstall()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		string startupPath = Application.StartupPath;
		Process process = new Process();
		process.StartInfo.FileName = "MSSQL2008-HaoSQL.exe";
		process.StartInfo.WorkingDirectory = startupPath;
		process.StartInfo.CreateNoWindow = true;
		process.Start();
	}

	private void button3_Click(object sender, EventArgs e)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkMaterialsForm.View.SqlServerInstall));
		this.button3 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.panel2 = new System.Windows.Forms.Panel();
		this.panel1 = new System.Windows.Forms.Panel();
		base.SuspendLayout();
		this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button3.Image = (System.Drawing.Image)resources.GetObject("button3.Image");
		this.button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
		this.button3.Location = new System.Drawing.Point(693, 451);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(205, 48);
		this.button3.TabIndex = 8;
		this.button3.Text = "关闭";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
		this.button1.Location = new System.Drawing.Point(351, 451);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(264, 48);
		this.button1.TabIndex = 7;
		this.button1.Text = "开始安装数据库";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.panel2.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel2.BackgroundImage");
		this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.panel2.Location = new System.Drawing.Point(486, 49);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(469, 371);
		this.panel2.TabIndex = 6;
		this.panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
		this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.panel1.Location = new System.Drawing.Point(31, 52);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(439, 368);
		this.panel1.TabIndex = 5;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(987, 521);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.panel1);
		base.Name = "SqlServerInstall";
		this.Text = "SqlServerInstall";
		base.ResumeLayout(false);
	}
}
