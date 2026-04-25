// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.HKSDK

using System;
using System.Text;
using System.Threading;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;

namespace BulkMaterialsForm.SDK;

public class HKSDK
{
	public int m_lDownHandle = -1;

	public static int HKLogin(string IP, string doccode, string pass)
	{
		MainData.init_Sdk_HaiKang();
		CHCNetSDK.NET_DVR_USER_LOGIN_INFO pLoginInfo = default(CHCNetSDK.NET_DVR_USER_LOGIN_INFO);
		byte[] bytes = Encoding.Default.GetBytes(IP);
		pLoginInfo.sDeviceAddress = new byte[129];
		bytes.CopyTo(pLoginInfo.sDeviceAddress, 0);
		byte[] bytes2 = Encoding.Default.GetBytes(doccode);
		pLoginInfo.sUserName = new byte[64];
		bytes2.CopyTo(pLoginInfo.sUserName, 0);
		byte[] bytes3 = Encoding.Default.GetBytes(pass);
		pLoginInfo.sPassword = new byte[64];
		bytes3.CopyTo(pLoginInfo.sPassword, 0);
		pLoginInfo.wPort = 8000;
		pLoginInfo.bUseAsynLogin = false;
		CHCNetSDK.NET_DVR_DEVICEINFO_V40 lpDeviceInfo = default(CHCNetSDK.NET_DVR_DEVICEINFO_V40);
		int num = CHCNetSDK.NET_DVR_Login_V40(ref pLoginInfo, ref lpDeviceInfo);
		LogSave.HKLog(DateTime.Now.ToString() + "设备IP:" + IP + "账号：" + doccode + "密码：" + pass + "抓拍机登录_logHandle" + num);
		if (num < 0)
		{
			return -1;
		}
		return num;
	}

	public void Snap(int RecordId, int _logHandle, int snapNumber)
	{
		try
		{
			for (int i = 0; i < 3; i++)
			{
				string text = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
				string strImageFile = MainData.strImageDir + "\\" + text + "zp.jpg";
				int lChannel = 1;
				CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA
				{
					wPicQuality = 0,
					wPicSize = 255
				};
				if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(_logHandle, lChannel, ref lpJpegPara, strImageFile))
				{
					break;
				}
				switch (i)
				{
				case 0:
					if (new DataServerContext<tb_exceptional>().Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath1 = strImageFile
					}, (tb_exceptional p) => p.id == RecordId))
					{
					}
					break;
				case 1:
					if (new DataServerContext<tb_exceptional>().Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath2 = strImageFile
					}, (tb_exceptional p) => p.id == RecordId))
					{
					}
					break;
				default:
					new DataServerContext<tb_exceptional>().Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath3 = strImageFile
					}, (tb_exceptional p) => p.id == RecordId);
					break;
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
			CHCNetSDK.NET_DVR_Logout(_logHandle);
		}
	}

	public void Download(DateTime start, DateTime end, int index, int Id, int m_lUserID)
	{
		try
		{
			index--;
			CHCNetSDK.NET_DVR_PLAYCOND pDownloadCond = new CHCNetSDK.NET_DVR_PLAYCOND
			{
				dwChannel = (uint)index,
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
			m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref pDownloadCond);
			if (m_lDownHandle < 0)
			{
				return;
			}
			uint LPOutValue = 0u;
			if (CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, 1u, IntPtr.Zero, 0u, IntPtr.Zero, ref LPOutValue))
			{
				new DataServerContext<tb_exceptional>().Current.Modify((tb_exceptional p) => new tb_exceptional
				{
					SnapVideoPath = sVideoFileName
				}, (tb_exceptional p) => p.id == Id);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			CHCNetSDK.NET_DVR_Logout(m_lUserID);
		}
	}

	public void timerProgress()
	{
		while (true)
		{
			try
			{
				if (m_lDownHandle > 0)
				{
					if (CHCNetSDK.NET_DVR_GetDownloadPos(m_lDownHandle) == 100)
					{
						CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle);
					}
					Thread.Sleep(3000);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public void Close()
	{
	}
}
