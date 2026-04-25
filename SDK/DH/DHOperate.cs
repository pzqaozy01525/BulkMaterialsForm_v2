using System;
using System.Runtime.InteropServices;
using System.Threading;
using BulkMaterialsForm.DH;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;

namespace BulkMaterialsForm.SDK.DH;

public class DHOperate
{
	public tb_videotape tb_Videotape;

	public IntPtr _logHandle;

	public IntPtr _PlayID;

	public int number = 0;

	public int RecordId = 0;

	public bool IsEnd = false;

	public void Init()
	{
		NET_DEVICEINFO_Ex deviceInfo = default(NET_DEVICEINFO_Ex);
		_logHandle = NETClient.LoginWithHighLevelSecurity(tb_Videotape.IP, 37777, tb_Videotape.doccode, tb_Videotape.pass, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);
		if (_logHandle != IntPtr.Zero)
		{
			_PlayID = NETClient.RealPlay(_logHandle, 0, IntPtr.Zero);
		}
		else if (_logHandle == IntPtr.Zero)
		{
			LogSave.DHLog(DateTime.Now.ToString() + "球机初始化异常：" + NETClient.GetLastError());
		}
	}

	public void Snap(int Id)
	{
		try
		{
			for (int i = 0; i < 3; i++)
			{
				RecordId = Id;
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
					Thread.Sleep(tb_Videotape.snapNumber * 1000);
					continue;
				}
				switch (i)
				{
				case 0:
				{
					DataServerContext<tb_exceptional> dataServerContext2 = new DataServerContext<tb_exceptional>();
					if (dataServerContext2.Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath1 = strImageFile
					}, (tb_exceptional p) => p.id == Id))
					{
					}
					number++;
					break;
				}
				case 1:
				{
					DataServerContext<tb_exceptional> dataServerContext3 = new DataServerContext<tb_exceptional>();
					if (dataServerContext3.Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath2 = strImageFile
					}, (tb_exceptional p) => p.id == Id))
					{
					}
					number++;
					break;
				}
				default:
				{
					DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
					if (dataServerContext.Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath3 = strImageFile
					}, (tb_exceptional p) => p.id == Id))
					{
					}
					number++;
					break;
				}
				}
				Thread.Sleep(tb_Videotape.snapNumber * 1000);
			}
		}
		catch (Exception ex)
		{
			LogSave.HKLog(DateTime.Now.ToString() + ex.ToString());
		}
	}
}
