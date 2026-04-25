// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.ServerHttp

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BulkMaterialsForm.Help;

public class ServerHttp
{
	private static HttpListener serverComet = new HttpListener();

	public static string port;

	public static object obj = new object();

	public static Thread startThread;

	public static void InitData()
	{
		port = "20132";
	}

	public static void Close()
	{
		if (startThread != null)
		{
			startThread.Abort();
			serverComet.Stop();
			serverComet.Close();
		}
	}

	public static void Init()
	{
		try
		{
			if (string.IsNullOrWhiteSpace(port))
			{
				return;
			}
			foreach (string item in CommonHelper.GetCurrentComputerIP())
			{
				serverComet.Prefixes.Add("http://" + item + ":" + port + "/");
			}
			serverComet.Start();
			startThread = new Thread(ListenForRequests);
			startThread.Start();
		}
		catch (Exception)
		{
			serverComet = new HttpListener();
		}
	}

	private static void ListenForRequests()
	{
		try
		{
			while (serverComet.IsListening)
			{
				HttpListenerContext context = serverComet.GetContext();
				Task.Factory.StartNew(HandleRequestRecordComet, context);
			}
		}
		catch (Exception)
		{
		}
	}

	private static void HandleRequestRecordComet(object o)
	{
		try
		{
			HttpListenerContext httpListenerContext = (HttpListenerContext)o;
			HttpListenerRequest request = httpListenerContext.Request;
			string value = null;
			using (StreamReader streamReader = new StreamReader(request.InputStream, Encoding.UTF8))
			{
				value = streamReader.ReadToEnd();
			}
			JsonConvert.DeserializeObject<JObject>(value);
			lock (obj)
			{
				ResultModel resultModel = new ResultModel();
				try
				{
					if (httpListenerContext.Request.RawUrl == "/api/vehicleRecordRealHM")
					{
						List<tb_CarRecord> list = new DataServerContext<tb_CarRecord>().Current.GetList((tb_CarRecord it) => it.upload_status == "上传成功").ToList();
						if (list != null)
						{
							foreach (tb_CarRecord item in list)
							{
								_ = item;
							}
						}
					}
					else if (!(httpListenerContext.Request.RawUrl == "/api/vehicleRecordRealHM"))
					{
						resultModel.code = 0;
						resultModel.msg = "接口不存在";
					}
				}
				catch (Exception)
				{
				}
				SendData(httpListenerContext.Response, resultModel);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void SendData(HttpListenerResponse resp, ResultModel data)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
		resp.ContentType = "application/json";
		resp.SendChunked = false;
		resp.ContentEncoding = Encoding.UTF8;
		resp.ContentLength64 = bytes.Length;
		resp.OutputStream.Write(bytes, 0, bytes.Length);
		resp.OutputStream.Close();
	}
}
