// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.TCPSeerver

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BulkMaterialsForm.Model.View;

namespace BulkMaterialsForm.Help;

public class TCPSeerver
{
	public delegate void CarTcpRecord(string ip, byte type);

	private static TcpListener tcpListener;

	private static int port = 14739;

	private static readonly CancellationTokenSource _cts = new CancellationTokenSource();

	public static List<tcpModel> tcpModels = new List<tcpModel>();

	public static event CarTcpRecord carTcpRecord;

	public static void StopServer()
	{
		_cts.Cancel();
		try
		{
			tcpListener?.Stop();
		}
		catch (Exception ex)
		{
			LogSave.XHTcpLog($"[TCPSeerver] 停止服务异常: {ex.Message}");
		}
		foreach (tcpModel item in tcpModels.ToList())
		{
			try
			{
				item.tcpClient?.Close();
			}
			catch { }
		}
		tcpModels.Clear();
	}

	public static async Task StartServerAsync()
	{
		try
		{
			tcpListener = new TcpListener(IPAddress.Parse(MainData.localhostIP), port);
			tcpListener.Start();
			LogSave.XHTcpLog($"[TCPSeerver] 服务启动，端口: {port}");
			while (!_cts.Token.IsCancellationRequested)
			{
				try
				{
					TcpClient client = await tcpListener.AcceptTcpClientAsync();
					tcpModel tcpModel2 = tcpModels.FirstOrDefault((tcpModel it) => it.ipAndPort == client.Client.RemoteEndPoint.ToString());
					if (tcpModel2 == null)
					{
						LogSave.XHTcpLog(DateTime.Now.ToString() + " 添加设备==" + client.Client.RemoteEndPoint.ToString());
						tcpModel2 = new tcpModel
						{
							tcpClient = client,
							ipAndPort = client.Client.RemoteEndPoint.ToString()
						};
						tcpModels.Add(tcpModel2);
					}
					else
					{
						LogSave.TCPLog(DateTime.Now.ToString() + " 已存在" + client.Client.RemoteEndPoint.ToString());
						tcpModel2.tcpClient = client;
					}
					HandleClientAsync(client);
					string text = (client.Client.RemoteEndPoint as IPEndPoint).Address.ToString();
					LogSave.XHTcpLog(DateTime.Now.ToString() + "TCP连接:" + text);
				}
				catch (OperationCanceledException)
				{
					break;
				}
				catch (Exception ex)
				{
					LogSave.XHTcpLog($"[TCPSeerver] 接受连接异常: {ex.Message}");
					await Task.Delay(1000, _cts.Token);
				}
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex)
		{
			LogSave.XHTcpLog($"[TCPSeerver] StartServerAsync异常: {ex.ToString()}");
		}
	}

	private static async Task HandleClientAsync(TcpClient client)
	{
		NetworkStream stream = client.GetStream();
		byte[] bytes = new byte[1024];
		try
		{
			int count;
			while ((count = await stream.ReadAsync(bytes, 0, bytes.Length, _cts.Token)) != 0)
			{
				string text = Encoding.UTF8.GetString(bytes, 0, count);
				IPAddress address = (client.Client.RemoteEndPoint as IPEndPoint).Address;
				LogSave.XHTcpLog(DateTime.Now.ToString() + "IP=" + address.ToString() + "TCP接受:" + text);
				if (TCPSeerver.carTcpRecord != null)
				{
					if (text.Contains("+DIN1:"))
					{
						string text2 = text.Replace("+DIN1:", "");
						byte type = 0;
						if (text2.Contains("0"))
						{
							type = 0;
						}
						else if (text2.Contains("1"))
						{
							type = 1;
						}
						TCPSeerver.carTcpRecord(address.ToString(), type);
					}
					else if (text.Contains("+OCCH1"))
					{
						string text3 = text.Replace("+OCCH1:", "");
						byte type2 = 0;
						LogSave.XHTcpLog(DateTime.Now.ToString() + "IP=" + address.ToString() + "text:" + text3);
						if (text3.Contains("0"))
						{
							type2 = 0;
						}
						else if (text3.Contains("1"))
						{
							type2 = 1;
						}
						TCPSeerver.carTcpRecord(address.ToString(), type2);
					}
				}
				else
				{
					LogSave.XHTcpLog(DateTime.Now.ToString() + "carTcpRecord为空");
				}
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex)
		{
			LogSave.XHTcpLog($"[TCPSeerver.HandleClient] 处理异常: {ex.Message}");
		}
		finally
		{
			try { client.Close(); } catch { }
		}
	}

	public static void SendData(TcpClient client, string message)
	{
		try
		{
			NetworkStream stream = client.GetStream();
			byte[] bytes = Encoding.UTF8.GetBytes(message);
			stream.Write(bytes, 0, bytes.Length);
		}
		catch (Exception ex)
		{
			LogSave.XHTcpLog($"[TCPSeerver.SendData] 发送异常: {ex.Message}");
		}
	}
}
