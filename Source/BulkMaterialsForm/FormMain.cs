// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm
// Type: BulkMaterialsForm.FormMain

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BulkMaterialsForm.API;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;
using BulkMaterialsForm.Properties;
using BulkMaterialsForm.SDK;
using BulkMaterialsForm.View;
using BulkMaterialsForm.Views.ZH;
using DevExpress.XtraBars;
using Newtonsoft.Json;

namespace BulkMaterialsForm;

public class FormMain : Form
{
	public List<VehicleNoInfoView> vehicleNoInfoViews = new List<VehicleNoInfoView>();

	public int rows;

	public int column;

	public int SplitX;

	public int SplitY;

	private List<tb_CarRecord> tb_CarRecords = new List<tb_CarRecord>();

	private bool isUpLoad;

	public bool IsLoad;

	private IContainer components;

	private BarDockControl barDockControlRight;

	private BarManager barManager1;

	private Bar bar2;

	private BarButtonItem barButtonItem1;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControl1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem6;

	private BarSubItem barSubItem1;

	private BarButtonItem barButtonItem7;

	private BarButtonItem barButtonItem8;

	private BarButtonItem barButtonItem9;

	private System.Windows.Forms.Timer timer1;

	private System.Windows.Forms.Timer timer2;

	private System.Windows.Forms.Timer timer3;

	private TableLayoutPanel tableLayoutPanel3;

	private Label label3;

	private PictureBox pictureBox1;

	private Label label2;

	private Label label1;

	private TableLayoutPanel tableLayoutPanel2;

	private Splitter splitter1;

	private BarButtonItem barButtonItem10;

	private BarButtonItem barButtonItem11;

	private System.Windows.Forms.Timer timer4;

	private BarButtonItem barButtonItem12;

	private BarButtonItem barButtonItem13;

	private BarButtonItem barButtonItem14;

	private Label label4;

	private BarSubItem barSubItem2;

	private BarButtonItem barButtonItem15;

	private BarButtonItem barButtonItem16;

	private DataGridView dataGridView1;

	private DataGridViewButtonColumn buhuo;

	private BarButtonItem barButtonItem17;

	private BarButtonItem barButtonItem18;

	private BarButtonItem barButtonItem19;

	private System.Windows.Forms.Timer timer5;

	private BarButtonItem barButtonItem20;

	private BarButtonItem barButtonItem21;

	private BarButtonItem barButtonItem22;

	private BarButtonItem barButtonItem23;

	public FormMain()
	{
		InitializeComponent();
		Control.CheckForIllegalCrossThreadCalls = false;
		base.Load += FormMain_Load;
		base.FormClosing += FormMain_FormClosing;
	}

	private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			timer1.Stop();
			timer2.Stop();
			timer3.Stop();
			MqttHostService.Close();
			foreach (Control control in tableLayoutPanel2.Controls)
			{
				if (control != null)
				{
					((IVideoMngInterface)control).Close();
					Thread.Sleep(200);
				}
			}
		}
		catch (Exception)
		{
		}
		Process[] processesByName = Process.GetProcessesByName("BulkMaterialsForm");
		for (int i = 0; i < processesByName.Length; i++)
		{
			processesByName[i].Kill();
		}
		Environment.Exit(0);
	}

	private void FormMain_Load(object sender, EventArgs e)
	{
		try
		{
			new DataServerContext<tb_tempVehicle>().Current.GetList();
		}
		catch (Exception)
		{
		}
		pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		MqttHostService.Init();
		TCPSeerver.StartServerAsync();
		if (MainData.scfwq)
		{
			MqttClientService.topic = MainData.khdId + "/get";
			MqttClientService.id = MainData.khdId;
			MqttClientService.Init();
		}
		MainData.Init();
		if (MainData.cdpfType != "无")
		{
			ClientHttpV2.InitTime();
		}
		Task.Run(delegate
		{
			if (MainData.DJPT == "高凌" && !string.IsNullOrWhiteSpace(MainData.GLcompanyCode))
			{
				Dictionary<string, object> companyControlInfo = CommonHelper.GetCompanyControlInfo(MainData.GLcompanyCode);
				if (companyControlInfo != null && companyControlInfo.ContainsKey("data") && companyControlInfo.ContainsKey("result") && companyControlInfo["result"].ToString().Equals("success"))
				{
					companyControlInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(companyControlInfo["data"].ToString());
					if (companyControlInfo != null)
					{
						MainData.GLcompanyName = companyControlInfo["companyName"].ToString();
						MainData.GLcontrolRunTime = companyControlInfo["controlRunTime"].ToString();
						MainData.GLcontrolEndTime = companyControlInfo["controlEndTime"].ToString();
						MainData.GLcontrolStrategy = CommonHelper.GetControlStrategy(companyControlInfo["controlStrategy"].ToString());
						MainData.GLresponseLevel = CommonHelper.GetResponseLevel(companyControlInfo["responseLevel"].ToString());
						MainData.GLcontrolLevel = CommonHelper.GetControlLevel(companyControlInfo["controlLevel"].ToString());
						MainData.GLcontrolUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
						New_IniFile.WriteContentValue("窗体框架配制", "高陵企业名称", MainData.GLcompanyName, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵管控开始时间", MainData.GLcontrolRunTime, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵管控结束时间", MainData.GLcontrolEndTime, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵管控策略", MainData.GLcontrolStrategy, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵响应等级", MainData.GLresponseLevel, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵预警等级", MainData.GLcontrolLevel, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵管控更新时间", MainData.GLcontrolUpdateTime, MainData.Spath);
					}
				}
			}
		});
		ClientHttpV2.Init();
		Task.Factory.StartNew(delegate
		{
			try
			{
				HybridActivationAPI instance = HybridActivationAPI.Instance;
				instance.Initialize();
				instance.StartBackgroundSync();
				LogSave.SaveExeLog("后台同步服务已启动（自动模式）");
			}
			catch (Exception ex4)
			{
				LogSave.SaveExeLog("启动后台同步服务异常: " + ex4.Message);
			}
		});
		string s = New_IniFile.ReadContentValue("窗体框架配制", "SplitX", MainData.Spath);
		string s2 = New_IniFile.ReadContentValue("窗体框架配制", "SplitY", MainData.Spath);
		if (!int.TryParse(s, out var result) || result <= 0)
		{
			result = tableLayoutPanel2.Width;
		}
		if (!int.TryParse(s2, out var result2) || result2 <= 0)
		{
			result2 = tableLayoutPanel2.Height;
		}
		SplitX = result;
		SplitY = result2;
		tableLayoutPanel2.Width = SplitX;
		tableLayoutPanel2.Height = SplitY;
		label3.Text = "软件初始化时间：" + DateTime.Now.ToString();
		if (DateTime.Now > MainData.ExpTime)
		{
			int days = (DateTime.Now - MainData.ExpTime).Days;
			if (days <= 15)
			{
				label4.Text = "系统维护以逾期" + days + "天,请尽快续费超过15天将无法连接平台";
			}
			else
			{
				MainData.IsBecomeDue = true;
				label4.Text = "系统维护以逾期" + days + "天,无法连接平台使用";
			}
			Text = MainData.XMMC + "系统维护到期时间:" + MainData.ExpTime.ToString();
		}
		else
		{
			Text = MainData.XMMC;
			label4.Text = "";
		}
		if (MainData.isInst == "2")
		{
			InitData();
			timer1_Tick(null, null);
			if (MainData.DPLX == "ZH")
			{
				int num = LedAgent.Init();
				if (num != 1)
				{
					LogSave.ZHLog(DateTime.Now.ToString() + "初始化失败" + num);
				}
				List<tb_large_screen> list = new DataServerContext<tb_large_screen>().Current.GetList();
				if (list != null)
				{
					foreach (tb_large_screen item in list)
					{
						ZHModle zHModle = new ZHModle();
						zHModle.tb_Led = item;
						zHModle.m_iCurrentDeviceId = LedAgent.RegisterDevice(item.IP, 58258u, null, IntPtr.Zero);
						ZHSDK.listZH.Add(zHModle);
						LogSave.ZHLog(DateTime.Now.ToString() + "m_iCurrentDeviceId:" + zHModle.m_iCurrentDeviceId);
					}
				}
			}
			else if (MainData.DPLX == "YB")
			{
				try
				{
					Led5kSDK.InitSdk(2, 2);
				}
				catch (Exception ex2)
				{
					LogSave.SaveExeLog("YB初始化异常" + ex2.ToString());
				}
			}
			if (MainData.kqsplx)
			{
				MainData.init_Sdk_DH();
				MainData.init_Sdk_HaiKang();
				DHSDK.Init();
				if (MainData.jhjtype == "hk")
				{
					MainData.hKLXJ.HKLXJLogin(MainData.jhjIp, MainData.jhjzh, MainData.jhjmm);
					MainData.hKLXJ.Init();
				}
			}
			Task.Factory.StartNew(delegate
			{
				Init();
			});
			timer2.Enabled = true;
			timer2.Interval = 10800000;
			timer2.Start();
			if (string.IsNullOrWhiteSpace(MainData.strImageDir))
			{
				MainData.strImageDir = Path.Combine(Application.StartupPath, "Image");
			}
			try
			{
				if (!Directory.Exists(MainData.strImageDir))
				{
					Directory.CreateDirectory(MainData.strImageDir);
				}
			}
			catch (Exception ex3)
			{
				LogSave.SaveExeLog("创建图片目录失败: " + ex3.Message);
			}
			MainData.cameraSnap += MainData_cameraSnap;
			if (MainData.TXIsOpen)
			{
				CommonHelper.TXHGGetToken();
			}
		}
		if (MainData.DJPT == "中科九州")
		{
			CommonHelper.GetKangFengV1Token();
		}
		else if (MainData.DJPT == "安车")
		{
			string msg = "";
			CommonHelper.AnCheToken(ref msg);
			barButtonItem11.Visibility = BarItemVisibility.Always;
		}
		else if (MainData.DJPT == "腾跃")
		{
			timer4.Start();
			timer3.Stop();
			dataGridView1.Columns["buhuo"].Visible = false;
		}
		else if (MainData.DJPT == "天地人车")
		{
			CommonHelper.tdrcCheToken();
		}
		else if (MainData.DJPT == "信阳")
		{
			CommonHelper.xyCheToken();
		}
		else
		{
			dataGridView1.Columns["buhuo"].Visible = false;
		}
	}

	public void Init()
	{
		MainData.IsInit = true;
	}

	private void MainData_cameraSnap(cmdModel model)
	{
		if (!(model.cmd == "抓拍"))
		{
			return;
		}
		foreach (Control control in tableLayoutPanel2.Controls)
		{
			if (control != null)
			{
				((IVideoMngInterface)control).Snap(JsonConvert.SerializeObject(model.data));
			}
		}
	}

	public void InitData()
	{
		List<tb_Channel> list = new DataServerContext<tb_Channel>().Current.GetList();
		List<tb_Device> list2 = new DataServerContext<tb_Device>().Current.GetList();
		if (list == null || list2 == null || list2.Count <= 0)
		{
			return;
		}
		if (list2.Count <= 2)
		{
			rows = 2;
			column = 1;
		}
		else if (list2.Count <= 4)
		{
			rows = 2;
			column = 2;
		}
		else if (list2.Count <= 6)
		{
			rows = 2;
			column = 3;
		}
		else if (list2.Count <= 9)
		{
			rows = 3;
			column = 3;
		}
		tableLayoutPanel2.RowCount = rows;
		tableLayoutPanel2.ColumnCount = column;
		DynamicLayout(tableLayoutPanel2, rows, column);
		int num = 0;
		int num2 = 0;
		foreach (tb_Device Device in list2)
		{
			if (Device.CameraBrand == "QY")
			{
				MainData.init_Sdk_QY();
				UserControlQY userControlQY = new UserControlQY();
				userControlQY.tb_Device = Device;
				userControlQY.tb_Channel = list.Where((tb_Channel it) => it.id == Device.ChannelNo).FirstOrDefault();
				userControlQY.Dock = DockStyle.Fill;
				userControlQY.carRecord += UserControlQY_carRecord;
				tableLayoutPanel2.Controls.Add(userControlQY);
				tableLayoutPanel2.SetRow(userControlQY, num);
				tableLayoutPanel2.SetColumn(userControlQY, num2);
			}
			else if (Device.CameraBrand == "HX")
			{
				MainData.init_Sdk_HX();
				UserControlHX userControlHX = new UserControlHX();
				userControlHX.tb_Device = Device;
				userControlHX.tb_Channel = list.Where((tb_Channel it) => it.id == Device.ChannelNo).FirstOrDefault();
				userControlHX.Dock = DockStyle.Fill;
				userControlHX.carRecord += UserControlQY_carRecord;
				tableLayoutPanel2.Controls.Add(userControlHX);
				tableLayoutPanel2.SetRow(userControlHX, num);
				tableLayoutPanel2.SetColumn(userControlHX, num2);
			}
			else if (Device.CameraBrand == "ZS")
			{
				MainData.init_Sdk_ZS();
				UserControlZS userControlZS = new UserControlZS();
				userControlZS.tb_Device = Device;
				userControlZS.tb_Channel = list.Where((tb_Channel it) => it.id == Device.ChannelNo).FirstOrDefault();
				userControlZS.Dock = DockStyle.Fill;
				userControlZS.carRecord += UserControlQY_carRecord;
				tableLayoutPanel2.Controls.Add(userControlZS);
				tableLayoutPanel2.SetRow(userControlZS, num);
				tableLayoutPanel2.SetColumn(userControlZS, num2);
			}
			else if (Device.CameraBrand == "DH")
			{
				MainData.init_Sdk_DH();
				UserControlDH userControlDH = new UserControlDH();
				userControlDH.tb_Device = Device;
				userControlDH.tb_Channel = list.Where((tb_Channel it) => it.id == Device.ChannelNo).FirstOrDefault();
				userControlDH.Dock = DockStyle.Fill;
				userControlDH.carRecord += UserControlQY_carRecord;
				tableLayoutPanel2.Controls.Add(userControlDH);
				tableLayoutPanel2.SetRow(userControlDH, num);
				tableLayoutPanel2.SetColumn(userControlDH, num2);
			}
			else if (Device.CameraBrand == "HK")
			{
				MainData.init_Sdk_HaiKang();
				UserControlHaiKang userControlHaiKang = new UserControlHaiKang();
				userControlHaiKang.tb_Device = Device;
				userControlHaiKang.tb_Channel = list.Where((tb_Channel it) => it.id == Device.ChannelNo).FirstOrDefault();
				userControlHaiKang.Dock = DockStyle.Fill;
				userControlHaiKang.carRecord += UserControlQY_carRecord;
				tableLayoutPanel2.Controls.Add(userControlHaiKang);
				tableLayoutPanel2.SetRow(userControlHaiKang, num);
				tableLayoutPanel2.SetColumn(userControlHaiKang, num2);
			}
			num2++;
			if (num2 >= column)
			{
				num2 = 0;
				num++;
			}
		}
		foreach (Control control in tableLayoutPanel2.Controls)
		{
			if (control != null)
			{
				((IVideoMngInterface)control).Init();
				Thread.Sleep(200);
				((IVideoMngInterface)control).StartVideoNetThread();
			}
		}
	}

	private void UserControlQY_carRecord(VehicleNoInfoView vehicleNoInfoView)
	{
		dataGridView1.Invoke((Action<List<VehicleNoInfoView>>)delegate
		{
			dataGridView1.DataSource = null;
			if (vehicleNoInfoViews.Count > 100)
			{
				vehicleNoInfoViews.RemoveAt(vehicleNoInfoViews.Count - 1);
				vehicleNoInfoViews.Insert(0, vehicleNoInfoView);
			}
			else
			{
				vehicleNoInfoViews.Insert(0, vehicleNoInfoView);
			}
			dataGridView1.DataSource = vehicleNoInfoViews;
		dataGridView1.Columns["VehicleNo"].HeaderText = "车牌号";
		dataGridView1.Columns["licenseColor"].HeaderText = "车牌颜色";
		dataGridView1.Columns["TrafficStatus"].HeaderText = "通行状态";
		dataGridView1.Columns["AddTime"].HeaderText = "识别时间";
		dataGridView1.Columns["ChannelType"].HeaderText = "进出标识";
		dataGridView1.Columns["ChannelName"].HeaderText = "通道名称";
		dataGridView1.Columns["fuelType"].HeaderText = "燃料类型";
		dataGridView1.Columns["emissionStandard"].HeaderText = "排放阶段";
		dataGridView1.Columns["DeviceName"].HeaderText = "设备名称";
		dataGridView1.Columns["ExeLog"].HeaderText = "系统日志";
			dataGridView1.Columns["ImagePath"].Visible = false;
			dataGridView1.Columns["id"].Visible = false;
			if (MainData.DJPT == "中科九州" || MainData.DJPT == "安车")
			{
				dataGridView1.Columns["buhuo"].Visible = true;
				dataGridView1.Columns["serialNum"].Visible = true;
			}
		}, vehicleNoInfoViews);
		label2.Invoke((Action<string>)delegate(string p)
		{
			label2.Text = p;
		}, vehicleNoInfoView.VehicleNo + "," + vehicleNoInfoView.ExeLog);
		label2.Invoke((Action<string>)delegate(string p)
		{
			if (File.Exists(p))
			{
				Image image = Image.FromFile(p);
				Image image2 = new Bitmap(image);
				image.Dispose();
				pictureBox1.Image = image2;
			}
		}, vehicleNoInfoView.ImagePath);
	}

	private void DynamicLayout(TableLayoutPanel layoutPanel, int row, int col)
	{
		layoutPanel.RowCount = row;
		int num = layoutPanel.Width / col;
		int num2 = layoutPanel.Height / row;
		for (int i = 0; i < row; i++)
		{
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, num2));
		}
		layoutPanel.ColumnCount = col;
		for (int j = 0; j < col; j++)
		{
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, num));
		}
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		new CameraForm().ShowDialog();
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		new ChannelForm().ShowDialog();
	}

	private void FormMain_SizeChanged(object sender, EventArgs e)
	{
		TableLayoutColumnStyleCollection columnStyles = tableLayoutPanel2.ColumnStyles;
		TableLayoutRowStyleCollection rowStyles = tableLayoutPanel2.RowStyles;
		if (rows != 0 && column != 0)
		{
			int num = tableLayoutPanel2.Height / rows;
			for (int i = 0; i < rows; i++)
			{
				rowStyles[i].Height = num;
			}
			int num2 = tableLayoutPanel2.Width / column;
			for (int j = 0; j < column; j++)
			{
				columnStyles[j].Width = num2;
			}
		}
	}

	private void pictureBox1_DoubleClick(object sender, EventArgs e)
	{
		if (pictureBox1.Tag != null && !string.IsNullOrWhiteSpace(pictureBox1.Tag.ToString()))
		{
			ImageView imageView = new ImageView();
			imageView.ListImage = new List<string>();
			imageView.ListImage.Add(pictureBox1.Tag.ToString());
			imageView.ShowDialog();
		}
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		new SystemSetForm().ShowDialog();
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		Process[] processesByName = Process.GetProcessesByName("BulkMaterialsForm");
		for (int i = 0; i < processesByName.Length; i++)
		{
			processesByName[i].Kill();
		}
		Environment.Exit(0);
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		new RecordList().ShowDialog();
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
		new whiteListForm().ShowDialog();
	}

	private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			if (MainData.DJPT == "消纳场")
			{
				string msg = "";
				if (CommonHelper.XNCVerify("豫A12345", "绿色", "123", "1", ref msg))
				{
					MessageBox.Show("上传成功");
				}
				else
				{
					MessageBox.Show(msg);
				}
			}
			else if (MainData.DJPT == "高凌")
			{
				string msg2 = "";
				VehicleNoInfoView vehicleNoInfoView = new VehicleNoInfoView();
				if (CommonHelper.GLVerify("沪A90157D", "绿色", MainData.GLExitPort, ref msg2, ref vehicleNoInfoView))
				{
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					dictionary.Add("license", "沪A90157D");
					dictionary.Add("inOutType", "out");
					dictionary.Add("gateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
					dictionary.Add("licensImg", "");
					dictionary.Add("vehImg", "");
					LogSave.GLLog(DateTime.Now.ToString() + "测试记录上传PassData/Send" + JsonConvert.SerializeObject(dictionary));
					string gLResultModel = CommonHelper.GetGLResultModel(MainData.GLIISUrl + ":" + MainData.GLExitPort + "/PassData/Send", dictionary);
					LogSave.GLLog(DateTime.Now.ToString() + "测试记录上传PassData/Send返回信息：" + gLResultModel);
					Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(gLResultModel);
					if (dictionary2 != null && dictionary2["result"].ToString().Equals("success"))
					{
						MessageBox.Show("上传成功");
					}
					else
					{
						MessageBox.Show(dictionary2["err"].ToString());
					}
				}
				else
				{
					MessageBox.Show(msg2);
				}
			}
			else if (MainData.DJPT == "腾跃")
			{
				string msg3 = "";
				if (CommonHelper.TYVerify("豫A12345", "绿色", MainData.TYEnterChannel, Application.StartupPath + "\\Image\\20230607090240122.jpg", ref msg3))
				{
					if (CommonHelper.TYSaveRecord("豫A12346", "绿色", MainData.TYEnterChannel, Application.StartupPath + "\\Image\\20230607090240122.jpg"))
					{
						MessageBox.Show("上传成功");
					}
					else
					{
						MessageBox.Show("上传失败");
					}
				}
				else
				{
					MessageBox.Show(msg3);
				}
			}
			else if (MainData.DJPT == "安车")
			{
				string msg4 = "";
				VehicleNoInfoView vehicleNoInfoView2 = new VehicleNoInfoView();
				if (CommonHelper.AnCheVerify("豫V38CK9", "0", ref msg4, ref vehicleNoInfoView2, "01"))
				{
					DateTime now = DateTime.Now;
					if (CommonHelper.AnCheUpLoad(MainData.ACEnterpriseID + "04A" + now.ToString("yyMMddHHmmss"), "A04", "豫V38CK9", "0", now.ToString("yyyy-MM-dd HH:mm:ss"), now.ToString("yyyy-MM-dd HH:mm:ss"), "1", "1", ref msg4, "", ""))
					{
						MessageBox.Show("上传成功");
					}
				}
				else
				{
					MessageBox.Show("上传失败原因：" + msg4);
				}
			}
			else
			{
				if (!(MainData.DJPT == "天地人车"))
				{
					return;
				}
				List<tb_Device> tb_Device2 = new DataServerContext<tb_Device>().Current.GetList();
				if (tb_Device2 != null && tb_Device2.Count > 0)
				{
					tb_Channel model = new DataServerContext<tb_Channel>().Current.GetModel((tb_Channel it) => it.id == tb_Device2[0].ChannelNo);
					if (model == null)
					{
						MessageBox.Show("通道不存在");
						return;
					}
					tb_CarRecord model2 = new DataServerContext<tb_CarRecord>().Current.GetModel((tb_CarRecord it) => it.car_no == "豫C51L10");
					if (model2 == null)
					{
						MessageBox.Show("记录不存在");
						return;
					}
					VehicleNoInfoView vehicleNoInfoView3 = new VehicleNoInfoView();
					vehicleNoInfoView3.VehicleNo = "豫C51L10";
					vehicleNoInfoView3.AddTime = DateTime.Now;
					vehicleNoInfoView3.ChannelName = model.ChannelName;
					vehicleNoInfoView3.DeviceName = tb_Device2[0].CameraName;
					vehicleNoInfoView3.ChannelType = model.ChannelType;
					vehicleNoInfoView3.ImagePath = model2.front_image;
					vehicleNoInfoView3.licenseColor = "蓝色";
					vehicleNoInfoView3.ChannelId = tb_Device2[0].ChannelNo;
					vehicleNoInfoView3.devId = tb_Device2[0].id;
					string msg5 = "";
					if (CommonHelper.tdrcCheVerify(vehicleNoInfoView3.VehicleNo, vehicleNoInfoView3.licenseColor, ref msg5, ref vehicleNoInfoView3, model.ChannelPort))
					{
						string text = "A";
						text = ((!(model.ChannelType == "入口")) ? "B" : "A");
						vehicleNoInfoView3.serialNum = MainData.tdrcEnterpriseID + model.ChannelPort + text + DateTime.Now.ToString("yyMMddHHmmss");
						if (MainData.KaiFengRecordSave(model2.car_image, model2.front_image, vehicleNoInfoView3.VehicleNo, vehicleNoInfoView3.licenseColor, model.ChannelType, model.id, tb_Device2[0].id, model.ChannelPort, vehicleNoInfoView3.serialNum, "摆杆通行", "未上传", ref vehicleNoInfoView3))
						{
							MessageBox.Show("上传成功");
						}
					}
					else
					{
						MessageBox.Show(msg5);
					}
				}
				else
				{
					MessageBox.Show("设备没查询到");
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
	{
		new DataBaseSet().ShowDialog();
	}

	private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (!isUpLoad)
		{
			isUpLoad = true;
			UpLoadForm upLoadForm = new UpLoadForm();
			if (upLoadForm.ShowDialog() == DialogResult.OK)
			{
				Task.Factory.StartNew(delegate
				{
					PastDataUpLoad(upLoadForm.start, upLoadForm.end, upLoadForm.type);
				});
			}
		}
		else
		{
			MessageBox.Show("上传中请结束以后继续上传");
		}
	}

	private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
	{
		new SnapForm().ShowDialog();
	}

	private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (MainData.DPLX == "YB")
		{
			new BulkMaterialsForm.View.LargeScreenForm().ShowDialog();
		}
		else
		{
			new BulkMaterialsForm.Views.ZH.LargeScreenForm().ShowDialog();
		}
	}

	public void PastDataUpLoad(DateTime start, DateTime end, string type)
	{
		DataServerContext<tb_CarRecord> dataServerContext = new DataServerContext<tb_CarRecord>();
		Expression<Func<tb_CarRecord, bool>> expression = PredicateBuilder.GetTrue<tb_CarRecord>();
		if (type != "全部")
		{
			expression.And((tb_CarRecord it) => it.car_no.Contains(type));
		}
		expression.And((tb_CarRecord it) => it.add_time >= start);
		expression.And((tb_CarRecord it) => it.add_time <= end);
		expression.And((tb_CarRecord it) => it.upload_number < 4);
		List<tb_CarRecord> list = dataServerContext.Current.GetList(expression);
		if (list == null || list.Count <= 0)
		{
			return;
		}
		foreach (tb_CarRecord item in list)
		{
			bool flag = false;
			if (MainData.DJPT.Equals("高凌"))
			{
				string text = "0";
				string text2 = "";
				if (item.out_type == "入口")
				{
					text = MainData.GLEnterPort;
					text2 = "in";
				}
				else
				{
					text = MainData.GLExitPort;
					text2 = "out";
				}
				string msg = "";
				VehicleNoInfoView vehicleNoInfoView = new VehicleNoInfoView();
				if (CommonHelper.GLVerify(item.car_no, item.car_color, text, ref msg, ref vehicleNoInfoView) && CommonHelper.GLSvaeHSRecord(item.car_no, text2, text, item.car_image, item.front_image))
				{
					flag = true;
				}
			}
			else if (!MainData.DJPT.Equals("消纳场"))
			{
				MainData.DJPT.Equals("腾跃");
			}
			if (flag)
			{
				dataServerContext = new DataServerContext<tb_CarRecord>();
				short number = 1;
				if (dataServerContext.Current.Modify((tb_CarRecord p) => new tb_CarRecord
				{
					upload_number = Convert.ToInt16(item.upload_number + number),
					upload_status = "上传成功"
				}, (tb_CarRecord p) => p.id == item.id))
				{
				}
				continue;
			}
			dataServerContext = new DataServerContext<tb_CarRecord>();
			short number2 = 1;
			dataServerContext.Current.Modify((tb_CarRecord p) => new tb_CarRecord
			{
				upload_number = Convert.ToInt16(item.upload_number + number2),
				upload_status = "上传失败"
			}, (tb_CarRecord p) => p.id == item.id);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		Task.Factory.StartNew(delegate
		{
			if (MainData.DJPT.Equals("高凌"))
			{
				Dictionary<string, object> companyControlInfo = CommonHelper.GetCompanyControlInfo(MainData.GLcompanyCode);
				if (companyControlInfo != null && companyControlInfo.ContainsKey("data") && companyControlInfo.ContainsKey("result") && companyControlInfo["result"].ToString().Equals("success"))
				{
					companyControlInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(companyControlInfo["data"].ToString());
					if (companyControlInfo != null)
					{
						MainData.GLcompanyName = companyControlInfo["companyName"].ToString();
						MainData.GLcontrolRunTime = companyControlInfo["controlRunTime"].ToString();
						MainData.GLcontrolEndTime = companyControlInfo["controlEndTime"].ToString();
						MainData.GLcontrolStrategy = CommonHelper.GetControlStrategy(companyControlInfo["controlStrategy"].ToString());
						MainData.GLresponseLevel = CommonHelper.GetResponseLevel(companyControlInfo["responseLevel"].ToString());
						MainData.GLcontrolLevel = CommonHelper.GetControlLevel(companyControlInfo["controlLevel"].ToString());
						MainData.GLcontrolUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
						New_IniFile.WriteContentValue("窗体框架配制", "高陵企业名称", MainData.GLcompanyName, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵管控开始时间", MainData.GLcontrolRunTime, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵管控结束时间", MainData.GLcontrolEndTime, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵管控策略", MainData.GLcontrolStrategy, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵响应等级", MainData.GLresponseLevel, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵预警等级", MainData.GLcontrolLevel, MainData.Spath);
						New_IniFile.WriteContentValue("窗体框架配制", "高陵管控更新时间", MainData.GLcontrolUpdateTime, MainData.Spath);
					}
				}
			}
			else if (MainData.DJPT.Equals("安车"))
			{
				CommonHelper.AnPutdcstatus();
				CommonHelper.acyqyc();
			}
			if (MainData.isInst == "2")
			{
				_ = MainData.IsInit;
			}
			Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(CommonHelper.GetGLResultModel(MainData.ServerIP + "ExpTime/GetExpTime?register=" + Activation.softAuthorize.GetInfo() + "&project_name=" + MainData.XMMC, ""));
			if (dictionary != null && dictionary.ContainsKey("data") && dictionary.ContainsKey("code") && dictionary["code"].ToString().Equals("200"))
			{
				_ = DateTime.Now;
				try
				{
					MainData.ExpTime = Convert.ToDateTime(dictionary["data"]);
				}
				catch (Exception)
				{
					MainData.ExpTime = DateTime.Now.AddDays(-1.0);
				}
			}
			if (DateTime.Now > MainData.ExpTime)
			{
				int days = (DateTime.Now - MainData.ExpTime).Days;
				if (days <= 15)
				{
					label4.Text = "系统维护以逾期" + days + "天,请尽快续费超过15天将无法连接平台";
				}
				else
				{
					MainData.IsBecomeDue = true;
					label4.Text = "系统维护以逾期" + days + "天,无法连接平台使用";
				}
				Text = MainData.XMMC + "系统维护到期时间:" + MainData.ExpTime.ToString();
			}
		});
	}

	private void timer2_Tick(object sender, EventArgs e)
	{
		Task.Factory.StartNew(delegate
		{
			try
			{
				if (MainData.DJPT == "中科九州")
				{
					for (int i = 0; i < 10; i++)
					{
						if (CommonHelper.GetKangFengV1Token())
						{
							break;
						}
					}
				}
				else if (MainData.DJPT == "安车" && DateTime.Now >= MainData.ACServerTime)
				{
					string msg = "";
					CommonHelper.AnCheToken(ref msg);
				}
			}
			catch (Exception)
			{
			}
		});
	}

	private void timer3_Tick(object sender, EventArgs e)
	{
		Task.Factory.StartNew(delegate
		{
			if (!IsLoad && MainData.isInst == "2" && MainData.IsInit)
			{
				IsLoad = true;
				Task.Factory.StartNew(delegate
				{
					PastDataUpload();
				});
			}
		});
	}

	public void PastDataUpload()
	{
		try
		{
			List<string> list = new List<string>();
			list.Add("");
			list.Add("上传失败");
			list.Add("未上传");
			list.Add("等待中");
			List<tb_CarRecord> list2 = new DataServerContext<tb_CarRecord>().Current.GetList((tb_CarRecord it) => list.Contains(it.upload_status) && it.upload_number < 3).ToList();
			if (list2 != null)
			{
				foreach (tb_CarRecord item in list2)
				{
					string msg = "";
					string text = "";
					if (MainData.DJPT.Equals("高凌"))
					{
						if (item.out_type == null)
						{
							if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_status = "禁止上传"
							}, (tb_CarRecord p) => p.id == item.id))
							{
							}
							continue;
						}
						if (item.out_type.Equals("入口"))
						{
							text = "in";
							_ = MainData.GLEnterPort;
						}
						else
						{
							text = "out";
							_ = MainData.GLExitPort;
						}
						Dictionary<string, object> dictionary = new Dictionary<string, object>();
						dictionary.Add("license", item.car_no);
						dictionary.Add("inOutType", text);
						dictionary.Add("gateTime", item.add_time.ToString("yyyy-MM-dd HH:mm:ss"));
						LogSave.GLLog(DateTime.Now.ToString() + MainData.GLIISUrl + ":" + item.ChannelPort + "记录上传PassData/Send" + JsonConvert.SerializeObject(dictionary));
						dictionary.Add("licensImg", CommonHelper.ImageToBase64(item.car_image));
						dictionary.Add("vehImg", CommonHelper.ImageToBase64(item.front_image));
						string gLResultModel = CommonHelper.GetGLResultModel(MainData.GLIISUrl + ":" + item.ChannelPort + "/PassData/Send", dictionary);
						LogSave.GLLog(DateTime.Now.ToString() + MainData.GLIISUrl + ":" + item.ChannelPort + "记录上传PassData/Send返回信息：" + gLResultModel);
						Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(gLResultModel);
						if (dictionary2 != null && dictionary2["result"].ToString().Equals("success"))
						{
							if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_status = "上传成功"
							}, (tb_CarRecord p) => p.id == item.id))
							{
							}
						}
						else if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
						{
							upload_number = 4,
							upload_status = "上传失败"
						}, (tb_CarRecord p) => p.id == item.id))
						{
						}
					}
					else if (MainData.DJPT == "中科九州")
					{
						string text2 = "";
						if (CommonHelper.GetKangFengV1Token())
						{
							if (item.out_type.Equals("入口"))
							{
								text = "A";
								text2 = "1";
							}
							else
							{
								text = "B";
								text2 = "2";
							}
							Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
							dictionary3.Add("serialNum", item.serialNum);
							dictionary3.Add("companyCode", MainData.companyCodeV1);
							dictionary3.Add("gateCode", item.ChannelPort);
							dictionary3.Add("license", item.car_no);
							dictionary3.Add("licenseColor", CommonHelper.GetKaiFenglicenseColor(item.car_color));
							dictionary3.Add("passStatus", text);
							dictionary3.Add("gateSignal", "0");
							dictionary3.Add("passTime", item.add_time.ToString("yyyy-MM-dd HH:mm:ss"));
							dictionary3.Add("imageNo", "1");
							dictionary3.Add("imageType", text2);
							dictionary3.Add("imageUrl", Path.GetFileName(item.front_image));
							dictionary3.Add("imageRecordTime", item.add_time.ToString("yyyy-MM-dd HH:mm:ss"));
							Dictionary<string, object> model = CommonHelper.GetKaiFengV1ResultModel(MainData.KFV1ServerIP + "/transport/record/pass", dictionary3, MainData.KFV1Token);
							if (model != null)
							{
								if (Convert.ToBoolean(model["success"]) && model["code"].ToString().Equals("200"))
								{
									new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
									{
										upload_status = "上传成功"
									}, (tb_CarRecord p) => p.id == item.id);
									if (text == "B" && MainData.DBDJ != "" && MainData.DBDJ != "无")
									{
										tb_CarRecord tb_Car = (from it in new DataServerContext<tb_CarRecord>().Current.GetList((tb_CarRecord it) => it.car_no == item.car_no && it.add_time >= DateTime.Now.Date && it.out_type == "入口")
											orderby it.id descending
											select it).FirstOrDefault();
										if (MainData.DBDJ.Equals("同欣"))
										{
											LogSave.DBLog(DateTime.Now.ToString() + "进入");
											if (tb_Car != null)
											{
												string text3 = $"SELECT * FROM 称重记录 WHERE 车号='{item.car_no}' and 过总时间 >='{tb_Car.add_time}' and 过总时间 <='{item.add_time}'";
												LogSave.DBLog(DateTime.Now.ToString() + "查询SQL" + text3);
												string msg2 = "";
												DataTable datatable = DataClass.GetDatatable(text3, ref msg2);
												if (datatable != null)
												{
													LogSave.DBLog(DateTime.Now.ToString() + "查询：" + JsonConvert.SerializeObject(datatable));
													DataRow[] inRow = datatable.Select("运输单位='进货'", "过总时间 DESC");
													if (inRow != null && inRow.Length != 0)
													{
														Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
														dictionary4.Add("serialNum", tb_Car.serialNum);
														dictionary4.Add("companyCode", MainData.companyCodeV1);
														dictionary4.Add("gateCode", tb_Car.ChannelPort);
														dictionary4.Add("license", tb_Car.car_no);
														dictionary4.Add("licenseColor", CommonHelper.GetKaiFenglicenseColor(tb_Car.car_color));
														dictionary4.Add("cargoName", inRow[0]["货物名称"].ToString());
														dictionary4.Add("cargoWeight", inRow[0]["实重"].ToString());
														dictionary4.Add("cargoRecordTime", tb_Car.add_time.ToString("yyyy-MM-dd HH:mm:ss"));
														dictionary4.Add("cargoWeightUnit", "吨（T）");
														model = CommonHelper.GetKaiFengV1ResultModel(MainData.KFV1ServerIP + "/transport/record/cargo", dictionary4, MainData.KFV1Token);
														if (model != null && Convert.ToBoolean(model["success"]) && model["code"].ToString().Equals("200"))
														{
															new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
															{
																cargoName = inRow[0]["货物名称"].ToString(),
																cargoWeight = inRow[0]["实重"].ToString()
															}, (tb_CarRecord p) => p.id == item.id);
														}
													}
													DataRow[] outRow = datatable.Select("运输单位='出货'", "过总时间 DESC");
													if (outRow != null && outRow.Length != 0)
													{
														Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
														dictionary5.Add("serialNum", item.serialNum);
														dictionary5.Add("companyCode", MainData.companyCodeV1);
														dictionary5.Add("gateCode", item.ChannelPort);
														dictionary5.Add("license", item.car_no);
														dictionary5.Add("licenseColor", CommonHelper.GetKaiFenglicenseColor(item.car_color));
														dictionary5.Add("cargoName", outRow[0]["货物名称"].ToString());
														dictionary5.Add("cargoWeight", outRow[0]["实重"].ToString());
														dictionary5.Add("cargoRecordTime", item.add_time.ToString("yyyy-MM-dd HH:mm:ss"));
														dictionary5.Add("cargoWeightUnit", "吨（T）");
														model = CommonHelper.GetKaiFengV1ResultModel(MainData.KFV1ServerIP + "/transport/record/cargo", dictionary5, MainData.KFV1Token);
														if (model != null && Convert.ToBoolean(model["success"]) && model["code"].ToString().Equals("200") && new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
														{
															cargoName = outRow[0]["货物名称"].ToString(),
															cargoWeight = outRow[0]["实重"].ToString()
														}, (tb_CarRecord p) => p.id == item.id))
														{
														}
													}
												}
											}
										}
										else if (MainData.DBDJ.Equals("威特") && tb_Car != null)
										{
											List<tb_Weig> list3 = new DataServerContext<tb_Weig>().Current.GetList((tb_Weig it) => it.vehicleNo == item.car_no && it.scale_time >= tb_Car.add_time && it.scale_time <= item.add_time);
											if (list3 != null)
											{
												tb_Weig inRow2 = list3.FirstOrDefault((tb_Weig it) => it.door_type == "进厂");
												if (inRow2 != null)
												{
													Dictionary<string, object> dictionary6 = new Dictionary<string, object>();
													dictionary6.Add("serialNum", tb_Car.serialNum);
													dictionary6.Add("companyCode", MainData.companyCodeV1);
													dictionary6.Add("gateCode", tb_Car.ChannelPort);
													dictionary6.Add("license", tb_Car.car_no);
													dictionary6.Add("licenseColor", CommonHelper.GetKaiFenglicenseColor(tb_Car.car_color));
													dictionary6.Add("cargoName", inRow2.goods_name);
													dictionary6.Add("cargoWeight", inRow2.goods_suttle);
													dictionary6.Add("cargoRecordTime", inRow2.scale_time.ToString("yyyy-MM-dd HH:mm:ss"));
													dictionary6.Add("cargoWeightUnit", "吨（T）");
													model = CommonHelper.GetKaiFengV1ResultModel(MainData.KFV1ServerIP + "/transport/record/cargo", dictionary6, MainData.KFV1Token);
													if (model != null && Convert.ToBoolean(model["success"]) && model["code"].ToString().Equals("200"))
													{
														new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
														{
															cargoName = inRow2.goods_name,
															cargoWeight = inRow2.goods_suttle
														}, (tb_CarRecord p) => p.id == item.id);
													}
												}
												tb_Weig outRow2 = list3.FirstOrDefault((tb_Weig it) => it.door_type == "出厂");
												if (outRow2 != null)
												{
													Dictionary<string, object> dictionary7 = new Dictionary<string, object>();
													dictionary7.Add("serialNum", item.serialNum);
													dictionary7.Add("companyCode", MainData.companyCodeV1);
													dictionary7.Add("gateCode", item.ChannelPort);
													dictionary7.Add("license", item.car_no);
													dictionary7.Add("licenseColor", CommonHelper.GetKaiFenglicenseColor(item.car_color));
													dictionary7.Add("cargoName", outRow2.goods_name);
													dictionary7.Add("cargoWeight", outRow2.goods_suttle);
													dictionary7.Add("cargoRecordTime", outRow2.scale_time.ToString("yyyy-MM-dd HH:mm:ss"));
													dictionary7.Add("cargoWeightUnit", "吨（T）");
													model = CommonHelper.GetKaiFengV1ResultModel(MainData.KFV1ServerIP + "/transport/record/cargo", dictionary7, MainData.KFV1Token);
													if (model != null && Convert.ToBoolean(model["success"]) && model["code"].ToString().Equals("200") && new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
													{
														cargoName = outRow2.goods_name,
														cargoWeight = outRow2.goods_suttle
													}, (tb_CarRecord p) => p.id == item.id))
													{
													}
												}
											}
										}
									}
								}
								else if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
								{
									upload_number = item.upload_number + 1,
									upload_status = "上传失败",
									platform_status = model["message"].ToString()
								}, (tb_CarRecord p) => p.id == item.id))
								{
								}
							}
						}
					}
					else if (MainData.DJPT == "安车")
					{
						text = ((!item.out_type.Equals("入口")) ? "2" : "1");
						if (CommonHelper.AnCheUpLoad(item.serialNum, item.ChannelPort, item.car_no, CommonHelper.GetKaiFenglicenseColor(item.car_color), item.add_time.ToString("yyyy-MM-dd HH:mm:ss"), item.add_time.ToString("yyyy-MM-dd HH:mm:ss"), "1", text, ref msg, CommonHelper.ImageToBase64(item.front_image), CommonHelper.ImageToBase64(item.car_image)))
						{
							if (item.front_image != null && !string.IsNullOrWhiteSpace(item.front_image))
							{
								for (int num = 0; num < 4; num++)
								{
									if (CommonHelper.AnCheUpLoadIamge(item.serialNum, item.ChannelPort, item.car_no, CommonHelper.GetKaiFenglicenseColor(item.car_color), "1", text, CommonHelper.ImageToBase64(item.front_image), item.add_time.ToString("yyyy-MM-dd HH:mm:ss"), ref msg))
									{
										break;
									}
									Thread.Sleep(500);
								}
							}
							if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_status = "上传成功"
							}, (tb_CarRecord p) => p.id == item.id))
							{
							}
						}
						else if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
						{
							upload_number = item.upload_number + 1,
							upload_status = "上传失败",
							platform_status = msg
						}, (tb_CarRecord p) => p.id == item.id))
						{
						}
					}
					else if (MainData.DJPT == "腾跃")
					{
						int num2 = -1;
						num2 = ((!item.out_type.Equals("入口")) ? MainData.TYExitChannel : MainData.TYEnterChannel);
						string path = CommonHelper.ImageToBase64(item.car_color);
						if (CommonHelper.TYSaveRecord(item.car_no, item.car_color, num2, path))
						{
							if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_status = "上传成功"
							}, (tb_CarRecord p) => p.id == item.id))
							{
							}
						}
						else if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
						{
							upload_number = item.upload_number + 1,
							upload_status = "上传失败",
							platform_status = msg
						}, (tb_CarRecord p) => p.id == item.id))
						{
						}
					}
					else if (MainData.DJPT == "天地人车")
					{
						text = ((!item.out_type.Equals("入口")) ? "2" : "1");
						if (CommonHelper.tdrcCheUpLoad(item.serialNum, item.ChannelPort, item.car_no, CommonHelper.GetKaiFenglicenseColor(item.car_color), item.add_time.ToString("yyyy-MM-dd HH:mm:ss"), item.add_time.ToString("yyyy-MM-dd HH:mm:ss"), "1", text, ref msg))
						{
							if (item.front_image != null && !string.IsNullOrWhiteSpace(item.front_image))
							{
								CommonHelper.tdrcCheUpLoadIamge(item.serialNum, item.ChannelPort, item.car_no, CommonHelper.GetKaiFenglicenseColor(item.car_color), "1", text, CommonHelper.ImageToBase64(item.front_image), item.add_time.ToString("yyyy-MM-dd HH:mm:ss"), ref msg);
							}
							if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_status = "上传成功"
							}, (tb_CarRecord p) => p.id == item.id))
							{
							}
						}
						else if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
						{
							upload_number = item.upload_number + 1,
							upload_status = "上传失败",
							platform_status = msg
						}, (tb_CarRecord p) => p.id == item.id))
						{
						}
					}
					else if (MainData.DJPT == "信阳")
					{
						text = ((!item.out_type.Equals("入口")) ? "2" : "1");
						if (CommonHelper.xyCheUpLoad(item.serialNum, item.ChannelPort, item.car_no, CommonHelper.GetKaiFenglicenseColor(item.car_color), item.add_time.ToString("yyyy-MM-dd HH:mm:ss"), item.add_time.ToString("yyyy-MM-dd HH:mm:ss"), "1", text, ref msg))
						{
							if (item.front_image != null && !string.IsNullOrWhiteSpace(item.front_image))
							{
								CommonHelper.xyCheUpLoadIamge(item.serialNum, item.ChannelPort, item.car_no, CommonHelper.GetKaiFenglicenseColor(item.car_color), "1", text, CommonHelper.ImageToBase64(item.front_image), item.add_time.ToString("yyyy-MM-dd HH:mm:ss"), ref msg);
							}
							if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_status = "上传成功"
							}, (tb_CarRecord p) => p.id == item.id))
							{
							}
						}
						else
						{
							new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_number = item.upload_number + 1,
								upload_status = "上传失败",
								platform_status = msg
							}, (tb_CarRecord p) => p.id == item.id);
						}
					}
					_ = MainData.TXIsOpen;
					Thread.Sleep(200);
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "上传数据错误:" + ex.Message);
			IsLoad = false;
		}
		IsLoad = false;
	}

	private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
	{
		New_IniFile.WriteContentValue("窗体框架配制", "SplitX", e.X.ToString(), MainData.Spath);
		New_IniFile.WriteContentValue("窗体框架配制", "SplitY", e.Y.ToString(), MainData.Spath);
	}

	private void dataGridView1_SelectionChanged(object sender, EventArgs e)
	{
		if (dataGridView1.CurrentCell == null)
		{
			return;
		}
		dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
		int index = int.Parse(dataGridView1.CurrentRow.Index.ToString());
		label2.Invoke((Action<string>)delegate(string p)
		{
			if (File.Exists(p))
			{
				Image image = Image.FromFile(p);
				Image image2 = new Bitmap(image);
				image.Dispose();
				pictureBox1.Image = image2;
			}
		}, dataGridView1.Rows[index].Cells["ImagePath"].Value);
	}

	private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
	{
		new AboutForm().ShowDialog();
	}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		if (dataGridView1.CurrentCell == null || !(dataGridView1.Columns[e.ColumnIndex].Name == "buhuo") || e.RowIndex < 0)
		{
			return;
		}
		int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
		tb_CarRecord tb_CarRecord2 = new DataServerContext<tb_CarRecord>().Current.GetList((tb_CarRecord it) => it.id == id).FirstOrDefault();
		if (tb_CarRecord2 != null)
		{
			if (tb_CarRecord2.cargoName != null && !string.IsNullOrWhiteSpace(tb_CarRecord2.cargoName))
			{
				MessageBox.Show("不可重复录入货物信息");
				return;
			}
			GoodsSetForm goodsSetForm = new GoodsSetForm();
			goodsSetForm.serialNum = tb_CarRecord2.serialNum;
			goodsSetForm.license = tb_CarRecord2.car_no;
			goodsSetForm.licenseColor = tb_CarRecord2.car_color;
			goodsSetForm.gateCode = tb_CarRecord2.ChannelPort;
			goodsSetForm.id = id;
			goodsSetForm.ShowDialog();
		}
		else
		{
			MessageBox.Show("查询数据失败，是否删除了次记录");
		}
	}

	private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void timer4_Tick(object sender, EventArgs e)
	{
		if (IsLoad || !(MainData.isInst == "2") || !MainData.IsInit)
		{
			return;
		}
		IsLoad = true;
		Task.Factory.StartNew(delegate
		{
			try
			{
				List<string> list = new List<string>();
				list.Add("腾跃1");
				list.Add("腾跃2");
				List<tb_CarRecord> list2 = new DataServerContext<tb_CarRecord>().Current.GetList((tb_CarRecord it) => list.Contains(it.upload_status) && it.upload_number < 4).ToList();
				if (list2 != null)
				{
					foreach (tb_CarRecord item in list2)
					{
						string msg = "";
						int num = -1;
						num = ((!item.out_type.Equals("入口")) ? MainData.TYExitChannel : MainData.TYEnterChannel);
						if (item.upload_status == "腾跃1" && !CommonHelper.TYVerify(item.car_no, item.car_color, num, item.front_image, ref msg))
						{
							new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_number = item.upload_number + 1,
								upload_status = "上传失败",
								platform_status = msg
							}, (tb_CarRecord p) => p.id == item.id);
						}
						if (CommonHelper.TYSaveRecord(item.car_no, item.car_color, num, item.car_image))
						{
							if (new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_status = "上传成功"
							}, (tb_CarRecord p) => p.id == item.id))
							{
							}
						}
						else
						{
							new DataServerContext<tb_CarRecord>().Current.Modify((tb_CarRecord p) => new tb_CarRecord
							{
								upload_number = item.upload_number + 1,
								upload_status = "上传失败",
								platform_status = msg
							}, (tb_CarRecord p) => p.id == item.id);
						}
						Thread.Sleep(200);
					}
				}
			}
			catch (Exception ex)
			{
				LogSave.SaveExeLog(DateTime.Now.ToString() + "上传数据错误:" + ex.Message);
				IsLoad = false;
			}
			IsLoad = false;
		});
	}

	private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
	{
		new exeRecordForm().ShowDialog();
	}

	private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\参数配置V4.43.72.exe")
			{
				UseShellExecute = true
			};
			Process process = new Process();
			process.StartInfo = startInfo;
			process.Start();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\LedshowZK\\LedshowZK.exe")
			{
				UseShellExecute = true
			};
			Process process = new Process();
			process.StartInfo = startInfo;
			process.Start();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
	{
		new FDLRecordForm().ShowDialog();
	}

	private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
	{
		new FDLYDJXForm().ShowDialog();
	}

	private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\XH\\ETH_Config_V110.exe")
			{
				UseShellExecute = true
			};
			Process process = new Process();
			process.StartInfo = startInfo;
			process.Start();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void timer5_Tick(object sender, EventArgs e)
	{
		Task.Factory.StartNew(delegate
		{
			if (DateTime.Now.Hour == 23 && DateTime.Now.Minute == 59 && DateTime.Now.DayOfWeek == DayOfWeek.Monday)
			{
				string text = Application.StartupPath + "\\database\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".bak";
				string directoryName = Path.GetDirectoryName(text);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				string cmdText = "BACKUP DATABASE [" + MainData.database + "] TO DISK = N'" + text + "' WITH NOFORMAT, NOINIT, NAME = N'" + MainData.database + "', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
				using SqlConnection sqlConnection = new SqlConnection(MainData.M_str_sqlcon);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				Console.WriteLine("数据库备份成功。");
			}
			if (DateTime.Now.Hour == 8 && DateTime.Now.Minute == 0 && MainData.DJPT == "天地人车")
			{
				List<tb_Device> tb_Device2 = new DataServerContext<tb_Device>().Current.GetList();
				if (tb_Device2 != null && tb_Device2.Count > 0)
				{
					tb_Channel model = new DataServerContext<tb_Channel>().Current.GetModel((tb_Channel it) => it.id == tb_Device2[0].ChannelNo);
					if (model != null)
					{
						tb_CarRecord model2 = new DataServerContext<tb_CarRecord>().Current.GetModel((tb_CarRecord it) => it.car_no == "豫C51L10");
						if (model2 != null)
						{
							VehicleNoInfoView vehicleNoInfoView = new VehicleNoInfoView
							{
								VehicleNo = "豫C51L10",
								AddTime = DateTime.Now,
								ChannelName = model.ChannelName,
								DeviceName = tb_Device2[0].CameraName,
								ChannelType = model.ChannelType,
								ImagePath = model2.front_image,
								licenseColor = "蓝色",
								ChannelId = tb_Device2[0].ChannelNo,
								devId = tb_Device2[0].id
							};
							string msg = "";
							if (CommonHelper.tdrcCheVerify(vehicleNoInfoView.VehicleNo, vehicleNoInfoView.licenseColor, ref msg, ref vehicleNoInfoView, model.ChannelPort))
							{
								string text2 = "A";
								text2 = ((!(model.ChannelType == "入口")) ? "B" : "A");
								vehicleNoInfoView.serialNum = MainData.tdrcEnterpriseID + model.ChannelPort + text2 + DateTime.Now.ToString("yyMMddHHmmss");
								MainData.KaiFengRecordSave(model2.car_image, model2.front_image, vehicleNoInfoView.VehicleNo, vehicleNoInfoView.licenseColor, model.ChannelType, model.id, tb_Device2[0].id, model.ChannelPort, vehicleNoInfoView.serialNum, "摆杆通行", "未上传", ref vehicleNoInfoView);
							}
						}
					}
				}
			}
			else if (DateTime.Now.Hour == 18 && DateTime.Now.Minute == 0 && MainData.DJPT == "天地人车")
			{
				List<tb_Device> tb_Device3 = new DataServerContext<tb_Device>().Current.GetList();
				if (tb_Device3 != null && tb_Device3.Count > 1)
				{
					tb_Channel model3 = new DataServerContext<tb_Channel>().Current.GetModel((tb_Channel it) => it.id == tb_Device3[1].ChannelNo);
					if (model3 != null)
					{
						tb_CarRecord model4 = new DataServerContext<tb_CarRecord>().Current.GetModel((tb_CarRecord it) => it.car_no == "豫C51L10");
						if (model4 != null)
						{
							VehicleNoInfoView vehicleNoInfoView2 = new VehicleNoInfoView
							{
								VehicleNo = "豫C51L10",
								AddTime = DateTime.Now,
								ChannelName = model3.ChannelName,
								DeviceName = tb_Device3[1].CameraName,
								ChannelType = model3.ChannelType,
								ImagePath = model4.front_image,
								licenseColor = "蓝色",
								ChannelId = tb_Device3[0].ChannelNo,
								devId = tb_Device3[1].id
							};
							string msg2 = "";
							if (CommonHelper.tdrcCheVerify(vehicleNoInfoView2.VehicleNo, vehicleNoInfoView2.licenseColor, ref msg2, ref vehicleNoInfoView2, model3.ChannelPort))
							{
								string text3 = "A";
								text3 = ((!(model3.ChannelType == "入口")) ? "B" : "A");
								vehicleNoInfoView2.serialNum = MainData.tdrcEnterpriseID + model3.ChannelPort + text3 + DateTime.Now.ToString("yyMMddHHmmss");
								MainData.KaiFengRecordSave(model4.car_image, model4.front_image, vehicleNoInfoView2.VehicleNo, vehicleNoInfoView2.licenseColor, model3.ChannelType, model3.id, tb_Device3[1].id, model3.ChannelPort, vehicleNoInfoView2.serialNum, "摆杆通行", "未上传", ref vehicleNoInfoView2);
							}
						}
					}
				}
			}
		});
	}

	private void tableLayoutPanel2_SizeChanged(object sender, EventArgs e)
	{
		TableLayoutColumnStyleCollection columnStyles = tableLayoutPanel2.ColumnStyles;
		TableLayoutRowStyleCollection rowStyles = tableLayoutPanel2.RowStyles;
		if (rows != 0 && column != 0)
		{
			int num = tableLayoutPanel2.Height / rows;
			for (int i = 0; i < rows; i++)
			{
				rowStyles[i].Height = num;
			}
			int num2 = tableLayoutPanel2.Width / column;
			for (int j = 0; j < column; j++)
			{
				columnStyles[j].Width = num2;
			}
		}
	}

	private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
	{
		new thirdPartytForm().ShowDialog();
	}

	private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			IntPtr logHandle = DHSDK.LXJLogin(MainData.jhjIp, MainData.jhjzh, MainData.jhjmm);
			LogSave.DHLog(DateTime.Now.ToString() + "intPtr" + logHandle + "；；；；jhjIp=" + MainData.jhjIp + "；；；jhjzh=" + MainData.jhjzh + "；；；jhjmm=" + MainData.jhjmm);
			DateTime now = DateTime.Now;
			new DHSDK().Download(now.AddMinutes(-6.0), now.AddMinutes(-5.0), 0, 1, logHandle);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "测试大华下载异常" + ex.ToString());
		}
	}

	private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
	{
		tb_CarRecord tb_CarRecord2 = (from it in new DataServerContext<tb_CarRecord>().Current.GetList((tb_CarRecord it) => it.car_no == "豫A6S2D9" && it.add_time >= DateTime.Now.Date)
			orderby it.id descending
			select it).FirstOrDefault();
		if (tb_CarRecord2 != null)
		{
			MessageBox.Show(JsonConvert.SerializeObject(tb_CarRecord2));
		}
	}

	private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
	{
		new csForm().ShowDialog();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.bar2 = new DevExpress.XtraBars.Bar();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem18 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem20 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem21 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem22 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem23 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.timer2 = new System.Windows.Forms.Timer(this.components);
		this.timer3 = new System.Windows.Forms.Timer(this.components);
		this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
		this.label3 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.buhuo = new System.Windows.Forms.DataGridViewButtonColumn();
		this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.splitter1 = new System.Windows.Forms.Splitter();
		this.timer4 = new System.Windows.Forms.Timer(this.components);
		this.timer5 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		this.tableLayoutPanel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		base.SuspendLayout();
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(1545, 40);
		this.barDockControlRight.Manager = null;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 847);
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.bar2 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControl1);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[25]
		{
			this.barButtonItem1, this.barButtonItem2, this.barButtonItem3, this.barButtonItem4, this.barButtonItem5, this.barButtonItem6, this.barSubItem1, this.barButtonItem7, this.barButtonItem8, this.barButtonItem9,
			this.barButtonItem10, this.barButtonItem11, this.barButtonItem12, this.barButtonItem13, this.barButtonItem14, this.barSubItem2, this.barButtonItem15, this.barButtonItem16, this.barButtonItem17, this.barButtonItem18,
			this.barButtonItem19, this.barButtonItem20, this.barButtonItem21, this.barButtonItem22, this.barButtonItem23
		});
		this.barManager1.MainMenu = this.bar2;
		this.barManager1.MaxItemId = 122;
		this.bar2.BarName = "Main menu";
		this.bar2.DockCol = 0;
		this.bar2.DockRow = 0;
		this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[12]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem12, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem13, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem14, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem5, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem6, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem10, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.bar2.OptionsBar.MultiLine = true;
		this.bar2.OptionsBar.UseWholeRow = true;
		this.bar2.Text = "Main menu";
		this.barButtonItem1.Caption = "相机设备";
		this.barButtonItem1.Id = 94;
		this.barButtonItem1.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.ide_32x32;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "通道管理";
		this.barButtonItem2.Id = 96;
		this.barButtonItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.reverssort_32x32;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem12.Caption = "大屏管理";
		this.barButtonItem12.Id = 108;
		this.barButtonItem12.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.tableofcontent_32x32;
		this.barButtonItem12.Name = "barButtonItem12";
		this.barButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem12_ItemClick);
		this.barButtonItem13.Caption = "云台管理";
		this.barButtonItem13.Id = 109;
		this.barButtonItem13.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.show_32x321;
		this.barButtonItem13.Name = "barButtonItem13";
		this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem13_ItemClick);
		this.barButtonItem14.Caption = "通行记录";
		this.barButtonItem14.Id = 110;
		this.barButtonItem14.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.verticalgridlinesnone_32x32;
		this.barButtonItem14.Name = "barButtonItem14";
		this.barButtonItem14.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem14_ItemClick);
		this.barButtonItem5.Caption = "业务台账";
		this.barButtonItem5.Id = 99;
		this.barButtonItem5.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.reading_32x32;
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.barButtonItem6.Caption = "车牌管理";
		this.barButtonItem6.Id = 100;
		this.barButtonItem6.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.newcontact_32x32;
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barSubItem1.Caption = "运维工具";
		this.barSubItem1.Id = 102;
		this.barSubItem1.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.chartyaxissettings_32x321;
		this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[10]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem8, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem9, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem11, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem18, true),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem17, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem20, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem21),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem22),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem23)
		});
		this.barSubItem1.Name = "barSubItem1";
		this.barButtonItem7.Caption = "[测试]上传诊断";
		this.barButtonItem7.Id = 103;
		this.barButtonItem7.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.nextcomment_32x32;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem7_ItemClick);
		this.barButtonItem8.Caption = "数据库设置";
		this.barButtonItem8.Id = 104;
		this.barButtonItem8.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.managedatasource_32x32;
		this.barButtonItem8.Name = "barButtonItem8";
		this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem8_ItemClick);
		this.barButtonItem9.Caption = "历史数据上传";
		this.barButtonItem9.Id = 105;
		this.barButtonItem9.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.bookmark_32x32;
		this.barButtonItem9.Name = "barButtonItem9";
		this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem9_ItemClick);
		this.barButtonItem11.Caption = "车牌补录";
		this.barButtonItem11.Id = 107;
		this.barButtonItem11.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.sendbackward_32x32;
		this.barButtonItem11.Name = "barButtonItem11";
		this.barButtonItem11.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem11_ItemClick);
		this.barButtonItem18.Caption = "非道路机械登记";
		this.barButtonItem18.Id = 116;
		this.barButtonItem18.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.insert_32x32;
		this.barButtonItem18.Name = "barButtonItem18";
		this.barButtonItem18.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem18_ItemClick);
		this.barButtonItem17.Caption = "非道路机械补录";
		this.barButtonItem17.Id = 115;
		this.barButtonItem17.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.switchrowcolumn_32x32;
		this.barButtonItem17.Name = "barButtonItem17";
		this.barButtonItem17.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem17_ItemClick);
		this.barButtonItem20.Caption = "第三方接口对接";
		this.barButtonItem20.Id = 118;
		this.barButtonItem20.Name = "barButtonItem20";
		this.barButtonItem20.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem20_ItemClick);
		this.barButtonItem21.Caption = "[测试]大华视频下载";
		this.barButtonItem21.Id = 119;
		this.barButtonItem21.Name = "barButtonItem21";
		this.barButtonItem21.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem21_ItemClick);
		this.barButtonItem22.Caption = "[测试]海康视频下载";
		this.barButtonItem22.Id = 120;
		this.barButtonItem22.Name = "barButtonItem22";
		this.barButtonItem22.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem22_ItemClick);
		this.barButtonItem23.Caption = "[测试]颜色调试";
		this.barButtonItem23.Id = 121;
		this.barButtonItem23.Name = "barButtonItem23";
		this.barButtonItem23.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem23_ItemClick);
		this.barButtonItem3.Caption = "系统设置";
		this.barButtonItem3.Id = 97;
		this.barButtonItem3.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.properties_32x32;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barSubItem2.Caption = "工具下载";
		this.barSubItem2.Id = 112;
		this.barSubItem2.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.iconsetredtoblack4_32x32;
		this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[3]
		{
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem15, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem16, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
			new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem19, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
		});
		this.barSubItem2.Name = "barSubItem2";
		this.barButtonItem15.Caption = "LED联动配置";
		this.barButtonItem15.Id = 113;
		this.barButtonItem15.ImageOptions.Image = BulkMaterialsForm.Properties.Resources._3dclusteredcolumn_32x32;
		this.barButtonItem15.Name = "barButtonItem15";
		this.barButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem15_ItemClick);
		this.barButtonItem16.Caption = "LED屏工具";
		this.barButtonItem16.Id = 114;
		this.barButtonItem16.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.greenyellow_32x32;
		this.barButtonItem16.Name = "barButtonItem16";
		this.barButtonItem16.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem16_ItemClick);
		this.barButtonItem19.Caption = "报警主机工具";
		this.barButtonItem19.Id = 117;
		this.barButtonItem19.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.record_32x32;
		this.barButtonItem19.Name = "barButtonItem19";
		this.barButtonItem19.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem19_ItemClick);
		this.barButtonItem10.Caption = "关于";
		this.barButtonItem10.Id = 106;
		this.barButtonItem10.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.label_32x32;
		this.barButtonItem10.Name = "barButtonItem10";
		this.barButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem10_ItemClick);
		this.barButtonItem4.Caption = "退出系统";
		this.barButtonItem4.Id = 98;
		this.barButtonItem4.ImageOptions.Image = BulkMaterialsForm.Properties.Resources.close_32x321;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(1400, 40);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 800);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(1400, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 760);
		this.barDockControl1.CausesValidation = false;
		this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControl1.Location = new System.Drawing.Point(1400, 40);
		this.barDockControl1.Manager = this.barManager1;
		this.barDockControl1.Size = new System.Drawing.Size(0, 760);
		this.timer1.Enabled = true;
		this.timer1.Interval = 600000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.timer2.Enabled = true;
		this.timer2.Interval = 6600000;
		this.timer2.Tick += new System.EventHandler(timer2_Tick);
		this.timer3.Enabled = true;
		this.timer3.Interval = 1000;
		this.timer3.Tick += new System.EventHandler(timer3_Tick);
		this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.tableLayoutPanel3.ColumnCount = 1;
		this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel3.Controls.Add(this.label3, 0, 3);
		this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 2);
		this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
		this.tableLayoutPanel3.Controls.Add(this.label4, 0, 4);
		this.tableLayoutPanel3.Controls.Add(this.label2, 0, 5);
		this.tableLayoutPanel3.Controls.Add(this.dataGridView1, 0, 6);
		this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel3.Location = new System.Drawing.Point(840, 40);
		this.tableLayoutPanel3.Name = "tableLayoutPanel3";
		this.tableLayoutPanel3.RowCount = 7;
		this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.38095f));
		this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50f));
		this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.61904f));
		this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.tableLayoutPanel3.Size = new System.Drawing.Size(560, 760);
		this.tableLayoutPanel3.TabIndex = 1;
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label3.Location = new System.Drawing.Point(255, 404);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(37, 17);
		this.label3.TabIndex = 1;
		this.label3.Text = "123";
		this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureBox1.Location = new System.Drawing.Point(4, 36);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(539, 360);
		this.pictureBox1.TabIndex = 1;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.DoubleClick += new System.EventHandler(pictureBox1_DoubleClick);
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(236, 5);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(74, 17);
		this.label1.TabIndex = 0;
		this.label1.Text = "识别图片";
		this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("微软雅黑", 9f);
		this.label4.ForeColor = System.Drawing.Color.Red;
		this.label4.Location = new System.Drawing.Point(246, 435);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(55, 17);
		this.label4.TabIndex = 6;
		this.label4.Text = "label4";
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.ForeColor = System.Drawing.Color.Red;
		this.label2.Location = new System.Drawing.Point(160, 471);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(227, 17);
		this.label2.TabIndex = 2;
		this.label2.Text = "豫A00000,请通行！";
		this.dataGridView1.AllowUserToAddRows = false;
		this.dataGridView1.AllowUserToDeleteRows = false;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Columns.AddRange(this.buhuo);
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dataGridView1.Location = new System.Drawing.Point(4, 516);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowTemplate.Height = 26;
		this.dataGridView1.Size = new System.Drawing.Size(539, 327);
		this.dataGridView1.TabIndex = 5;
		this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
		this.dataGridView1.SelectionChanged += new System.EventHandler(dataGridView1_SelectionChanged);
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.NullValue = "货物补录";
		this.buhuo.DefaultCellStyle = dataGridViewCellStyle;
		this.buhuo.HeaderText = "货物补录";
		this.buhuo.Name = "buhuo";
		this.buhuo.ReadOnly = true;
		this.buhuo.Text = "货物补录";
		this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.tableLayoutPanel2.ColumnCount = 1;
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 40);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(840, 760);
		this.tableLayoutPanel2.TabIndex = 6;
		this.tableLayoutPanel2.SizeChanged += new System.EventHandler(tableLayoutPanel2_SizeChanged);
		this.splitter1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.splitter1.Location = new System.Drawing.Point(840, 40);
		this.splitter1.Name = "splitter1";
		this.splitter1.Size = new System.Drawing.Size(2, 847);
		this.splitter1.TabIndex = 7;
		this.splitter1.MinSize = 300;
		this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(splitter1_SplitterMoved);
		this.timer4.Interval = 1000;
		this.timer4.Tick += new System.EventHandler(timer4_Tick);
		this.timer5.Enabled = true;
		this.timer5.Interval = 60000;
		this.timer5.Tick += new System.EventHandler(timer5_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.MinimumSize = new System.Drawing.Size(1200, 700);
		base.ClientSize = new System.Drawing.Size(1400, 800);
		base.Controls.Add(this.splitter1);
		base.Controls.Add(this.tableLayoutPanel3);
		base.Controls.Add(this.tableLayoutPanel2);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControl1);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "FormMain";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.SizeChanged += new System.EventHandler(FormMain_SizeChanged);
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.tableLayoutPanel3.ResumeLayout(false);
		this.tableLayoutPanel3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
