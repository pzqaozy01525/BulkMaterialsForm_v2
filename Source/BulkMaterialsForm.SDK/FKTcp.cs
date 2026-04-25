// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.FKTcp

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;

namespace BulkMaterialsForm.SDK;

public class FKTcp : IDisposable
{
	public struct TEXT_CONTEXT
	{
		public byte LID;

		public byte DisMode;

		public byte DelayTime;

		public byte DisTimes;

		public uint TextColor;

		public string Text;
	}

	public const uint LED_COLOR_RED = 255u;

	public const uint LED_COLOR_GREEN = 65280u;

	public const uint LED_COLOR_YEELOW = 65535u;

	public readonly uint[] ColorMap = new uint[8] { 255u, 65280u, 16711680u, 65535u, 16776960u, 16711935u, 16777215u, 0u };

	private static byte[] _CRCHi = new byte[256]
	{
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
		128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
		129, 64, 1, 192, 128, 65, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
		129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
		129, 64, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
		128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
		129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64
	};

	private static byte[] _CRCLo = new byte[256]
	{
		0, 192, 193, 1, 195, 3, 2, 194, 198, 6,
		7, 199, 5, 197, 196, 4, 204, 12, 13, 205,
		15, 207, 206, 14, 10, 202, 203, 11, 201, 9,
		8, 200, 216, 24, 25, 217, 27, 219, 218, 26,
		30, 222, 223, 31, 221, 29, 28, 220, 20, 212,
		213, 21, 215, 23, 22, 214, 210, 18, 19, 211,
		17, 209, 208, 16, 240, 48, 49, 241, 51, 243,
		242, 50, 54, 246, 247, 55, 245, 53, 52, 244,
		60, 252, 253, 61, 255, 63, 62, 254, 250, 58,
		59, 251, 57, 249, 248, 56, 40, 232, 233, 41,
		235, 43, 42, 234, 238, 46, 47, 239, 45, 237,
		236, 44, 228, 36, 37, 229, 39, 231, 230, 38,
		34, 226, 227, 35, 225, 33, 32, 224, 160, 96,
		97, 161, 99, 163, 162, 98, 102, 166, 167, 103,
		165, 101, 100, 164, 108, 172, 173, 109, 175, 111,
		110, 174, 170, 106, 107, 171, 105, 169, 168, 104,
		120, 184, 185, 121, 187, 123, 122, 186, 190, 126,
		127, 191, 125, 189, 188, 124, 180, 116, 117, 181,
		119, 183, 182, 118, 114, 178, 179, 115, 177, 113,
		112, 176, 80, 144, 145, 81, 147, 83, 82, 146,
		150, 86, 87, 151, 85, 149, 148, 84, 156, 92,
		93, 157, 95, 159, 158, 94, 90, 154, 155, 91,
		153, 89, 88, 152, 136, 72, 73, 137, 75, 139,
		138, 74, 78, 142, 143, 79, 141, 77, 76, 140,
		68, 132, 133, 69, 135, 71, 70, 134, 130, 66,
		67, 131, 65, 129, 128, 64
	};

	public static byte[] LED_MuiltLineDisAndPlayVoice(TEXT_CONTEXT[] TextContext, string VoiceText, byte SaveFlag, string host)
	{
		byte[] Buff = new byte[255];
		byte b = (byte)TextContext.Length;
		int num = 0;
		Buff[num++] = 0;
		Buff[num++] = 100;
		Buff[num++] = byte.MaxValue;
		Buff[num++] = byte.MaxValue;
		Buff[num++] = 110;
		Buff[num++] = 0;
		Buff[num++] = SaveFlag;
		Buff[num++] = b;
		for (int i = 0; i < b; i++)
		{
			Buff[num++] = TextContext[i].LID;
			Buff[num++] = TextContext[i].DisMode;
			Buff[num++] = 1;
			Buff[num++] = TextContext[i].DelayTime;
			Buff[num++] = TextContext[i].DisTimes;
			Buff[num++] = (byte)(TextContext[i].TextColor & 0xFF);
			Buff[num++] = (byte)((TextContext[i].TextColor >> 8) & 0xFF);
			Buff[num++] = (byte)((TextContext[i].TextColor >> 16) & 0xFF);
			Buff[num++] = (byte)((TextContext[i].TextColor >> 24) & 0xFF);
			byte[] bytes = Encoding.Default.GetBytes(TextContext[i].Text);
			if (num + bytes.Length >= 255)
			{
				return Buff;
			}
			Buff[num++] = (byte)bytes.Length;
			for (int j = 0; j < bytes.Length; j++)
			{
				Buff[num++] = bytes[j];
			}
			if (i == b - 1)
			{
				Buff[num++] = 0;
			}
			else
			{
				Buff[num++] = 13;
			}
		}
		byte[] bytes2 = Encoding.Default.GetBytes(VoiceText);
		if (bytes2.Length != 0)
		{
			Buff[num++] = 10;
			Buff[num++] = (byte)bytes2.Length;
			if (num + bytes2.Length >= 255)
			{
				return Buff;
			}
			for (int k = 0; k < bytes2.Length; k++)
			{
				Buff[num++] = bytes2[k];
			}
		}
		else
		{
			Buff[num++] = 0;
		}
		Buff[num++] = 0;
		Buff[5] = (byte)(num - 6);
		ushort num2 = MB_CRC16(ref Buff, num);
		Buff[num++] = (byte)(num2 & 0xFF);
		Buff[num++] = (byte)((num2 >> 8) & 0xFF);
		SnedTransmission(Buff, num, host);
		return Buff;
	}

	public static void Send(VehicleNoInfoView vehicleNoInfo)
	{
		tb_large_screen model = new DataServerContext<tb_large_screen>().Current.GetModel((tb_large_screen it) => it.id == vehicleNoInfo.largeId);
		if (model == null)
		{
			return;
		}
		List<tb_large_screen_detaile> list = new DataServerContext<tb_large_screen_detaile>().Current.GetList((tb_large_screen_detaile it) => it.largeId == vehicleNoInfo.largeId);
		if (list == null)
		{
			return;
		}
		TEXT_CONTEXT[] array = new TEXT_CONTEXT[list.Count];
		int num = 0;
		foreach (tb_large_screen_detaile item in list)
		{
			array[num].LID = Convert.ToByte(item.charId);
			array[num].DisMode = 10;
			array[num].DelayTime = 0;
			array[num].DisTimes = 0;
			array[num].TextColor = 255u;
			array[num].Text = item.customText.Replace("{车牌号}", vehicleNoInfo.VehicleNo).Replace("{排放阶段}", vehicleNoInfo.emissionStandard).Replace("{燃油类型}", vehicleNoInfo.fuelType)
				.Replace("{通行状态}", vehicleNoInfo.TrafficStatus)
				.Replace("{验证提示}", vehicleNoInfo.ExeLog);
			num++;
		}
		LED_MuiltLineDisAndPlayVoice(array, "", 0, model.IP);
	}

	private static readonly Dictionary<string, Socket> _socketPool = new Dictionary<string, Socket>();
	private static readonly Dictionary<string, DateTime> _lastActiveTime = new Dictionary<string, DateTime>();
	private static readonly object _poolLock = new object();
	private const int PoolTimeoutMinutes = 30;

	public static Socket GetConnection(string host)
	{
		lock (_poolLock)
		{
			if (_socketPool.TryGetValue(host, out var socket) && IsSocketConnected(socket))
			{
				_lastActiveTime[host] = DateTime.Now;
				return socket;
			}
			CloseSocket(socket);
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
			{
				SendTimeout = 3000,
				ReceiveTimeout = 3000
			};
			var result = socket.BeginConnect(host, 8800, null, null);
			if (!result.AsyncWaitHandle.WaitOne(3000))
			{
				socket.Close();
				throw new SocketException((int)SocketError.TimedOut);
			}
			socket.EndConnect(result);
			_socketPool[host] = socket;
			_lastActiveTime[host] = DateTime.Now;
			return socket;
		}
	}

	private static bool IsSocketConnected(Socket socket)
	{
		if (socket == null) return false;
		try
		{
			return !(socket.Poll(1000, SelectMode.SelectError) && socket.Available == 0);
		}
		catch { return false; }
	}

	private static void CloseSocket(Socket socket)
	{
		try { socket?.Close(); } catch { }
	}

	public static void ClosePool()
	{
		lock (_poolLock)
		{
			foreach (var s in _socketPool.Values)
				CloseSocket(s);
			_socketPool.Clear();
			_lastActiveTime.Clear();
		}
	}

	public static void CleanupIdleConnections()
	{
		lock (_poolLock)
		{
			var expired = new List<string>();
			foreach (var kvp in _lastActiveTime)
			{
				if ((DateTime.Now - kvp.Value).TotalMinutes >= PoolTimeoutMinutes)
					expired.Add(kvp.Key);
			}
			foreach (var key in expired)
			{
				if (_socketPool.TryGetValue(key, out var s))
					CloseSocket(s);
				_socketPool.Remove(key);
				_lastActiveTime.Remove(key);
			}
		}
	}

	public static void SnedTransmission(byte[] Buff, int Len, string host)
	{
		Socket socket = null;
		try
		{
			socket = GetConnection(host);
			lock (socket)
			{
				socket.Send(Buff, Len, SocketFlags.None);
			}
		}
		catch (SocketException ex)
		{
			lock (_poolLock)
			{
				CloseSocket(socket);
				_socketPool.Remove(host);
				_lastActiveTime.Remove(host);
			}
			BulkMaterialsForm.Help.LogSave.SaveExeLog($"[FKTcp] 发送失败，{host}:8800，{ex.Message}");
		}
		catch (Exception ex2)
		{
			BulkMaterialsForm.Help.LogSave.SaveExeLog($"[FKTcp] 异常，{host}:8800，{ex2.Message}");
		}
	}

	public void Dispose()
	{
		ClosePool();
	}

	private static ushort MB_CRC16(ref byte[] Buff, int count)
	{
		byte b = byte.MaxValue;
		byte b2 = byte.MaxValue;
		int num = 0;
		while (count-- > 0)
		{
			int num2 = b2 ^ Buff[num++];
			b2 = (byte)(b ^ _CRCHi[num2]);
			b = _CRCLo[num2];
		}
		return (ushort)((b << 8) | b2);
	}
}
