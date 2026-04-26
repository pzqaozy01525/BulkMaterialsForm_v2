// BulkMaterialsForm.Help
// Common UI helper methods shared across all View forms.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;

namespace BulkMaterialsForm.Help;

public static class FormHelper
{
	/// <summary>
	/// Thread-safe message box display. Use as: FormHelper.ShowMessage(this, "text").
	/// </summary>
	public static void ShowMessage(Form form, string msg, string caption = "")
	{
		if (form == null || string.IsNullOrEmpty(msg))
			return;
		Action show = () => MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
		if (form.InvokeRequired)
			form.Invoke(show);
		else
			show();
	}

	/// <summary>
	/// Thread-safe message box display with icon. Use as: FormHelper.ShowMessage(this, "text", icon).
	/// </summary>
	public static void ShowMessage(Form form, string msg, MessageBoxIcon icon, string caption = "")
	{
		if (form == null || string.IsNullOrEmpty(msg))
			return;
		Action show = () => MessageBox.Show(msg, caption, MessageBoxButtons.OK, icon);
		if (form.InvokeRequired)
			form.Invoke(show);
		else
			show();
	}

	/// <summary>
	/// Thread-safe message box display for errors. Shows error icon automatically.
	/// </summary>
	public static void ShowError(Form form, string msg)
	{
		ShowMessage(form, msg, MessageBoxIcon.Error, "错误");
	}

	/// <summary>
	/// Thread-safe message box display for success. Shows information icon automatically.
	/// </summary>
	public static void ShowSuccess(Form form, string msg)
	{
		ShowMessage(form, msg, MessageBoxIcon.Information, "成功");
	}

	/// <summary>
	/// Thread-safe message box display for warnings.
	/// </summary>
	public static void ShowWarning(Form form, string msg)
	{
		ShowMessage(form, msg, MessageBoxIcon.Warning, "警告");
	}

	/// <summary>
	/// Collect selected row IDs (int) from a DataGridView with a checkbox column.
	/// Assumes first column is checkbox and "id" column contains the ID.
	/// </summary>
	public static List<int> GetSelectedIds(DataGridView dgv)
	{
		var ids = new List<int>();
		if (dgv == null)
			return ids;
		foreach (DataGridViewRow row in dgv.Rows)
		{
			if (row.Cells[0].Value is bool b && b)
			{
				var idCell = row.Cells["id"].Value;
				if (idCell != null)
					ids.Add(Convert.ToInt32(idCell));
			}
		}
		return ids;
	}

	/// <summary>
	/// Collect selected row IDs (int) from a DataGridView with a checkbox column,
	/// using a custom ID column name.
	/// </summary>
	public static List<int> GetSelectedIds(DataGridView dgv, string idColumnName)
	{
		var ids = new List<int>();
		if (dgv == null)
			return ids;
		foreach (DataGridViewRow row in dgv.Rows)
		{
			if (row.Cells[0].Value is bool b && b)
			{
				var idCell = row.Cells[idColumnName].Value;
				if (idCell != null)
					ids.Add(Convert.ToInt32(idCell));
			}
		}
		return ids;
	}

	/// <summary>
	/// Collect selected row IDs (string) from a DataGridView with a checkbox column.
	/// </summary>
	public static List<string> GetSelectedIdsString(DataGridView dgv)
	{
		var ids = new List<string>();
		if (dgv == null)
			return ids;
		foreach (DataGridViewRow row in dgv.Rows)
		{
			if (row.Cells[0].Value is bool b && b)
			{
				var idCell = row.Cells["id"].Value;
				if (idCell != null)
					ids.Add(idCell.ToString()!);
			}
		}
		return ids;
	}

	/// <summary>
	/// Import Excel file to DataTable. Supports .xls and .xlsx.
	/// </summary>
	public static DataSet ExcelToDataSet(string filePath)
	{
		var ext = Path.GetExtension(filePath).ToLowerInvariant();
		string[] providers = { "Microsoft.ACE.OLEDB.16.0", "Microsoft.ACE.OLEDB.15.0",
			"Microsoft.ACE.OLEDB.12.0", "Microsoft.Jet.OLEDB.4.0" };
		string[] sheets = ext == ".xlsx"
			? new[] { "Excel 12.0 Xml;HDR=YES;IMEX=1", "Excel 12.0;HDR=YES;IMEX=1" }
			: new[] { "Excel 12.0;HDR=YES;IMEX=1" };

		foreach (var prov in providers)
		{
			foreach (var sheet in sheets)
			{
				try
				{
					var connStr = $"Provider={prov};Data Source={filePath};Extended Properties=\"{sheet}\"";
					using var conn = new OleDbConnection(connStr);
					conn.Open();
					var ds = new DataSet();
					var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
					foreach (DataRow row in dt.Rows)
					{
						var name = row["TABLE_NAME"].ToString()!;
						if (name.Contains("$") || name.Contains("_"))
						{
							var adapter = new OleDbDataAdapter($"SELECT * FROM [{name}]", conn);
							adapter.Fill(ds, name);
						}
					}
					return ds;
				}
				catch { }
			}
		}
		return new DataSet();
	}

	/// <summary>
	/// Export DataGridView rows to tab-separated text file with UTF-8 BOM.
	/// </summary>
	public static void ExportToTsv(DataGridView dgv, string filePath, string[] headerNames)
	{
		var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
		using var sw = new StreamWriter(filePath, append: false, encoding);
		sw.WriteLine(string.Join("\t", headerNames));
		foreach (DataGridViewRow row in dgv.Rows)
		{
			if (!row.Visible)
				continue;
			var cells = Enumerable.Range(0, dgv.ColumnCount)
				.Select(i => row.Cells[i].Value?.ToString() ?? "")
				.Select(v => v.Replace("\t", " ").Replace("\r", "").Replace("\n", " "));
			sw.WriteLine(string.Join("\t", cells));
		}
	}

	/// <summary>
	/// Export DataGridView rows to tab-separated text file with UTF-8 BOM (custom value arrays).
	/// </summary>
	public static void ExportToTsv<T>(IEnumerable<T> rows, string filePath, Func<T, string[]> valueExtractor, string[] headerNames)
	{
		var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
		using var sw = new StreamWriter(filePath, append: false, encoding);
		sw.WriteLine(string.Join("\t", headerNames));
		foreach (var row in rows)
		{
			var values = valueExtractor(row);
			var cleaned = values.Select(v => (v ?? "").Replace("\t", " ").Replace("\r", "").Replace("\n", " "));
			sw.WriteLine(string.Join("\t", cleaned));
		}
	}

	/// <summary>
	/// Build a timestamped image path under a base directory.
	/// Handles both trailing-backslash and no-backslash base directories.
	/// Usage: FormHelper.BuildImagePath(MainData.strImageDir, "jpg")
	///        FormHelper.BuildImagePath(MainData.strImageDir, "jpg", "cp")
	/// </summary>
	public static string BuildImagePath(string baseDir, string ext, string suffix = null)
	{
		string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
		if (!string.IsNullOrEmpty(suffix))
			fileName = fileName + suffix + "." + ext;
		else
			fileName = fileName + "." + ext;
		return Path.Combine(baseDir, fileName);
	}

	/// <summary>
	/// Check if a vehicle plate color is restricted by transit color settings.
	/// Returns true if the color is blocked (vehicle should be rejected).
	/// </summary>
	public static bool IsColorRestricted(string[] transitColors, string licenseColor)
	{
		return transitColors != null && transitColors.Length != 0 && !transitColors.Contains(licenseColor);
	}

	/// <summary>
	/// Check if a vehicle plate number exists in the registered car list (tb_car_info).
	/// Used in color whitelist verification logic.
	/// </summary>
	public static bool IsRegisteredVehicle(string vehicleNo)
	{
		return new DataServerContext<tb_car_info>().Current.GetModel((tb_car_info it) => it.car_no == vehicleNo) != null;
	}
}
