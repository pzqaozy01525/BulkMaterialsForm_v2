// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.MqttClientService

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using Newtonsoft.Json;

namespace BulkMaterialsForm.Help;

public class MqttClientService
{
	public delegate void SendMessage(string msg);

	public delegate void OpenMessage(string channelId);

	public static IMqttClient _mqttClient;

	public static System.Timers.Timer timer1;

	public static string topic = string.Empty;

	public static string id = string.Empty;

	public static bool isInit = false;

	private static object obj = new object();

	private static bool isEnd = false;

	public event SendMessage sendMessage;

	public static event OpenMessage openMessage;

	public static void MqttClientStart()
	{
		MqttClientOptions options = new MqttClientOptionsBuilder().WithTcpServer(MainData.bstIP, Convert.ToInt32(MainData.bstPort)).WithCredentials("admin", "bst").WithClientId(id)
			.WithCleanSession()
			.WithTls(new MqttClientOptionsBuilderTlsParameters
			{
				UseTls = false
			})
			.Build();
		_mqttClient = new MqttFactory().CreateMqttClient();
		_mqttClient.ConnectedAsync += _mqttClient_ConnectedAsync;
		_mqttClient.DisconnectedAsync += _mqttClient_DisconnectedAsync;
		_mqttClient.ApplicationMessageReceivedAsync += _mqttClient_ApplicationMessageReceivedAsync;
		_mqttClient.ConnectAsync(options);
		Subscribe();
		Thread.Sleep(1000);
		timer1.Start();
	}

	public static void Init()
	{
		try
		{
			timer1 = new System.Timers.Timer();
			timer1.Enabled = true;
			timer1.Interval = 10000.0;
			timer1.Elapsed += Timer1_Elapsed;
			MqttClientStart();
		}
		catch (Exception)
		{
		}
	}

	private static void Timer1_Elapsed(object sender, ElapsedEventArgs e)
	{
		try
		{
			lock (obj)
			{
				if (!_mqttClient.IsConnected)
				{
					if (!isEnd)
					{
						isEnd = true;
						_mqttClient.Dispose();
						Thread.Sleep(1000);
						MqttClientStart();
						isEnd = false;
					}
				}
				else
				{
					Publish(JsonConvert.SerializeObject(new Dictionary<string, object> { { "cmd", "heartbeat" } }), MainData.khdId + "/updata");
				}
			}
		}
		catch (Exception)
		{
			isEnd = false;
		}
	}

	public static void Subscribe()
	{
		_mqttClient.SubscribeAsync(topic, MqttQualityOfServiceLevel.AtLeastOnce);
	}

	public static void Dis()
	{
		if (_mqttClient != null)
		{
			_mqttClient.Dispose();
		}
	}

	private static Task _mqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
	{
		timer1.Stop();
		Thread.Sleep(1000);
		Dis();
		Thread.Sleep(5000);
		MqttClientStart();
		return Task.CompletedTask;
	}

	private static Task _mqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
	{
		_mqttClient.SubscribeAsync(topic);
		return Task.CompletedTask;
	}

	private static Task _mqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
	{
		if (arg.ApplicationMessage.Payload != null)
		{
			try
			{
				string text = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);
				LogSave.MQTTLog(DateTime.Now.ToString() + "发送人" + arg.ClientId + "Mqtt客户端接收事件消息" + text);
				Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(text);
				if (data != null)
				{
					if (!data.ContainsKey("cmd"))
					{
						Convert.ToBoolean(data["isOpen"]);
						tb_vehicleInfo New_VehicleInfo = JsonConvert.DeserializeObject<tb_vehicleInfo>(data["data"].ToString());
						DataServerContext<tb_vehicleInfo> dataServerContext = new DataServerContext<tb_vehicleInfo>();
						tb_vehicleInfo tb_VehicleInfo = dataServerContext.Current.GetModel((tb_vehicleInfo it) => it.vehicleNo == New_VehicleInfo.vehicleNo);
						if (tb_VehicleInfo != null)
						{
							if (dataServerContext.Current.Modify((tb_vehicleInfo p) => new tb_vehicleInfo
							{
								vehicleNo = New_VehicleInfo.vehicleNo,
								licenseColor = New_VehicleInfo.licenseColor,
								vehicleType = New_VehicleInfo.vehicleType,
								vin = New_VehicleInfo.vin,
								useCharacter = New_VehicleInfo.useCharacter,
								engineNo = New_VehicleInfo.engineNo,
								onwer = New_VehicleInfo.onwer,
								address = New_VehicleInfo.address,
								model = New_VehicleInfo.model,
								registerDate = New_VehicleInfo.registerDate,
								issueDate = New_VehicleInfo.issueDate,
								emissionStandard = New_VehicleInfo.emissionStandard,
								drivingLicenseImg = New_VehicleInfo.drivingLicenseImg,
								fueltype = New_VehicleInfo.fueltype,
								enterpriseId = tb_VehicleInfo.enterpriseId
							}, (tb_vehicleInfo p) => tb_VehicleInfo.id == p.id))
							{
							}
						}
						else
						{
							dataServerContext.Current.Add(New_VehicleInfo);
						}
						return Task.CompletedTask;
					}
					if (data["cmd"].ToString().Equals("更新货物信息"))
					{
						if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
						{
							cargoName = data["cargoName"].ToString(),
							cargoWeight = data["cargoWeight"].ToString()
						}, (tb_CarRecord p) => p.serialNum == data["lsh"].ToString()) && Convert.ToBoolean(data["isOpen"]) && MqttClientService.openMessage != null)
						{
							MqttClientService.openMessage(data["channelId"].ToString());
						}
					}
					else if (data["cmd"].ToString().Equals("同步车辆信息"))
					{
						Convert.ToBoolean(data["isOpen"]);
						tb_vehicleInfo New_VehicleInfo2 = JsonConvert.DeserializeObject<tb_vehicleInfo>(data["data"].ToString());
						DataServerContext<tb_vehicleInfo> dataServerContext2 = new DataServerContext<tb_vehicleInfo>();
						tb_vehicleInfo tb_VehicleInfo2 = dataServerContext2.Current.GetModel((tb_vehicleInfo it) => it.vehicleNo == New_VehicleInfo2.vehicleNo);
						if (tb_VehicleInfo2 != null)
						{
							if (dataServerContext2.Current.Modify((tb_vehicleInfo p) => new tb_vehicleInfo
							{
								vehicleNo = New_VehicleInfo2.vehicleNo,
								licenseColor = New_VehicleInfo2.licenseColor,
								vehicleType = New_VehicleInfo2.vehicleType,
								vin = New_VehicleInfo2.vin,
								useCharacter = New_VehicleInfo2.useCharacter,
								engineNo = New_VehicleInfo2.engineNo,
								onwer = New_VehicleInfo2.onwer,
								address = New_VehicleInfo2.address,
								model = New_VehicleInfo2.model,
								registerDate = New_VehicleInfo2.registerDate,
								issueDate = New_VehicleInfo2.issueDate,
								emissionStandard = New_VehicleInfo2.emissionStandard,
								drivingLicenseImg = New_VehicleInfo2.drivingLicenseImg,
								fueltype = New_VehicleInfo2.fueltype,
								enterpriseId = tb_VehicleInfo2.enterpriseId
							}, (tb_vehicleInfo p) => tb_VehicleInfo2.id == p.id))
							{
							}
						}
						else
						{
							dataServerContext2.Current.Add(New_VehicleInfo2);
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogSave.SaveExeLog(DateTime.Now.ToString() + "_mqttClient_ApplicationMessageReceivedAsync异常" + ex.ToString());
			}
		}
		return Task.CompletedTask;
	}

	public static void Publish(string data, string Topic)
	{
		MqttApplicationMessage applicationMessage = new MqttApplicationMessage
		{
			Topic = Topic,
			Payload = Encoding.UTF8.GetBytes(data),
			QualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce,
			Retain = true
		};
		_mqttClient.PublishAsync(applicationMessage);
	}
}
