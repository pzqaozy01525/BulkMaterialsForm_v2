// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.ChartForm

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;

namespace BulkMaterialsForm.View;

public class ChartForm : Form
{
	private IContainer components;

	private TableLayoutPanel tableLayoutPanel1;

	private Chart chart1;

	private Panel panel1;

	private DateTimePicker dateEnd;

	private Label label4;

	private Label label3;

	private DateTimePicker dateStart;

	private Button button1;

	private Chart chart2;

	public ChartForm()
	{
		InitializeComponent();
		base.Load += ChartForm_Load;
	}

	private void ChartForm_Load(object sender, EventArgs e)
	{
		Title title = new Title();
		title.Text = "进出车辆汇总数据";
		title.Font = new Font("微软雅黑", 14f, FontStyle.Bold);
		title.ForeColor = Color.DarkBlue;
		title.Alignment = ContentAlignment.TopCenter;
		chart1.Titles.Add(title);
		Title title2 = new Title();
		title2.Text = "货物汇总数据";
		title2.Font = new Font("微软雅黑", 16f, FontStyle.Bold);
		title2.ForeColor = Color.DarkBlue;
		title2.Alignment = ContentAlignment.TopCenter;
		chart2.Titles.Add(title2);
		InitChart();
	}

	private void InitChart()
	{
		Expression<Func<tb_CarRecord, bool>> first = PredicateBuilder.GetTrue<tb_CarRecord>();
		first = first.And((tb_CarRecord it) => it.upload_status == "上传成功");
		DateTime start = dateStart.Value.Date;
		DateTime end = dateEnd.Value.AddDays(1.0).Date.AddSeconds(-1.0);
		first = first.And((tb_CarRecord it) => it.add_time >= start);
		first = first.And((tb_CarRecord it) => it.add_time <= end);
		List<tb_CarRecord> list = new DataServerContext<tb_CarRecord>().Current.GetList(first);
		if (list != null)
		{
			List<tb_CarRecord> tb_ = list.Where((tb_CarRecord it) => it.emissionStandard == "国5").ToList();
			List<tb_CarRecord> tb_2 = list.Where((tb_CarRecord it) => it.emissionStandard == "国6").ToList();
			List<tb_CarRecord> tb_dd = list.Where((tb_CarRecord it) => it.emissionStandard == "电动").ToList();
			List<tb_CarRecord> tb_qt = list.Where((tb_CarRecord it) => it.emissionStandard != "电动" || it.emissionStandard != "国5" || it.emissionStandard != "国6").ToList();
			AddOutEnterVehicleDataBindXY(tb_, tb_2, tb_dd, tb_qt);
			AddGoodsDataBindXY(tb_, tb_2, tb_dd, tb_qt);
		}
	}

	public void AddOutEnterVehicleDataBindXY(List<tb_CarRecord> tb_5, List<tb_CarRecord> tb_6, List<tb_CarRecord> tb_dd, List<tb_CarRecord> tb_qt)
	{
		List<string> list = new List<string>();
		List<double> list2 = new List<double>();
		if (tb_5.Count > 0)
		{
			list.Add("国五:" + tb_5.Count + " 辆");
			list2.Add(tb_5.Count);
		}
		else
		{
			list.Add("国五:0 辆");
			list2.Add(0.01);
		}
		if (tb_6.Count > 0)
		{
			list.Add("国六:" + tb_6.Count + " 辆");
			list2.Add(tb_6.Count);
		}
		else
		{
			list.Add("国六:0 辆");
			list2.Add(0.01);
		}
		if (tb_dd.Count > 0)
		{
			list.Add("电动:" + tb_dd.Count + " 辆");
			list2.Add(tb_dd.Count);
		}
		else
		{
			list.Add("电动:0 辆");
			list2.Add(0.01);
		}
		if (tb_qt.Count > 0)
		{
			list.Add("其他:" + tb_qt.Count + " 辆");
			list2.Add(tb_qt.Count);
		}
		else
		{
			list.Add("其他:0 辆");
			list2.Add(0.01);
		}
		chart1.Series[0]["PieLabelStyle"] = "Outside";
		chart1.Series[0]["PieLineColor"] = "Black";
		chart1.Series[0].Points.DataBindXY(list, list2);
	}

	public void AddGoodsDataBindXY(List<tb_CarRecord> tb_5, List<tb_CarRecord> tb_6, List<tb_CarRecord> tb_dd, List<tb_CarRecord> tb_qt)
	{
		double num = tb_5.Sum((tb_CarRecord it) => Convert.ToDouble(it.cargoWeight));
		double num2 = tb_6.Sum((tb_CarRecord it) => Convert.ToDouble(it.cargoWeight));
		double num3 = tb_dd.Sum((tb_CarRecord it) => Convert.ToDouble(it.cargoWeight));
		double num4 = tb_qt.Sum((tb_CarRecord it) => Convert.ToDouble(it.cargoWeight));
		List<string> list = new List<string>();
		List<double> list2 = new List<double>();
		if (num > 0.0)
		{
			list.Add("国五:" + num + " 吨");
			list2.Add(num);
		}
		else
		{
			list.Add("国五:0 吨");
			list2.Add(0.01);
		}
		if (num2 > 0.0)
		{
			list.Add("国六:" + num2 + " 吨");
			list2.Add(num2);
		}
		else
		{
			list.Add("国六:0 吨");
			list2.Add(0.01);
		}
		if (num3 > 0.0)
		{
			list.Add("电动:" + num3 + " 吨");
			list2.Add(num3);
		}
		else
		{
			list.Add("电动:0 吨");
			list2.Add(0.01);
		}
		if (num4 > 0.0)
		{
			list.Add("其他:" + num4 + " 吨");
			list2.Add(num4);
		}
		else
		{
			list.Add("其他:0 吨");
			list2.Add(0.01);
		}
		chart2.Series[0]["PieLabelStyle"] = "Outside";
		chart2.Series[0]["PieLineColor"] = "Black";
		chart2.Series[0].Points.DataBindXY(list, list2);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		InitChart();
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
		System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
		System.Windows.Forms.DataVisualization.Charting.Legend legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
		System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series();
		System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
		System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
		System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
		this.panel1 = new System.Windows.Forms.Panel();
		this.button1 = new System.Windows.Forms.Button();
		this.dateEnd = new System.Windows.Forms.DateTimePicker();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.dateStart = new System.Windows.Forms.DateTimePicker();
		this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
		this.tableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chart1).BeginInit();
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chart2).BeginInit();
		base.SuspendLayout();
		this.tableLayoutPanel1.ColumnCount = 2;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.Controls.Add(this.chart2, 1, 1);
		this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 2;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(986, 581);
		this.tableLayoutPanel1.TabIndex = 1;
		chartArea.Name = "ChartArea1";
		this.chart1.ChartAreas.Add(chartArea);
		this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
		legend.Name = "Legend1";
		this.chart1.Legends.Add(legend);
		this.chart1.Location = new System.Drawing.Point(3, 63);
		this.chart1.Name = "chart1";
		series.ChartArea = "ChartArea1";
		series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
		series.Legend = "Legend1";
		series.Name = "Series1";
		this.chart1.Series.Add(series);
		this.chart1.Size = new System.Drawing.Size(487, 515);
		this.chart1.TabIndex = 0;
		this.chart1.Text = "chart1";
		this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
		this.panel1.Controls.Add(this.button1);
		this.panel1.Controls.Add(this.dateEnd);
		this.panel1.Controls.Add(this.label4);
		this.panel1.Controls.Add(this.label3);
		this.panel1.Controls.Add(this.dateStart);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panel1.Location = new System.Drawing.Point(3, 3);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(980, 54);
		this.panel1.TabIndex = 2;
		this.button1.Location = new System.Drawing.Point(763, 9);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(102, 35);
		this.button1.TabIndex = 50;
		this.button1.Text = "查询";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.dateEnd.CalendarFont = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.dateEnd.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.dateEnd.Location = new System.Drawing.Point(483, 12);
		this.dateEnd.Name = "dateEnd";
		this.dateEnd.Size = new System.Drawing.Size(251, 29);
		this.dateEnd.TabIndex = 49;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(387, 16);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(90, 21);
		this.label4.TabIndex = 48;
		this.label4.Text = "结束时间：";
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(3, 16);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(90, 21);
		this.label3.TabIndex = 46;
		this.label3.Text = "开始时间：";
		this.dateStart.CalendarFont = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.dateStart.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.dateStart.Location = new System.Drawing.Point(98, 12);
		this.dateStart.Name = "dateStart";
		this.dateStart.Size = new System.Drawing.Size(251, 29);
		this.dateStart.TabIndex = 47;
		chartArea2.Name = "ChartArea1";
		this.chart2.ChartAreas.Add(chartArea2);
		this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
		legend2.Name = "Legend1";
		this.chart2.Legends.Add(legend2);
		this.chart2.Location = new System.Drawing.Point(496, 63);
		this.chart2.Name = "chart2";
		series2.ChartArea = "ChartArea1";
		series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
		series2.Legend = "Legend1";
		series2.Name = "Series1";
		this.chart2.Series.Add(series2);
		this.chart2.Size = new System.Drawing.Size(487, 515);
		this.chart2.TabIndex = 3;
		this.chart2.Text = "chart2";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(986, 581);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Name = "ChartForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "统计表";
		this.tableLayoutPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chart1).EndInit();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.chart2).EndInit();
		base.ResumeLayout(false);
	}
}
