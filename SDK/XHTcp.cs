using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using BulkMaterialsForm.Help;

namespace BulkMaterialsForm.SDK;

public class XHTcp
{
	public static Socket SocketClient = null;

	public static Thread threadwatch = null;

	public static Dictionary<string, Socket> xhTcpList = new Dictionary<string, Socket>();

	public void Init()
	{
		SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		IPAddress address = IPAddress.Parse(MqttHostService.GetCurrentComputerIP());
		IPEndPoint localEP = new IPEndPoint(address, 9055);
		SocketClient.Bind(localEP);
		SocketClient.Listen(100);
		SocketClient.SendTimeout = 30000;
		threadwatch = new Thread(watchconnecting);
		threadwatch.IsBackground = true;
		threadwatch.Start();
	}

	private static void watchconnecting()
	{
		try
		{
			Socket socket = null;
			while (true)
			{
				try
				{
					socket = SocketClient.Accept();
				}
				catch (Exception)
				{
					break;
				}
				IPAddress address = (socket.RemoteEndPoint as IPEndPoint).Address;
				xhTcpList[address.ToString()] = socket;
				int port = (socket.RemoteEndPoint as IPEndPoint).Port;
				ParameterizedThreadStart start = recv;
				Thread thread = new Thread(start);
				thread.IsBackground = true;
				thread.Start(socket);
			}
		}
		catch (Exception)
		{
		}
	}

	private static void recv(object socketclientpara)
	{
		try
		{
			Socket socket = socketclientpara as Socket;
			while (true)
			{
				try
				{
					if (socket != null)
					{
						byte[] array = new byte[48];
						int num = socket.Receive(array);
						if (num == 0)
						{
							socket.Shutdown(SocketShutdown.Both);
							socket.Close();
							socket.Dispose();
							break;
						}
						IPAddress address = (socket.RemoteEndPoint as IPEndPoint).Address;
						int port = (socket.RemoteEndPoint as IPEndPoint).Port;
						string text = Encoding.UTF8.GetString(array, 0, num);
						LogSave.XHTcpLog(DateTime.Now.ToString() + "IP:" + address?.ToString() + "端口:" + port + "内容：" + text);
					}
				}
				catch (Exception)
				{
					break;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void SendON(Socket socket)
	{
		string s = "ADMINAT+RELAY=1";
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		socket.Send(bytes);
	}

	public static void SendOFF(Socket socket)
	{
		string s = "ADMINAT+RELAY=1";
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		socket.Send(bytes);
	}
}
