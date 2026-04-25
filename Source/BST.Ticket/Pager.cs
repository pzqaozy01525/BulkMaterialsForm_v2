// Decompiled from: BulkMaterialsForm.exe
// Namespace: BST.Ticket
// Type: BST.Ticket.Pager

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BST.Ticket;

public class Pager : UserControl
{
	private int _pageSize = 20;

	private int _nMax;

	private int _pageCount;

	private int _pageCurrent;

	private IContainer components;

	public BindingNavigator bindingNavigator;

	private ToolStripSeparator bindingNavigatorSeparator;

	private ToolStripSeparator bindingNavigatorSeparator2;

	public BindingSource bindingSource;

	private ToolStripTextBox txtCurrentPage;

	private ToolStripLabel toolStripLabel1;

	private ToolStripLabel lblMaxPage;

	private ToolStripButton btnFirst;

	private ToolStripButton btnPrev;

	private ToolStripButton btnNext;

	private ToolStripButton btnLast;

	private ToolStripLabel lblPageCount;

	private ToolStripSeparator toolStripSeparator2;

	private ToolStripButton btnGo;

	private ToolStripLabel toolStripLabel4;

	private ToolStripSeparator toolStripSeparator3;

	private ToolStripLabel toolStripLabel2;

	private ToolStripLabel toolStripLabel3;

	private ToolStripSeparator toolStripSeparator4;

	private ToolStripComboBox toolStripComboBox1;

	public int PageSize
	{
		get
		{
			return _pageSize;
		}
		set
		{
			_pageSize = value;
			GetPageCount();
		}
	}

	public int NMax
	{
		get
		{
			return _nMax;
		}
		set
		{
			_nMax = value;
			GetPageCount();
		}
	}

	public int PageCount
	{
		get
		{
			return _pageCount;
		}
		set
		{
			_pageCount = value;
		}
	}

	public int PageCurrent
	{
		get
		{
			return _pageCurrent;
		}
		set
		{
			_pageCurrent = value;
		}
	}

	public BindingNavigator ToolBar => bindingNavigator;

	public event EventPagingHandler EventPaging;

	public Pager()
	{
		InitializeComponent();
		toolStripComboBox1.SelectedItem = PageSize.ToString();
	}

	private void GetPageCount()
	{
		if (NMax > 0)
		{
			PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(NMax) / Convert.ToDouble(PageSize)));
		}
		else
		{
			PageCount = 0;
		}
	}

	public void Bind()
	{
		if (this.EventPaging != null)
		{
			NMax = this.EventPaging(new EventPagingArg(PageCurrent));
		}
		if (PageCurrent > PageCount)
		{
			PageCurrent = PageCount;
		}
		if (PageCount == 1)
		{
			PageCurrent = 1;
		}
		lblPageCount.Text = PageCount.ToString();
		lblMaxPage.Text = "共" + NMax + "条记录";
		txtCurrentPage.Text = PageCurrent.ToString();
		if (PageCurrent == 1)
		{
			btnPrev.Enabled = false;
			btnFirst.Enabled = false;
		}
		else
		{
			btnPrev.Enabled = true;
			btnFirst.Enabled = true;
		}
		if (PageCurrent == PageCount)
		{
			btnLast.Enabled = false;
			btnNext.Enabled = false;
		}
		else
		{
			btnLast.Enabled = true;
			btnNext.Enabled = true;
		}
		if (NMax == 0)
		{
			btnNext.Enabled = false;
			btnLast.Enabled = false;
			btnFirst.Enabled = false;
			btnPrev.Enabled = false;
		}
	}

	private void btnFirst_Click(object sender, EventArgs e)
	{
		PageCurrent = 1;
		Bind();
	}

	private void btnPrev_Click(object sender, EventArgs e)
	{
		PageCurrent--;
		if (PageCurrent <= 0)
		{
			PageCurrent = 1;
		}
		Bind();
	}

	private void btnNext_Click(object sender, EventArgs e)
	{
		PageCurrent++;
		if (PageCurrent > PageCount)
		{
			PageCurrent = PageCount;
		}
		Bind();
	}

	private void btnLast_Click(object sender, EventArgs e)
	{
		PageCurrent = PageCount;
		Bind();
	}

	private void btnGo_Click(object sender, EventArgs e)
	{
		if (txtCurrentPage.Text != null && txtCurrentPage.Text != "" && int.TryParse(txtCurrentPage.Text, out _pageCurrent))
		{
			Bind();
		}
	}

	private void txtCurrentPage_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			Bind();
		}
	}

	private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		PageSize = Convert.ToInt32(toolStripComboBox1.SelectedItem);
		Bind();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BST.Ticket.Pager));
		this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
		this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
		this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.btnFirst = new System.Windows.Forms.ToolStripButton();
		this.btnPrev = new System.Windows.Forms.ToolStripButton();
		this.btnNext = new System.Windows.Forms.ToolStripButton();
		this.btnLast = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
		this.txtCurrentPage = new System.Windows.Forms.ToolStripTextBox();
		this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		this.btnGo = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
		this.lblPageCount = new System.Windows.Forms.ToolStripLabel();
		this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
		this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.lblMaxPage = new System.Windows.Forms.ToolStripLabel();
		this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
		((System.ComponentModel.ISupportInitialize)this.bindingNavigator).BeginInit();
		this.bindingNavigator.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.bindingSource).BeginInit();
		base.SuspendLayout();
		this.bindingNavigator.AddNewItem = null;
		this.bindingNavigator.CountItem = null;
		this.bindingNavigator.DeleteItem = null;
		this.bindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
		this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[18]
		{
			this.bindingNavigatorSeparator, this.toolStripComboBox1, this.bindingNavigatorSeparator2, this.btnFirst, this.btnPrev, this.btnNext, this.btnLast, this.toolStripSeparator2, this.toolStripLabel4, this.txtCurrentPage,
			this.toolStripLabel1, this.btnGo, this.toolStripSeparator3, this.toolStripLabel2, this.lblPageCount, this.toolStripLabel3, this.toolStripSeparator4, this.lblMaxPage
		});
		this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
		this.bindingNavigator.MoveFirstItem = null;
		this.bindingNavigator.MoveLastItem = null;
		this.bindingNavigator.MoveNextItem = null;
		this.bindingNavigator.MovePreviousItem = null;
		this.bindingNavigator.Name = "bindingNavigator";
		this.bindingNavigator.PositionItem = null;
		this.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		this.bindingNavigator.Size = new System.Drawing.Size(830, 30);
		this.bindingNavigator.TabIndex = 0;
		this.bindingNavigator.Text = "bindingNavigator1";
		this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
		this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 30);
		this.toolStripComboBox1.Items.AddRange(new object[4] { "20", "50", "100", "200" });
		this.toolStripComboBox1.Name = "toolStripComboBox1";
		this.toolStripComboBox1.Size = new System.Drawing.Size(121, 30);
		this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(toolStripComboBox1_SelectedIndexChanged);
		this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
		this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 30);
		this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.btnFirst.Image = (System.Drawing.Image)resources.GetObject("btnFirst.Image");
		this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnFirst.Name = "btnFirst";
		this.btnFirst.Size = new System.Drawing.Size(48, 27);
		this.btnFirst.Text = "第一页";
		this.btnFirst.Click += new System.EventHandler(btnFirst_Click);
		this.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.btnPrev.Image = (System.Drawing.Image)resources.GetObject("btnPrev.Image");
		this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnPrev.Name = "btnPrev";
		this.btnPrev.Size = new System.Drawing.Size(48, 27);
		this.btnPrev.Text = "上一页";
		this.btnPrev.Click += new System.EventHandler(btnPrev_Click);
		this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.btnNext.Image = (System.Drawing.Image)resources.GetObject("btnNext.Image");
		this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnNext.Name = "btnNext";
		this.btnNext.Size = new System.Drawing.Size(48, 27);
		this.btnNext.Text = "下一页";
		this.btnNext.Click += new System.EventHandler(btnNext_Click);
		this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.btnLast.Image = (System.Drawing.Image)resources.GetObject("btnLast.Image");
		this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnLast.Name = "btnLast";
		this.btnLast.Size = new System.Drawing.Size(48, 27);
		this.btnLast.Text = "最后页";
		this.btnLast.Click += new System.EventHandler(btnLast_Click);
		this.toolStripSeparator2.Name = "toolStripSeparator2";
		this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
		this.toolStripLabel4.Name = "toolStripLabel4";
		this.toolStripLabel4.Size = new System.Drawing.Size(20, 27);
		this.toolStripLabel4.Text = "第";
		this.txtCurrentPage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.txtCurrentPage.Name = "txtCurrentPage";
		this.txtCurrentPage.Size = new System.Drawing.Size(40, 30);
		this.txtCurrentPage.KeyDown += new System.Windows.Forms.KeyEventHandler(txtCurrentPage_KeyDown);
		this.toolStripLabel1.Name = "toolStripLabel1";
		this.toolStripLabel1.Size = new System.Drawing.Size(20, 27);
		this.toolStripLabel1.Text = "页";
		this.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.btnGo.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Bold);
		this.btnGo.Image = (System.Drawing.Image)resources.GetObject("btnGo.Image");
		this.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnGo.Name = "btnGo";
		this.btnGo.Size = new System.Drawing.Size(23, 27);
		this.btnGo.Text = "GO";
		this.btnGo.Click += new System.EventHandler(btnGo_Click);
		this.toolStripSeparator3.Name = "toolStripSeparator3";
		this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
		this.toolStripLabel2.Name = "toolStripLabel2";
		this.toolStripLabel2.Size = new System.Drawing.Size(20, 27);
		this.toolStripLabel2.Text = "共";
		this.lblPageCount.Name = "lblPageCount";
		this.lblPageCount.Size = new System.Drawing.Size(85, 27);
		this.lblPageCount.Text = "lblPageCount";
		this.toolStripLabel3.Name = "toolStripLabel3";
		this.toolStripLabel3.Size = new System.Drawing.Size(20, 27);
		this.toolStripLabel3.Text = "页";
		this.toolStripSeparator4.Name = "toolStripSeparator4";
		this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
		this.lblMaxPage.Name = "lblMaxPage";
		this.lblMaxPage.Size = new System.Drawing.Size(76, 27);
		this.lblMaxPage.Text = "lblMaxPage";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.bindingNavigator);
		base.Name = "Pager";
		base.Size = new System.Drawing.Size(830, 30);
		((System.ComponentModel.ISupportInitialize)this.bindingNavigator).EndInit();
		this.bindingNavigator.ResumeLayout(false);
		this.bindingNavigator.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.bindingSource).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
