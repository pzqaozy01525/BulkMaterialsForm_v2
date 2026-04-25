// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.MqttHostService

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace BulkMaterialsForm.Help;

public class MqttHostService
{
	public delegate void SendMessage(string msg);

	public delegate void IOChangeDelegate(string ip, int data);

	public delegate void Serverbreakoff(string ip, int data);

	private const string ServerClientId = "SERVER";

	public static bool isInit = false;

	public static Timer timer1;

	public static List<MqttClientInfo> mqttClientInfos = new List<MqttClientInfo>();

	public static event IOChangeDelegate ioChangeDelegate;

	public static event Serverbreakoff serverbreakoff;

	public static string GetCurrentComputerIP()
	{
		string result = "127.0.0.1";
		IPAddress[] addressList = Dns.GetHostEntry("").AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				result = iPAddress.ToString();
				break;
			}
		}
		return result;
	}

	public static void StartAsync()
	{
		string currentComputerIP = GetCurrentComputerIP();
		LogSave.MQTTLog(currentComputerIP);
		string value = "6000";
		MqttServerOptionsBuilder mqttServerOptionsBuilder = new MqttServerOptionsBuilder();
		mqttServerOptionsBuilder.WithDefaultEndpoint();
		mqttServerOptionsBuilder.WithDefaultEndpointBoundIPAddress(IPAddress.Parse(currentComputerIP));
		mqttServerOptionsBuilder.WithDefaultEndpointPort(Convert.ToInt32(value));
		mqttServerOptionsBuilder.WithConnectionBacklog(60000);
		MqttServerOptions options = mqttServerOptionsBuilder.Build();
		MqttService._mqttServer = new MqttFactory().CreateMqttServer(options);
		MqttService._mqttServer.ClientConnectedAsync += _mqttServer_ClientConnectedAsync;
		MqttService._mqttServer.ClientDisconnectedAsync += _mqttServer_ClientDisconnectedAsync;
		MqttService._mqttServer.ApplicationMessageNotConsumedAsync += _mqttServer_ApplicationMessageNotConsumedAsync;
		MqttService._mqttServer.ClientSubscribedTopicAsync += _mqttServer_ClientSubscribedTopicAsync;
		MqttService._mqttServer.ClientUnsubscribedTopicAsync += _mqttServer_ClientUnsubscribedTopicAsync;
		MqttService._mqttServer.StartedAsync += _mqttServer_StartedAsync;
		MqttService._mqttServer.StoppedAsync += _mqttServer_StoppedAsync;
		MqttService._mqttServer.InterceptingPublishAsync += _mqttServer_InterceptingPublishAsync;
		MqttService._mqttServer.ValidatingConnectionAsync += _mqttServer_ValidatingConnectionAsync;
		MqttService._mqttServer.StartAsync();
	}

	public static void Init()
	{
		StartAsync();
	}

	public static void Close()
	{
		if (MqttService._mqttServer != null)
		{
			MqttService._mqttServer.Dispose();
		}
	}

	private static Task _mqttServer_ClientSubscribedTopicAsync(ClientSubscribedTopicEventArgs arg)
	{
		Console.WriteLine($"ClientSubscribedTopicAsync：客户端ID=【{arg.ClientId}】订阅的主题=【{arg.TopicFilter}】 ");
		LogSave.MQTTLog(DateTime.Now.ToString() + "客户端ID" + arg.ClientId + "订阅的主题" + arg.TopicFilter);
		return Task.FromResult("");
	}

	private static Task _mqttServer_StoppedAsync(EventArgs arg)
	{
		Console.WriteLine("StoppedAsync：MQTT服务已关闭……");
		return Task.FromResult("");
	}

	private static Task _mqttServer_ValidatingConnectionAsync(ValidatingConnectionEventArgs arg)
	{
		arg.ReasonCode = MqttConnectReasonCode.Success;
		if ((arg.Username ?? string.Empty) != "admin" || (arg.Password ?? string.Empty) != "123456")
		{
			arg.ReasonCode = MqttConnectReasonCode.Banned;
			Console.WriteLine("ValidatingConnectionAsync：客户端ID=【" + arg.ClientId + "】用户名或密码验证错误 ");
		}
		return Task.FromResult("");
	}

	private static Task _mqttServer_InterceptingPublishAsync(InterceptingPublishEventArgs arg)
	{
		if (arg.ApplicationMessage.Payload != null)
		{
			string text = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);
			LogSave.MQTTLog(DateTime.Now.ToString() + "客户端ID=" + arg.ClientId + "Mqtt服务端接收事件消息" + text);
		}
		Console.WriteLine($"InterceptingPublishAsync：客户端ID=【{arg.ClientId}】 Topic主题=【{arg.ApplicationMessage.Topic}】 消息=【{Encoding.UTF8.GetString(arg.ApplicationMessage.Payload)}】 qos等级=【{arg.ApplicationMessage.QualityOfServiceLevel}】");
		return Task.FromResult("");
	}

	private static Task _mqttServer_StartedAsync(EventArgs arg)
	{
		Console.WriteLine("StartedAsync：MQTT服务已启动……");
		return Task.FromResult("");
	}

	private static Task _mqttServer_ClientUnsubscribedTopicAsync(ClientUnsubscribedTopicEventArgs arg)
	{
		Console.WriteLine("ClientUnsubscribedTopicAsync：客户端ID=【" + arg.ClientId + "】已取消订阅的主题=【" + arg.TopicFilter + "】  ");
		return Task.FromResult("");
	}

	private static Task _mqttServer_ApplicationMessageNotConsumedAsync(ApplicationMessageNotConsumedEventArgs arg)
	{
		_ = arg.ApplicationMessage.Payload;
		Console.WriteLine($"ApplicationMessageNotConsumedAsync：发送端ID=【{arg.SenderId}】 Topic主题=【{arg.ApplicationMessage.Topic}】 消息=【{Encoding.UTF8.GetString(arg.ApplicationMessage.Payload)}】 qos等级=【{arg.ApplicationMessage.QualityOfServiceLevel}】");
		return Task.FromResult("");
	}

	private static Task _mqttServer_ClientDisconnectedAsync(ClientDisconnectedEventArgs arg)
	{
		MqttClientInfo mqttClientInfo = mqttClientInfos.FirstOrDefault((MqttClientInfo t) => t.ClientId == arg.ClientId);
		if (mqttClientInfo != null)
		{
			LogSave.MQTTLog(DateTime.Now.ToString() + "客户端断开ID" + arg.ClientId);
			mqttClientInfos.Remove(mqttClientInfo);
		}
		return Task.FromResult("");
	}

	private static Task _mqttServer_ClientConnectedAsync(ClientConnectedEventArgs arg)
	{
		MqttClientInfo mqttClientInfo = new MqttClientInfo();
		mqttClientInfo.ClientId = arg.ClientId;
		mqttClientInfo.ClientIP = arg.Endpoint;
		mqttClientInfos.Add(mqttClientInfo);
		Console.WriteLine("ClientConnectedAsync：客户端ID=【" + arg.ClientId + "】已连接, 用户名=【" + arg.UserName + "】地址=【" + arg.Endpoint + "】  ");
		LogSave.MQTTLog(DateTime.Now.ToString() + "客户端连接ID" + arg.ClientId);
		return Task.FromResult("");
	}
}
