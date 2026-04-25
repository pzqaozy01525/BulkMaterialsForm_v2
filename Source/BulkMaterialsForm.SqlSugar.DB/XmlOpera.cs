// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SqlSugar.DB
// Type: BulkMaterialsForm.SqlSugar.DB.XmlOpera

using System;
using System.IO;
using System.Xml;
using BulkMaterialsForm.Model;
using SqlSugar;

namespace BulkMaterialsForm.SqlSugar.DB;

public class XmlOpera<T> where T : class, new()
{
	public static void GetXmlTableList(SimpleClient<T> content, Type t)
	{
		try
		{
			string text = AppDomain.CurrentDomain.BaseDirectory + t.Name.ToString() + ".xml";
			if (!File.Exists(text))
			{
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(text);
			foreach (XmlNode item in xmlDocument.SelectNodes("table"))
			{
				foreach (XmlNode item2 in item.SelectNodes("row"))
				{
					if (t.Name == "tb_kayValue")
					{
						AddKayValue(content, item2);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void AddKayValue(SimpleClient<T> content, XmlNode node)
	{
		T insertObj = new tb_kayValue
		{
			keyCode = node.Attributes["keyCode"].InnerText,
			keyValue = node.Attributes["keyValue"].InnerText,
			keyType = node.Attributes["keyType"].InnerText
		} as T;
		content.InsertReturnIdentity(insertObj);
	}
}
