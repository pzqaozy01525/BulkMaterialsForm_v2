// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SqlSugar.DB
// Type: BulkMaterialsForm.SqlSugar.DB.InitData

using System;
using System.Linq;
using SqlSugar;

namespace BulkMaterialsForm.SqlSugar.DB;

public class InitData<T> where T : class, new()
{
	public static void InitTableData(SimpleClient<T> content, Type t)
	{
		if (content.GetList().Count() == 0)
		{
			XmlOpera<T>.GetXmlTableList(content, t);
		}
	}
}
