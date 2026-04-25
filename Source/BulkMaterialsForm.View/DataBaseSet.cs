// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.DataBaseSet

using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Properties;
using DevExpress.XtraBars;

namespace BulkMaterialsForm.View;

public class DataBaseSet : Form
{
	private IContainer components;

	private BarManager barManager1;

	private Bar bar2;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private BarSubItem barSubItem1;

	private TextBox textBox11;

	private Label label11;

	private TextBox textBox10;

	private Label label10;

	private TextBox textBox9;

	private Label label9;

	private TextBox textBox8;

	private Label label8;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem6;

	private BarButtonItem barButtonItem7;

	public DataBaseSet()
	{
		InitializeComponent();
		base.Load += DataBaseSet_Load;
	}

	private void DataBaseSet_Load(object sender, EventArgs e)
	{
		textBox8.Text = New_IniFile.ReadContentValue("数据库连接", "server", MainData.Spath);
		textBox9.Text = New_IniFile.ReadContentValue("数据库连接", "database", MainData.Spath);
		textBox10.Text = New_IniFile.ReadContentValue("数据库连接", "uid", MainData.Spath);
		textBox11.Text = New_IniFile.ReadContentValue("数据库连接", "pwd", MainData.Spath);
	}

	private static string BuildConn(string server, string database, string uid, string pwd)
	{
		return "server=" + server + ";database=" + database + ";uid=" + uid + ";pwd=" + pwd;
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		New_IniFile.WriteContentValue("数据库连接", "server", textBox8.Text, MainData.Spath);
		New_IniFile.WriteContentValue("数据库连接", "database", textBox9.Text, MainData.Spath);
		New_IniFile.WriteContentValue("数据库连接", "uid", textBox10.Text, MainData.Spath);
		New_IniFile.WriteContentValue("数据库连接", "pwd", textBox11.Text, MainData.Spath);
		MainData.server = textBox8.Text;
		MainData.database = textBox9.Text;
		MainData.uid = textBox10.Text;
		MainData.pwd = textBox11.Text;
		MainData.M_str_sqlcon = BuildConn(MainData.server, MainData.database, MainData.uid, MainData.pwd);
		MessageBox.Show("保存成功");
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		string connectionString = BuildConn(textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text);
		try
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
			}
			MessageBox.Show("连接成功");
		}
		catch (Exception ex)
		{
			MessageBox.Show("连接失败: " + ex.Message);
		}
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		new SqlServerInstall().ShowDialog();
		string text = textBox9.Text?.Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			MessageBox.Show("请先填写数据库名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}
		string connectionString = BuildConn(textBox8.Text, "master", textBox10.Text, textBox11.Text);
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			using SqlCommand sqlCommand = sqlConnection.CreateCommand();
			sqlCommand.CommandText = "IF DB_ID('" + text.Replace("'", "''") + "') IS NULL EXEC('CREATE DATABASE [" + text.Replace("'", "''") + "]');";
			sqlCommand.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show("创建数据库失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}
		string connectionString2 = BuildConn(textBox8.Text, text, textBox10.Text, textBox11.Text);
		string path = Application.StartupPath + "\\创建.sql";
		if (!File.Exists(path))
		{
			MessageBox.Show("初始化脚本 [创建.sql] 不存在，跳过建表。\n请确保 [创建.sql] 文件在程序目录下。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}
		try
		{
			using SqlConnection sqlConnection2 = new SqlConnection(connectionString2);
			sqlConnection2.Open();
			using SqlCommand cmd = sqlConnection2.CreateCommand();
			CreateDatebase(path, cmd);
			MessageBox.Show("创建完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (Exception ex2)
		{
			MessageBox.Show("执行初始化脚本失败: " + ex2.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	public static void CreateDatebase(string path, SqlCommand cmd)
	{
		cmd.CommandTimeout = 600;
		using StreamReader streamReader = new StreamReader(path, Encoding.Default);
		StringBuilder stringBuilder = new StringBuilder();
		string text;
		while ((text = streamReader.ReadLine()) != null)
		{
			string a = text.Trim();
			if (string.Equals(a, "GO", StringComparison.OrdinalIgnoreCase) || string.Equals(a, "GO;", StringComparison.OrdinalIgnoreCase))
			{
				string text2 = stringBuilder.ToString().Trim();
				if (!string.IsNullOrWhiteSpace(text2))
				{
					cmd.CommandText = text2;
					cmd.ExecuteNonQuery();
				}
				stringBuilder.Clear();
			}
			else
			{
				stringBuilder.AppendLine(text);
			}
		}
		string text3 = stringBuilder.ToString().Trim();
		if (!string.IsNullOrWhiteSpace(text3))
		{
			cmd.CommandText = text3;
			cmd.ExecuteNonQuery();
		}
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			using (SqlConnection sqlConnection = new SqlConnection(MainData.M_str_sqlcon))
			{
				sqlConnection.Open();
			}
			string path = Application.StartupPath + "\\更新.sql";
			if (!File.Exists(path))
			{
				MessageBox.Show("更新脚本 [更新.sql] 不存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(MainData.M_str_sqlcon))
			{
				sqlConnection2.Open();
				using SqlCommand sqlCommand = sqlConnection2.CreateCommand();
				sqlCommand.CommandText = "IF OBJECT_ID(N'dbo.tb_TempCarInfo','U') IS NOT NULL DELETE FROM dbo.tb_TempCarInfo;";
				sqlCommand.ExecuteNonQuery();
				CreateDatebase(path, sqlCommand);
			}
			MessageBox.Show("更新完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (Exception ex)
		{
			MessageBox.Show("更新失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
		string m_str_sqlcon = MainData.M_str_sqlcon;
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "bak files (*.bak)|*.bak|All files (*.*)|*.*";
		saveFileDialog.FilterIndex = 1;
		saveFileDialog.FilterIndex = 0;
		saveFileDialog.RestoreDirectory = true;
		saveFileDialog.CreatePrompt = false;
		saveFileDialog.Title = "备份数据库";
		saveFileDialog.FileName = "yyyyMMddHHmmssfff.bak";
		if (saveFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string fileName = saveFileDialog.FileName;
		string cmdText = "BACKUP DATABASE [" + textBox9.Text + "] TO DISK = N'" + fileName + "' WITH NOFORMAT, NOINIT, NAME = N'" + textBox9.Text + "', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
		using SqlConnection sqlConnection = new SqlConnection(m_str_sqlcon);
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		sqlCommand.ExecuteNonQuery();
		Console.WriteLine("数据库备份成功。");
	}

	private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "数据库备份文件(*.BAK)|*.bak";
		openFileDialog.CheckFileExists = true;
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string fileName = openFileDialog.FileName;
		try
		{
			string cmdText = "RESTORE DATABASE " + textBox9.Text + " FROM DISK = '" + fileName + "' WITH REPLACE";
			string text = "Provider=SQLOLEDB;Server=" + MainData.server + "; Database=Master; User ID=" + MainData.uid + "; Password=" + MainData.pwd + ";Connect Timeout=30";
			Kill_DBConn(text, MainData.database);
			using OleDbConnection oleDbConnection = new OleDbConnection(text);
			SqlConnection.ClearAllPools();
			OleDbConnection.ReleaseObjectPool();
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			try
			{
				oleDbCommand.CommandTimeout = 60;
				oleDbCommand.ExecuteNonQuery();
				oleDbCommand.Dispose();
				oleDbConnection.Close();
				oleDbConnection.Dispose();
				Application.Exit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		catch (Exception)
		{
		}
	}

	private void Kill_DBConn(string sqlConnectString, string parkDbName)
	{
		string cmdText = "SELECT spid FROM sysprocesses ,sysdatabases WHERE sysprocesses.dbid=sysdatabases.dbid AND sysdatabases.Name='" + parkDbName + "'";
		using OleDbConnection oleDbConnection = new OleDbConnection(sqlConnectString);
		oleDbConnection.Open();
		DataSet dataSet = new DataSet();
		OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
		new OleDbDataAdapter(oleDbCommand).Fill(dataSet);
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			try
			{
				oleDbCommand.CommandText = "KILL " + row[0].ToString();
				oleDbCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
			}
		}
		oleDbCommand.Dispose();
		oleDbConnection.Close();
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
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
		this.textBox11 = new System.Windows.Forms.TextBox();
		this.label11 = new System.Windows.Forms.Label();
		this.textBox10 = new System.Windows.Forms.TextBox();
		this.label10 = new System.Windows.Forms.Label();
		this.textBox9 = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.textBox8 = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[8] { this.barSubItem1, this.barButtonItem1, this.barButtonItem2, this.barButtonItem3, this.barButtonItem4, this.barButtonItem5, this.barButtonItem6, this.barButtonItem7 });
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 103;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[7]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem5, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem6, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem7, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard)
		});
		this.bar2.OptionsBar.MultiLine = true;
		this.bar2.OptionsBar.UseWholeRow = true;
		this.bar2.Text = "Main menu";
		this.barButtonItem1.Caption = "保存";
		this.barButtonItem1.Id = 96;
		this.barButtonItem1.ImageOptions.Image = null;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "关闭";
		this.barButtonItem2.Id = 97;
		this.barButtonItem2.ImageOptions.Image = null;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "测试连接";
		this.barButtonItem3.Id = 98;
		this.barButtonItem3.ImageOptions.Image = null;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem4.Caption = "创建数据库";
		this.barButtonItem4.Id = 99;
		this.barButtonItem4.ImageOptions.Image = null;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barButtonItem5.Caption = "升级数据库";
		this.barButtonItem5.Id = 100;
		this.barButtonItem5.ImageOptions.Image = null;
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(620, 71);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 361);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(620, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 71);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 290);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(620, 71);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 290);
		this.barSubItem1.Caption = "保存";
		this.barSubItem1.Id = 95;
		this.barSubItem1.Name = "barSubItem1";
		this.textBox11.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox11.Location = new System.Drawing.Point(234, 311);
		this.textBox11.Name = "textBox11";
		this.textBox11.PasswordChar = '*';
		this.textBox11.Size = new System.Drawing.Size(195, 34);
		this.textBox11.TabIndex = 38;
		this.label11.AutoSize = true;
		this.label11.BackColor = System.Drawing.Color.Transparent;
		this.label11.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label11.Location = new System.Drawing.Point(112, 311);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(112, 27);
		this.label11.TabIndex = 37;
		this.label11.Text = "数据库密码";
		this.textBox10.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox10.Location = new System.Drawing.Point(234, 242);
		this.textBox10.Name = "textBox10";
		this.textBox10.Size = new System.Drawing.Size(195, 34);
		this.textBox10.TabIndex = 36;
		this.label10.AutoSize = true;
		this.label10.BackColor = System.Drawing.Color.Transparent;
		this.label10.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label10.Location = new System.Drawing.Point(112, 245);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(112, 27);
		this.label10.TabIndex = 35;
		this.label10.Text = "数据库账号";
		this.textBox9.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox9.Location = new System.Drawing.Point(234, 174);
		this.textBox9.Name = "textBox9";
		this.textBox9.Size = new System.Drawing.Size(195, 34);
		this.textBox9.TabIndex = 34;
		this.label9.AutoSize = true;
		this.label9.BackColor = System.Drawing.Color.Transparent;
		this.label9.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label9.Location = new System.Drawing.Point(112, 174);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(112, 27);
		this.label9.TabIndex = 33;
		this.label9.Text = "数据库名称";
		this.textBox8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.textBox8.Location = new System.Drawing.Point(234, 107);
		this.textBox8.Name = "textBox8";
		this.textBox8.Size = new System.Drawing.Size(195, 34);
		this.textBox8.TabIndex = 32;
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label8.Location = new System.Drawing.Point(132, 107);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(92, 27);
		this.label8.TabIndex = 31;
		this.label8.Text = "数据库IP";
		this.barButtonItem6.Caption = "备份数据";
		this.barButtonItem6.Id = 101;
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem6.ImageOptions.Image = null;
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barButtonItem7.Caption = "导入备份数据";
		this.barButtonItem7.Id = 102;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem7.ImageOptions.Image = null;
		this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem7_ItemClick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(620, 361);
		base.Controls.Add(this.textBox11);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.textBox10);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.textBox9);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.textBox8);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "DataBaseSet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "数据库设置";
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
