// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.DataClass

using System;
using System.Data;
using System.Data.SqlClient;

namespace BulkMaterialsForm.Help;

public class DataClass
{
	public static SqlConnection My_con;

	public static SqlConnection mySqlConnection;

	public static SqlConnection getcon()
	{
		My_con = new SqlConnection(MainData.M_str_sqlcon);
		My_con.Open();
		return My_con;
	}

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
		catch (Exception)
		{
		}
		finally
		{
			mySqlConnection.Close();
		}
		return result;
	}

	public static DataTable GetDatatable(string str, ref string msg)
	{
		using SqlConnection sqlConnection = new SqlConnection(MainData.DBServer);
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, sqlConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tables");
			new DataTable();
			DataTable result = dataSet.Tables[0];
			sqlConnection.Close();
			return result;
		}
		catch (Exception ex)
		{
			msg = ex.Message;
			return null;
		}
	}
}
