// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SqlSugar.DB
// Type: BulkMaterialsForm.SqlSugar.DB.XmlUtil

using System;
using System.IO;
using System.Xml.Serialization;

namespace BulkMaterialsForm.SqlSugar.DB;

public class XmlUtil
{
	public static object Deserialize(Type type, string xml)
	{
		try
		{
			using StringReader textReader = new StringReader(xml);
			return new XmlSerializer(type).Deserialize(textReader);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static object Deserialize(Type type, Stream stream)
	{
		return new XmlSerializer(type).Deserialize(stream);
	}

	public static string Serializer(Type type, object obj)
	{
		MemoryStream memoryStream = new MemoryStream();
		XmlSerializer xmlSerializer = new XmlSerializer(type);
		try
		{
			xmlSerializer.Serialize(memoryStream, obj);
		}
		catch (InvalidOperationException)
		{
			throw;
		}
		memoryStream.Position = 0L;
		StreamReader streamReader = new StreamReader(memoryStream);
		string result = streamReader.ReadToEnd();
		streamReader.Dispose();
		memoryStream.Dispose();
		return result;
	}
}
