using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			string value = item.customText.Replace("{车牌号}", vehicleNoInfo.VehicleNo).Replace("{排放阶段}", vehicleNoInfo.emissionStandard).Replace("{燃油类型}", vehicleNoInfo.fuelType)
				.Replace("{通行状态}", vehicleNoInfo.TrafficStatus)
				.Replace("{验证提示}", vehicleNoInfo.ExeLog);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(value);
			if (LedAgent.ShowInstantText(zHModle.m_iCurrentDeviceId, 1u, ConvertToColor(item.fontColor), stringBuilder, uint.Parse(item.charId)) == 0)
			{
			}
		}
	}

	public static void SendMsg(int id, string customText, string charId)
	{
		if (listZH.Count <= 0)
		{
			return;
		}
		ZHModle zHModle = listZH.FirstOrDefault((ZHModle it) => it.tb_Led.id == id);
		if (zHModle != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(customText);
			if (LedAgent.ShowInstantText(zHModle.m_iCurrentDeviceId, 1u, 1u, stringBuilder, uint.Parse(charId)) == 0)
			{
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
