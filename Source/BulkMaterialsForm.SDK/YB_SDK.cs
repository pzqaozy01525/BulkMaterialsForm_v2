// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.YB_SDK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;
using Newtonsoft.Json;

namespace BulkMaterialsForm.SDK;

public class YB_SDK
{
	private static Timer timer1 = new Timer();

	public static List<timerModel> tb_Large_Screens = new List<timerModel>();

	public static void Init()
	{
		timer1.Interval = 1000;
		timer1.Tick += Timer1_Tick;
		timer1.Start();
	}

	public static uint LedConnect(string ip)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(ip);
		uint led_port = Convert.ToUInt32("5005");
		byte[] array = new byte[15];
		array[0] = 254;
		array[1] = 81;
		array[2] = 88;
		array[3] = 84;
		array[4] = 83;
		array[5] = 92;
		array[6] = 97;
		array[7] = 98;
		array[8] = 99;
		array[9] = 100;
		array[10] = 101;
		array[11] = 102;
		array[12] = 103;
		array[13] = 104;
		array[13] = 105;
		int num = 0;
		return Led5kSDK.CreateClient(bytes, led_port, (Led5kSDK.bx_5k_card_type)array[num], 1, 0, null);
	}

	public static void YBLedSendMes(tb_large_screen tb_Large_Screen, VehicleNoInfoView vehicleNoInfoView, bool isOpen)
	{
		try
		{
			int num = 0;
			timerModel timerModel2 = tb_Large_Screens.FirstOrDefault((timerModel it) => it.id == tb_Large_Screen.id);
			LogSave.YBLog("tb_Large_Screens:" + tb_Large_Screens);
			if (timerModel2 != null)
			{
				tb_Large_Screens.Remove(timerModel2);
			}
			uint num2 = LedConnect(tb_Large_Screen.IP);
			LogSave.YBLog("hand:" + num2);
			List<tb_large_screen_detaile> list = new DataServerContext<tb_large_screen_detaile>().Current.GetList((tb_large_screen_detaile it) => it.largeId == tb_Large_Screen.id);
			if (list != null && list.Count > 0)
			{
				int tlsj = 0;
				foreach (tb_large_screen_detaile item in list)
				{
					if (item.customText.Contains("{车牌号}") || item.customText.Contains("{排放阶段}") || item.customText.Contains("{燃油类型}") || item.customText.Contains("{预警等级}") || item.customText.Contains("{管控策略}") || item.customText.Contains("{响应等级}") || item.customText.Contains("{通行状态}") || item.customText.Contains("{验证提示}") || item.customText.Contains("{企业名称}") || item.customText.Contains("{管控开始时间}") || item.customText.Contains("{管控结束时间}") || item.customText.Contains("{管控更新时间}"))
					{
						Led5kSDK.bx_5k_area_header bx_5k_area_header = default(Led5kSDK.bx_5k_area_header);
						tlsj = item.tlsj;
						bx_5k_area_header.AreaType = 0;
						bx_5k_area_header.DynamicAreaLoc = (byte)num;
						bx_5k_area_header.AreaX = (ushort)(Convert.ToUInt16(item.x) / 8);
						bx_5k_area_header.AreaWidth = (ushort)(Convert.ToUInt16(item.Width) / 8);
						bx_5k_area_header.AreaY = Convert.ToUInt16(item.y);
						bx_5k_area_header.AreaHeight = Convert.ToUInt16(item.Height);
						bx_5k_area_header.Lines_sizes = Convert.ToByte(0);
						bx_5k_area_header.RunMode = 0;
						bx_5k_area_header.Timeout = Convert.ToInt16(item.tlsj);
						bx_5k_area_header.StayTime = Convert.ToByte(item.tlsj);
						bx_5k_area_header.Reserved1 = 0;
						bx_5k_area_header.Reserved2 = 0;
						bx_5k_area_header.Reserved3 = 10;
						bx_5k_area_header.SingleLine = 1;
						bx_5k_area_header.NewLine = 1;
						if (item.xstx.Equals("静止显示"))
						{
							bx_5k_area_header.DisplayMode = 1;
						}
						else if (item.xstx.Equals("快速打出"))
						{
							bx_5k_area_header.DisplayMode = 2;
						}
						else if (item.xstx.Equals("向左移动"))
						{
							bx_5k_area_header.DisplayMode = 3;
							bx_5k_area_header.Reserved3 = 0;
						}
						else if (item.xstx.Equals("向右移动"))
						{
							bx_5k_area_header.DisplayMode = 4;
							bx_5k_area_header.Reserved3 = 0;
						}
						else if (item.xstx.Equals("向上移动"))
						{
							bx_5k_area_header.DisplayMode = 5;
							bx_5k_area_header.Reserved3 = 0;
						}
						else if (item.xstx.Equals("向下移动"))
						{
							bx_5k_area_header.DisplayMode = 6;
							bx_5k_area_header.Reserved3 = 0;
						}
						else
						{
							bx_5k_area_header.DisplayMode = 1;
						}
						bx_5k_area_header.ExitMode = 0;
						bx_5k_area_header.Speed = (byte)item.yxsd;
						string safeCompanyName = string.IsNullOrWhiteSpace(MainData.GLcompanyName) ? "暂无" : MainData.GLcompanyName;
						string safeControlRunTime = string.IsNullOrWhiteSpace(MainData.GLcontrolRunTime) ? "暂无" : MainData.GLcontrolRunTime;
						string safeControlEndTime = string.IsNullOrWhiteSpace(MainData.GLcontrolEndTime) ? "暂无" : MainData.GLcontrolEndTime;
						string safeControlLevel = string.IsNullOrWhiteSpace(MainData.GLcontrolLevel) ? "暂无" : MainData.GLcontrolLevel;
						string safeControlStrategy = string.IsNullOrWhiteSpace(MainData.GLcontrolStrategy) ? "暂无管控" : MainData.GLcontrolStrategy;
						string safeResponseLevel = string.IsNullOrWhiteSpace(MainData.GLresponseLevel) ? "暂无" : MainData.GLresponseLevel;
						string safeUpdateTime = string.IsNullOrWhiteSpace(MainData.GLcontrolUpdateTime) ? "暂无" : MainData.GLcontrolUpdateTime;
						string text = item.customText.Replace("{车牌号}", vehicleNoInfoView.VehicleNo).Replace("{排放阶段}", vehicleNoInfoView.emissionStandard).Replace("{燃油类型}", vehicleNoInfoView.fuelType)
							.Replace("{预警等级}", safeControlLevel)
							.Replace("{管控策略}", safeControlStrategy)
							.Replace("{响应等级}", safeResponseLevel)
							.Replace("{当前时间}", "\\DY年\\DL月\\DD日\\DH时\\DM分\\DS秒")
							.Replace("{通行状态}", vehicleNoInfoView.TrafficStatus)
							.Replace("{验证提示}", vehicleNoInfoView.ExeLog)
							.Replace("{企业名称}", safeCompanyName)
							.Replace("{管控开始时间}", safeControlRunTime)
							.Replace("{管控结束时间}", safeControlEndTime)
							.Replace("{管控更新时间}", safeUpdateTime);
						if (item.fontColor == "红色")
						{
							text = "\\C1" + text;
						}
						else if (item.fontColor == "绿色")
						{
							text = "\\C2" + text;
						}
						else if (item.fontColor == "黄色")
						{
							text = "\\C3" + text;
						}
						byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(text.Trim());
						bx_5k_area_header.DataLen = bytes.Length;
						LogSave.YBLog("SCREEN_SendDynamicArea:" + Led5kSDK.SCREEN_SendDynamicArea(num2, bx_5k_area_header, (ushort)bx_5k_area_header.DataLen, bytes));
						LogSave.YBLog("customText:" + text);
						LogSave.YBLog("SCREEN_SendDynamicArea:" + JsonConvert.SerializeObject(bx_5k_area_header));
						num++;
					}
				}
				timerModel2 = new timerModel();
				timerModel2.id = tb_Large_Screen.id;
				timerModel2.addTime = DateTime.Now;
				timerModel2.tlsj = tlsj;
				timerModel2.IP = tb_Large_Screen.IP;
				tb_Large_Screens.Add(timerModel2);
			}
			LogSave.YBLog("SCREEN_SendIO:" + Led5kSDK.SCREEN_SendIO(header: new Led5kSDK.bx_k_IO
			{
				EXTEN = 2
			}, dwHand: num2));
			if (isOpen)
			{
				Led5kSDK.SCREEN_Send_one_IO(num2, 0, 1);
			}
			if (num2 >= 0)
			{
				Led5kSDK.Destroy(num2);
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("大屏流程异常" + ex.ToString());
		}
	}

	public static void YBLedGDSendMes(tb_large_screen tb_Large_Screen, VehicleNoInfoView vehicleNoInfoView, bool isOpen)
	{
		int num = 0;
		timerModel timerModel2 = tb_Large_Screens.FirstOrDefault((timerModel it) => it.id == tb_Large_Screen.id);
		if (timerModel2 != null)
		{
			tb_Large_Screens.Remove(timerModel2);
		}
		uint num2 = LedConnect(tb_Large_Screen.IP);
		LogSave.YBLog("OFS_DeleteFile:" + Led5kSDK.OFS_DeleteFile(num2, 0, null));
		Led5kProgram led5kProgram = new Led5kProgram();
		List<tb_large_screen_detaile> list = new DataServerContext<tb_large_screen_detaile>().Current.GetList((tb_large_screen_detaile it) => it.largeId == tb_Large_Screen.id);
		if (list != null && list.Count > 0)
		{
			int tlsj = 0;
			foreach (tb_large_screen_detaile item in list)
			{
				if (!item.customText.Contains("{车牌号}") && !item.customText.Contains("{排放阶段}") && !item.customText.Contains("{燃油类型}") && !item.customText.Contains("{预警等级}") && !item.customText.Contains("{管控策略}") && !item.customText.Contains("{响应等级}") && !item.customText.Contains("{通行状态}") && !item.customText.Contains("{验证提示}") && !item.customText.Contains("{企业名称}") && !item.customText.Contains("{管控开始时间}") && !item.customText.Contains("{管控结束时间}") && !item.customText.Contains("{管控更新时间}"))
				{
					Led5kSDK.bx_5k_area_header header = default(Led5kSDK.bx_5k_area_header);
					tlsj = item.tlsj;
					header.AreaType = 0;
					header.DynamicAreaLoc = (byte)num;
					header.AreaX = (ushort)(Convert.ToUInt16(item.x) / 8);
					header.AreaWidth = (ushort)(Convert.ToUInt16(item.Width) / 8);
					header.AreaY = Convert.ToUInt16(item.y);
					header.AreaHeight = Convert.ToUInt16(item.Height);
					header.Lines_sizes = Convert.ToByte(0);
					header.RunMode = 0;
					header.Timeout = Convert.ToInt16(item.tlsj);
					header.StayTime = Convert.ToByte(item.tlsj);
					header.Reserved1 = 0;
					header.Reserved2 = 0;
					header.Reserved3 = 10;
					header.SingleLine = 1;
					header.NewLine = 1;
					if (item.xstx.Equals("静止显示"))
					{
						header.DisplayMode = 1;
					}
					else if (item.xstx.Equals("快速打出"))
					{
						header.DisplayMode = 2;
					}
					else if (item.xstx.Equals("向左移动"))
					{
						header.DisplayMode = 3;
						header.Reserved3 = 0;
					}
					else if (item.xstx.Equals("向右移动"))
					{
						header.DisplayMode = 4;
						header.Reserved3 = 0;
					}
					else if (item.xstx.Equals("向上移动"))
					{
						header.DisplayMode = 5;
						header.Reserved3 = 0;
					}
					else if (item.xstx.Equals("向下移动"))
					{
						header.DisplayMode = 6;
						header.Reserved3 = 0;
					}
					else
					{
						header.DisplayMode = 1;
					}
					header.ExitMode = 0;
					header.Speed = (byte)item.yxsd;
					string safeCompanyName = string.IsNullOrWhiteSpace(MainData.GLcompanyName) ? "暂无" : MainData.GLcompanyName;
					string safeControlRunTime = string.IsNullOrWhiteSpace(MainData.GLcontrolRunTime) ? "暂无" : MainData.GLcontrolRunTime;
					string safeControlEndTime = string.IsNullOrWhiteSpace(MainData.GLcontrolEndTime) ? "暂无" : MainData.GLcontrolEndTime;
					string safeControlLevel = string.IsNullOrWhiteSpace(MainData.GLcontrolLevel) ? "暂无" : MainData.GLcontrolLevel;
					string safeControlStrategy = string.IsNullOrWhiteSpace(MainData.GLcontrolStrategy) ? "暂无管控" : MainData.GLcontrolStrategy;
					string safeResponseLevel = string.IsNullOrWhiteSpace(MainData.GLresponseLevel) ? "暂无" : MainData.GLresponseLevel;
					string safeUpdateTime = string.IsNullOrWhiteSpace(MainData.GLcontrolUpdateTime) ? "暂无" : MainData.GLcontrolUpdateTime;
					string text2 = item.customText.Replace("{车牌号}", vehicleNoInfoView.VehicleNo).Replace("{排放阶段}", vehicleNoInfoView.emissionStandard).Replace("{燃油类型}", vehicleNoInfoView.fuelType)
						.Replace("{预警等级}", safeControlLevel)
						.Replace("{管控策略}", safeControlStrategy)
						.Replace("{响应等级}", safeResponseLevel)
						.Replace("{通行状态}", vehicleNoInfoView.TrafficStatus)
						.Replace("{验证提示}", vehicleNoInfoView.ExeLog)
						.Replace("{企业名称}", safeCompanyName)
						.Replace("{管控开始时间}", safeControlRunTime)
						.Replace("{管控结束时间}", safeControlEndTime)
						.Replace("{管控更新时间}", safeUpdateTime);
					if (item.fontColor == "红色")
					{
						text2 = "\\C1" + text2;
					}
					else if (item.fontColor == "绿色")
					{
						text2 = "\\C2" + text2;
					}
					else if (item.fontColor == "黄色")
					{
						text2 = "\\C3" + text2;
					}
					Encoding.Default.GetBytes(text2.Trim());
					header.DataLen = text2.Length;
					Led5kstaticArea led5kstaticArea = new Led5kstaticArea();
					led5kstaticArea.header = header;
					led5kstaticArea.text = text2;
					led5kProgram.m_arealist.Add(led5kstaticArea);
					num++;
				}
			}
			timerModel2 = new timerModel();
			timerModel2.id = tb_Large_Screen.id;
			timerModel2.addTime = DateTime.Now;
			timerModel2.tlsj = tlsj;
			timerModel2.IP = tb_Large_Screen.IP;
			tb_Large_Screens.Add(timerModel2);
		}
		led5kProgram.AreaNum = Convert.ToByte(led5kProgram.m_arealist.Count);
		led5kProgram.overwrite = true;
		led5kProgram.name = "P001";
		led5kProgram.ProgramWeek = 1;
		led5kProgram.IsPlayOnTime = false;
		led5kProgram.IsValidAlways = true;
		led5kProgram.DisplayType = 0;
		led5kProgram.PlayTimes = 1;
		LogSave.YBLog("SendProgram:" + led5kProgram.SendProgram(num2));
		if (num2 >= 0)
		{
			Led5kSDK.Destroy(num2);
		}
	}

	private static void Timer1_Tick(object sender, EventArgs e)
	{
		if (tb_Large_Screens.Count <= 0)
		{
			return;
		}
		List<timerModel> list = new List<timerModel>();
		foreach (timerModel item in tb_Large_Screens)
		{
			if (!(item.addTime.AddSeconds(item.tlsj) <= DateTime.Now))
			{
				continue;
			}
			uint num = LedConnect(item.IP);
			List<tb_large_screen_detaile> list2 = new DataServerContext<tb_large_screen_detaile>().Current.GetList((tb_large_screen_detaile it) => it.largeId == item.id);
			if (list2 != null && list2.Count > 0)
			{
				int num2 = 0;
				foreach (tb_large_screen_detaile item2 in list2)
				{
					_ = item2;
					Led5kSDK.SCREEN_DelDynamicArea(num, Convert.ToByte(num2));
					num2++;
				}
			}
			Led5kSDK.SCREEN_Send_one_IO(num, 0, 0);
			if (num >= 0)
			{
				Led5kSDK.Destroy(num);
			}
			list.Add(item);
		}
		foreach (timerModel item3 in list)
		{
			tb_Large_Screens.Remove(item3);
		}
	}
}
