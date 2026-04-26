// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.DataClass

using System;
using System.Data;
using System.Data.SqlClient;

namespace BulkMaterialsForm.Help;

public class DataClass
{
	public static SqlConnection mySqlConnection;

	public static bool connectTestW()
	{
		bool result = false;
		mySqlConnection = new SqlConnection(MainData.M_str_sqlcon);
		try
		{
			mySqlConnection.Open();
			if (mySqlConnection.State == ConnectionState.Open)
			{
				result = true;
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"[connectTestW] 数据库连接失败: {ex.Message}");
		}
		finally
		{
			mySqlConnection.Close();
		}
		return result;
	}

	public static DataTable GetDatatable(string str, ref string msg)
	{
		return GetDatatable(str, null, ref msg);
	}

	public static DataTable GetDatatable(string sql, SqlParameter[] parameters, ref string msg)
	{
		using SqlConnection sqlConnection = new SqlConnection(MainData.DBServer);
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
			if (parameters != null)
			{
				foreach (SqlParameter p in parameters)
					sqlDataAdapter.SelectCommand.Parameters.Add(p);
			}
			DataTable result = new DataTable();
			sqlDataAdapter.Fill(result);
			return result;
		}
		catch (Exception ex)
		{
			msg = ex.Message;
			return null;
		}
	}
}
