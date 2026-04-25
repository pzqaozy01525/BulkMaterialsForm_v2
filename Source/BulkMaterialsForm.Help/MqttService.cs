// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.MqttService

using System;
using System.Text;
using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace BulkMaterialsForm.Help;

public class MqttService
{
	public static MqttServer _mqttServer { get; set; }

	public static void PublishData(string data, string Topic)
	{
		MqttApplicationMessage applicationMessage = new MqttApplicationMessage
		{
			Topic = Topic,
			Payload = Encoding.ASCII.GetBytes(data),
			QualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce,
			Retain = false
		};
		LogSave.MQTTLog(DateTime.Now.ToString() + "服务端发送:" + data);
		_mqttServer.InjectApplicationMessage(new InjectedMqttApplicationMessage(applicationMessage)
		{
			SenderClientId = "SERVER"
		}).GetAwaiter().GetResult();
	}

	public static void Dis()
	{
		if (_mqttServer != null)
		{
			_mqttServer.Dispose();
		}
	}
}
