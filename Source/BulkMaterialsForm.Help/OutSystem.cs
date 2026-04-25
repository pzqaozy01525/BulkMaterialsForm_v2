// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.OutSystem

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BulkMaterialsForm.Model.View;
using BulkMaterialsForm.Views;

namespace BulkMaterialsForm.Help;

public class OutSystem
{
	public delegate void CarOutRecord(VehicleNoInfoView vehicleNoInfoView);

	public List<VehicleNoInfoView> vehicleNoInfoViews = new List<VehicleNoInfoView>();

	public static List<ConfimVehicleForm> outVehicle = new List<ConfimVehicleForm>();

	private static Thread videoNetThread;

	private static object userLock = new object();

	public static event CarOutRecord carOutRecord;

	public void StartThread(VehicleNoInfoView vehicleNoInfoView)
	{
		vehicleNoInfoViews.Add(vehicleNoInfoView);
		videoNetThread = new Thread(doExecFlowTask);
		videoNetThread.IsBackground = true;
		videoNetThread.Start();
	}

	public static void AddOut(VehicleNoInfoView vehicleNoInfoView)
	{
		outVehicle.FirstOrDefault((ConfimVehicleForm it) => it.vehicleNoInfoView.ChannelId == vehicleNoInfoView.ChannelId)?.Close();
		new OutSystem().StartThread(vehicleNoInfoView);
	}

	private void doExecFlowTask()
	{
		while (vehicleNoInfoViews.Count > 0)
		{
			lock (userLock)
			{
				ConfimVehicleForm confimVehicleForm = new ConfimVehicleForm();
				confimVehicleForm.vehicleNoInfoView = vehicleNoInfoViews[0];
				confimVehicleForm.TopMost = true;
				outVehicle.Add(confimVehicleForm);
				confimVehicleForm.ShowDialog();
				if (confimVehicleForm.isSave)
				{
					confimVehicleForm.vehicleNoInfoView.IsRelease = true;
				}
				else
				{
					confimVehicleForm.vehicleNoInfoView.IsRelease = false;
					confimVehicleForm.vehicleNoInfoView.TrafficStatus = "禁止通行";
					confimVehicleForm.vehicleNoInfoView.ExeLog = "人工禁止通行";
				}
				if (OutSystem.carOutRecord != null)
				{
					OutSystem.carOutRecord(vehicleNoInfoViews[0]);
				}
				outVehicle.Remove(confimVehicleForm);
				vehicleNoInfoViews.Remove(vehicleNoInfoViews[0]);
			}
		}
	}
}
