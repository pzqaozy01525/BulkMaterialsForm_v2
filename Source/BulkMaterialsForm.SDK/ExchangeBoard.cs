// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.ExchangeBoard

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;

namespace BulkMaterialsForm.SDK;

public class ExchangeBoard
{
	public static int m_lUserID;

	public static CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;

	private static uint dwAChanTotalNum = 0u;

	private static uint dwDChanTotalNum = 0u;

	private static int[] iChannelNum = new int[96];

	private static CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;

	public static CHCNetSDK.NET_DVR_GET_STREAM_UNION m_unionGetStream;

	public static CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;

	private static List<int> ListChannel = new List<int>();

	private static List<int> m_lDownHandles = new List<int>();

	public static int Init()
	{
		string jhjIp = MainData.jhjIp;
		short wDVRPort = short.Parse("8000");
		string jhjzh = MainData.jhjzh;
		string jhjmm = MainData.jhjmm;
		DeviceInfo = default(CHCNetSDK.NET_DVR_DEVICEINFO_V30);
		m_lUserID = CHCNetSDK.NET_DVR_Login_V30(jhjIp, wDVRPort, jhjzh, jhjmm, ref DeviceInfo);
		if (m_lUserID < 0)
		{
			return m_lUserID;
		}
		dwAChanTotalNum = DeviceInfo.byChanNum;
		dwDChanTotalNum = (uint)(DeviceInfo.byIPChanNum + 256 * DeviceInfo.byHighDChanNum);
		if (dwDChanTotalNum != 0)
		{
			InfoIPChannel();
		}
		return m_lUserID;
	}

	public static void InfoIPChannel()
	{
		uint num = (uint)Marshal.SizeOf(m_struIpParaCfgV40);
		IntPtr intPtr = Marshal.AllocHGlobal((int)num);
		Marshal.StructureToPtr(m_struIpParaCfgV40, intPtr, fDeleteOld: false);
		uint lpBytesReturned = 0u;
		int lChannel = 0;
		if (CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, 1062u, lChannel, intPtr, num, ref lpBytesReturned))
		{
			m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(intPtr, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));
			for (int i = 0; i < dwAChanTotalNum; i++)
			{
				iChannelNum[i] = i + DeviceInfo.byStartChan;
			}
			uint num2 = 64u;
			if (dwDChanTotalNum < 64)
			{
				num2 = dwDChanTotalNum;
			}
			for (int j = 0; j < num2; j++)
			{
				iChannelNum[j + dwAChanTotalNum] = j + (int)m_struIpParaCfgV40.dwStartDChan;
				byte byGetStreamType = m_struIpParaCfgV40.struStreamMode[j].byGetStreamType;
				m_unionGetStream = m_struIpParaCfgV40.struStreamMode[j].uGetStream;
				if (byGetStreamType == 0)
				{
					num = (uint)Marshal.SizeOf(m_unionGetStream);
					IntPtr intPtr2 = Marshal.AllocHGlobal((int)num);
					Marshal.StructureToPtr(m_unionGetStream, intPtr2, fDeleteOld: false);
					m_struChanInfo = (CHCNetSDK.NET_DVR_IPCHANINFO)Marshal.PtrToStructure(intPtr2, typeof(CHCNetSDK.NET_DVR_IPCHANINFO));
					ListChannel.Add(j + 1);
					Marshal.FreeHGlobal(intPtr2);
				}
			}
		}
		Marshal.FreeHGlobal(intPtr);
		Task.Factory.StartNew(delegate
		{
			timerProgress();
		});
	}

	public static void Download(DateTime start, DateTime end, int index, int Id)
	{
		index--;
		CHCNetSDK.NET_DVR_PLAYCOND pDownloadCond = new CHCNetSDK.NET_DVR_PLAYCOND
		{
			dwChannel = (uint)iChannelNum[index],
			struStartTime = 
			{
				dwYear = (uint)start.Year,
				dwMonth = (uint)start.Month,
				dwDay = (uint)start.Day,
				dwHour = (uint)start.Hour,
				dwMinute = (uint)start.Minute,
				dwSecond = (uint)start.Second
			},
			struStopTime = 
			{
				dwYear = (uint)end.Year,
				dwMonth = (uint)end.Month,
				dwDay = (uint)end.Day,
				dwHour = (uint)end.Hour,
				dwMinute = (uint)end.Minute,
				dwSecond = (uint)end.Second
			}
		};
		string text = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
		string sVideoFileName = MainData.strImageDir + "\\" + text + ".mp4";
		int num = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref pDownloadCond);
		if (num < 0)
		{
			return;
		}
		uint LPOutValue = 0u;
		if (CHCNetSDK.NET_DVR_PlayBackControl_V40(num, 1u, IntPtr.Zero, 0u, IntPtr.Zero, ref LPOutValue))
		{
			new DataServerContext<tb_exceptional>().Current.Modify((tb_exceptional p) => new tb_exceptional
			{
				SnapVideoPath = sVideoFileName
			}, (tb_exceptional p) => p.id == Id);
			m_lDownHandles.Add(index);
		}
	}

	public static void timerProgress()
	{
		while (true)
		{
			try
			{
				if (m_lDownHandles == null || m_lDownHandles.Count <= 0)
				{
					continue;
				}
				for (int i = 0; i < m_lDownHandles.Count; i++)
				{
					switch (CHCNetSDK.NET_DVR_GetDownloadPos(m_lDownHandles[i]))
					{
					case 100:
						CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandles[i]);
						m_lDownHandles.Remove(i);
						i--;
						break;
					case 200:
						m_lDownHandles.Remove(i);
						i--;
						break;
					}
				}
				Thread.Sleep(3000);
			}
			catch (Exception)
			{
			}
		}
	}

	public static void Close()
	{
		CHCNetSDK.NET_DVR_Logout(m_lUserID);
	}

	public static bool CeShi(string ip, string jhjzh, string jhjmm)
	{
		short wDVRPort = short.Parse("8000");
		CHCNetSDK.NET_DVR_DEVICEINFO_V30 lpDeviceInfo = default(CHCNetSDK.NET_DVR_DEVICEINFO_V30);
		if (CHCNetSDK.NET_DVR_Login_V30(ip, wDVRPort, jhjzh, jhjmm, ref lpDeviceInfo) < 0)
		{
			return false;
		}
		return true;
	}
}
