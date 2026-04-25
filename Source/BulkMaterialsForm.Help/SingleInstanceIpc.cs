// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.SingleInstanceIpc

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.Help;

public static class SingleInstanceIpc
{
	private const string MessageName = "BulkMaterialsForm_ShowMainWindow";

	private static readonly int _msgId = RegisterWindowMessage("BulkMaterialsForm_ShowMainWindow");

	private static readonly IntPtr HWND_BROADCAST = new IntPtr(65535);

	public static int MessageId => _msgId;

	[DllImport("user32", CharSet = CharSet.Auto)]
	private static extern int RegisterWindowMessage(string lpString);

	[DllImport("user32", SetLastError = true)]
	private static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

	public static void BroadcastShowMainWindow()
	{
		try
		{
			if (_msgId != 0)
			{
				PostMessage(HWND_BROADCAST, _msgId, IntPtr.Zero, IntPtr.Zero);
			}
		}
		catch
		{
		}
	}
}
