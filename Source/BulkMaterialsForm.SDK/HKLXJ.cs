// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.HKLXJ

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.SDK.DH;

namespace BulkMaterialsForm.SDK;

public class HKLXJ
{
	public int m_lUserID;

	public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;

	private uint dwAChanTotalNum;

	private uint dwDChanTotalNum;

	private int[] iChannelNum = new int[96];

	private CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;

	public CHCNetSDK.NET_DVR_GET_STREAM_UNION m_unionGetStream;

	public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;

	public List<int> ListChannel = new List<int>();

	private static Thread videoNetThread;

	public int m_lDownHandle = -1;

	private object userLock = new object();

	public List<DownloadMode> downloadModes = new List<DownloadMode>();

	public int HKLXJLogin(string IP, string doccode, string pass)
	{
		MainData.init_Sdk_HaiKang();
		CHCNetSDK.NET_DVR_DEVICEINFO_V30 lpDeviceInfo = default(CHCNetSDK.NET_DVR_DEVICEINFO_V30);
		m_lUserID = CHCNetSDK.NET_DVR_Login_V30(IP, 8000, doccode, pass, ref lpDeviceInfo);
		LogSave.HKLog($"海康录像机登录: IP={IP}, User={doccode}, Handle={m_lUserID}");
		if (m_lUserID < 0)
		{
			return -1;
		}
		dwAChanTotalNum = lpDeviceInfo.byChanNum;
		dwDChanTotalNum = (uint)(lpDeviceInfo.byIPChanNum + 256 * lpDeviceInfo.byHighDChanNum);
		if (dwDChanTotalNum != 0)
		{
			InfoIPChannel();
		}
		return m_lUserID;
	}

	public void InfoIPChannel()
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
	}

	public int Download(DateTime start, DateTime end, int index, int Id, string sVideoFileName)
	{
		try
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
			m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref pDownloadCond);
			LogSave.HKLog(DateTime.Now.ToString() + "NET_DVR_GetFileByTime_V40==" + m_lDownHandle + "m_lUserID=" + m_lUserID + "iChannelNum=" + pDownloadCond.dwChannel);
			if (m_lDownHandle < 0)
			{
				uint num = CHCNetSDK.NET_DVR_GetLastError();
				LogSave.HKLog(DateTime.Now.ToString() + "NET_DVR_GetFileByTime_V40下载失败" + num);
				return m_lDownHandle;
			}
			uint LPOutValue = 0u;
			if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, 1u, IntPtr.Zero, 0u, IntPtr.Zero, ref LPOutValue))
			{
				uint num2 = CHCNetSDK.NET_DVR_GetLastError();
				LogSave.HKLog(DateTime.Now.ToString() + "NET_DVR_PlayBackControl_V40下载失败" + num2);
				return m_lDownHandle;
			}
			new DataServerContext<tb_exceptional>().Current.Modify((tb_exceptional p) => new tb_exceptional
			{
				SnapVideoPath = sVideoFileName
			}, (tb_exceptional p) => p.id == Id);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "海康下载视频异常" + ex.ToString());
			LogSave.SaveExeLog(DateTime.Now.ToString() + "海康下载视频异常" + ex.Message);
		}
		finally
		{
			LogSave.HKLog(DateTime.Now.ToString() + "下载结束");
		}
		return m_lDownHandle;
	}

	public void Init()
	{
		StartThread();
	}

	public void StartThread()
	{
		videoNetThread = new Thread(doExecFlowTask);
		videoNetThread.IsBackground = true;
		videoNetThread.Start();
	}

	private void doExecFlowTask()
	{
		while (true)
		{
			try
			{
				lock (userLock)
				{
					if (downloadModes.Count > 0)
					{
						DownloadMode downloadMode = downloadModes[0];
						try
						{
							Task.Factory.StartNew(delegate
							{
								downloadMode.m_DownloadID = Download(downloadMode.start, downloadMode.end, downloadMode.index, downloadMode.Id, downloadMode.sVideoFileName);
								LogSave.HKLog(DateTime.Now.ToString() + "下载视频" + downloadMode.m_DownloadID);
								if (downloadMode.m_DownloadID == -1)
								{
									downloadMode.number++;
									if (downloadMode.number > 5)
									{
										downloadModes.Remove(downloadMode);
									}
								}
								else
								{
									while (!downloadMode.isload)
									{
										Thread.Sleep(3000);
										int num = CHCNetSDK.NET_DVR_GetDownloadPos(downloadMode.m_DownloadID);
										if (num == 100)
										{
											CHCNetSDK.NET_DVR_StopGetFile(downloadMode.m_DownloadID);
											downloadMode.isload = true;
											break;
										}
										if (num == 200)
										{
											downloadMode.isload = true;
											break;
										}
									}
									downloadModes.Remove(downloadMode);
								}
								Thread.Sleep(1000);
							}).Wait();
						}
						catch (Exception ex)
						{
							LogSave.HKLog(DateTime.Now.ToString() + "doExecFlowTask异常" + ex.ToString());
							CHCNetSDK.NET_DVR_StopGetFile(downloadMode.m_DownloadID);
						}
					}
					Thread.Sleep(1000);
				}
			}
			catch (Exception ex2)
			{
				LogSave.HKLog(DateTime.Now.ToString() + "doExecFlowTask异常" + ex2.ToString());
			}
		}
	}

	public void Add(DateTime start, DateTime end, int index, int Id, string sVideoFileName)
	{
		DownloadMode downloadMode = new DownloadMode();
		downloadMode.start = start;
		downloadMode.end = end;
		downloadMode.Id = Id;
		downloadMode.index = index;
		downloadMode.sVideoFileName = sVideoFileName;
		downloadModes.Add(downloadMode);
	}
}
