// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.HKOperate

using System;
using System.Text;
using System.Threading;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;

namespace BulkMaterialsForm.SDK;

public class HKOperate
{
	public tb_videotape tb_Videotape;

	public int _logHandle;

	public int number;

	public int RecordId;

	public bool IsEnd;

	public void Init()
	{
		CHCNetSDK.NET_DVR_USER_LOGIN_INFO pLoginInfo = default(CHCNetSDK.NET_DVR_USER_LOGIN_INFO);
		byte[] bytes = Encoding.Default.GetBytes(tb_Videotape.IP);
		pLoginInfo.sDeviceAddress = new byte[129];
		bytes.CopyTo(pLoginInfo.sDeviceAddress, 0);
		byte[] bytes2 = Encoding.Default.GetBytes(tb_Videotape.doccode);
		pLoginInfo.sUserName = new byte[64];
		bytes2.CopyTo(pLoginInfo.sUserName, 0);
		byte[] bytes3 = Encoding.Default.GetBytes(tb_Videotape.pass);
		pLoginInfo.sPassword = new byte[64];
		bytes3.CopyTo(pLoginInfo.sPassword, 0);
		pLoginInfo.wPort = 8000;
		pLoginInfo.bUseAsynLogin = false;
		CHCNetSDK.NET_DVR_DEVICEINFO_V40 lpDeviceInfo = default(CHCNetSDK.NET_DVR_DEVICEINFO_V40);
		_logHandle = CHCNetSDK.NET_DVR_Login_V40(ref pLoginInfo, ref lpDeviceInfo);
		LogSave.HKLog(DateTime.Now.ToString() + "抓拍机_logHandle" + _logHandle);
		_ = _logHandle;
		_ = 0;
	}

	public void Snap(int Id)
	{
		try
		{
			for (int i = 0; i < 3; i++)
			{
				RecordId = Id;
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
					new DataServerContext<tb_exceptional>().Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath1 = strImageFile
					}, (tb_exceptional p) => p.id == Id);
					number++;
					break;
				case 1:
					new DataServerContext<tb_exceptional>().Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath2 = strImageFile
					}, (tb_exceptional p) => p.id == Id);
					number++;
					break;
				default:
					new DataServerContext<tb_exceptional>().Current.Modify((tb_exceptional p) => new tb_exceptional
					{
						SnapImagePath3 = strImageFile
					}, (tb_exceptional p) => p.id == Id);
					number++;
					break;
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
