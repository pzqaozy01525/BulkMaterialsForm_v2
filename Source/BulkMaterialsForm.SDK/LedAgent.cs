// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.LedAgent

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace BulkMaterialsForm.SDK;

public class LedAgent
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void OnDeviceNotify(uint uDeviceId, IntPtr pNotifiedData, uint uCommand, IntPtr pUserParam);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int GetVersion();

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int Init(string sIp = null, uint uPort = 60000u, uint uHeartBeatTimeout = 10000u, string sDeviceType = "ZH_E1L");

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int DeInit();

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern uint RegisterDevice(string sIp, uint uPort, OnDeviceNotify fNotify, IntPtr pUserParam);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int UnregisterDevice(uint uDevId);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int OpenDevice(uint uDeviceId);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int CloseDevice(uint uDeviceId);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int SetDeviceLightness(uint uDevId, uint uLightnessValue);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int ShowInstantText(uint uDevId, uint uEncodeMode, uint uColor, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pText, uint uField);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int HideInstantText(uint uDevId, uint uField);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int UpdateDeviceText(uint uDevId, uint uStringIndex, uint uEncodeMode, uint uColor, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pText, uint uField);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int SwitchDeviceText(uint uDevId, int StringIndex, uint uField);

	[DllImport("\\DPZH\\TriColorSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int DeleteDeviceText(uint uDevId, uint uStringIndex, uint uField);
}
