// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Manager
// Type: BulkMaterialsForm.Manager.DBHelp

using System;
using System.Linq;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.SqlSugar.DB;
using SqlSugar;

namespace BulkMaterialsForm.Manager;

public class DBHelp
{
	public static void Init()
	{
		Type[] entityTypes = new Type[17]
		{
			typeof(tb_ChannelSeniorSet),
			typeof(tb_CarRecord),
			typeof(tb_videotape),
			typeof(tb_large_screen),
			typeof(tb_Device),
			typeof(tb_exceptional),
			typeof(tb_tempVehicle),
			typeof(tb_kayValue),
			typeof(tb_Weig),
			typeof(tb_Channel),
			typeof(tb_ImageDetaile),
			typeof(tb_large_screen_detaile),
			typeof(tb_nonRoad),
			typeof(tb_nonRoadRecord),
			typeof(tb_TempCarInfo),
			typeof(tb_vehicleInfo),
			typeof(tb_vehicleInfoV2)
		};
		SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig
		{
			ConnectionString = MainData.M_str_sqlcon,
			DbType = DbType.SqlServer,
			InitKeyType = InitKeyType.Attribute,
			IsAutoCloseConnection = true
		});
		Db.Aop.OnLogExecuting = delegate(string sql, SugarParameter[] pars)
		{
			// SQL logging to console removed for production safety.
			// Enable via debug build or environment variable if needed.
		};
		Db.CodeFirst.InitTables(entityTypes);
		InitData<tb_kayValue>.InitTableData(new SimpleClient<tb_kayValue>(Db), typeof(tb_kayValue));
	}
}
