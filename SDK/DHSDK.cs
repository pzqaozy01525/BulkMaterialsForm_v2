using System;
using System.Runtime.InteropServices;
using System.Threading;
using BulkMaterialsForm.DH;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;

namespace BulkMaterialsForm.SDK;

public class DHSDK
{
	private static fTimeDownLoadPosCallBack m_DownloadPosCallBack;

	public IntPtr LogPtr;

	public static void Init()
	{
		MainData.init_Sdk_DH();
		m_DownloadPosCallBack = DownLoadPosCallBack;
	}

	public static IntPtr Login(string jhjIp, string jhjzh, string jhjmm)
	{
		MainData.init_Sdk_DH();
		NET_DEVICEINFO_Ex deviceInfo = default(NET_DEVICEINFO_Ex);
		IntPtr intPtr = NETClient.LoginWithHighLevelSecurity(jhjIp, 37777, jhjzh, jhjmm, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);
		if (intPtr == IntPtr.Zero)
		{
			LogSave.DHLog(DateTime.Now.ToString() + "录像机初始化异常：" + NETClient.GetLastError());
			return IntPtr.Zero;
		}
		return intPtr;
	}

	public static IntPtr LXJLogin(string jhjIp, string jhjzh, string jhjmm)
	{
		try
		{
			MainData.init_Sdk_DH();
			NET_DEVICEINFO_Ex deviceInfo = default(NET_DEVICEINFO_Ex);
			IntPtr intPtr = NETClient.LoginWithHighLevelSecurity(jhjIp, 37777, jhjzh, jhjmm, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);
			if (intPtr == IntPtr.Zero)
			{
				LogSave.DHLog(DateTime.Now.ToString() + "录像机初始化异常：" + NETClient.GetLastError());
				return IntPtr.Zero;
			}
			return intPtr;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "录像机登录异常" + ex.ToString());
			return IntPtr.Zero;
		}
	}

	private static void DownLoadPosCallBack(IntPtr lPlayHandle, uint dwTotalSize, uint dwDownLoadSize, int index, NET_RECORDFILE_INFO recordfileinfo, IntPtr dwUser)
	{
		try
		{
			int num = 0;
			if (-1 == (int)dwDownLoadSize)
			{
				LogSave.SaveExeLog(DateTime.Now.ToString() + "下载结束" + lPlayHandle);
				NETClient.StopDownload(lPlayHandle);
			}
			else if (-2 != (int)dwDownLoadSize)
			{
				if (dwDownLoadSize >= dwTotalSize)
				{
					num = 100;
				}
				else
				{
					num = (int)(dwDownLoadSize * 100 / dwTotalSize);
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.DHLog(DateTime.Now.ToString() + "DownLoadPosCallBack异常" + ex.ToString());
		}
	}

	public IntPtr Download(DateTime start, DateTime end, int Id, int index, IntPtr _logHandle)
	{
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			index--;
			LogSave.DHLog(DateTime.Now.ToString() + "Id=" + Id + "index:" + index + "_logHandle:" + _logHandle + "开始时间" + start.ToString() + "结束时间" + end.ToString());
			EM_STREAM_TYPE structure = EM_STREAM_TYPE.MAIN;
			IntPtr intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
			Marshal.StructureToPtr((int)structure, intPtr2, fDeleteOld: true);
			if (!NETClient.SetDeviceMode(_logHandle, EM_USEDEV_MODE.RECORD_STREAM_TYPE, intPtr2))
			{
				string lastError = NETClient.GetLastError();
				NETClient.Logout(_logHandle);
				LogSave.DHLog(DateTime.Now.ToString() + "SetDeviceMode错误：" + lastError);
				if (!lastError.Equals("句柄无效"))
				{
				}
			}
			string text = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
			string sVideoFileName = MainData.strImageDir + "\\" + text + ".mp4";
			NET_IN_DOWNLOAD_BY_DATA_TYPE pstInParam = new NET_IN_DOWNLOAD_BY_DATA_TYPE
			{
				dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_OPEN_STROBE)),
				nChannelID = index,
				emRecordType = EM_QUERY_RECORD_TYPE.ALL,
				szSavedFileName = Marshal.StringToHGlobalAnsi(sVideoFileName),
				stStartTime = NET_TIME.FromDateTime(start),
				stStopTime = NET_TIME.FromDateTime(end),
				cbDownLoadPos = m_DownloadPosCallBack,
				dwPosUser = IntPtr.Zero,
				fDownLoadDataCallBack = null,
				emDataType = EM_REAL_DATA_TYPE.MP4,
				emAudioType = EM_AUDIO_DATA_TYPE.EM_AUDIO_DATA_TYPE_G711A
			};
			NET_OUT_DOWNLOAD_BY_DATA_TYPE pstOutParam = new NET_OUT_DOWNLOAD_BY_DATA_TYPE
			{
				dwSize = 52428800u
			};
			intPtr = NETClient.DownloadByDataType(_logHandle, pstInParam, ref pstOutParam, 60000u);
			if (IntPtr.Zero != intPtr)
			{
				DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
				if (!dataServerContext.Current.Modify((tb_exceptional p) => new tb_exceptional
				{
					SnapVideoPath = sVideoFileName
				}, (tb_exceptional p) => p.id == Id))
				{
				}
			}
			else
			{
				string lastError2 = NETClient.GetLastError();
				NETClient.Logout(_logHandle);
				LogSave.DHLog(DateTime.Now.ToString() + "下载视频错误：" + lastError2);
				if (!lastError2.Equals("句柄无效"))
				{
				}
			}
		}
		catch (Exception ex)
		{
			NETClient.Logout(_logHandle);
			LogSave.DHLog(DateTime.Now.ToString() + "下载视频错误：" + ex.ToString());
		}
		finally
		{
		}
		LogSave.DHLog(DateTime.Now.ToString() + "结束m_DownloadID=" + intPtr);
		return intPtr;
	}

	public void Snap(int RecordId, IntPtr _logHandle, int snapNumber)
	{
		try
		{
			for (int i = 0; i < 3; i++)
			{
				string arg = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
				string strImageFile = $"{MainData.strImageDir}\\{arg}zp.jpg";
				NET_IN_SNAP_PIC_TO_FILE_PARAM inParam = default(NET_IN_SNAP_PIC_TO_FILE_PARAM);
				NET_SNAP_PARAMS stuParam = new NET_SNAP_PARAMS
				{
					Channel = 0u,
					Quality = 4u,
					ImageSize = 2u,
					mode = 1u
				};
				inParam.szFilePath = strImageFile;
				inParam.stuParam = stuParam;
				NET_OUT_SNAP_PIC_TO_FILE_PARAM outParam = default(NET_OUT_SNAP_PIC_TO_FILE_PARAM);
				outParam.dwPicBufRetLen = (outParam.dwPicBufLen = 5242880u);
				IntPtr szPicBuf = Marshal.AllocHGlobal(5242880);
				outParam.szPicBuf = szPicBuf;
				uint dwSize = Convert.ToUInt32(Marshal.SizeOf(outParam));
				outParam.dwSize = dwSize;
				dwSize = Convert.ToUInt32(Marshal.SizeOf(inParam));
				inParam.dwSize = dwSize;
				if (!NETClient.SnapPictureToFile(_logHandle, ref inParam, ref outParam, 10000))
				{
					LogSave.DHLog(DateTime.Now.ToString() + "图片加载异常" + NETClient.GetLastError());
					Thread.Sleep(snapNumber * 1000);
					continue;
				}
				switch (i)
				{
				case 0:
				{
					DataServerContext<tb_exceptional> dataServerContext3 = new DataServerContext<tb_exceptional>();
					if (!dataServerContext3.Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath1 = strImageFile
					}, (tb_exceptional p) => p.id == RecordId))
					{
					}
					break;
				}
				case 1:
				{
					DataServerContext<tb_exceptional> dataServerContext2 = new DataServerContext<tb_exceptional>();
					if (!dataServerContext2.Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath2 = strImageFile
					}, (tb_exceptional p) => p.id == RecordId))
					{
					}
					break;
				}
				default:
				{
					DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
					if (!dataServerContext.Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath3 = strImageFile
					}, (tb_exceptional p) => p.id == RecordId))
					{
					}
					break;
				}
				}
				Thread.Sleep(snapNumber * 1000);
			}
		}
		catch (Exception ex)
		{
			LogSave.HKLog(DateTime.Now.ToString() + ex.ToString());
		}
		finally
		{
			NETClient.Logout(_logHandle);
		}
	}

	public void Close()
	{
		NETClient.Logout(LogPtr);
	}
}
