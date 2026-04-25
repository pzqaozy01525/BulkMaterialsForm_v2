using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BulkMaterialsForm.SDK;

public class WindowsXFTTSUtils
{
	public enum ErrorCode
	{
		MSP_SUCCESS = 0,
		MSP_ERROR_FAIL = -1,
		MSP_ERROR_EXCEPTION = -2,
		MSP_ERROR_GENERAL = 10100,
		MSP_ERROR_OUT_OF_MEMORY = 10101,
		MSP_ERROR_FILE_NOT_FOUND = 10102,
		MSP_ERROR_NOT_SUPPORT = 10103,
		MSP_ERROR_NOT_IMPLEMENT = 10104,
		MSP_ERROR_ACCESS = 10105,
		MSP_ERROR_INVALID_PARA = 10106,
		MSP_ERROR_INVALID_PARA_VALUE = 10107,
		MSP_ERROR_INVALID_HANDLE = 10108,
		MSP_ERROR_INVALID_DATA = 10109,
		MSP_ERROR_NO_LICENSE = 10110,
		MSP_ERROR_NOT_INIT = 10111,
		MSP_ERROR_NULL_HANDLE = 10112,
		MSP_ERROR_OVERFLOW = 10113,
		MSP_ERROR_TIME_OUT = 10114,
		MSP_ERROR_OPEN_FILE = 10115,
		MSP_ERROR_NOT_FOUND = 10116,
		MSP_ERROR_NO_ENOUGH_BUFFER = 10117,
		MSP_ERROR_NO_DATA = 10118,
		MSP_ERROR_NO_MORE_DATA = 10119,
		MSP_ERROR_SKIPPED = 10120,
		MSP_ERROR_ALREADY_EXIST = 10121,
		MSP_ERROR_LOAD_MODULE = 10122,
		MSP_ERROR_BUSY = 10123,
		MSP_ERROR_INVALID_CONFIG = 10124,
		MSP_ERROR_VERSION_CHECK = 10125,
		MSP_ERROR_CANCELED = 10126,
		MSP_ERROR_INVALID_MEDIA_TYPE = 10127,
		MSP_ERROR_CONFIG_INITIALIZE = 10128,
		MSP_ERROR_CREATE_HANDLE = 10129,
		MSP_ERROR_CODING_LIB_NOT_LOAD = 10130,
		MSP_ERROR_NET_GENERAL = 10200,
		MSP_ERROR_NET_OPENSOCK = 10201,
		MSP_ERROR_NET_CONNECTSOCK = 10202,
		MSP_ERROR_NET_ACCEPTSOCK = 10203,
		MSP_ERROR_NET_SENDSOCK = 10204,
		MSP_ERROR_NET_RECVSOCK = 10205,
		MSP_ERROR_NET_INVALIDSOCK = 10206,
		MSP_ERROR_NET_BADADDRESS = 10207,
		MSP_ERROR_NET_BINDSEQUENCE = 10208,
		MSP_ERROR_NET_NOTOPENSOCK = 10209,
		MSP_ERROR_NET_NOTBIND = 10210,
		MSP_ERROR_NET_NOTLISTEN = 10211,
		MSP_ERROR_NET_CONNECTCLOSE = 10212,
		MSP_ERROR_NET_NOTDGRAMSOCK = 10213,
		MSP_ERROR_MSG_GENERAL = 10300,
		MSP_ERROR_MSG_PARSE_ERROR = 10301,
		MSP_ERROR_MSG_BUILD_ERROR = 10302,
		MSP_ERROR_MSG_PARAM_ERROR = 10303,
		MSP_ERROR_MSG_CONTENT_EMPTY = 10304,
		MSP_ERROR_MSG_INVALID_CONTENT_TYPE = 10305,
		MSP_ERROR_MSG_INVALID_CONTENT_LENGTH = 10306,
		MSP_ERROR_MSG_INVALID_CONTENT_ENCODE = 10307,
		MSP_ERROR_MSG_INVALID_KEY = 10308,
		MSP_ERROR_MSG_KEY_EMPTY = 10309,
		MSP_ERROR_MSG_SESSION_ID_EMPTY = 10310,
		MSP_ERROR_MSG_LOGIN_ID_EMPTY = 10311,
		MSP_ERROR_MSG_SYNC_ID_EMPTY = 10312,
		MSP_ERROR_MSG_APP_ID_EMPTY = 10313,
		MSP_ERROR_MSG_EXTERN_ID_EMPTY = 10314,
		MSP_ERROR_MSG_INVALID_CMD = 10315,
		MSP_ERROR_MSG_INVALID_SUBJECT = 10316,
		MSP_ERROR_MSG_INVALID_VERSION = 10317,
		MSP_ERROR_MSG_NO_CMD = 10318,
		MSP_ERROR_MSG_NO_SUBJECT = 10319,
		MSP_ERROR_MSG_NO_VERSION = 10320,
		MSP_ERROR_MSG_MSSP_EMPTY = 10321,
		MSP_ERROR_MSG_NEW_RESPONSE = 10322,
		MSP_ERROR_MSG_NEW_CONTENT = 10323,
		MSP_ERROR_MSG_INVALID_SESSION_ID = 10324,
		MSP_ERROR_DB_GENERAL = 10400,
		MSP_ERROR_DB_EXCEPTION = 10401,
		MSP_ERROR_DB_NO_RESULT = 10402,
		MSP_ERROR_DB_INVALID_USER = 10403,
		MSP_ERROR_DB_INVALID_PWD = 10404,
		MSP_ERROR_DB_CONNECT = 10405,
		MSP_ERROR_DB_INVALID_SQL = 10406,
		MSP_ERROR_DB_INVALID_APPID = 10407,
		MSP_ERROR_RES_GENERAL = 10500,
		MSP_ERROR_RES_LOAD = 10501,
		MSP_ERROR_RES_FREE = 10502,
		MSP_ERROR_RES_MISSING = 10503,
		MSP_ERROR_RES_INVALID_NAME = 10504,
		MSP_ERROR_RES_INVALID_ID = 10505,
		MSP_ERROR_RES_INVALID_IMG = 10506,
		MSP_ERROR_RES_WRITE = 10507,
		MSP_ERROR_RES_LEAK = 10508,
		MSP_ERROR_RES_HEAD = 10509,
		MSP_ERROR_RES_DATA = 10510,
		MSP_ERROR_RES_SKIP = 10511,
		MSP_ERROR_TTS_GENERAL = 10600,
		MSP_ERROR_TTS_TEXTEND = 10601,
		MSP_ERROR_TTS_TEXT_EMPTY = 10602,
		MSP_ERROR_REC_GENERAL = 10700,
		MSP_ERROR_REC_INACTIVE = 10701,
		MSP_ERROR_REC_GRAMMAR_ERROR = 10702,
		MSP_ERROR_REC_NO_ACTIVE_GRAMMARS = 10703,
		MSP_ERROR_REC_DUPLICATE_GRAMMAR = 10704,
		MSP_ERROR_REC_INVALID_MEDIA_TYPE = 10705,
		MSP_ERROR_REC_INVALID_LANGUAGE = 10706,
		MSP_ERROR_REC_URI_NOT_FOUND = 10707,
		MSP_ERROR_REC_URI_TIMEOUT = 10708,
		MSP_ERROR_REC_URI_FETCH_ERROR = 10709,
		MSP_ERROR_EP_GENERAL = 10800,
		MSP_ERROR_EP_NO_SESSION_NAME = 10801,
		MSP_ERROR_EP_INACTIVE = 10802,
		MSP_ERROR_EP_INITIALIZED = 10803,
		MSP_ERROR_TUV_GENERAL = 10900,
		MSP_ERROR_TUV_GETHIDPARAM = 10901,
		MSP_ERROR_TUV_TOKEN = 10902,
		MSP_ERROR_TUV_CFGFILE = 10903,
		MSP_ERROR_TUV_RECV_CONTENT = 10904,
		MSP_ERROR_TUV_VERFAIL = 10905,
		MSP_ERROR_IMTV_SUCCESS = 11000,
		MSP_ERROR_IMTV_NO_LICENSE = 11001,
		MSP_ERROR_IMTV_SESSIONID_INVALID = 11002,
		MSP_ERROR_IMTV_SESSIONID_ERROR = 11003,
		MSP_ERROR_IMTV_UNLOGIN = 11004,
		MSP_ERROR_IMTV_SYSTEM_ERROR = 11005,
		MSP_ERROR_HCR_GENERAL = 11100,
		MSP_ERROR_HCR_RESOURCE_NOT_EXIST = 11101,
		MSP_ERROR_HTTP_BASE = 12000,
		MSP_ERROR_ISV_NO_USER = 13000
	}

	public enum SynthStatus
	{
		MSP_TTS_FLAG_STILL_HAVE_DATA = 1,
		MSP_TTS_FLAG_DATA_END = 2,
		MSP_TTS_FLAG_CMD_CANCELED = 0
	}

	private struct WAVE_Header
	{
		public int RIFF_ID;

		public int File_Size;

		public int RIFF_Type;

		public int FMT_ID;

		public int FMT_Size;

		public short FMT_Tag;

		public ushort FMT_Channel;

		public int FMT_SamplesPerSec;

		public int AvgBytesPerSec;

		public ushort BlockAlign;

		public ushort BitsPerSample;

		public int DATA_ID;

		public int DATA_Size;
	}

	[DllImport("msc.dll")]
	public static extern int MSPLogin(string user, string password, string configs);

	[DllImport("msc.dll")]
	public static extern int MSPLogout();

	[DllImport("msc.dll")]
	public static extern IntPtr QTTSSessionBegin(string _params, ref int errorCode);

	[DllImport("msc.dll")]
	public static extern int QTTSTextPut(string sessionID, string textString, uint textLen, string _params);

	[DllImport("msc.dll")]
	public static extern IntPtr QTTSAudioGet(string sessionID, ref uint audioLen, ref SynthStatus synthStatus, ref int errorCode);

	[DllImport("msc.dll")]
	public static extern IntPtr QTTSAudioInfo(string sessionID);

	[DllImport("msc.dll")]
	public static extern int QTTSSessionEnd(string sessionID, string hints);

	public static bool GetAudio(string text, string filename, string speaker, int speed)
	{
		IntPtr p = IntPtr.Zero;
		try
		{
			string configs = "appid=60629d10";
			uint audioLen = 0u;
			SynthStatus synthStatus = SynthStatus.MSP_TTS_FLAG_STILL_HAVE_DATA;
			int errorCode = MSPLogin(string.Empty, string.Empty, configs);
			if (errorCode != 0)
			{
				return false;
			}
			string text2 = "engine_type = local,rdn = 2, speed = 4, volume = 100, rcn = 0, voice_name=xiaoyan, tts_res_path =fo|res\\tts\\xiaoyan.jet;fo|res\\tts\\common.jet, sample_rate = 16000";
			p = QTTSSessionBegin(text2, ref errorCode);
			if (errorCode != 0)
			{
				return false;
			}
			errorCode = QTTSTextPut(Ptr2Str(p), text, (uint)Encoding.Default.GetByteCount(text), string.Empty);
			if (errorCode != 0)
			{
				return false;
			}
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(new byte[44], 0, 44);
			do
			{
				IntPtr intPtr = QTTSAudioGet(Ptr2Str(p), ref audioLen, ref synthStatus, ref errorCode);
				if (intPtr != IntPtr.Zero)
				{
					byte[] array = new byte[audioLen];
					if (audioLen != 0)
					{
						Marshal.Copy(intPtr, array, 0, (int)audioLen);
					}
					memoryStream.Write(array, 0, array.Length);
				}
			}
			while (synthStatus != SynthStatus.MSP_TTS_FLAG_DATA_END && errorCode == 0);
			WAVE_Header wave_Header = GetWave_Header((int)memoryStream.Length - 44);
			byte[] array2 = StructToBytes(wave_Header);
			memoryStream.Position = 0L;
			memoryStream.Write(array2, 0, array2.Length);
			memoryStream.Position = 0L;
			if (filename != null)
			{
				string directoryName = Path.GetDirectoryName(filename);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
				memoryStream.WriteTo(fileStream);
				memoryStream.Close();
				fileStream.Close();
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
		finally
		{
			QTTSSessionEnd(Ptr2Str(p), "");
			MSPLogout();
		}
	}

	private static byte[] StructToBytes(object structure)
	{
		int num = Marshal.SizeOf(structure);
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		try
		{
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: false);
			byte[] array = new byte[num];
			Marshal.Copy(intPtr, array, 0, num);
			return array;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	private static WAVE_Header GetWave_Header(int data_len)
	{
		return new WAVE_Header
		{
			RIFF_ID = 1179011410,
			File_Size = data_len + 36,
			RIFF_Type = 1163280727,
			FMT_ID = 544501094,
			FMT_Size = 16,
			FMT_Tag = 1,
			FMT_Channel = 1,
			FMT_SamplesPerSec = 16000,
			AvgBytesPerSec = 32000,
			BlockAlign = 2,
			BitsPerSample = 16,
			DATA_ID = 1635017060,
			DATA_Size = data_len
		};
	}

	public static string Ptr2Str(IntPtr p)
	{
		List<byte> list = new List<byte>();
		while (Marshal.ReadByte(p) != 0)
		{
			list.Add(Marshal.ReadByte(p));
			p += 1;
		}
		return Encoding.Default.GetString(list.ToArray());
	}
}
