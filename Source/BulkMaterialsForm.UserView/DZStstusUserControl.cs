// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.UserView
// Type: BulkMaterialsForm.UserView.DZStstusUserControl

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BulkMaterialsForm.UserView;

public class DZStstusUserControl : UserControl
{
	private IContainer components;

	private TableLayoutPanel tableLayoutPanel1;

	private Label label3;

	private Label label1;

	private Label lbD01;

	private Label label2;

	public DZStstusUserControl()
	{
		InitializeComponent();
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
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.lbD01 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.tableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.tableLayoutPanel1.ColumnCount = 2;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
		this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.lbD01, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 2;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(226, 142);
		this.tableLayoutPanel1.TabIndex = 0;
		this.lbD01.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lbD01.AutoSize = true;
		this.lbD01.Font = new System.Drawing.Font("宋体", 36f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.lbD01.ForeColor = System.Drawing.Color.Red;
		this.lbD01.Location = new System.Drawing.Point(135, 82);
		this.lbD01.Name = "lbD01";
		this.lbD01.Size = new System.Drawing.Size(68, 48);
		this.lbD01.TabIndex = 34;
		this.lbD01.Text = "●";
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("宋体", 36f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.ForeColor = System.Drawing.Color.Red;
		this.label1.Location = new System.Drawing.Point(22, 82);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(68, 48);
		this.label1.TabIndex = 35;
		this.label1.Text = "●";
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 29);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(101, 12);
		this.label2.TabIndex = 36;
		this.label2.Text = "道闸状态红色升起";
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(119, 29);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(101, 12);
		this.label3.TabIndex = 37;
		this.label3.Text = "报警状态红色警报";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.tableLayoutPanel1);
		base.Name = "DZStstusUserControl";
		base.Size = new System.Drawing.Size(226, 142);
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel1.PerformLayout();
		base.ResumeLayout(false);
	}
}
