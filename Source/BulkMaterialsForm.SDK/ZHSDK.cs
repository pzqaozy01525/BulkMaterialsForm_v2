// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.ZHSDK

using System.Collections.Generic;
using System.Linq;
using System.Text;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;

namespace BulkMaterialsForm.SDK;

public class ZHSDK
{
	public static List<ZHModle> listZH = new List<ZHModle>();

	public static void SendZH(VehicleNoInfoView vehicleNoInfo)
	{
		if (listZH.Count <= 0)
		{
			return;
		}
		ZHModle zHModle = listZH.FirstOrDefault((ZHModle it) => it.tb_Led.id == vehicleNoInfo.largeId);
		if (zHModle == null)
		{
			return;
		}
		List<tb_large_screen_detaile> list = new DataServerContext<tb_large_screen_detaile>().Current.GetList((tb_large_screen_detaile it) => it.largeId == vehicleNoInfo.largeId);
		if (list == null || list.Count <= 0)
		{
			return;
		}
		foreach (tb_large_screen_detaile item in list)
		{
			string safeControlLevel = string.IsNullOrWhiteSpace(MainData.GLcontrolLevel) ? "暂无" : MainData.GLcontrolLevel;
			string safeControlStrategy = string.IsNullOrWhiteSpace(MainData.GLcontrolStrategy) ? "暂无管控" : MainData.GLcontrolStrategy;
			string safeResponseLevel = string.IsNullOrWhiteSpace(MainData.GLresponseLevel) ? "暂无" : MainData.GLresponseLevel;
			string safeCompanyName = string.IsNullOrWhiteSpace(MainData.GLcompanyName) ? "暂无" : MainData.GLcompanyName;
			string safeControlRunTime = string.IsNullOrWhiteSpace(MainData.GLcontrolRunTime) ? "暂无" : MainData.GLcontrolRunTime;
			string safeControlEndTime = string.IsNullOrWhiteSpace(MainData.GLcontrolEndTime) ? "暂无" : MainData.GLcontrolEndTime;
			string safeUpdateTime = string.IsNullOrWhiteSpace(MainData.GLcontrolUpdateTime) ? "暂无" : MainData.GLcontrolUpdateTime;
			string value = item.customText.Replace("{车牌号}", vehicleNoInfo.VehicleNo).Replace("{排放阶段}", vehicleNoInfo.emissionStandard).Replace("{燃油类型}", vehicleNoInfo.fuelType)
				.Replace("{通行状态}", vehicleNoInfo.TrafficStatus)
				.Replace("{验证提示}", vehicleNoInfo.ExeLog)
				.Replace("{预警等级}", safeControlLevel)
				.Replace("{管控策略}", safeControlStrategy)
				.Replace("{响应等级}", safeResponseLevel)
				.Replace("{企业名称}", safeCompanyName)
				.Replace("{管控开始时间}", safeControlRunTime)
				.Replace("{管控结束时间}", safeControlEndTime)
				.Replace("{管控更新时间}", safeUpdateTime);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(value);
			LedAgent.ShowInstantText(zHModle.m_iCurrentDeviceId, 1u, ConvertToColor(item.fontColor), stringBuilder, uint.Parse(item.charId));
		}
	}

	public static void SendMsg(int id, string customText, string charId)
	{
		if (listZH.Count > 0)
		{
			ZHModle zHModle = listZH.FirstOrDefault((ZHModle it) => it.tb_Led.id == id);
			if (zHModle != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(customText);
				LedAgent.ShowInstantText(zHModle.m_iCurrentDeviceId, 1u, 1u, stringBuilder, uint.Parse(charId));
			}
		}
	}

	private static uint ConvertToColor(string sText)
	{
		return sText switch
		{
			"红色" => 1u, 
			"绿色" => 2u, 
			"黄色" => 3u, 
			"蓝色" => 4u, 
			"紫色" => 5u, 
			"青色" => 6u, 
			"白色" => 7u, 
			_ => 1u, 
		};
	}
}
