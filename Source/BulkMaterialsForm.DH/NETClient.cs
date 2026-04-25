// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NETClient

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace BulkMaterialsForm.DH;

public static class NETClient
{
	private static bool m_IsThrowErrorMessage = false;

	public static uint NET_DEVSTATE_COMPOSITE_CHN = 71u;

	private static Dictionary<EM_ErrorCode, string> en_us_String = new Dictionary<EM_ErrorCode, string>
	{
		{
			EM_ErrorCode.NET_NOERROR,
			"No error"
		},
		{
			EM_ErrorCode.NET_ERROR,
			"Unknown error"
		},
		{
			EM_ErrorCode.NET_SYSTEM_ERROR,
			"Windows system error"
		},
		{
			EM_ErrorCode.NET_NETWORK_ERROR,
			"Protocol error it may result from network timeout"
		},
		{
			EM_ErrorCode.NET_DEV_VER_NOMATCH,
			"Device protocol does not match"
		},
		{
			EM_ErrorCode.NET_INVALID_HANDLE,
			"Handle is invalid"
		},
		{
			EM_ErrorCode.NET_OPEN_CHANNEL_ERROR,
			"Failed to open channel"
		},
		{
			EM_ErrorCode.NET_CLOSE_CHANNEL_ERROR,
			"Failed to close channel"
		},
		{
			EM_ErrorCode.NET_ILLEGAL_PARAM,
			"User parameter is illegal"
		},
		{
			EM_ErrorCode.NET_SDK_INIT_ERROR,
			"SDK initialization error"
		},
		{
			EM_ErrorCode.NET_SDK_UNINIT_ERROR,
			"SDK clear error"
		},
		{
			EM_ErrorCode.NET_RENDER_OPEN_ERROR,
			"Error occurs when apply for render resources"
		},
		{
			EM_ErrorCode.NET_DEC_OPEN_ERROR,
			"Error occurs when opening the decoder library"
		},
		{
			EM_ErrorCode.NET_DEC_CLOSE_ERROR,
			"Error occurs when closing the decoder library"
		},
		{
			EM_ErrorCode.NET_MULTIPLAY_NOCHANNEL,
			"The detected channel number is 0 in multiple-channel preview"
		},
		{
			EM_ErrorCode.NET_TALK_INIT_ERROR,
			"Failed to initialize record library"
		},
		{
			EM_ErrorCode.NET_TALK_NOT_INIT,
			"The record library has not been initialized"
		},
		{
			EM_ErrorCode.NET_TALK_SENDDATA_ERROR,
			"Error occurs when sending out audio data"
		},
		{
			EM_ErrorCode.NET_REAL_ALREADY_SAVING,
			"The real-time has been protected"
		},
		{
			EM_ErrorCode.NET_NOT_SAVING,
			"The real-time data has not been save"
		},
		{
			EM_ErrorCode.NET_OPEN_FILE_ERROR,
			"Error occurs when opening the file"
		},
		{
			EM_ErrorCode.NET_PTZ_SET_TIMER_ERROR,
			"Failed to enable PTZ to control timer"
		},
		{
			EM_ErrorCode.NET_RETURN_DATA_ERROR,
			"Error occurs when verify returned data"
		},
		{
			EM_ErrorCode.NET_INSUFFICIENT_BUFFER,
			"There is no sufficient buffer"
		},
		{
			EM_ErrorCode.NET_NOT_SUPPORTED,
			"The current SDK does not support this function"
		},
		{
			EM_ErrorCode.NET_NO_RECORD_FOUND,
			"There is no searched result"
		},
		{
			EM_ErrorCode.NET_NOT_AUTHORIZED,
			"You have no operation right"
		},
		{
			EM_ErrorCode.NET_NOT_NOW,
			"Can not operate right now"
		},
		{
			EM_ErrorCode.NET_NO_TALK_CHANNEL,
			"There is no audio talk channel"
		},
		{
			EM_ErrorCode.NET_NO_AUDIO,
			"There is no audio"
		},
		{
			EM_ErrorCode.NET_NO_INIT,
			"The network SDK has not been initialized"
		},
		{
			EM_ErrorCode.NET_DOWNLOAD_END,
			"The download completed"
		},
		{
			EM_ErrorCode.NET_EMPTY_LIST,
			"There is no searched result"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SYSATTR,
			"Failed to get system property setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SERIAL,
			"Failed to get SN"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_GENERAL,
			"Failed to get general property"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_DSPCAP,
			"Failed to get DSP capacity description"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_NETCFG,
			"Failed to get network channel setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_CHANNAME,
			"Failed to get channel name"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_VIDEO,
			"Failed to get video property"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_RECORD,
			"Failed to get record setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_PRONAME,
			"Failed to get decoder protocol name"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_FUNCNAME,
			"Failed to get 232 COM function name"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_485DECODER,
			"Failed to get decoder property"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_232COM,
			"Failed to get 232 COM setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_ALARMIN,
			"Failed to get external alarm input setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_ALARMDET,
			"Failed to get motion detection alarm"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SYSTIME,
			"Failed to get device time"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_PREVIEW,
			"Failed to get preview parameter"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_AUTOMT,
			"Failed to get audio maintenance setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_VIDEOMTRX,
			"Failed to get video matrix setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_COVER,
			"Failed to get privacy mask zone setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_WATERMAKE,
			"Failed to get video watermark setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_MULTICAST,
			"Failed to get config multicast port by channel"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_GENERAL,
			"Failed to modify general property"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_NETCFG,
			"Failed to modify channel setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_CHANNAME,
			"Failed to modify channel name"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_VIDEO,
			"Failed to modify video channel"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_RECORD,
			"Failed to modify record setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_485DECODER,
			"Failed to modify decoder property"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_232COM,
			"Failed to modify 232 COM setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_ALARMIN,
			"Failed to modify external input alarm setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_ALARMDET,
			"Failed to modify motion detection alarm setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_SYSTIME,
			"Failed to modify device time"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_PREVIEW,
			"Failed to modify preview parameter"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_AUTOMT,
			"Failed to modify auto maintenance setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_VIDEOMTRX,
			"Failed to modify video matrix setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_COVER,
			"Failed to modify privacy mask zone"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_WATERMAKE,
			"Failed to modify video watermark setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_WLAN,
			"Failed to modify wireless network information"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_WLANDEV,
			"Failed to select wireless network device"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_REGISTER,
			"Failed to modify the actively registration parameter setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_CAMERA,
			"Failed to modify camera property"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_INFRARED,
			"Failed to modify IR alarm setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_SOUNDALARM,
			"Failed to modify audio alarm setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_STORAGE,
			"Failed to modify storage position setup"
		},
		{
			EM_ErrorCode.NET_AUDIOENCODE_NOTINIT,
			"The audio encode port has not been successfully initialized"
		},
		{
			EM_ErrorCode.NET_DATA_TOOLONGH,
			"The data are too long"
		},
		{
			EM_ErrorCode.NET_UNSUPPORTED,
			"The device does not support current operation"
		},
		{
			EM_ErrorCode.NET_DEVICE_BUSY,
			"Device resources is not sufficient"
		},
		{
			EM_ErrorCode.NET_SERVER_STARTED,
			"The server has boot up"
		},
		{
			EM_ErrorCode.NET_SERVER_STOPPED,
			"The server has not fully boot up"
		},
		{
			EM_ErrorCode.NET_LISTER_INCORRECT_SERIAL,
			"Input serial number is not correct"
		},
		{
			EM_ErrorCode.NET_QUERY_DISKINFO_FAILED,
			"Failed to get HDD information"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SESSION,
			"Failed to get connect session information"
		},
		{
			EM_ErrorCode.NET_USER_FLASEPWD_TRYTIME,
			"The password you typed is incorrect. You have exceeded the maximum number of retries"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_PASSWORD,
			"Password is not correct"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_USER,
			"The account does not exist"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_TIMEOUT,
			"Time out for log in returned value"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_RELOGGIN,
			"The account has logged in"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_LOCKED,
			"The account has been locked"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_BLACKLIST,
			"The account has been in the blocklist"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_BUSY,
			"Resources are not sufficient. System is busy now"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_CONNECT,
			"Time out. Please check network and try again"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_NETWORK,
			"Network connection failed"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_SUBCONNECT,
			"Successfully logged in the device but can not create video channel. Please check network connection"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_MAXCONNECT,
			"exceed the max connect number"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_PROTOCOL3_ONLY,
			"protocol 3 support"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_UKEY_LOST,
			"There is no USB or USB info error"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_NO_AUTHORIZED,
			"Client-end IP address has no right to login"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_USER_OR_PASSOWRD,
			"user or password error"
		},
		{
			EM_ErrorCode.NET_RENDER_SOUND_ON_ERROR,
			"Error occurs when Render library open audio"
		},
		{
			EM_ErrorCode.NET_RENDER_SOUND_OFF_ERROR,
			"Error occurs when Render library close audio"
		},
		{
			EM_ErrorCode.NET_RENDER_SET_VOLUME_ERROR,
			"Error occurs when Render library control volume"
		},
		{
			EM_ErrorCode.NET_RENDER_ADJUST_ERROR,
			"Error occurs when Render library set video parameter"
		},
		{
			EM_ErrorCode.NET_RENDER_PAUSE_ERROR,
			"Error occurs when Render library pause play"
		},
		{
			EM_ErrorCode.NET_RENDER_SNAP_ERROR,
			"Render library snapshot error"
		},
		{
			EM_ErrorCode.NET_RENDER_STEP_ERROR,
			"Render library stepper error"
		},
		{
			EM_ErrorCode.NET_RENDER_FRAMERATE_ERROR,
			"Error occurs when Render library set frame rate"
		},
		{
			EM_ErrorCode.NET_RENDER_DISPLAYREGION_ERROR,
			"Error occurs when Render lib setting show region"
		},
		{
			EM_ErrorCode.NET_RENDER_GETOSDTIME_ERROR,
			"An error occurred when Render library getting current play time"
		},
		{
			EM_ErrorCode.NET_GROUP_EXIST,
			"Group name has been existed"
		},
		{
			EM_ErrorCode.NET_GROUP_NOEXIST,
			"The group name does not exist"
		},
		{
			EM_ErrorCode.NET_GROUP_RIGHTOVER,
			"The group right exceeds the right list"
		},
		{
			EM_ErrorCode.NET_GROUP_HAVEUSER,
			"The group can not be removed since there is user in it"
		},
		{
			EM_ErrorCode.NET_GROUP_RIGHTUSE,
			"The user has used one of the group right. It can not be removed"
		},
		{
			EM_ErrorCode.NET_GROUP_SAMENAME,
			"New group name has been existed"
		},
		{
			EM_ErrorCode.NET_USER_EXIST,
			"The user name has been existed"
		},
		{
			EM_ErrorCode.NET_USER_NOEXIST,
			"The account does not exist"
		},
		{
			EM_ErrorCode.NET_USER_RIGHTOVER,
			"User right exceeds the group right"
		},
		{
			EM_ErrorCode.NET_USER_PWD,
			"Reserved account. It does not allow to be modified"
		},
		{
			EM_ErrorCode.NET_USER_FLASEPWD,
			"password is not correct"
		},
		{
			EM_ErrorCode.NET_USER_NOMATCHING,
			"Password is invalid"
		},
		{
			EM_ErrorCode.NET_USER_INUSE,
			"account in use"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_ETHERNET,
			"Failed to get network card setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_WLAN,
			"Failed to get wireless network information"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_WLANDEV,
			"Failed to get wireless network device"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_REGISTER,
			"Failed to get actively registration parameter"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_CAMERA,
			"Failed to get camera property"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_INFRARED,
			"Failed to get IR alarm setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SOUNDALARM,
			"Failed to get audio alarm setup"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_STORAGE,
			"Failed to get storage position"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_MAIL,
			"Failed to get mail setup"
		},
		{
			EM_ErrorCode.NET_CONFIG_DEVBUSY,
			"Can not set right now"
		},
		{
			EM_ErrorCode.NET_CONFIG_DATAILLEGAL,
			"The configuration setup data are illegal"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_DST,
			"Failed to get DST setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_DST,
			"Failed to set DST"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_VIDEO_OSD,
			"Failed to get video osd setup"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_VIDEO_OSD,
			"Failed to set video osd"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_GPRSCDMA,
			"Failed to get CDMA\\GPRS configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_GPRSCDMA,
			"Failed to set CDMA\\GPRS configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_IPFILTER,
			"Failed to get IP Filter configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_IPFILTER,
			"Failed to set IP Filter configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_TALKENCODE,
			"Failed to get Talk Encode configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_TALKENCODE,
			"Failed to set Talk Encode configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_RECORDLEN,
			"Failed to get The length of the video package configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_RECORDLEN,
			"Failed to set The length of the video package configuration"
		},
		{
			EM_ErrorCode.NET_DONT_SUPPORT_SUBAREA,
			"Not support Network hard disk partition"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_AUTOREGSERVER,
			"Failed to get the register server information"
		},
		{
			EM_ErrorCode.NET_ERROR_CONTROL_AUTOREGISTER,
			"Failed to control actively registration"
		},
		{
			EM_ErrorCode.NET_ERROR_DISCONNECT_AUTOREGISTER,
			"Failed to disconnect actively registration"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_MMS,
			"Failed to get mms configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_MMS,
			"Failed to set mms configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SMSACTIVATION,
			"Failed to get SMS configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_SMSACTIVATION,
			"Failed to set SMS configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_DIALINACTIVATION,
			"Failed to get activation of a wireless connection"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_DIALINACTIVATION,
			"Failed to set activation of a wireless connection"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_VIDEOOUT,
			"Failed to get the parameter of video output"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_VIDEOOUT,
			"Failed to set the configuration of video output"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_OSDENABLE,
			"Failed to get osd overlay enabling"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_OSDENABLE,
			"Failed to set OSD overlay enabling"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_ENCODERINFO,
			"Failed to set digital input configuration of front encoders"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_TVADJUST,
			"Failed to get TV adjust configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_TVADJUST,
			"Failed to set TV adjust configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_CONNECT_FAILED,
			"Failed to request to establish a connection"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_BURNFILE,
			"Failed to request to upload burn files"
		},
		{
			EM_ErrorCode.NET_ERROR_SNIFFER_GETCFG,
			"Failed to get capture configuration information"
		},
		{
			EM_ErrorCode.NET_ERROR_SNIFFER_SETCFG,
			"Failed to set capture configuration information"
		},
		{
			EM_ErrorCode.NET_ERROR_DOWNLOADRATE_GETCFG,
			"Failed to get download restrictions information"
		},
		{
			EM_ErrorCode.NET_ERROR_DOWNLOADRATE_SETCFG,
			"Failed to set download restrictions information"
		},
		{
			EM_ErrorCode.NET_ERROR_SEARCH_TRANSCOM,
			"Failed to query serial port parameters"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_POINT,
			"Failed to get the preset info"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_POINT,
			"Failed to set the preset info"
		},
		{
			EM_ErrorCode.NET_SDK_LOGOUT_ERROR,
			"SDK log out the device abnormally"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_VEHICLE_CFG,
			"Failed to get vehicle configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_VEHICLE_CFG,
			"Failed to set vehicle configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_ATM_OVERLAY_CFG,
			"Failed to get ATM overlay configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_ATM_OVERLAY_CFG,
			"Failed to set ATM overlay configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_ATM_OVERLAY_ABILITY,
			"Failed to get ATM overlay ability"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_DECODER_TOUR_CFG,
			"Failed to get decoder tour configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_DECODER_TOUR_CFG,
			"Failed to set decoder tour configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_CTRL_DECODER_TOUR,
			"Failed to control decoder tour"
		},
		{
			EM_ErrorCode.NET_GROUP_OVERSUPPORTNUM,
			"Beyond the device supports for the largest number of user groups"
		},
		{
			EM_ErrorCode.NET_USER_OVERSUPPORTNUM,
			"Beyond the device supports for the largest number of users"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_SIP_CFG,
			"Failed to get SIP configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_SIP_CFG,
			"Failed to set SIP configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_SIP_ABILITY,
			"Failed to get SIP capability"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_WIFI_AP_CFG,
			"Failed to get 'WIFI ap' configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_WIFI_AP_CFG,
			"Failed to set 'WIFI ap' configuration"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_DECODE_POLICY,
			"Failed to get decode policy"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_DECODE_POLICY,
			"Failed to set decode policy"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_REJECT,
			"refuse talk"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_OPENED,
			"talk has opened by other client"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_RESOURCE_CONFLICIT,
			"resource conflict"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_UNSUPPORTED_ENCODE,
			"unsupported encode type"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_RIGHTLESS,
			"no right"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_FAILED,
			"request failed"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_MACHINE_CFG,
			"Failed to get device relative config"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_MACHINE_CFG,
			"Failed to set device relative config"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_DATA_FAILED,
			"get data failed"
		},
		{
			EM_ErrorCode.NET_ERROR_MAC_VALIDATE_FAILED,
			"MAC validate failed"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_INSTANCE,
			"Failed to get server instance"
		},
		{
			EM_ErrorCode.NET_ERROR_JSON_REQUEST,
			"Generated json string is error"
		},
		{
			EM_ErrorCode.NET_ERROR_JSON_RESPONSE,
			"The responding json string is error"
		},
		{
			EM_ErrorCode.NET_ERROR_VERSION_HIGHER,
			"The protocol version is lower than current version"
		},
		{
			EM_ErrorCode.NET_SPARE_NO_CAPACITY,
			"Hotspare disk operation failed. The capacity is low"
		},
		{
			EM_ErrorCode.NET_ERROR_SOURCE_IN_USE,
			"Display source is used by other output"
		},
		{
			EM_ErrorCode.NET_ERROR_REAVE,
			"advanced users grab low-level user resource"
		},
		{
			EM_ErrorCode.NET_ERROR_NETFORBID,
			"net forbid"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_MACFILTER,
			"get MAC filter configuration error"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_MACFILTER,
			"set MAC filter configuration error"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_IPMACFILTER,
			"get IP/MAC filter configuration error"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_IPMACFILTER,
			"set IP/MAC filter configuration error"
		},
		{
			EM_ErrorCode.NET_ERROR_OPERATION_OVERTIME,
			"operation over time"
		},
		{
			EM_ErrorCode.NET_ERROR_SENIOR_VALIDATE_FAILED,
			"senior validation failure"
		},
		{
			EM_ErrorCode.NET_ERROR_DEVICE_ID_NOT_EXIST,
			"device ID is not exist"
		},
		{
			EM_ErrorCode.NET_ERROR_UNSUPPORTED,
			"unsupport operation"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_DLLLOAD,
			"proxy dll load error"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_ILLEGAL_PARAM,
			"proxy user parameter is not legal"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_INVALID_HANDLE,
			"handle invalid"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_LOGIN_DEVICE_ERROR,
			"login device error"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_START_SERVER_ERROR,
			"start proxy server error"
		},
		{
			EM_ErrorCode.NET_ERROR_SPEAK_FAILED,
			"request speak failed"
		},
		{
			EM_ErrorCode.NET_ERROR_NOT_SUPPORT_F6,
			"unsupport F6"
		},
		{
			EM_ErrorCode.NET_ERROR_CD_UNREADY,
			"CD is not ready"
		},
		{
			EM_ErrorCode.NET_ERROR_DIR_NOT_EXIST,
			"Directory does not exist"
		},
		{
			EM_ErrorCode.NET_ERROR_UNSUPPORTED_SPLIT_MODE,
			"The device does not support the segmentation model"
		},
		{
			EM_ErrorCode.NET_ERROR_OPEN_WND_PARAM,
			"Open the window parameter is illegal"
		},
		{
			EM_ErrorCode.NET_ERROR_LIMITED_WND_COUNT,
			"Open the window more than limit"
		},
		{
			EM_ErrorCode.NET_ERROR_UNMATCHED_REQUEST,
			"Request command with the current pattern don't match"
		},
		{
			EM_ErrorCode.NET_RENDER_ENABLELARGEPICADJUSTMENT_ERROR,
			"Render Library to enable high-definition image internal adjustment strategy error"
		},
		{
			EM_ErrorCode.NET_ERROR_UPGRADE_FAILED,
			"Upgrade equipment failure"
		},
		{
			EM_ErrorCode.NET_ERROR_NO_TARGET_DEVICE,
			"Can't find the target device"
		},
		{
			EM_ErrorCode.NET_ERROR_NO_VERIFY_DEVICE,
			"Can't find the verify device"
		},
		{
			EM_ErrorCode.NET_ERROR_CASCADE_RIGHTLESS,
			"No cascade permissions"
		},
		{
			EM_ErrorCode.NET_ERROR_LOW_PRIORITY,
			"low priority"
		},
		{
			EM_ErrorCode.NET_ERROR_REMOTE_REQUEST_TIMEOUT,
			"The remote device request timeout"
		},
		{
			EM_ErrorCode.NET_ERROR_LIMITED_INPUT_SOURCE,
			"Input source beyond maximum route restrictions"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_LOG_PRINT_INFO,
			"Failed to set log print"
		},
		{
			EM_ErrorCode.NET_ERROR_PARAM_DWSIZE_ERROR,
			"'dwSize' is not initialized in input param"
		},
		{
			EM_ErrorCode.NET_ERROR_LIMITED_MONITORWALL_COUNT,
			"TV wall exceed limit"
		},
		{
			EM_ErrorCode.NET_ERROR_PART_PROCESS_FAILED,
			"Fail to execute part of the process"
		},
		{
			EM_ErrorCode.NET_ERROR_TARGET_NOT_SUPPORT,
			"Fail to transmit due to not supported by target"
		},
		{
			EM_ErrorCode.NET_ERROR_VISITE_FILE,
			"Access to the file failed"
		},
		{
			EM_ErrorCode.NET_ERROR_DEVICE_STATUS_BUSY,
			"Device busy"
		},
		{
			EM_ErrorCode.NET_USER_PWD_NOT_AUTHORIZED,
			"Fail to change the password"
		},
		{
			EM_ErrorCode.NET_USER_PWD_NOT_STRONG,
			"Password strength is not enough"
		},
		{
			EM_ErrorCode.NET_ERROR_NO_SUCH_CONFIG,
			"No corresponding setup"
		},
		{
			EM_ErrorCode.NET_ERROR_AUDIO_RECORD_FAILED,
			"Failed to record audio"
		},
		{
			EM_ErrorCode.NET_ERROR_SEND_DATA_FAILED,
			"Failed to send out data"
		},
		{
			EM_ErrorCode.NET_ERROR_OBSOLESCENT_INTERFACE,
			"Abandoned port"
		},
		{
			EM_ErrorCode.NET_ERROR_INSUFFICIENT_INTERAL_BUF,
			"Internal buffer is not sufficient"
		},
		{
			EM_ErrorCode.NET_ERROR_NEED_ENCRYPTION_PASSWORD,
			"verify password when changing device IP"
		},
		{
			EM_ErrorCode.NET_ERROR_NOSUPPORT_RECORD,
			"device not support the record"
		},
		{
			EM_ErrorCode.NET_ERROR_SERIALIZE_ERROR,
			"Failed to serialize data"
		},
		{
			EM_ErrorCode.NET_ERROR_DESERIALIZE_ERROR,
			"Failed to deserialize data"
		},
		{
			EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_EXISTED,
			"the wireless id is already existed"
		},
		{
			EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_LIMIT,
			"the wireless id limited"
		},
		{
			EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_ABNORMAL,
			"add the wireless id abnormaly"
		},
		{
			EM_ErrorCode.NET_ERROR_ENCRYPT,
			"encrypt data fail"
		},
		{
			EM_ErrorCode.NET_ERROR_PWD_ILLEGAL,
			"new password illegal"
		},
		{
			EM_ErrorCode.NET_ERROR_DEVICE_ALREADY_INIT,
			"device is already init"
		},
		{
			EM_ErrorCode.NET_ERROR_SECURITY_CODE,
			"security code check out fail"
		},
		{
			EM_ErrorCode.NET_ERROR_SECURITY_CODE_TIMEOUT,
			"security code out of time"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_PWD_SPECI,
			"get passwd specification fail"
		},
		{
			EM_ErrorCode.NET_ERROR_NO_AUTHORITY_OF_OPERATION,
			"no authority of operation"
		},
		{
			EM_ErrorCode.NET_ERROR_DECRYPT,
			"decrypt data fail"
		},
		{
			EM_ErrorCode.NET_ERROR_2D_CODE,
			"2D code check out fail"
		},
		{
			EM_ErrorCode.NET_ERROR_INVALID_REQUEST,
			"invalid request"
		},
		{
			EM_ErrorCode.NET_ERROR_PWD_RESET_DISABLE,
			"pwd reset disabled"
		},
		{
			EM_ErrorCode.NET_ERROR_PLAY_PRIVATE_DATA,
			"failed to display private data,such as rule box"
		},
		{
			EM_ErrorCode.NET_ERROR_ROBOT_OPERATE_FAILED,
			"robot operate failed"
		},
		{
			EM_ErrorCode.NET_ERROR_CHANNEL_ALREADY_OPENED,
			"channel has already been opened"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_INVALID_CHANNEL,
			"invaild channel"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_REOPEN_CHANNEL,
			"reopen channel failed"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_SEND_DATA,
			"send data failed"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_CREATE_SOCKET,
			"create socket failed"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_LISTEN_FAILED,
			"Start listen failed"
		},
		{
			EM_ErrorCode.NET_ERROR_FACE_RECOGNITION_SERVER_GROUP_ID_EXCEED,
			"Target recognition server group id exceed "
		},
		{
			EM_ErrorCode.ERR_NOT_SUPPORT_HIGHLEVEL_SECURITY_LOGIN,
			"device not support high level security login"
		}
	};

	private static Dictionary<EM_ErrorCode, string> zh_cn_String = new Dictionary<EM_ErrorCode, string>
	{
		{
			EM_ErrorCode.NET_NOERROR,
			"没有错误"
		},
		{
			EM_ErrorCode.NET_ERROR,
			"未知错误"
		},
		{
			EM_ErrorCode.NET_SYSTEM_ERROR,
			"Windows系统出错"
		},
		{
			EM_ErrorCode.NET_NETWORK_ERROR,
			"网络错误,可能是因为网络超时"
		},
		{
			EM_ErrorCode.NET_DEV_VER_NOMATCH,
			"设备协议不匹配"
		},
		{
			EM_ErrorCode.NET_INVALID_HANDLE,
			"句柄无效"
		},
		{
			EM_ErrorCode.NET_OPEN_CHANNEL_ERROR,
			"打开通道失败"
		},
		{
			EM_ErrorCode.NET_CLOSE_CHANNEL_ERROR,
			"关闭通道失败"
		},
		{
			EM_ErrorCode.NET_ILLEGAL_PARAM,
			"用户参数不合法"
		},
		{
			EM_ErrorCode.NET_SDK_INIT_ERROR,
			"SDK初始化出错"
		},
		{
			EM_ErrorCode.NET_SDK_UNINIT_ERROR,
			"SDK清理出错"
		},
		{
			EM_ErrorCode.NET_RENDER_OPEN_ERROR,
			"申请render资源出错"
		},
		{
			EM_ErrorCode.NET_DEC_OPEN_ERROR,
			"打开解码库出错"
		},
		{
			EM_ErrorCode.NET_DEC_CLOSE_ERROR,
			"关闭解码库出错"
		},
		{
			EM_ErrorCode.NET_MULTIPLAY_NOCHANNEL,
			"多画面预览中检测到通道数为0"
		},
		{
			EM_ErrorCode.NET_TALK_INIT_ERROR,
			"录音库初始化失败"
		},
		{
			EM_ErrorCode.NET_TALK_NOT_INIT,
			"录音库未经初始化"
		},
		{
			EM_ErrorCode.NET_TALK_SENDDATA_ERROR,
			"发送音频数据出错"
		},
		{
			EM_ErrorCode.NET_REAL_ALREADY_SAVING,
			"实时数据已经处于保存状态"
		},
		{
			EM_ErrorCode.NET_NOT_SAVING,
			"未保存实时数据"
		},
		{
			EM_ErrorCode.NET_OPEN_FILE_ERROR,
			"打开文件出错"
		},
		{
			EM_ErrorCode.NET_PTZ_SET_TIMER_ERROR,
			"启动云台控制定时器失败"
		},
		{
			EM_ErrorCode.NET_RETURN_DATA_ERROR,
			"对返回数据的校验出错"
		},
		{
			EM_ErrorCode.NET_INSUFFICIENT_BUFFER,
			"没有足够的缓存"
		},
		{
			EM_ErrorCode.NET_NOT_SUPPORTED,
			"当前SDK未支持该功能"
		},
		{
			EM_ErrorCode.NET_NO_RECORD_FOUND,
			"查询不到录象"
		},
		{
			EM_ErrorCode.NET_NOT_AUTHORIZED,
			"无操作权限"
		},
		{
			EM_ErrorCode.NET_NOT_NOW,
			"暂时无法执行"
		},
		{
			EM_ErrorCode.NET_NO_TALK_CHANNEL,
			"未发现对讲通道"
		},
		{
			EM_ErrorCode.NET_NO_AUDIO,
			"未发现音频"
		},
		{
			EM_ErrorCode.NET_NO_INIT,
			"网络SDK未经初始化"
		},
		{
			EM_ErrorCode.NET_DOWNLOAD_END,
			"下载已结束"
		},
		{
			EM_ErrorCode.NET_EMPTY_LIST,
			"查询结果为空"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SYSATTR,
			"获取系统属性配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SERIAL,
			"获取序列号失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_GENERAL,
			"获取常规属性失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_DSPCAP,
			"获取DSP能力描述失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_NETCFG,
			"获取网络配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_CHANNAME,
			"获取通道名称失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_VIDEO,
			"获取视频属性失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_RECORD,
			"获取录象配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_PRONAME,
			"获取解码器协议名称失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_FUNCNAME,
			"获取232串口功能名称失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_485DECODER,
			"获取解码器属性失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_232COM,
			"获取232串口配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_ALARMIN,
			"获取外部报警输入配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_ALARMDET,
			"获取动态检测报警失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SYSTIME,
			"获取设备时间失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_PREVIEW,
			"获取预览参数失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_AUTOMT,
			"获取自动维护配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_VIDEOMTRX,
			"获取视频矩阵配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_COVER,
			"获取区域遮挡配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_WATERMAKE,
			"获取图象水印配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_MULTICAST,
			"获取配置失败位置：组播端口按通道配置"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_GENERAL,
			"修改常规属性失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_NETCFG,
			"修改网络配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_CHANNAME,
			"修改通道名称失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_VIDEO,
			"修改视频属性失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_RECORD,
			"修改录象配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_485DECODER,
			"修改解码器属性失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_232COM,
			"修改232串口配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_ALARMIN,
			"修改外部输入报警配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_ALARMDET,
			"修改动态检测报警配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_SYSTIME,
			"修改设备时间失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_PREVIEW,
			"修改预览参数失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_AUTOMT,
			"修改自动维护配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_VIDEOMTRX,
			"修改视频矩阵配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_COVER,
			"修改区域遮挡配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_WATERMAKE,
			"修改图象水印配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_WLAN,
			"修改无线网络信息失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_WLANDEV,
			"选择无线网络设备失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_REGISTER,
			"修改主动注册参数配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_CAMERA,
			"修改摄像头属性配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_INFRARED,
			"修改红外报警配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_SOUNDALARM,
			"修改音频报警配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_STORAGE,
			"修改存储位置配置失败"
		},
		{
			EM_ErrorCode.NET_AUDIOENCODE_NOTINIT,
			"音频编码接口没有成功初始化"
		},
		{
			EM_ErrorCode.NET_DATA_TOOLONGH,
			"数据过长"
		},
		{
			EM_ErrorCode.NET_UNSUPPORTED,
			"设备不支持该操作"
		},
		{
			EM_ErrorCode.NET_DEVICE_BUSY,
			"设备资源不足"
		},
		{
			EM_ErrorCode.NET_SERVER_STARTED,
			"服务器已经启动"
		},
		{
			EM_ErrorCode.NET_SERVER_STOPPED,
			"服务器尚未成功启动"
		},
		{
			EM_ErrorCode.NET_LISTER_INCORRECT_SERIAL,
			"输入序列号有误"
		},
		{
			EM_ErrorCode.NET_QUERY_DISKINFO_FAILED,
			"获取硬盘信息失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SESSION,
			"获取连接Session信息"
		},
		{
			EM_ErrorCode.NET_USER_FLASEPWD_TRYTIME,
			"输入密码错误超过限制次数"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_PASSWORD,
			"密码不正确"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_USER,
			"帐户不存在"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_TIMEOUT,
			"等待登录返回超时"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_RELOGGIN,
			"帐号已登录"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_LOCKED,
			"帐号已被锁定"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_BLACKLIST,
			"帐号已被列为禁用名单"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_BUSY,
			"资源不足,系统忙"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_CONNECT,
			"登录设备超时,请检查网络并重试"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_NETWORK,
			"网络连接失败"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_SUBCONNECT,
			"登录设备成功,但无法创建视频通道,请检查网络状况"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_MAXCONNECT,
			"超过最大连接数"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_PROTOCOL3_ONLY,
			"只支持3代协议"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_UKEY_LOST,
			"未插入U盾或U盾信息错误"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_NO_AUTHORIZED,
			"客户端IP地址没有登录权限"
		},
		{
			EM_ErrorCode.NET_LOGIN_ERROR_USER_OR_PASSOWRD,
			"账号或密码错误"
		},
		{
			EM_ErrorCode.NET_RENDER_SOUND_ON_ERROR,
			"Render库打开音频出错"
		},
		{
			EM_ErrorCode.NET_RENDER_SOUND_OFF_ERROR,
			"Render库关闭音频出错"
		},
		{
			EM_ErrorCode.NET_RENDER_SET_VOLUME_ERROR,
			"Render库控制音量出错"
		},
		{
			EM_ErrorCode.NET_RENDER_ADJUST_ERROR,
			"Render库设置画面参数出错"
		},
		{
			EM_ErrorCode.NET_RENDER_PAUSE_ERROR,
			"Render库暂停播放出错"
		},
		{
			EM_ErrorCode.NET_RENDER_SNAP_ERROR,
			"Render库抓图出错"
		},
		{
			EM_ErrorCode.NET_RENDER_STEP_ERROR,
			"Render库步进出错"
		},
		{
			EM_ErrorCode.NET_RENDER_FRAMERATE_ERROR,
			"Render库设置帧率出错"
		},
		{
			EM_ErrorCode.NET_RENDER_DISPLAYREGION_ERROR,
			"Render库设置显示区域出错"
		},
		{
			EM_ErrorCode.NET_RENDER_GETOSDTIME_ERROR,
			"Render库获取当前播放时间出错"
		},
		{
			EM_ErrorCode.NET_GROUP_EXIST,
			"组名已存在"
		},
		{
			EM_ErrorCode.NET_GROUP_NOEXIST,
			"组名不存在"
		},
		{
			EM_ErrorCode.NET_GROUP_RIGHTOVER,
			"组的权限超出权限列表范围"
		},
		{
			EM_ErrorCode.NET_GROUP_HAVEUSER,
			"组下有用户,不能删除"
		},
		{
			EM_ErrorCode.NET_GROUP_RIGHTUSE,
			"组的某个权限被用户使用,不能出除"
		},
		{
			EM_ErrorCode.NET_GROUP_SAMENAME,
			"新组名同已有组名重复"
		},
		{
			EM_ErrorCode.NET_USER_EXIST,
			"用户已存在"
		},
		{
			EM_ErrorCode.NET_USER_NOEXIST,
			"用户不存在"
		},
		{
			EM_ErrorCode.NET_USER_RIGHTOVER,
			"用户权限超出组权限"
		},
		{
			EM_ErrorCode.NET_USER_PWD,
			"保留帐号,不容许修改密码"
		},
		{
			EM_ErrorCode.NET_USER_FLASEPWD,
			"密码不正确"
		},
		{
			EM_ErrorCode.NET_USER_NOMATCHING,
			"密码不匹配"
		},
		{
			EM_ErrorCode.NET_USER_INUSE,
			"账号正在使用中"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_ETHERNET,
			"获取网卡配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_WLAN,
			"获取无线网络信息失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_WLANDEV,
			"获取无线网络设备失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_REGISTER,
			"获取主动注册参数失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_CAMERA,
			"获取摄像头属性失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_INFRARED,
			"获取红外报警配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SOUNDALARM,
			"获取音频报警配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_STORAGE,
			"获取存储位置配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_MAIL,
			"获取邮件配置失败"
		},
		{
			EM_ErrorCode.NET_CONFIG_DEVBUSY,
			"暂时无法设置"
		},
		{
			EM_ErrorCode.NET_CONFIG_DATAILLEGAL,
			"配置数据不合法"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_DST,
			"获取夏令时配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_DST,
			"设置夏令时配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_VIDEO_OSD,
			"获取视频OSD叠加配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_VIDEO_OSD,
			"设置视频OSD叠加配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_GPRSCDMA,
			"获取CDMA\\GPRS网络配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_GPRSCDMA,
			"设置CDMA\\GPRS网络配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_IPFILTER,
			"获取IP过滤配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_IPFILTER,
			"设置IP过滤配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_TALKENCODE,
			"获取语音对讲编码配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_TALKENCODE,
			"设置语音对讲编码配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_RECORDLEN,
			"获取录像打包长度配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_RECORDLEN,
			"设置录像打包长度配置失败"
		},
		{
			EM_ErrorCode.NET_DONT_SUPPORT_SUBAREA,
			"不支持网络硬盘分区"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_AUTOREGSERVER,
			"获取设备上主动注册服务器信息失败"
		},
		{
			EM_ErrorCode.NET_ERROR_CONTROL_AUTOREGISTER,
			"主动注册重定向注册错误"
		},
		{
			EM_ErrorCode.NET_ERROR_DISCONNECT_AUTOREGISTER,
			"断开主动注册服务器错误"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_MMS,
			"获取mms配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_MMS,
			"设置mms配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_SMSACTIVATION,
			"获取短信激活无线连接配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_SMSACTIVATION,
			"设置短信激活无线连接配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_DIALINACTIVATION,
			"获取拨号激活无线连接配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_DIALINACTIVATION,
			"设置拨号激活无线连接配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_VIDEOOUT,
			"查询视频输出参数配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_VIDEOOUT,
			"设置视频输出参数配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_OSDENABLE,
			"获取osd叠加使能配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_OSDENABLE,
			"设置osd叠加使能配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_ENCODERINFO,
			"设置数字通道前端编码接入配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_TVADJUST,
			"获取TV调节配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_TVADJUST,
			"设置TV调节配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_CONNECT_FAILED,
			"请求建立连接失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_BURNFILE,
			"请求刻录文件上传失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SNIFFER_GETCFG,
			"获取抓包配置信息失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SNIFFER_SETCFG,
			"设置抓包配置信息失败"
		},
		{
			EM_ErrorCode.NET_ERROR_DOWNLOADRATE_GETCFG,
			"查询下载限制信息失败"
		},
		{
			EM_ErrorCode.NET_ERROR_DOWNLOADRATE_SETCFG,
			"设置下载限制信息失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SEARCH_TRANSCOM,
			"查询串口参数失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_POINT,
			"获取预制点信息错误"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_POINT,
			"设置预制点信息错误"
		},
		{
			EM_ErrorCode.NET_SDK_LOGOUT_ERROR,
			"SDK没有正常登出设备"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_VEHICLE_CFG,
			"获取车载配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_VEHICLE_CFG,
			"设置车载配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_ATM_OVERLAY_CFG,
			"获取atm叠加配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_ATM_OVERLAY_CFG,
			"设置atm叠加配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_ATM_OVERLAY_ABILITY,
			"获取atm叠加能力失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_DECODER_TOUR_CFG,
			"获取解码器解码轮巡配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_DECODER_TOUR_CFG,
			"设置解码器解码轮巡配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_CTRL_DECODER_TOUR,
			"控制解码器解码轮巡失败"
		},
		{
			EM_ErrorCode.NET_GROUP_OVERSUPPORTNUM,
			"超出设备支持最大用户组数目"
		},
		{
			EM_ErrorCode.NET_USER_OVERSUPPORTNUM,
			"超出设备支持最大用户数目"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_SIP_CFG,
			"获取SIP配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_SIP_CFG,
			"设置SIP配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_SIP_ABILITY,
			"获取SIP能力失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_WIFI_AP_CFG,
			"获取WIFI ap配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_WIFI_AP_CFG,
			"设置WIFI ap配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_DECODE_POLICY,
			"获取解码策略配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_DECODE_POLICY,
			"设置解码策略配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_REJECT,
			"拒绝对讲"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_OPENED,
			"对讲被其他客户端打开"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_RESOURCE_CONFLICIT,
			"资源冲突"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_UNSUPPORTED_ENCODE,
			"不支持的语音编码格式"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_RIGHTLESS,
			"无权限"
		},
		{
			EM_ErrorCode.NET_ERROR_TALK_FAILED,
			"请求对讲失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_MACHINE_CFG,
			"获取机器相关配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_MACHINE_CFG,
			"设置机器相关配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_DATA_FAILED,
			"设备无法获取当前请求数据"
		},
		{
			EM_ErrorCode.NET_ERROR_MAC_VALIDATE_FAILED,
			"MAC地址验证失败 "
		},
		{
			EM_ErrorCode.NET_ERROR_GET_INSTANCE,
			"获取服务器实例失败"
		},
		{
			EM_ErrorCode.NET_ERROR_JSON_REQUEST,
			"生成的jason字符串错误"
		},
		{
			EM_ErrorCode.NET_ERROR_JSON_RESPONSE,
			"响应的jason字符串错误"
		},
		{
			EM_ErrorCode.NET_ERROR_VERSION_HIGHER,
			"协议版本低于当前使用的版本"
		},
		{
			EM_ErrorCode.NET_SPARE_NO_CAPACITY,
			"热备操作失败, 容量不足"
		},
		{
			EM_ErrorCode.NET_ERROR_SOURCE_IN_USE,
			"显示源被其他输出占用"
		},
		{
			EM_ErrorCode.NET_ERROR_REAVE,
			"高级用户抢占低级用户资源"
		},
		{
			EM_ErrorCode.NET_ERROR_NETFORBID,
			"禁止入网 "
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_MACFILTER,
			"获取MAC过滤配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_MACFILTER,
			"设置MAC过滤配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_GETCFG_IPMACFILTER,
			"获取IP/MAC过滤配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SETCFG_IPMACFILTER,
			"设置IP/MAC过滤配置失败"
		},
		{
			EM_ErrorCode.NET_ERROR_OPERATION_OVERTIME,
			"当前操作超时 "
		},
		{
			EM_ErrorCode.NET_ERROR_SENIOR_VALIDATE_FAILED,
			"高级校验失败"
		},
		{
			EM_ErrorCode.NET_ERROR_DEVICE_ID_NOT_EXIST,
			"设备ID不存在"
		},
		{
			EM_ErrorCode.NET_ERROR_UNSUPPORTED,
			"不支持当前操作"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_DLLLOAD,
			"代理库加载失败"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_ILLEGAL_PARAM,
			"代理用户参数不合法"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_INVALID_HANDLE,
			"代理句柄无效"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_LOGIN_DEVICE_ERROR,
			"代理登入前端设备失败"
		},
		{
			EM_ErrorCode.NET_ERROR_PROXY_START_SERVER_ERROR,
			"启动代理服务失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SPEAK_FAILED,
			"请求喊话失败"
		},
		{
			EM_ErrorCode.NET_ERROR_NOT_SUPPORT_F6,
			"设备不支持此F6接口调用"
		},
		{
			EM_ErrorCode.NET_ERROR_CD_UNREADY,
			"光盘未就绪"
		},
		{
			EM_ErrorCode.NET_ERROR_DIR_NOT_EXIST,
			"目录不存在"
		},
		{
			EM_ErrorCode.NET_ERROR_UNSUPPORTED_SPLIT_MODE,
			"设备不支持的分割模式"
		},
		{
			EM_ErrorCode.NET_ERROR_OPEN_WND_PARAM,
			"开窗参数不合法"
		},
		{
			EM_ErrorCode.NET_ERROR_LIMITED_WND_COUNT,
			"开窗数量超过限制"
		},
		{
			EM_ErrorCode.NET_ERROR_UNMATCHED_REQUEST,
			"请求命令与当前模式不匹配"
		},
		{
			EM_ErrorCode.NET_RENDER_ENABLELARGEPICADJUSTMENT_ERROR,
			"Render库启用高清图像内部调整策略出错"
		},
		{
			EM_ErrorCode.NET_ERROR_UPGRADE_FAILED,
			"设备升级失败"
		},
		{
			EM_ErrorCode.NET_ERROR_NO_TARGET_DEVICE,
			"找不到目标设备"
		},
		{
			EM_ErrorCode.NET_ERROR_NO_VERIFY_DEVICE,
			"找不到验证设备"
		},
		{
			EM_ErrorCode.NET_ERROR_CASCADE_RIGHTLESS,
			"无级联权限"
		},
		{
			EM_ErrorCode.NET_ERROR_LOW_PRIORITY,
			"低优先级"
		},
		{
			EM_ErrorCode.NET_ERROR_REMOTE_REQUEST_TIMEOUT,
			"远程设备请求超时"
		},
		{
			EM_ErrorCode.NET_ERROR_LIMITED_INPUT_SOURCE,
			"输入源超出最大路数限制"
		},
		{
			EM_ErrorCode.NET_ERROR_SET_LOG_PRINT_INFO,
			"设置日志打印失败"
		},
		{
			EM_ErrorCode.NET_ERROR_PARAM_DWSIZE_ERROR,
			"入参的dwsize字段出错"
		},
		{
			EM_ErrorCode.NET_ERROR_LIMITED_MONITORWALL_COUNT,
			"电视墙数量超过上限"
		},
		{
			EM_ErrorCode.NET_ERROR_PART_PROCESS_FAILED,
			"部分过程执行失败"
		},
		{
			EM_ErrorCode.NET_ERROR_TARGET_NOT_SUPPORT,
			"该功能不支持转发"
		},
		{
			EM_ErrorCode.NET_ERROR_VISITE_FILE,
			"访问文件失败"
		},
		{
			EM_ErrorCode.NET_ERROR_DEVICE_STATUS_BUSY,
			"设备忙"
		},
		{
			EM_ErrorCode.NET_USER_PWD_NOT_AUTHORIZED,
			"修改密码无权限"
		},
		{
			EM_ErrorCode.NET_USER_PWD_NOT_STRONG,
			"密码强度不够"
		},
		{
			EM_ErrorCode.NET_ERROR_NO_SUCH_CONFIG,
			"没有对应的配置"
		},
		{
			EM_ErrorCode.NET_ERROR_AUDIO_RECORD_FAILED,
			"录音失败"
		},
		{
			EM_ErrorCode.NET_ERROR_SEND_DATA_FAILED,
			"数据发送失败"
		},
		{
			EM_ErrorCode.NET_ERROR_OBSOLESCENT_INTERFACE,
			"废弃接口"
		},
		{
			EM_ErrorCode.NET_ERROR_INSUFFICIENT_INTERAL_BUF,
			"内部缓冲不足"
		},
		{
			EM_ErrorCode.NET_ERROR_NEED_ENCRYPTION_PASSWORD,
			"修改设备ip时,需要校验密码"
		},
		{
			EM_ErrorCode.NET_ERROR_NOSUPPORT_RECORD,
			"设备不支持此记录集"
		},
		{
			EM_ErrorCode.NET_ERROR_SERIALIZE_ERROR,
			"数据序列化错误"
		},
		{
			EM_ErrorCode.NET_ERROR_DESERIALIZE_ERROR,
			"数据反序列化错误"
		},
		{
			EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_EXISTED,
			"该无线ID已存在"
		},
		{
			EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_LIMIT,
			"无线ID数量已超限"
		},
		{
			EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_ABNORMAL,
			"无线异常添加"
		},
		{
			EM_ErrorCode.NET_ERROR_ENCRYPT,
			"加密数据失败"
		},
		{
			EM_ErrorCode.NET_ERROR_PWD_ILLEGAL,
			"新密码不合规范"
		},
		{
			EM_ErrorCode.NET_ERROR_DEVICE_ALREADY_INIT,
			"设备已经初始化"
		},
		{
			EM_ErrorCode.NET_ERROR_SECURITY_CODE,
			"安全码错误"
		},
		{
			EM_ErrorCode.NET_ERROR_SECURITY_CODE_TIMEOUT,
			"安全码超出有效期"
		},
		{
			EM_ErrorCode.NET_ERROR_GET_PWD_SPECI,
			"获取密码规范失败"
		},
		{
			EM_ErrorCode.NET_ERROR_NO_AUTHORITY_OF_OPERATION,
			"无权限进行该操作"
		},
		{
			EM_ErrorCode.NET_ERROR_DECRYPT,
			"解密数据失败"
		},
		{
			EM_ErrorCode.NET_ERROR_2D_CODE,
			"2D code校验失败"
		},
		{
			EM_ErrorCode.NET_ERROR_INVALID_REQUEST,
			"非法的RPC请求"
		},
		{
			EM_ErrorCode.NET_ERROR_PWD_RESET_DISABLE,
			"密码重置功能已关闭"
		},
		{
			EM_ErrorCode.NET_ERROR_PLAY_PRIVATE_DATA,
			"显示私有数据，比如规则框等失败"
		},
		{
			EM_ErrorCode.NET_ERROR_ROBOT_OPERATE_FAILED,
			"机器人操作失败"
		},
		{
			EM_ErrorCode.NET_ERROR_CHANNEL_ALREADY_OPENED,
			"通道已经打开"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_INVALID_CHANNEL,
			"错误的通道号"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_REOPEN_CHANNEL,
			"打开重复通道"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_SEND_DATA,
			"发送消息失败"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_CREATE_SOCKET,
			"创建socket失败"
		},
		{
			EM_ErrorCode.ERR_INTERNAL_LISTEN_FAILED,
			"启动监听失败"
		},
		{
			EM_ErrorCode.NET_ERROR_FACE_RECOGNITION_SERVER_GROUP_ID_EXCEED,
			"组ID超过最大值"
		},
		{
			EM_ErrorCode.ERR_NOT_SUPPORT_HIGHLEVEL_SECURITY_LOGIN,
			"设备不支持高安全等级登录"
		}
	};

	public static void SetThrowErrorMessage(bool isThrow)
	{
		m_IsThrowErrorMessage = isThrow;
	}

	private static string GetLastErrorMessage(EM_ErrorCode errorCode)
	{
		string value = string.Empty;
		if (CultureInfo.CurrentCulture.LCID == 2052)
		{
			zh_cn_String.TryGetValue(errorCode, out value);
		}
		else
		{
			en_us_String.TryGetValue(errorCode, out value);
		}
		if (value == null)
		{
			value = errorCode.ToString("X");
		}
		return value;
	}

	private static void NetGetLastError<T>(T value) where T : struct
	{
		object obj = value;
		bool flag = false;
		if (value is IntPtr)
		{
			IntPtr intPtr = (IntPtr)obj;
			if (IntPtr.Zero == intPtr)
			{
				flag = true;
			}
		}
		else if (value is int)
		{
			int num = (int)obj;
			if (0 > num)
			{
				flag = true;
			}
		}
		else
		{
			if (!(value is bool))
			{
				return;
			}
			if (!(bool)obj)
			{
				flag = true;
			}
		}
		if (flag && m_IsThrowErrorMessage)
		{
			int num2 = OriginalSDK.CLIENT_GetLastError();
			if (num2 != 0)
			{
				string lastErrorMessage = GetLastErrorMessage((EM_ErrorCode)num2);
				throw new NETClientExcetion(num2, lastErrorMessage);
			}
		}
	}

	public static string GetLastError()
	{
		string result = null;
		int num = OriginalSDK.CLIENT_GetLastError();
		if (num != 0)
		{
			result = GetLastErrorMessage((EM_ErrorCode)num);
		}
		return result;
	}

	public static bool Init(fDisConnectCallBack cbDisConnect, IntPtr dwUser, NETSDK_INIT_PARAM? stuInitParam)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			if (stuInitParam.HasValue)
			{
				intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETSDK_INIT_PARAM)));
				Marshal.StructureToPtr(stuInitParam, intPtr, fDeleteOld: true);
			}
			flag = OriginalSDK.CLIENT_InitEx(cbDisConnect, dwUser, intPtr);
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool InitWithDefaultSetting(fDisConnectCallBack cbDisConnect, fHaveReConnectCallBack cbReconnect, IntPtr dwUser, NETSDK_INIT_PARAM? stuInitParam)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			if (stuInitParam.HasValue)
			{
				intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETSDK_INIT_PARAM)));
				Marshal.StructureToPtr(stuInitParam, intPtr, fDeleteOld: true);
			}
			flag = OriginalSDK.CLIENT_InitEx(cbDisConnect, dwUser, intPtr);
			NetGetLastError(flag);
			if (!flag)
			{
				return false;
			}
			NET_PARAM structure = new NET_PARAM
			{
				nConnectTime = 5000,
				nGetConnInfoTime = 3000
			};
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_PARAM)));
			Marshal.StructureToPtr(structure, intPtr2, fDeleteOld: true);
			OriginalSDK.CLIENT_SetNetworkParam(intPtr2);
			OriginalSDK.CLIENT_SetAutoReconnect(cbReconnect, IntPtr.Zero);
			int nTryTimes = 3;
			OriginalSDK.CLIENT_SetConnectTime(5000, nTryTimes);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
	}

	public static void Cleanup()
	{
		OriginalSDK.CLIENT_Cleanup();
	}

	public static IntPtr Login(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, EM_LOGIN_SPAC_CAP_TYPE emSpecCap, IntPtr pCapParam, ref NET_DEVICEINFO_Ex deviceInfo)
	{
		_ = IntPtr.Zero;
		int error = 0;
		IntPtr intPtr = OriginalSDK.CLIENT_LoginEx2(pchDVRIP, wDVRPort, pchUserName, pchPassword, emSpecCap, pCapParam, ref deviceInfo, ref error);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static IntPtr LoginWithHighLevelSecurity(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, EM_LOGIN_SPAC_CAP_TYPE emSpecCap, IntPtr pCapParam, ref NET_DEVICEINFO_Ex deviceInfo)
	{
		_ = IntPtr.Zero;
		NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY pstInParam = default(NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY);
		pstInParam.dwSize = (uint)Marshal.SizeOf(pstInParam);
		pstInParam.szIP = pchDVRIP;
		pstInParam.nPort = wDVRPort;
		pstInParam.szUserName = pchUserName;
		pstInParam.szPassword = pchPassword;
		pstInParam.emSpecCap = emSpecCap;
		pstInParam.pCapParam = pCapParam;
		NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY pstOutParam = default(NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY);
		pstOutParam.dwSize = (uint)Marshal.SizeOf(pstOutParam);
		IntPtr intPtr = OriginalSDK.CLIENT_LoginWithHighLevelSecurity(ref pstInParam, ref pstOutParam);
		deviceInfo = pstOutParam.stuDeviceInfo;
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool Logout(IntPtr lLoginID)
	{
		bool num = OriginalSDK.CLIENT_Logout(lLoginID);
		NetGetLastError(num);
		return num;
	}

	public static void SetAutoReconnect(fHaveReConnectCallBack cbAutoConnect, IntPtr dwUser)
	{
		OriginalSDK.CLIENT_SetAutoReconnect(cbAutoConnect, dwUser);
	}

	public static void SetNetworkParam(NET_PARAM? netParam)
	{
		if (netParam.HasValue)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_PARAM)));
			Marshal.StructureToPtr(netParam, intPtr, fDeleteOld: true);
			OriginalSDK.CLIENT_SetNetworkParam(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static IntPtr StartRealPlay(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType, fRealDataCallBackEx cbRealData, fRealPlayDisConnectCallBack cbDisconnect, IntPtr dwUser, uint dwWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartRealPlay(lLoginID, nChannelID, hWnd, rType, cbRealData, cbDisconnect, dwUser, dwWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static IntPtr RealPlay(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType = EM_RealPlayType.Realplay)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_RealPlayEx(lLoginID, nChannelID, hWnd, rType);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopRealPlay(IntPtr lRealHandle)
	{
		bool num = OriginalSDK.CLIENT_StopRealPlayEx(lRealHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool SetRealDataCallBack(IntPtr lRealHandle, fRealDataCallBackEx2 cbRealData, IntPtr dwUser, EM_REALDATA_FLAG dwFlag)
	{
		bool num = OriginalSDK.CLIENT_SetRealDataCallBackEx2(lRealHandle, cbRealData, dwUser, (uint)dwFlag);
		NetGetLastError(num);
		return num;
	}

	public static bool SaveRealData(IntPtr lRealHandle, string pchFileName)
	{
		bool num = OriginalSDK.CLIENT_SaveRealData(lRealHandle, pchFileName);
		NetGetLastError(num);
		return num;
	}

	public static bool StopSaveRealData(IntPtr lRealHandle)
	{
		bool num = OriginalSDK.CLIENT_StopSaveRealData(lRealHandle);
		NetGetLastError(num);
		return num;
	}

	public static void SetSnapRevCallBack(fSnapRevCallBack OnSnapRevMessage, IntPtr dwUser)
	{
		OriginalSDK.CLIENT_SetSnapRevCallBack(OnSnapRevMessage, dwUser);
	}

	public static bool SnapPictureEx(IntPtr lLoginID, NET_SNAP_PARAMS par, IntPtr reserved)
	{
		bool num = OriginalSDK.CLIENT_SnapPictureEx(lLoginID, ref par, reserved);
		NetGetLastError(num);
		return num;
	}

	public static bool SnapPictureToFile(IntPtr lLoginID, ref NET_IN_SNAP_PIC_TO_FILE_PARAM inParam, ref NET_OUT_SNAP_PIC_TO_FILE_PARAM outParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_SnapPictureToFile(lLoginID, ref inParam, ref outParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr PlayBackByTime(IntPtr lLoginID, int nChannelID, NET_IN_PLAY_BACK_BY_TIME_INFO pstNetIn, ref NET_OUT_PLAY_BACK_BY_TIME_INFO pstNetOut)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_PlayBackByTimeEx2(lLoginID, nChannelID, ref pstNetIn, ref pstNetOut);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool QueryRecordFile(IntPtr lLoginID, int nChannelId, EM_QUERY_RECORD_TYPE nRecordFileType, DateTime tmStart, DateTime tmEnd, string pchCardid, ref NET_RECORDFILE_INFO[] nriFileinfo, ref int filecount, int waittime, bool bTime)
	{
		bool flag = false;
		filecount = 0;
		IntPtr intPtr = IntPtr.Zero;
		int num = Marshal.SizeOf(typeof(NET_RECORDFILE_INFO)) * nriFileinfo.Length;
		try
		{
			NET_TIME tmStart2 = NET_TIME.FromDateTime(tmStart);
			NET_TIME tmEnd2 = NET_TIME.FromDateTime(tmEnd);
			intPtr = Marshal.AllocHGlobal(num);
			int num2 = 0;
			if (intPtr != IntPtr.Zero)
			{
				flag = OriginalSDK.CLIENT_QueryRecordFile(lLoginID, nChannelId, (int)nRecordFileType, ref tmStart2, ref tmEnd2, pchCardid, intPtr, num, ref filecount, waittime, bTime);
				NetGetLastError(flag);
				num2 = ((filecount <= nriFileinfo.Length) ? filecount : nriFileinfo.Length);
				for (int i = 0; i < num2; i++)
				{
					nriFileinfo[i] = (NET_RECORDFILE_INFO)Marshal.PtrToStructure(IntPtr.Add(intPtr, Marshal.SizeOf(typeof(NET_RECORDFILE_INFO)) * i), typeof(NET_RECORDFILE_INFO));
				}
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			intPtr = IntPtr.Zero;
		}
		return flag;
	}

	public static bool QueryRecordStatus(IntPtr lLoginID, int nChannelId, EM_QUERY_RECORD_TYPE nRecordFileType, DateTime tmMonth, string pchCardid, ref NET_RECORD_STATUS pRecordStatus, int waittime = 1000)
	{
		NET_TIME tmMonth2 = NET_TIME.FromDateTime(tmMonth);
		bool num = OriginalSDK.CLIENT_QueryRecordStatus(lLoginID, nChannelId, (int)nRecordFileType, ref tmMonth2, pchCardid, ref pRecordStatus, waittime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetPlayBackOsdTime(IntPtr lPlayHandle, ref NET_TIME lpOsdTime, ref NET_TIME lpStartTime, ref NET_TIME lpEndTime)
	{
		bool num = OriginalSDK.CLIENT_GetPlayBackOsdTime(lPlayHandle, ref lpOsdTime, ref lpStartTime, ref lpEndTime);
		NetGetLastError(num);
		return num;
	}

	public static bool CapturePicture(IntPtr hPlayHandle, string pchPicFileName, EM_NET_CAPTURE_FORMATS eFormat)
	{
		bool num = OriginalSDK.CLIENT_CapturePictureEx(hPlayHandle, pchPicFileName, eFormat);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr DownloadByTime(IntPtr lLoginID, int nChannelId, EM_QUERY_RECORD_TYPE nRecordFileType, DateTime tmStart, DateTime tmEnd, string sSavedFileName, fTimeDownLoadPosCallBack cbTimeDownLoadPos, IntPtr dwUserData, fDataCallBack fDownLoadDataCallBack, IntPtr dwDataUser, IntPtr pReserved)
	{
		_ = IntPtr.Zero;
		NET_TIME tmStart2 = NET_TIME.FromDateTime(tmStart);
		NET_TIME tmEnd2 = NET_TIME.FromDateTime(tmEnd);
		IntPtr intPtr = OriginalSDK.CLIENT_DownloadByTimeEx(lLoginID, nChannelId, (int)nRecordFileType, ref tmStart2, ref tmEnd2, sSavedFileName, cbTimeDownLoadPos, dwUserData, fDownLoadDataCallBack, dwDataUser, pReserved);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopDownload(IntPtr lFileHandle)
	{
		bool num = OriginalSDK.CLIENT_StopDownload(lFileHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool GetDownloadPos(IntPtr lFileHandle, ref int nTotalSize, ref int nDownLoadSize)
	{
		bool num = OriginalSDK.CLIENT_GetDownloadPos(lFileHandle, ref nTotalSize, ref nDownLoadSize);
		NetGetLastError(num);
		return num;
	}

	public static bool PTZControl(IntPtr lLoginID, int nChannelID, EM_EXTPTZ_ControlType dwPTZCommand, int lParam1, int lParam2, int lParam3, bool dwStop, IntPtr param4)
	{
		bool num = OriginalSDK.CLIENT_DHPTZControlEx2(lLoginID, nChannelID, (uint)dwPTZCommand, lParam1, lParam2, lParam3, dwStop, param4);
		NetGetLastError(num);
		return num;
	}

	public static bool PTZSetPanGroupLimit(IntPtr lLoginID, ref NET_IN_PAN_GROUP_LIMIT_INFO pstInParam, ref NET_OUT_PAN_GROUP_LIMIT_INFO pstOutParam, uint dwWaitTime)
	{
		bool num = OriginalSDK.CLIENT_PTZSetPanGroupLimit(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool PTZSetPanGroup(IntPtr lLoginID, ref NET_IN_SET_PAN_GROUP_PARAM pstInParam, ref NET_OUT_SET_PAN_GROUP_PARAM pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_PTZSetPanGroup(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool PTZGetPanGroup(IntPtr lLoginID, ref NET_IN_GET_PAN_GROUP_PARAM pInParam, ref NET_OUT_GET_PAN_GROUP_PARAM pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_PTZGetPanGroup(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool OpenSound(IntPtr lPlayHandle)
	{
		bool num = OriginalSDK.CLIENT_OpenSound(lPlayHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool CloseSound()
	{
		bool num = OriginalSDK.CLIENT_CloseSound();
		NetGetLastError(num);
		return num;
	}

	public static void MultiArraySet(int index, int maxLen, string src, ref string dst)
	{
		byte[] bytes = Encoding.Default.GetBytes(src);
		byte[] bytes2 = Encoding.Default.GetBytes(dst);
		bytes.CopyTo(bytes2, index * maxLen);
		dst = Encoding.Default.GetString(bytes2);
	}

	public static string MultiArrayGet(int index, int maxLen, string dst)
	{
		byte[] bytes = Encoding.Default.GetBytes(dst);
		return Encoding.Default.GetString(bytes, index * maxLen, maxLen);
	}

	public static bool PlayBackControl(IntPtr lPlayHandle, PlayBackType type)
	{
		bool flag = false;
		switch (type)
		{
		case PlayBackType.Play:
			flag = OriginalSDK.CLIENT_PausePlayBack(lPlayHandle, bPause: false);
			NetGetLastError(flag);
			break;
		case PlayBackType.Pause:
			flag = OriginalSDK.CLIENT_PausePlayBack(lPlayHandle, bPause: true);
			NetGetLastError(flag);
			break;
		case PlayBackType.Stop:
			flag = OriginalSDK.CLIENT_StopPlayBack(lPlayHandle);
			NetGetLastError(flag);
			break;
		case PlayBackType.Fast:
			flag = OriginalSDK.CLIENT_FastPlayBack(lPlayHandle);
			NetGetLastError(flag);
			break;
		case PlayBackType.Slow:
			flag = OriginalSDK.CLIENT_SlowPlayBack(lPlayHandle);
			NetGetLastError(flag);
			break;
		case PlayBackType.Normal:
			flag = OriginalSDK.CLIENT_NormalPlayBack(lPlayHandle);
			NetGetLastError(flag);
			break;
		}
		return flag;
	}

	public static bool SetDeviceMode(IntPtr lLoginID, EM_USEDEV_MODE emType, IntPtr pValue)
	{
		bool num = OriginalSDK.CLIENT_SetDeviceMode(lLoginID, emType, pValue);
		NetGetLastError(num);
		return num;
	}

	public static void SetDVRMessCallBack(fMessCallBackEx cbMessage, IntPtr dwUser)
	{
		OriginalSDK.CLIENT_SetDVRMessCallBackEx1(cbMessage, dwUser);
	}

	public static bool StartListen(IntPtr lLoginID)
	{
		bool num = OriginalSDK.CLIENT_StartListenEx(lLoginID);
		NetGetLastError(num);
		return num;
	}

	public static bool StopListen(IntPtr lLoginID)
	{
		bool num = OriginalSDK.CLIENT_StopListen(lLoginID);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr RealLoadPicture(IntPtr lLoginID, int nChannelID, uint dwAlarmType, bool bNeedPicFile, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser, IntPtr reserved)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_RealLoadPictureEx(lLoginID, nChannelID, dwAlarmType, bNeedPicFile, cbAnalyzerData, dwUser, reserved);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopLoadPic(IntPtr lAnalyzerHandle)
	{
		bool num = OriginalSDK.CLIENT_StopLoadPic(lAnalyzerHandle);
		NetGetLastError(num);
		return num;
	}

	private static bool QuerySystemInfo(IntPtr lLoginID, EM_SYS_ABILITY nSystemType, IntPtr pSysInfoBuffer, int maxlen, ref int nSysInfolen, int waittime)
	{
		bool num = OriginalSDK.CLIENT_QuerySystemInfo(lLoginID, (int)nSystemType, pSysInfoBuffer, maxlen, ref nSysInfolen, waittime);
		NetGetLastError(num);
		return num;
	}

	public static bool QuerySystemInfo(IntPtr lLoginID, EM_SYS_ABILITY nSystemType, ref object obj, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		Type type = obj.GetType();
		int num = Marshal.SizeOf(obj);
		int nSysInfolen = 0;
		try
		{
			intPtr = Marshal.AllocHGlobal(num);
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = QuerySystemInfo(lLoginID, nSystemType, intPtr, num, ref nSysInfolen, waittime);
			obj = Marshal.PtrToStructure(intPtr, type);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool QueryDeviceLog(IntPtr lLoginID, ref NET_QUERY_DEVICE_LOG_PARAM pQueryParam, IntPtr pLogBuffer, int nLogBufferLen, ref int pRecLogNum, int waittime)
	{
		bool num = OriginalSDK.CLIENT_QueryDeviceLog(lLoginID, ref pQueryParam, pLogBuffer, nLogBufferLen, ref pRecLogNum, waittime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartTalk(IntPtr lLoginID, fAudioDataCallBack pfcb, IntPtr dwUser)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartTalkEx(lLoginID, pfcb, dwUser);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopTalk(IntPtr lTalkHandle)
	{
		bool num = OriginalSDK.CLIENT_StopTalkEx(lTalkHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool RecordStart(IntPtr lLoginID)
	{
		bool num = OriginalSDK.CLIENT_RecordStartEx(lLoginID);
		NetGetLastError(num);
		return num;
	}

	public static bool RecordStop(IntPtr lLoginID)
	{
		bool num = OriginalSDK.CLIENT_RecordStopEx(lLoginID);
		NetGetLastError(num);
		return num;
	}

	public static int TalkSendData(IntPtr lTalkHandle, IntPtr pSendBuf, uint dwBufSize)
	{
		int num = OriginalSDK.CLIENT_TalkSendData(lTalkHandle, pSendBuf, dwBufSize);
		NetGetLastError(num);
		return num;
	}

	public static void AudioDec(IntPtr pAudioDataBuf, uint dwBufSize)
	{
		OriginalSDK.CLIENT_AudioDec(pAudioDataBuf, dwBufSize);
	}

	public static bool ControlDevice(IntPtr lLoginID, EM_CtrlType type, IntPtr param, int waittime)
	{
		bool num = OriginalSDK.CLIENT_ControlDevice(lLoginID, type, param, waittime);
		NetGetLastError(num);
		return num;
	}

	public static bool ControlDeviceEx(IntPtr lLoginID, EM_CtrlType emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_ControlDeviceEx(lLoginID, emType, pInBuf, pOutBuf, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool QueryDevState(IntPtr lLoginID, int nType, ref object obj, Type typeName, int waittime)
	{
		bool flag = false;
		int pRetLen = 0;
		int num = 0;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			num = Marshal.SizeOf(typeName);
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_QueryDevState(lLoginID, nType, intPtr, num, ref pRetLen, waittime);
			NetGetLastError(flag);
			obj = Marshal.PtrToStructure(intPtr, typeName);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			num = 0;
		}
	}

	public static bool QueryDevState(IntPtr lLoginID, EM_DEVICE_STATE nType, ref object obj, Type typeName, int waittime)
	{
		bool flag = false;
		int pRetLen = 0;
		int num = 0;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			num = Marshal.SizeOf(typeName);
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_QueryDevState(lLoginID, (int)nType, intPtr, num, ref pRetLen, waittime);
			NetGetLastError(flag);
			obj = Marshal.PtrToStructure(intPtr, typeName);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			num = 0;
		}
	}

	public static bool QueryDevState(IntPtr lLoginID, int nType, ref object[] objs, Type typeName, int waittime)
	{
		bool flag = false;
		int pRetLen = 0;
		int num = 0;
		IntPtr intPtr = IntPtr.Zero;
		int num2 = objs.Length;
		try
		{
			num = Marshal.SizeOf(typeName) * num2;
			intPtr = Marshal.AllocHGlobal(num);
			for (int i = 0; i < num2; i++)
			{
				IntPtr ptr = IntPtr.Add(intPtr, i * Marshal.SizeOf(typeName));
				if (objs[i] != null && objs[i].GetType() == typeName)
				{
					Marshal.StructureToPtr(objs[i], ptr, fDeleteOld: true);
					continue;
				}
				for (int j = 0; j < Marshal.SizeOf(typeName); j++)
				{
					Marshal.WriteByte(ptr, j, 0);
				}
			}
			flag = OriginalSDK.CLIENT_QueryDevState(lLoginID, nType, intPtr, num, ref pRetLen, waittime);
			NetGetLastError(flag);
			if (flag)
			{
				int num3 = pRetLen / Marshal.SizeOf(typeName);
				objs = new object[num3];
				for (int k = 0; k < num3; k++)
				{
					objs[k] = Marshal.PtrToStructure(IntPtr.Add(intPtr, k * Marshal.SizeOf(typeName)), typeName);
				}
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			num = 0;
		}
		return flag;
	}

	public static bool QueryDevState(IntPtr lLoginID, int nType, ref byte[] byStates, int waittime)
	{
		bool flag = false;
		int pRetLen = 0;
		int num = 1048576;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(num);
			flag = OriginalSDK.CLIENT_QueryDevState(lLoginID, nType, intPtr, num, ref pRetLen, waittime);
			NetGetLastError(flag);
			if (pRetLen == 0)
			{
				byStates = new byte[0];
			}
			else
			{
				byStates = new byte[pRetLen];
				for (int i = 0; i < byStates.Length; i++)
				{
					byStates[i] = Marshal.ReadByte(IntPtr.Add(intPtr, i));
				}
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			num = 0;
		}
		return flag;
	}

	public static bool QueryNewSystemInfo(IntPtr lLoginID, int lChannel, string strCommand, ref object obj, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		uint num = 1048576u;
		uint error = 0u;
		try
		{
			intPtr = Marshal.AllocHGlobal((int)num);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			if (obj.GetType() == typeName)
			{
				Marshal.StructureToPtr(obj, intPtr2, fDeleteOld: true);
			}
			else
			{
				for (int i = 0; i < Marshal.SizeOf(typeName); i++)
				{
					Marshal.WriteByte(intPtr2, i, 0);
				}
			}
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)));
			if (intPtr != IntPtr.Zero && intPtr2 != IntPtr.Zero)
			{
				flag = OriginalSDK.CLIENT_QueryNewSystemInfo(lLoginID, strCommand, lChannel, intPtr, num, ref error, waittime);
				NetGetLastError(flag);
				if (flag)
				{
					flag = OriginalSDK.CLIENT_ParseData(strCommand, intPtr, intPtr2, (uint)Marshal.SizeOf(typeName), intPtr3);
					_ = (uint)Marshal.PtrToStructure(intPtr3, typeof(uint));
					obj = Marshal.PtrToStructure(intPtr2, typeName);
				}
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			intPtr = IntPtr.Zero;
			intPtr2 = IntPtr.Zero;
			intPtr3 = IntPtr.Zero;
		}
	}

	public static bool QueryNewSystemInfoEx(IntPtr lLoginID, int lChannel, string strCommand, ref object obj, Type typeName, object extendInfo, Type extendInfoType, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		uint num = 1048576u;
		uint error = 0u;
		IntPtr intPtr4 = IntPtr.Zero;
		try
		{
			if (extendInfo != null && extendInfoType != null)
			{
				intPtr4 = Marshal.AllocHGlobal(Marshal.SizeOf(extendInfoType));
				Marshal.StructureToPtr(extendInfo, intPtr4, fDeleteOld: true);
			}
			intPtr = Marshal.AllocHGlobal((int)num);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)));
			if (intPtr != IntPtr.Zero && intPtr2 != IntPtr.Zero)
			{
				flag = OriginalSDK.CLIENT_QueryNewSystemInfoEx(lLoginID, strCommand, lChannel, intPtr, num, ref error, intPtr4, waittime);
				NetGetLastError(flag);
				if (flag)
				{
					flag = OriginalSDK.CLIENT_ParseData(strCommand, intPtr, intPtr2, (uint)Marshal.SizeOf(typeName), intPtr3);
					_ = (uint)Marshal.PtrToStructure(intPtr3, typeof(uint));
					obj = Marshal.PtrToStructure(intPtr2, typeName);
				}
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr4);
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			intPtr4 = IntPtr.Zero;
			intPtr = IntPtr.Zero;
			intPtr2 = IntPtr.Zero;
			intPtr3 = IntPtr.Zero;
		}
	}

	public static bool FindRecord(IntPtr lLoginID, EM_NET_RECORD_TYPE emRecordType, object oCondition, Type tyCondition, ref IntPtr lFindID, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		NET_IN_FIND_RECORD_PARAM pInParam = default(NET_IN_FIND_RECORD_PARAM);
		NET_OUT_FIND_RECORD_PARAM pOutParam = default(NET_OUT_FIND_RECORD_PARAM);
		pInParam.dwSize = (uint)Marshal.SizeOf(pInParam);
		pInParam.emType = emRecordType;
		try
		{
			if (oCondition == null || tyCondition == null)
			{
				pInParam.pQueryCondition = IntPtr.Zero;
			}
			else
			{
				intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(tyCondition));
				Marshal.StructureToPtr(oCondition, intPtr, fDeleteOld: true);
				pInParam.pQueryCondition = intPtr;
			}
			pOutParam.dwSize = (uint)Marshal.SizeOf(pOutParam);
			flag = OriginalSDK.CLIENT_FindRecord(lLoginID, ref pInParam, ref pOutParam, waittime);
			NetGetLastError(flag);
			lFindID = pOutParam.lFindeHandle;
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static int FindNextRecord(IntPtr lFindeHandle, int nMaxNum, ref int nRetNum, ref List<object> ls, Type tyRecord, int waittime)
	{
		int num = 0;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			NET_IN_FIND_NEXT_RECORD_PARAM pInParam = default(NET_IN_FIND_NEXT_RECORD_PARAM);
			pInParam.dwSize = (uint)Marshal.SizeOf(pInParam);
			pInParam.lFindeHandle = lFindeHandle;
			pInParam.nFileCount = nMaxNum;
			NET_OUT_FIND_NEXT_RECORD_PARAM pOutParam = default(NET_OUT_FIND_NEXT_RECORD_PARAM);
			pOutParam.dwSize = (uint)Marshal.SizeOf(pOutParam);
			pOutParam.nMaxRecordNum = nMaxNum;
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(tyRecord) * nMaxNum);
			for (int i = 0; i < nMaxNum; i++)
			{
				Marshal.StructureToPtr(ls[i], IntPtr.Add(intPtr, Marshal.SizeOf(tyRecord) * i), fDeleteOld: true);
			}
			pOutParam.pRecordList = intPtr;
			num = OriginalSDK.CLIENT_FindNextRecord(ref pInParam, ref pOutParam, waittime);
			if (num >= 0)
			{
				nRetNum = pOutParam.nRetRecordNum;
				ls.Clear();
				for (int j = 0; j < nRetNum; j++)
				{
					ls.Add(Marshal.PtrToStructure(IntPtr.Add(intPtr, Marshal.SizeOf(tyRecord) * j), tyRecord));
				}
			}
			else
			{
				NetGetLastError(num);
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
		return num;
	}

	public static bool FindRecordClose(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_FindRecordClose(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool QueryRecordCount(IntPtr lFindHandle, ref int nRecordCount, int waittime)
	{
		NET_IN_QUEYT_RECORD_COUNT_PARAM pInParam = default(NET_IN_QUEYT_RECORD_COUNT_PARAM);
		pInParam.dwSize = (uint)Marshal.SizeOf(pInParam);
		pInParam.lFindeHandle = lFindHandle;
		NET_OUT_QUEYT_RECORD_COUNT_PARAM pOutParam = default(NET_OUT_QUEYT_RECORD_COUNT_PARAM);
		pOutParam.dwSize = (uint)Marshal.SizeOf(pOutParam);
		bool num = OriginalSDK.CLIENT_QueryRecordCount(ref pInParam, ref pOutParam, waittime);
		nRecordCount = pOutParam.nRecordCount;
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartFindNumberStat(IntPtr lLoginID, ref NET_IN_FINDNUMBERSTAT pstInParam, ref NET_OUT_FINDNUMBERSTAT pstOutParam)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartFindNumberStat(lLoginID, ref pstInParam, ref pstOutParam);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static int DoFindNumberStat(IntPtr lFindHandle, ref NET_IN_DOFINDNUMBERSTAT pstInParam, ref NET_NUMBERSTAT[] pNumberStats)
	{
		int num = 0;
		uint nCount = pstInParam.nCount;
		IntPtr intPtr = IntPtr.Zero;
		NET_OUT_DOFINDNUMBERSTAT pstOutParam = default(NET_OUT_DOFINDNUMBERSTAT);
		int num2 = Marshal.SizeOf(typeof(NET_NUMBERSTAT));
		try
		{
			intPtr = Marshal.AllocHGlobal(num2 * (int)nCount);
			pstOutParam.dwSize = (uint)Marshal.SizeOf(pstOutParam);
			pstOutParam.pstuNumberStat = intPtr;
			pstOutParam.nBufferLen = (int)nCount * num2;
			pstOutParam.nCount = (int)pstInParam.nCount;
			for (int i = 0; i < nCount; i++)
			{
				NET_NUMBERSTAT structure = default(NET_NUMBERSTAT);
				structure.dwSize = (uint)Marshal.SizeOf(structure);
				Marshal.StructureToPtr(structure, IntPtr.Add(intPtr, i * num2), fDeleteOld: true);
			}
			num = OriginalSDK.CLIENT_DoFindNumberStat(lFindHandle, ref pstInParam, ref pstOutParam);
			NetGetLastError(num);
			if (num > 0)
			{
				pNumberStats = new NET_NUMBERSTAT[pstOutParam.nCount];
				for (int j = 0; j < pstOutParam.nCount; j++)
				{
					pNumberStats[j] = (NET_NUMBERSTAT)Marshal.PtrToStructure(IntPtr.Add(intPtr, j * num2), typeof(NET_NUMBERSTAT));
				}
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			intPtr = IntPtr.Zero;
		}
		return num;
	}

	public static bool StopFindNumberStat(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_StopFindNumberStat(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachVideoStatSummary(IntPtr lLoginID, ref NET_IN_ATTACH_VIDEOSTAT_SUM pInParam, ref NET_OUT_ATTACH_VIDEOSTAT_SUM pOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachVideoStatSummary(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachVideoStatSummary(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachVideoStatSummary(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr CreateTransComChannel(IntPtr lLoginID, int TransComType, uint baudrate, uint databits, uint stopbits, uint parity, fTransComCallBack cbTransCom, IntPtr dwUser)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_CreateTransComChannel(lLoginID, TransComType, baudrate, databits, stopbits, parity, cbTransCom, dwUser);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool SendTransComData(IntPtr lTransComChannel, byte[] byDatas)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		uint num = (uint)byDatas.Length;
		try
		{
			intPtr = Marshal.AllocHGlobal(byDatas.Length);
			for (int i = 0; i < num; i++)
			{
				Marshal.WriteByte(intPtr, i, byDatas[i]);
			}
			flag = OriginalSDK.CLIENT_SendTransComData(lTransComChannel, intPtr, (uint)byDatas.Length);
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
		NetGetLastError(flag);
		return flag;
	}

	public static bool DestroyTransComChannel(IntPtr lTransComChannel)
	{
		bool num = OriginalSDK.CLIENT_DestroyTransComChannel(lTransComChannel);
		NetGetLastError(num);
		return num;
	}

	public static bool NetSetSecurityKey(IntPtr lPlayHandle, string szKey)
	{
		bool num = OriginalSDK.CLIENT_SetSecurityKey(lPlayHandle, szKey, (uint)szKey.Length);
		NetGetLastError(num);
		return num;
	}

	public static bool QueryMatrixCardInfo(IntPtr lLoginID, ref NET_MATRIX_CARD_LIST pstuCardList, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_QueryMatrixCardInfo(lLoginID, ref pstuCardList, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetSplitCaps(IntPtr lLoginId, int nChannel, ref NET_SPLIT_CAPS stuCaps, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetSplitCaps(lLoginId, nChannel, ref stuCaps, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetSplitMode(IntPtr lLoginID, int nChannel, ref NET_SPLIT_MODE_INFO stuSplitInfo, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetSplitMode(lLoginID, nChannel, ref stuSplitInfo, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetSplitMode(IntPtr lLoginID, int nChannel, ref NET_SPLIT_MODE_INFO stuSplitInfo, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_SetSplitMode(lLoginID, nChannel, ref stuSplitInfo, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool OpenSplitWindow(IntPtr lLoginID, ref NET_IN_SPLIT_OPEN_WINDOW pInParam, ref NET_OUT_SPLIT_OPEN_WINDOW pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_OpenSplitWindow(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool MatrixSetCameras(IntPtr lLoginID, ref NET_IN_MATRIX_SET_CAMERAS pInParam, ref NET_OUT_MATRIX_SET_CAMERAS pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_MatrixSetCameras(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool MatrixGetCameras(IntPtr lLoginID, out NET_MATRIX_CAMERA_INFO[] stuCameras, int nMaxCameraCount, int nWaitTime)
	{
		bool flag = false;
		stuCameras = new NET_MATRIX_CAMERA_INFO[nMaxCameraCount];
		NET_IN_MATRIX_GET_CAMERAS pInParam = default(NET_IN_MATRIX_GET_CAMERAS);
		pInParam.dwSize = (uint)Marshal.SizeOf(pInParam.GetType());
		NET_OUT_MATRIX_GET_CAMERAS pOutParam = default(NET_OUT_MATRIX_GET_CAMERAS);
		pOutParam.dwSize = (uint)Marshal.SizeOf(pOutParam.GetType());
		try
		{
			int cb = Marshal.SizeOf(typeof(NET_MATRIX_CAMERA_INFO)) * nMaxCameraCount;
			pOutParam.pstuCameras = Marshal.AllocHGlobal(cb);
			for (int i = 0; i < nMaxCameraCount; i++)
			{
				stuCameras[i].dwSize = (uint)Marshal.SizeOf(stuCameras[i].GetType());
				stuCameras[i].stuRemoteDevice.dwSize = (uint)Marshal.SizeOf(stuCameras[i].stuRemoteDevice.GetType());
				IntPtr ptr = IntPtr.Add(pOutParam.pstuCameras, Marshal.SizeOf(typeof(NET_MATRIX_CAMERA_INFO)) * i);
				Marshal.StructureToPtr(stuCameras[i], ptr, fDeleteOld: true);
			}
			pOutParam.nMaxCameraCount = nMaxCameraCount;
			flag = OriginalSDK.CLIENT_MatrixGetCameras(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
			NetGetLastError(flag);
			if (flag)
			{
				int num = Math.Min(pOutParam.nMaxCameraCount, pOutParam.nRetCameraCount);
				stuCameras = new NET_MATRIX_CAMERA_INFO[num];
				for (int j = 0; j < num; j++)
				{
					IntPtr ptr2 = IntPtr.Add(pOutParam.pstuCameras, Marshal.SizeOf(typeof(NET_MATRIX_CAMERA_INFO)) * j);
					stuCameras[j] = (NET_MATRIX_CAMERA_INFO)Marshal.PtrToStructure(ptr2, typeof(NET_MATRIX_CAMERA_INFO));
				}
			}
		}
		finally
		{
			Marshal.FreeHGlobal(pOutParam.pstuCameras);
		}
		return flag;
	}

	public static bool SetSplitSource(IntPtr lLoginID, int nChannel, int nWindow, NET_SPLIT_SOURCE[] stuSplitSrcs, int nWaitTime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_SPLIT_SOURCE)) * stuSplitSrcs.Length);
			for (int i = 0; i < stuSplitSrcs.Length; i++)
			{
				IntPtr ptr = IntPtr.Add(intPtr, Marshal.SizeOf(typeof(NET_SPLIT_SOURCE)) * i);
				Marshal.StructureToPtr(stuSplitSrcs[i], ptr, fDeleteOld: true);
			}
			flag = OriginalSDK.CLIENT_SetSplitSource(lLoginID, nChannel, nWindow, intPtr, stuSplitSrcs.Length, nWaitTime);
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
		NetGetLastError(flag);
		return flag;
	}

	public static bool SetSplitSourceEx(IntPtr lLoginID, NET_IN_SET_SPLIT_SOURCE inParam, ref NET_OUT_SET_SPLIT_SOURCE outParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_SetSplitSourceEx(lLoginID, ref inParam, ref outParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetNewDevConfig(IntPtr lLoginID, int lChannel, string strCommand, ref object obj, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		uint num = 1048576u;
		int error = 0;
		try
		{
			intPtr = Marshal.AllocHGlobal((int)num);
			for (int i = 0; i < num; i++)
			{
				Marshal.WriteByte(intPtr, i, 0);
			}
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			if (obj.GetType() == typeName)
			{
				Marshal.StructureToPtr(obj, intPtr2, fDeleteOld: true);
			}
			else
			{
				for (int j = 0; j < Marshal.SizeOf(typeName); j++)
				{
					Marshal.WriteByte(intPtr2, j, 0);
				}
			}
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)));
			if (intPtr != IntPtr.Zero && intPtr2 != IntPtr.Zero)
			{
				flag = OriginalSDK.CLIENT_GetNewDevConfig(lLoginID, strCommand, lChannel, intPtr, num, out error, waittime);
				if (flag)
				{
					flag = OriginalSDK.CLIENT_ParseData(strCommand, intPtr, intPtr2, (uint)Marshal.SizeOf(typeName), intPtr3);
					obj = Marshal.PtrToStructure(intPtr2, typeName);
				}
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			intPtr = IntPtr.Zero;
			intPtr2 = IntPtr.Zero;
			intPtr3 = IntPtr.Zero;
		}
		NetGetLastError(flag);
		return flag;
	}

	public static bool GetNewDevConfig(IntPtr lLoginID, int lChannel, string strCommand, ref object[] objs, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		uint num = 1048576u;
		int num2 = Marshal.SizeOf(typeName) * objs.Length;
		int error = 0;
		try
		{
			intPtr = Marshal.AllocHGlobal((int)num);
			for (int i = 0; i < num; i++)
			{
				Marshal.WriteByte(intPtr, i, 0);
			}
			intPtr2 = Marshal.AllocHGlobal(num2);
			for (int j = 0; j < objs.Length; j++)
			{
				IntPtr ptr = intPtr2 + j * Marshal.SizeOf(typeName);
				if (objs[j].GetType() == typeName)
				{
					Marshal.StructureToPtr(objs[j], ptr, fDeleteOld: true);
					continue;
				}
				for (int k = 0; k < Marshal.SizeOf(typeName); k++)
				{
					Marshal.WriteByte(ptr, k, 0);
				}
			}
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
			Marshal.WriteInt32(intPtr3, 0);
			if (intPtr != IntPtr.Zero && intPtr2 != IntPtr.Zero)
			{
				flag = OriginalSDK.CLIENT_GetNewDevConfig(lLoginID, strCommand, lChannel, intPtr, num, out error, waittime);
				if (flag)
				{
					flag = OriginalSDK.CLIENT_ParseData(strCommand, intPtr, intPtr2, (uint)num2, intPtr3);
					if (flag)
					{
						int num3 = Marshal.ReadInt32(intPtr3) / Marshal.SizeOf(typeName);
						objs = new object[num3];
						for (int l = 0; l < num3; l++)
						{
							objs[l] = Marshal.PtrToStructure(IntPtr.Add(intPtr2, l * Marshal.SizeOf(typeName)), typeName);
						}
					}
				}
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			intPtr = IntPtr.Zero;
			intPtr2 = IntPtr.Zero;
			intPtr3 = IntPtr.Zero;
		}
		NetGetLastError(flag);
		return flag;
	}

	public static bool SetNewDevConfig(IntPtr lLoginID, int lChannel, string strCommand, object obj, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		uint num = 1048576u;
		int restart = 0;
		int error = 0;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			for (int i = 0; i < Marshal.SizeOf(typeName); i++)
			{
				Marshal.WriteByte(intPtr, i, 0);
			}
			intPtr2 = Marshal.AllocHGlobal((int)num);
			for (int j = 0; j < num; j++)
			{
				Marshal.WriteByte(intPtr2, j, 0);
			}
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_PacketData(strCommand, intPtr, (uint)Marshal.SizeOf(typeName), intPtr2, num);
			if (flag)
			{
				flag = OriginalSDK.CLIENT_SetNewDevConfig(lLoginID, strCommand, lChannel, intPtr2, num, ref error, ref restart, waittime);
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			intPtr = IntPtr.Zero;
			intPtr2 = IntPtr.Zero;
		}
		NetGetLastError(flag);
		return flag;
	}

	public static bool PacketData(string szCommand, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr szOutBuffer, uint dwOutFufferSize)
	{
		bool num = OriginalSDK.CLIENT_PacketData(szCommand, lpInBuffer, dwInBufferSize, szOutBuffer, dwOutFufferSize);
		NetGetLastError(num);
		return num;
	}

	public static bool SetNewDevConfigs(IntPtr lLoginID, int lChannel, string strCommand, object[] objs, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		uint num = (uint)(1048576 * objs.Length);
		int restart = 0;
		int error = 0;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName) * objs.Length);
			for (int i = 0; i < objs.Length; i++)
			{
				IntPtr ptr = IntPtr.Add(intPtr, i * Marshal.SizeOf(typeName));
				for (int j = 0; j < Marshal.SizeOf(typeName); j++)
				{
					Marshal.WriteByte(ptr, j, 0);
				}
				Marshal.StructureToPtr(objs[i], ptr, fDeleteOld: true);
			}
			intPtr2 = Marshal.AllocHGlobal((int)num);
			for (int k = 0; k < num; k++)
			{
				Marshal.WriteByte(intPtr2, k, 0);
			}
			flag = OriginalSDK.CLIENT_PacketData(strCommand, intPtr, (uint)(Marshal.SizeOf(typeName) * objs.Length), intPtr2, num);
			if (flag)
			{
				flag = OriginalSDK.CLIENT_SetNewDevConfig(lLoginID, strCommand, lChannel, intPtr2, num, ref error, ref restart, waittime);
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			intPtr = IntPtr.Zero;
			intPtr2 = IntPtr.Zero;
		}
		NetGetLastError(flag);
		return flag;
	}

	public static bool GetOperateConfig(IntPtr lLoginID, EM_CFG_OPERATE_TYPE cfg_type, int lChannel, ref object obj, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)cfg_type, lChannel, intPtr, (uint)Marshal.SizeOf(typeName), waittime, IntPtr.Zero);
			NetGetLastError(flag);
			obj = Marshal.PtrToStructure(intPtr, typeName);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool SetOperateConfig(IntPtr lLoginID, EM_CFG_OPERATE_TYPE cfg_type, int lChannel, object obj, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)cfg_type, lChannel, intPtr, (uint)Marshal.SizeOf(typeName), waittime, IntPtr.Zero, IntPtr.Zero);
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool GetAttendanceConfig(IntPtr lLoginID, int lChannel, ref object obj, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_GetConfig(lLoginID, 3908, lChannel, intPtr, (uint)Marshal.SizeOf(typeName), waittime, IntPtr.Zero);
			NetGetLastError(!flag);
			obj = Marshal.PtrToStructure(intPtr, typeName);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool SetAttendanceConfig(IntPtr lLoginID, int lChannel, object obj, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_SetConfig(lLoginID, 3908, lChannel, intPtr, (uint)Marshal.SizeOf(typeName), waittime, IntPtr.Zero, IntPtr.Zero);
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool QueryDeviceTime(IntPtr lLoginID, ref NET_TIME pDeviceTime, int waittime)
	{
		bool num = OriginalSDK.CLIENT_QueryDeviceTime(lLoginID, ref pDeviceTime, waittime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetupDeviceTime(IntPtr lLoginID, NET_TIME DeviceTime)
	{
		bool num = OriginalSDK.CLIENT_SetupDeviceTime(lLoginID, ref DeviceTime);
		NetGetLastError(num);
		return num;
	}

	public static bool ClearRepeatEnter(IntPtr lLoginID, ref NET_IN_CLEAR_REPEAT_ENTER pInParam, ref NET_OUT_CLEAR_REPEAT_ENTER pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_ClearRepeatEnter(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool FaceInfoOpreate(IntPtr lLoginID, EM_FACEINFO_OPREATE_TYPE emType, IntPtr pInParam, IntPtr pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_FaceInfoOpreate(lLoginID, emType, pInParam, pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartFindFaceInfo(IntPtr lLoginID, NET_IN_FACEINFO_START_FIND inParam, ref NET_OUT_FACEINFO_START_FIND outParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartFindFaceInfo(lLoginID, ref inParam, ref outParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DoFindFaceInfo(IntPtr lFindHandle, NET_IN_FACEINFO_DO_FIND inParam, ref NET_OUT_FACEINFO_DO_FIND outParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_DoFindFaceInfo(lFindHandle, ref inParam, ref outParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StopFindFaceInfo(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_StopFindFaceInfo(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool InsertOperateAccessUserService(IntPtr lLoginID, NET_ACCESS_USER_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
	{
		bool flag = false;
		int num = stInParam.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		IntPtr intPtr4 = IntPtr.Zero;
		NET_IN_ACCESS_USER_SERVICE_INSERT structure = default(NET_IN_ACCESS_USER_SERVICE_INSERT);
		NET_OUT_ACCESS_USER_SERVICE_INSERT structure2 = default(NET_OUT_ACCESS_USER_SERVICE_INSERT);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_USER_INFO)) * num);
			intPtr4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			for (int i = 0; i < num; i++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_ACCESS_USER_INFO)) * i);
				Marshal.StructureToPtr(stInParam[i], ptr, fDeleteOld: true);
			}
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.nInfoNum = num;
			structure.pUserInfo = intPtr3;
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr4;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessUserService(lLoginID, EM_ACCESS_CTL_USER_SERVICE.INSERT, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_USER_SERVICE_INSERT)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_USER_SERVICE_INSERT));
			stOutParam = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int j = 0; j < structure2.nMaxRetNum; j++)
			{
				IntPtr ptr2 = IntPtr.Add(intPtr4, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * j);
				stOutParam[j] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr2, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			Marshal.FreeHGlobal(intPtr4);
		}
	}

	public static bool InsertOperateAccessCardService(IntPtr lLoginID, NET_ACCESS_CARD_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
	{
		bool flag = false;
		int num = stInParam.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		IntPtr intPtr4 = IntPtr.Zero;
		NET_IN_ACCESS_CARD_SERVICE_INSERT structure = default(NET_IN_ACCESS_CARD_SERVICE_INSERT);
		NET_OUT_ACCESS_CARD_SERVICE_INSERT structure2 = default(NET_OUT_ACCESS_CARD_SERVICE_INSERT);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * num);
			intPtr4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			for (int i = 0; i < num; i++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * i);
				Marshal.StructureToPtr(stInParam[i], ptr, fDeleteOld: true);
			}
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.nInfoNum = num;
			structure.pCardInfo = intPtr3;
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr4;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.INSERT, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_CARD_SERVICE_INSERT)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_CARD_SERVICE_INSERT));
			stOutParam = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int j = 0; j < structure2.nMaxRetNum; j++)
			{
				IntPtr ptr2 = IntPtr.Add(intPtr4, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * j);
				stOutParam[j] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr2, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			Marshal.FreeHGlobal(intPtr4);
		}
	}

	public static bool InsertOperateAccessFingerprintService(IntPtr lLoginID, NET_ACCESS_FINGERPRINT_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
	{
		bool flag = false;
		int num = stInParam.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		IntPtr intPtr4 = IntPtr.Zero;
		NET_IN_ACCESS_FINGERPRINT_SERVICE_INSERT structure = default(NET_IN_ACCESS_FINGERPRINT_SERVICE_INSERT);
		NET_OUT_ACCESS_FINGERPRINT_SERVICE_INSERT structure2 = default(NET_OUT_ACCESS_FINGERPRINT_SERVICE_INSERT);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_FINGERPRINT_INFO)) * num);
			intPtr4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			for (int i = 0; i < num; i++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_ACCESS_FINGERPRINT_INFO)) * i);
				Marshal.StructureToPtr(stInParam[i], ptr, fDeleteOld: true);
			}
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.nFpNum = num;
			structure.pFingerPrintInfo = intPtr3;
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr4;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.INSERT, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_FINGERPRINT_SERVICE_INSERT)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_FINGERPRINT_SERVICE_INSERT));
			stOutParam = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int j = 0; j < structure2.nMaxRetNum; j++)
			{
				IntPtr ptr2 = IntPtr.Add(intPtr4, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * j);
				stOutParam[j] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr2, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			Marshal.FreeHGlobal(intPtr4);
		}
	}

	public static bool GetOperateAccessUserService(IntPtr lLoginID, string[] userid, out NET_ACCESS_USER_INFO[] stOutParam1, out NET_EM_FAILCODE[] stOutParam2, int nWaitTime)
	{
		bool flag = false;
		int num = userid.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		IntPtr intPtr4 = IntPtr.Zero;
		NET_IN_ACCESS_USER_SERVICE_GET structure = default(NET_IN_ACCESS_USER_SERVICE_GET);
		NET_OUT_ACCESS_USER_SERVICE_GET structure2 = default(NET_OUT_ACCESS_USER_SERVICE_GET);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_USER_INFO)) * num);
			intPtr4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.szUserID = new NET_STRING_32_USER_ID[100];
			structure.nUserNum = num;
			for (int i = 0; i < Math.Min(num, structure.szUserID.Length); i++)
			{
				structure.szUserID[i].szUserID = userid[i];
			}
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr4;
			structure2.pUserInfo = intPtr3;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessUserService(lLoginID, EM_ACCESS_CTL_USER_SERVICE.GET, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_USER_SERVICE_GET)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_USER_SERVICE_GET));
			stOutParam1 = new NET_ACCESS_USER_INFO[structure2.nMaxRetNum];
			for (int j = 0; j < num; j++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_ACCESS_USER_INFO)) * j);
				stOutParam1[j] = (NET_ACCESS_USER_INFO)Marshal.PtrToStructure(ptr, typeof(NET_ACCESS_USER_INFO));
			}
			stOutParam2 = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int k = 0; k < structure2.nMaxRetNum; k++)
			{
				IntPtr ptr2 = IntPtr.Add(intPtr4, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * k);
				stOutParam2[k] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr2, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			Marshal.FreeHGlobal(intPtr4);
		}
	}

	public static bool GetOperateAccessCardService(IntPtr lLoginID, string[] Cardid, out NET_ACCESS_CARD_INFO[] stOutParam1, out NET_EM_FAILCODE[] stOutParam2, int nWaitTime)
	{
		bool flag = false;
		int num = Cardid.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		IntPtr intPtr4 = IntPtr.Zero;
		NET_IN_ACCESS_CARD_SERVICE_GET structure = default(NET_IN_ACCESS_CARD_SERVICE_GET);
		NET_OUT_ACCESS_CARD_SERVICE_GET structure2 = default(NET_OUT_ACCESS_CARD_SERVICE_GET);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * num);
			intPtr4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.szCardNo = new NET_STRING_32_CARD_NO[100];
			structure.nCardNum = num;
			for (int i = 0; i < Math.Min(num, structure.szCardNo.Length); i++)
			{
				structure.szCardNo[i].szCardNo = Cardid[i];
			}
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr4;
			structure2.pCardInfo = intPtr3;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.GET, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_CARD_SERVICE_GET)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_CARD_SERVICE_GET));
			stOutParam1 = new NET_ACCESS_CARD_INFO[structure2.nMaxRetNum];
			for (int j = 0; j < num; j++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * j);
				stOutParam1[j] = (NET_ACCESS_CARD_INFO)Marshal.PtrToStructure(ptr, typeof(NET_ACCESS_CARD_INFO));
			}
			stOutParam2 = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int k = 0; k < structure2.nMaxRetNum; k++)
			{
				IntPtr ptr2 = IntPtr.Add(intPtr4, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * k);
				stOutParam2[k] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr2, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			Marshal.FreeHGlobal(intPtr4);
		}
	}

	public static bool GetOperateAccessFingerprintService(IntPtr lLoginID, string userid, IntPtr pFingerprintData, int dataLen, out NET_ACCESS_FINGERPRINT_INFO stOutParam1, int nWaitTime)
	{
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		NET_IN_ACCESS_FINGERPRINT_SERVICE_GET structure = default(NET_IN_ACCESS_FINGERPRINT_SERVICE_GET);
		NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET structure2 = default(NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.szUserID = userid;
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxFingerDataLength = dataLen;
			structure2.pbyFingerData = pFingerprintData;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			bool result = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.GET, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET));
			stOutParam1 = default(NET_ACCESS_FINGERPRINT_INFO);
			stOutParam1.szUserID = userid;
			stOutParam1.nDuressIndex = structure2.nDuressIndex;
			stOutParam1.nPacketLen = structure2.nSinglePacketLength;
			stOutParam1.nPacketNum = structure2.nRetFingerPrintCount;
			stOutParam1.szFingerPrintInfo = structure2.pbyFingerData;
			return result;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
	}

	public static bool RemoveOperateAccessUserService(IntPtr lLoginID, string[] userid, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
	{
		bool flag = false;
		int num = userid.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		NET_IN_ACCESS_USER_SERVICE_REMOVE structure = default(NET_IN_ACCESS_USER_SERVICE_REMOVE);
		NET_OUT_ACCESS_USER_SERVICE_REMOVE structure2 = default(NET_OUT_ACCESS_USER_SERVICE_REMOVE);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.szUserID = new NET_STRING_32_USER_ID[100];
			structure.nUserNum = num;
			for (int i = 0; i < Math.Min(num, structure.szUserID.Length); i++)
			{
				structure.szUserID[i].szUserID = userid[i];
			}
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr3;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessUserService(lLoginID, EM_ACCESS_CTL_USER_SERVICE.REMOVE, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_USER_SERVICE_REMOVE)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_USER_SERVICE_REMOVE));
			stOutParam = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int j = 0; j < structure2.nMaxRetNum; j++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * j);
				stOutParam[j] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
		}
	}

	public static bool RemoveOperateAccessCardService(IntPtr lLoginID, string[] Cardid, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
	{
		bool flag = false;
		int num = Cardid.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		NET_IN_ACCESS_CARD_SERVICE_REMOVE structure = default(NET_IN_ACCESS_CARD_SERVICE_REMOVE);
		NET_OUT_ACCESS_CARD_SERVICE_REMOVE structure2 = default(NET_OUT_ACCESS_CARD_SERVICE_REMOVE);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.szCardNo = new NET_STRING_32_CARD_NO[100];
			structure.nCardNum = num;
			for (int i = 0; i < Math.Min(num, structure.szCardNo.Length); i++)
			{
				structure.szCardNo[i].szCardNo = Cardid[i];
			}
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr3;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.REMOVE, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_CARD_SERVICE_REMOVE)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_CARD_SERVICE_REMOVE));
			stOutParam = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int j = 0; j < structure2.nMaxRetNum; j++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * j);
				stOutParam[j] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
		}
	}

	public static bool RemoveOperateAccessFingerprintService(IntPtr lLoginID, string[] userid, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
	{
		bool flag = false;
		int num = userid.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		NET_IN_ACCESS_FINGERPRINT_SERVICE_REMOVE structure = default(NET_IN_ACCESS_FINGERPRINT_SERVICE_REMOVE);
		NET_OUT_ACCESS_FINGERPRINT_SERVICE_REMOVE structure2 = default(NET_OUT_ACCESS_FINGERPRINT_SERVICE_REMOVE);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.szUserID = new NET_STRING_32_USER_ID[100];
			structure.nUserNum = num;
			for (int i = 0; i < Math.Min(num, structure.szUserID.Length); i++)
			{
				structure.szUserID[i].szUserID = userid[i];
			}
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr3;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.REMOVE, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_FINGERPRINT_SERVICE_REMOVE)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_FINGERPRINT_SERVICE_REMOVE));
			stOutParam = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int j = 0; j < structure2.nMaxRetNum; j++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * j);
				stOutParam[j] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
		}
	}

	public static bool ClearOperateAccessUserService(IntPtr lLoginID, int nWaitTime)
	{
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		NET_IN_ACCESS_USER_SERVICE_CLEAR structure = default(NET_IN_ACCESS_USER_SERVICE_CLEAR);
		NET_OUT_ACCESS_USER_SERVICE_CLEAR structure2 = default(NET_OUT_ACCESS_USER_SERVICE_CLEAR);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			bool num = OriginalSDK.CLIENT_OperateAccessUserService(lLoginID, EM_ACCESS_CTL_USER_SERVICE.CLEAR, intPtr, intPtr2, nWaitTime);
			NetGetLastError(num);
			return num;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
	}

	public static bool ClearOperateAccessCardService(IntPtr lLoginID, int nWaitTime)
	{
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		NET_IN_ACCESS_CARD_SERVICE_CLEAR structure = default(NET_IN_ACCESS_CARD_SERVICE_CLEAR);
		NET_OUT_ACCESS_CARD_SERVICE_CLEAR structure2 = default(NET_OUT_ACCESS_CARD_SERVICE_CLEAR);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			bool num = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.CLEAR, intPtr, intPtr2, nWaitTime);
			NetGetLastError(num);
			return num;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
	}

	public static bool ClearOperateAccessFingerprintService(IntPtr lLoginID, int nWaitTime)
	{
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		NET_IN_ACCESS_FINGERPRINT_SERVICE_CLEAR structure = default(NET_IN_ACCESS_FINGERPRINT_SERVICE_CLEAR);
		NET_OUT_ACCESS_FINGERPRINT_SERVICE_CLEAR structure2 = default(NET_OUT_ACCESS_FINGERPRINT_SERVICE_CLEAR);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			bool num = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.CLEAR, intPtr, intPtr2, nWaitTime);
			NetGetLastError(num);
			return num;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
	}

	public static bool UpdateOperateAccessCardService(IntPtr lLoginID, NET_ACCESS_CARD_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
	{
		bool flag = false;
		int num = stInParam.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		IntPtr intPtr4 = IntPtr.Zero;
		NET_IN_ACCESS_CARD_SERVICE_UPDATE structure = default(NET_IN_ACCESS_CARD_SERVICE_UPDATE);
		NET_OUT_ACCESS_CARD_SERVICE_UPDATE structure2 = default(NET_OUT_ACCESS_CARD_SERVICE_UPDATE);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * num);
			intPtr4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			for (int i = 0; i < num; i++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * i);
				Marshal.StructureToPtr(stInParam[i], ptr, fDeleteOld: true);
			}
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.nInfoNum = num;
			structure.pCardInfo = intPtr3;
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr4;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.UPDATE, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_CARD_SERVICE_UPDATE)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_CARD_SERVICE_UPDATE));
			stOutParam = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int j = 0; j < structure2.nMaxRetNum; j++)
			{
				IntPtr ptr2 = IntPtr.Add(intPtr4, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * j);
				stOutParam[j] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr2, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			Marshal.FreeHGlobal(intPtr4);
		}
	}

	public static bool UpdateOperateAccessFingerprintService(IntPtr lLoginID, NET_ACCESS_FINGERPRINT_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
	{
		bool flag = false;
		int num = stInParam.Length;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		IntPtr intPtr4 = IntPtr.Zero;
		NET_IN_ACCESS_FINGERPRINT_SERVICE_UPDATE structure = default(NET_IN_ACCESS_FINGERPRINT_SERVICE_UPDATE);
		NET_OUT_ACCESS_FINGERPRINT_SERVICE_UPDATE structure2 = default(NET_OUT_ACCESS_FINGERPRINT_SERVICE_UPDATE);
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_FINGERPRINT_INFO)) * num);
			intPtr4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * num);
			for (int i = 0; i < num; i++)
			{
				IntPtr ptr = IntPtr.Add(intPtr3, Marshal.SizeOf(typeof(NET_ACCESS_FINGERPRINT_INFO)) * i);
				Marshal.StructureToPtr(stInParam[i], ptr, fDeleteOld: true);
			}
			structure.dwSize = (uint)Marshal.SizeOf(structure);
			structure.nFpNum = num;
			structure.pFingerPrintInfo = intPtr3;
			structure2.dwSize = (uint)Marshal.SizeOf(structure2);
			structure2.nMaxRetNum = num;
			structure2.pFailCode = intPtr4;
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.UPDATE, intPtr, intPtr2, nWaitTime);
			structure2 = (NET_OUT_ACCESS_FINGERPRINT_SERVICE_UPDATE)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_ACCESS_FINGERPRINT_SERVICE_UPDATE));
			stOutParam = new NET_EM_FAILCODE[structure2.nMaxRetNum];
			for (int j = 0; j < structure2.nMaxRetNum; j++)
			{
				IntPtr ptr2 = IntPtr.Add(intPtr4, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * j);
				stOutParam[j] = (NET_EM_FAILCODE)Marshal.PtrToStructure(ptr2, typeof(NET_EM_FAILCODE));
			}
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			Marshal.FreeHGlobal(intPtr4);
		}
	}

	public static bool OperateFaceRecognitionDB(IntPtr lLoginID, ref NET_IN_OPERATE_FACERECONGNITIONDB pstInParam, ref NET_OUT_OPERATE_FACERECONGNITIONDB pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_OperateFaceRecognitionDB(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr FindFile(IntPtr lLoginID, EM_FILE_QUERY_TYPE emType, object oQueryCondition, Type tyCondition, int waittime)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			if (oQueryCondition == null || tyCondition == null)
			{
				intPtr = IntPtr.Zero;
			}
			else
			{
				int cb = Marshal.SizeOf(tyCondition);
				Marshal.SizeOf(oQueryCondition);
				intPtr = Marshal.AllocHGlobal(cb);
				Marshal.StructureToPtr(oQueryCondition, intPtr, fDeleteOld: true);
			}
			zero = OriginalSDK.CLIENT_FindFileEx(lLoginID, emType, intPtr, IntPtr.Zero, waittime);
			NetGetLastError(zero);
			return zero;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static int FindNextFile(IntPtr lFindHandle, int nFilecount, List<object> lsOMediaFileInfo, Type tyFile, int waittime)
	{
		int num = 0;
		IntPtr intPtr = IntPtr.Zero;
		int num2 = Marshal.SizeOf(tyFile);
		int num3 = num2 * nFilecount;
		try
		{
			intPtr = Marshal.AllocHGlobal(num3);
			for (int i = 0; i < nFilecount; i++)
			{
				Marshal.StructureToPtr(lsOMediaFileInfo[i], IntPtr.Add(intPtr, i * num2), fDeleteOld: true);
			}
			num = OriginalSDK.CLIENT_FindNextFileEx(lFindHandle, nFilecount, intPtr, num3, IntPtr.Zero, waittime);
			if (num >= 0)
			{
				for (int j = 0; j < num; j++)
				{
					lsOMediaFileInfo[j] = Marshal.PtrToStructure(IntPtr.Add(intPtr, j * num2), tyFile);
				}
			}
			else
			{
				NetGetLastError(num);
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
		return num;
	}

	public static bool FindClose(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_FindCloseEx(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool DetectFace(IntPtr lLoginID, ref NET_IN_DETECT_FACE pstInParam, ref NET_OUT_DETECT_FACE pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_DetectFace(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachFaceFindState(IntPtr lLoginID, ref NET_IN_FACE_FIND_STATE pstInParam, ref NET_OUT_FACE_FIND_STATE pstOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachFaceFindState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachFaceFindState(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachFaceFindState(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool StartFindFaceRecognition(IntPtr lLoginID, ref NET_IN_STARTFIND_FACERECONGNITION pstInParam, ref NET_OUT_STARTFIND_FACERECONGNITION pstOutParam, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_IN_STARTFIND_FACERECONGNITION)));
			Marshal.StructureToPtr(pstInParam, intPtr, fDeleteOld: true);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_STARTFIND_FACERECONGNITION)));
			Marshal.StructureToPtr(pstOutParam, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_StartFindFaceRecognition(lLoginID, intPtr, intPtr2, waittime);
			NetGetLastError(flag);
			if (flag)
			{
				pstOutParam = (NET_OUT_STARTFIND_FACERECONGNITION)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_STARTFIND_FACERECONGNITION));
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
		return flag;
	}

	public static bool StartMultiFindFaceRecognition(IntPtr lLoginID, ref NET_IN_STARTMULTIFIND_FACERECONGNITION pstInParam, ref NET_OUT_STARTMULTIFIND_FACERECONGNITION pstOutParam, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_IN_STARTMULTIFIND_FACERECONGNITION)));
			Marshal.StructureToPtr(pstInParam, intPtr, fDeleteOld: true);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_STARTMULTIFIND_FACERECONGNITION)));
			Marshal.StructureToPtr(pstOutParam, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_StartMultiFindFaceRecognition(lLoginID, intPtr, intPtr2, waittime);
			NetGetLastError(flag);
			if (flag)
			{
				pstOutParam = (NET_OUT_STARTMULTIFIND_FACERECONGNITION)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_STARTMULTIFIND_FACERECONGNITION));
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
		return flag;
	}

	public static bool DoFindFaceRecognition(ref NET_IN_DOFIND_FACERECONGNITION pstInParam, ref NET_OUT_DOFIND_FACERECONGNITION pstOutParam, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_IN_DOFIND_FACERECONGNITION)));
			Marshal.StructureToPtr(pstInParam, intPtr, fDeleteOld: true);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_DOFIND_FACERECONGNITION)));
			Marshal.StructureToPtr(pstOutParam, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_DoFindFaceRecognition(intPtr, intPtr2, waittime);
			NetGetLastError(flag);
			if (flag)
			{
				pstOutParam = (NET_OUT_DOFIND_FACERECONGNITION)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_DOFIND_FACERECONGNITION));
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
		return flag;
	}

	public static bool StopFindFaceRecognition(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_StopFindFaceRecognition(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool DoFindFaceRecognitionRecordEx(NET_IN_DOFIND_FACERECONGNITIONRECORD_EX inParam, ref NET_OUT_DOFIND_FACERECONGNITIONRECORD_EX outParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_DoFindFaceRecognitionRecordEx(ref inParam, ref outParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool FaceRecognitionPutDisposition(IntPtr lLoginID, NET_IN_FACE_RECOGNITION_PUT_DISPOSITION_INFO inParam, ref NET_OUT_FACE_RECOGNITION_PUT_DISPOSITION_INFO outParam, int nWaitTime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_IN_FACE_RECOGNITION_PUT_DISPOSITION_INFO)));
			Marshal.StructureToPtr(inParam, intPtr, fDeleteOld: true);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_FACE_RECOGNITION_PUT_DISPOSITION_INFO)));
			Marshal.StructureToPtr(outParam, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_FaceRecognitionPutDisposition(lLoginID, intPtr, intPtr2, nWaitTime);
			NetGetLastError(flag);
			if (flag)
			{
				outParam = (NET_OUT_FACE_RECOGNITION_PUT_DISPOSITION_INFO)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_FACE_RECOGNITION_PUT_DISPOSITION_INFO));
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
		return flag;
	}

	public static bool FaceRecognitionDelDisposition(IntPtr lLoginID, NET_IN_FACE_RECOGNITION_DEL_DISPOSITION_INFO inParam, ref NET_OUT_FACE_RECOGNITION_DEL_DISPOSITION_INFO outParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_FaceRecognitionDelDisposition(lLoginID, ref inParam, ref outParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetTotalFileCount(IntPtr lFindHandle, ref int pTotalCount, IntPtr pReserved, int nWaittime)
	{
		bool num = OriginalSDK.CLIENT_GetTotalFileCount(lFindHandle, ref pTotalCount, pReserved, nWaittime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetFindingJumpOption(IntPtr lFindHandle, ref NET_FINDING_JUMP_OPTION_INFO pOption, IntPtr reserved, int waittime)
	{
		bool num = OriginalSDK.CLIENT_SetFindingJumpOption(lFindHandle, ref pOption, reserved, waittime);
		NetGetLastError(num);
		return num;
	}

	public static bool FindGroupInfo(IntPtr lLoginID, ref NET_IN_FIND_GROUP_INFO pstInParam, ref NET_OUT_FIND_GROUP_INFO pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_FindGroupInfo(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool OperateFaceRecognitionGroup(IntPtr lLoginID, ref NET_IN_OPERATE_FACERECONGNITION_GROUP pstInParam, ref NET_OUT_OPERATE_FACERECONGNITION_GROUP pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_OperateFaceRecognitionGroup(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool RenderPrivateData(IntPtr lPlayHandle, bool bTrue)
	{
		bool num = OriginalSDK.CLIENT_RenderPrivateData(lPlayHandle, bTrue);
		NetGetLastError(num);
		return num;
	}

	public static bool QueryDevInfo(IntPtr lLoginID, ref NET_IN_STORAGE_DEV_INFOS stuInInfo, ref NET_OUT_STORAGE_DEV_INFOS stuOutInfo, int nWaitTime)
	{
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
			Marshal.StructureToPtr(stuInInfo, intPtr, fDeleteOld: true);
			Marshal.StructureToPtr(stuOutInfo, intPtr2, fDeleteOld: true);
			bool num = OriginalSDK.CLIENT_QueryDevInfo(lLoginID, 2, intPtr, intPtr2, IntPtr.Zero, nWaitTime);
			if (num)
			{
				stuOutInfo = (NET_OUT_STORAGE_DEV_INFOS)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_STORAGE_DEV_INFOS));
			}
			NetGetLastError(num);
			return num;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
	}

	public static bool GetOSDConfig(IntPtr lLoginID, EM_CFG_OSD_TYPE emCfgOpType, int nChannelID, ref object obj, int waittime)
	{
		bool flag = false;
		Type type = obj.GetType();
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)emCfgOpType, nChannelID, intPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero);
			NetGetLastError(flag);
			obj = Marshal.PtrToStructure(intPtr, type);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool SetOSDConfig(IntPtr lLoginID, EM_CFG_OSD_TYPE emCfgOpType, int nChannelID, object obj, int waittime)
	{
		bool flag = false;
		Type type = obj.GetType();
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)emCfgOpType, nChannelID, intPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool GetEncodeConfig(IntPtr lLoginID, EM_CFG_ENCODE_TYPE emCfgOpType, int nChannelID, ref object obj, int waittime)
	{
		bool flag = false;
		Type type = obj.GetType();
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)emCfgOpType, nChannelID, intPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero);
			NetGetLastError(flag);
			obj = Marshal.PtrToStructure(intPtr, type);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool SetEncodeConfig(IntPtr lLoginID, EM_CFG_ENCODE_TYPE emCfgOpType, int nChannelID, object obj, int waittime)
	{
		bool flag = false;
		Type type = obj.GetType();
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)emCfgOpType, nChannelID, intPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool SetTrafficVoiceBroadcast(IntPtr lLoginID, NET_CFG_TRAFFIC_VOICE_BROADCAST_INFO info, int waittime)
	{
		bool flag = false;
		Type type = info.GetType();
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
			Marshal.StructureToPtr(info, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_SetConfig(lLoginID, 10001, -1, intPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool GetTrafficVoiceBroadcast(IntPtr lLoginID, ref NET_CFG_TRAFFIC_VOICE_BROADCAST_INFO info, int waittime)
	{
		bool flag = false;
		Type type = info.GetType();
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
			Marshal.StructureToPtr(info, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_GetConfig(lLoginID, 10001, -1, intPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero);
			NetGetLastError(flag);
			info = (NET_CFG_TRAFFIC_VOICE_BROADCAST_INFO)Marshal.PtrToStructure(intPtr, type);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool SetTrafficLatticeScreen(IntPtr lLoginID, NET_CFG_TRAFFIC_LATTICE_SCREEN_INFO info, int waittime)
	{
		bool flag = false;
		Type type = info.GetType();
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
			Marshal.StructureToPtr(info, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_SetConfig(lLoginID, 10000, -1, intPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool GetTrafficLatticeScreen(IntPtr lLoginID, ref NET_CFG_TRAFFIC_LATTICE_SCREEN_INFO info, int waittime)
	{
		bool flag = false;
		Type type = info.GetType();
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
			Marshal.StructureToPtr(info, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_GetConfig(lLoginID, 10000, -1, intPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero);
			NetGetLastError(flag);
			info = (NET_CFG_TRAFFIC_LATTICE_SCREEN_INFO)Marshal.PtrToStructure(intPtr, type);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool SetSpecialDaysScheduleConfig(IntPtr lLoginID, NET_CFG_ACCESSCTL_SPECIALDAY_GROUP_INFO info, int waittime)
	{
		bool flag = false;
		Type type = info.GetType();
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
			Marshal.StructureToPtr(info, intPtr, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_SetConfig(lLoginID, 3902, -1, intPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
			NetGetLastError(flag);
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool GetSpecialDaysScheduleConfig(IntPtr lLoginID, ref object[] objs, Type typeName, int waittime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			int num = Marshal.SizeOf(typeName) * objs.Length;
			intPtr = Marshal.AllocHGlobal(num);
			flag = OriginalSDK.CLIENT_GetConfig(lLoginID, 3902, -1, intPtr, (uint)num, waittime, IntPtr.Zero);
			NetGetLastError(flag);
			for (int i = 0; i < objs.Length; i++)
			{
				objs[i] = Marshal.PtrToStructure(IntPtr.Add(intPtr, i * Marshal.SizeOf(typeName)), typeName);
			}
			return flag;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool GetSplitWindowsInfo(IntPtr lLoginID, object inParam, ref object outParam, int nWaitTime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(inParam.GetType()));
			Marshal.StructureToPtr(inParam, intPtr, fDeleteOld: true);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(outParam.GetType()));
			Marshal.StructureToPtr(outParam, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_GetSplitWindowsInfo(lLoginID, intPtr, intPtr2, nWaitTime);
			NetGetLastError(flag);
			if (flag)
			{
				outParam = Marshal.PtrToStructure(intPtr2, outParam.GetType());
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
		return flag;
	}

	public static bool OperateSplit(IntPtr lLoginID, EM_NET_SPLIT_OPERATE_TYPE emType, object inParam, ref object outParam, int nWaitTime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(inParam.GetType()));
			Marshal.StructureToPtr(inParam, intPtr, fDeleteOld: true);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(outParam.GetType()));
			Marshal.StructureToPtr(outParam, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateSplit(lLoginID, emType, intPtr, intPtr2, nWaitTime);
			NetGetLastError(flag);
			if (flag)
			{
				outParam = Marshal.PtrToStructure(intPtr2, outParam.GetType());
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
		return flag;
	}

	public static bool OperateSplitPlayer(IntPtr lLoginID, EM_NET_PLAYER_OPERATE_TYPE emType, object inParam, ref object outParam, int nWaitTime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(inParam.GetType()));
			Marshal.StructureToPtr(inParam, intPtr, fDeleteOld: true);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(outParam.GetType()));
			Marshal.StructureToPtr(outParam, intPtr2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_OperateSplitPlayer(lLoginID, emType, intPtr, intPtr2, nWaitTime);
			NetGetLastError(flag);
			if (flag)
			{
				outParam = Marshal.PtrToStructure(intPtr2, outParam.GetType());
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
		return flag;
	}

	public static bool WindowRegionEnlarge(IntPtr lLoginID, NET_IN_WINDOW_REGION_ENLARGE inParam, ref NET_OUT_WINDOW_REGION_ENLARGE outParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_WindowRegionEnlarge(lLoginID, ref inParam, ref outParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool WindowEnlargeReduction(IntPtr lLoginID, NET_IN_WINDOW_ENLARGE_REDUCTION inParam, ref NET_OUT_WINDOW_ENLARGE_REDUCTION outParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_WindowEnlargeReduction(lLoginID, ref inParam, ref outParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool OperateTrafficList(IntPtr lLoginID, NET_IN_OPERATE_TRAFFIC_LIST_RECORD inParam, ref NET_OUT_OPERATE_TRAFFIC_LIST_RECORD outParam, int waittime)
	{
		bool num = OriginalSDK.CLIENT_OperateTrafficList(lLoginID, ref inParam, ref outParam, waittime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr FileTransmit(IntPtr lLoginID, EM_FIELTRANSMIT_TYPE nTransType, object obj, fTransFileCallBack cbTransFile, IntPtr dwUserData, int waittime)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(obj.GetType()));
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: true);
			zero = OriginalSDK.CLIENT_FileTransmit(lLoginID, (int)nTransType, intPtr, Marshal.SizeOf(obj.GetType()), cbTransFile, dwUserData, waittime);
			NetGetLastError(zero);
			return zero;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool QueryUserInfoNew(IntPtr lLoginID, ref NET_USER_MANAGE_INFO_NEW info, int waittime)
	{
		IntPtr intPtr = Marshal.AllocHGlobal((int)info.dwSize);
		Marshal.StructureToPtr(info, intPtr, fDeleteOld: true);
		bool num = OriginalSDK.CLIENT_QueryUserInfoNew(lLoginID, intPtr, IntPtr.Zero, waittime);
		NetGetLastError(num);
		if (num)
		{
			info = (NET_USER_MANAGE_INFO_NEW)Marshal.PtrToStructure(intPtr, typeof(NET_USER_MANAGE_INFO_NEW));
		}
		Marshal.FreeHGlobal(intPtr);
		return num;
	}

	public static bool OperateUserInfoNew(IntPtr lLoginID, EM_OPERATE_USER_TYPE nOperateType, IntPtr opParam, IntPtr subParam, int waittime)
	{
		bool num = OriginalSDK.CLIENT_OperateUserInfoNew(lLoginID, (int)nOperateType, opParam, subParam, IntPtr.Zero, waittime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartSearchDevice(fSearchDevicesCB cbSearchDevice, IntPtr pUserData, IntPtr szLocalIp)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartSearchDevices(cbSearchDevice, pUserData, szLocalIp);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool ModifyDevice(DEVICE_NET_INFO_EX devNetInfo, uint dwWaitTime)
	{
		int iError = 0;
		bool num = OriginalSDK.CLIENT_ModifyDevice(ref devNetInfo, dwWaitTime, ref iError, null, IntPtr.Zero);
		NetGetLastError(num);
		return num;
	}

	public static bool StopSearchDevice(IntPtr lSearchHandle)
	{
		bool num = OriginalSDK.CLIENT_StopSearchDevices(lSearchHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool DownloadRemoteFile(IntPtr lLoginID, ref NET_IN_DOWNLOAD_REMOTE_FILE inParam, ref NET_OUT_DOWNLOAD_REMOTE_FILE outParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_DownloadRemoteFile(lLoginID, ref inParam, ref outParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetDevEncodeCaps(IntPtr lLoginID, NET_IN_ENCODE_CFG_CAPS stuInParam, ref NET_OUT_ENCODE_CFG_CAPS stuOutParam, int nWaitTime)
	{
		bool flag = false;
		NET_INTERNAL_IN_ENCODE_CAPS structure = new NET_INTERNAL_IN_ENCODE_CAPS
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_INTERNAL_IN_ENCODE_CAPS)),
			stuInEncodeCaps = stuInParam
		};
		NET_INTERNAL_OUT_ENCODE_CAPS structure2 = new NET_INTERNAL_OUT_ENCODE_CAPS
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_INTERNAL_OUT_ENCODE_CAPS)),
			stuOutEncodeCaps = stuOutParam
		};
		Marshal.SizeOf(typeof(NET_INTERNAL_OUT_ENCODE_CAPS));
		for (int i = 0; i < 3; i++)
		{
			structure2.stuOutEncodeCaps.stuMainFormatCaps[i].dwSize = (uint)Marshal.SizeOf(typeof(NET_STREAM_CFG_CAPS));
			structure2.stuOutEncodeCaps.stuExtraFormatCaps[i].dwSize = (uint)Marshal.SizeOf(typeof(NET_STREAM_CFG_CAPS));
			if (i != 2)
			{
				structure2.stuOutEncodeCaps.stuSnapFormatCaps[i].dwSize = (uint)Marshal.SizeOf(typeof(NET_STREAM_CFG_CAPS));
			}
		}
		uint num = 1048576u;
		string szCommand = "Encode";
		_ = IntPtr.Zero;
		int error = 0;
		try
		{
			structure.pchEncodeJson = Marshal.AllocHGlobal((int)num);
		}
		catch (OutOfMemoryException)
		{
			return false;
		}
		flag = OriginalSDK.CLIENT_GetNewDevConfig(lLoginID, szCommand, stuInParam.nChannelId, structure.pchEncodeJson, num, out error, nWaitTime);
		if (flag)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			try
			{
				zero = Marshal.AllocHGlobal((int)structure.dwSize);
				zero2 = Marshal.AllocHGlobal((int)structure2.dwSize);
			}
			catch (OutOfMemoryException)
			{
				Marshal.FreeHGlobal(structure.pchEncodeJson);
				return false;
			}
			Marshal.StructureToPtr(structure, zero, fDeleteOld: true);
			Marshal.StructureToPtr(structure2, zero2, fDeleteOld: true);
			flag = OriginalSDK.CLIENT_GetDevCaps(lLoginID, 2, zero, zero2, nWaitTime);
			if (flag)
			{
				stuOutParam = ((NET_INTERNAL_OUT_ENCODE_CAPS)Marshal.PtrToStructure(zero2, typeof(NET_INTERNAL_OUT_ENCODE_CAPS))).stuOutEncodeCaps;
			}
			else
			{
				NetGetLastError(flag);
			}
			Marshal.FreeHGlobal(zero);
			Marshal.FreeHGlobal(zero2);
		}
		Marshal.FreeHGlobal(structure.pchEncodeJson);
		return flag;
	}

	public static bool QueryChannelName(IntPtr lLoginID, IntPtr pChannelName, int maxlen, ref int nChannelCount, int waittime)
	{
		bool num = OriginalSDK.CLIENT_QueryChannelName(lLoginID, pChannelName, maxlen, ref nChannelCount, waittime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetDeviceSearchParam(NET_DEVICE_SEARCH_PARAM inParam)
	{
		bool num = OriginalSDK.CLIENT_SetDeviceSearchParam(ref inParam);
		NetGetLastError(num);
		return num;
	}

	public static bool GetDevConfig(IntPtr lLoginID, EM_DEV_CFG_TYPE type, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint bytesReturned, int waittime)
	{
		bool num = OriginalSDK.CLIENT_GetDevConfig(lLoginID, (uint)type, lChannel, lpOutBuffer, dwOutBufferSize, ref bytesReturned, waittime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetDevConfig(IntPtr lLoginID, EM_DEV_CFG_TYPE type, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize, int waittime)
	{
		bool num = OriginalSDK.CLIENT_SetDevConfig(lLoginID, (uint)type, lChannel, lpInBuffer, dwInBufferSize, waittime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr DownloadByRecordFile(IntPtr lLoginID, ref NET_RECORDFILE_INFO lpRecordFile, string sSavedFileName, fDownLoadPosCallBack cbDownLoadPos, IntPtr dwUserData)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_DownloadByRecordFile(lLoginID, ref lpRecordFile, sSavedFileName, cbDownLoadPos, dwUserData);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool RebootDev(IntPtr lLoginID)
	{
		bool num = OriginalSDK.CLIENT_RebootDev(lLoginID);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_AddUser(IntPtr lLoginID, NET_IN_ATTENDANCE_ADDUSER stuInAddUser, ref NET_OUT_ATTENDANCE_ADDUSER stuOutAddUser, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_AddUser(lLoginID, ref stuInAddUser, ref stuOutAddUser, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_DelUser(IntPtr lLoginID, NET_IN_ATTENDANCE_DELUSER stuInDelUser, ref NET_OUT_ATTENDANCE_DELUSER stuOutDelUser, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_DelUser(lLoginID, ref stuInDelUser, ref stuOutDelUser, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_ModifyUser(IntPtr lLoginID, NET_IN_ATTENDANCE_ModifyUSER stuInModifyUser, ref NET_OUT_ATTENDANCE_ModifyUSER stuOutModifyUser, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_ModifyUser(lLoginID, ref stuInModifyUser, ref stuOutModifyUser, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_GetUser(IntPtr lLoginID, NET_IN_ATTENDANCE_GetUSER stuInGetUser, ref NET_OUT_ATTENDANCE_GetUSER stuOutGetUser, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_GetUser(lLoginID, ref stuInGetUser, ref stuOutGetUser, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_FindUser(IntPtr lLoginID, NET_IN_ATTENDANCE_FINDUSER stuInFindUser, ref NET_OUT_ATTENDANCE_FINDUSER stuOutFindUser, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_FindUser(lLoginID, ref stuInFindUser, ref stuOutFindUser, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_InsertFingerByUserID(IntPtr lLoginID, ref NET_IN_FINGERPRINT_INSERT_BY_USERID stuInInsert, ref NET_OUT_FINGERPRINT_INSERT_BY_USERID stuOutInsert, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_InsertFingerByUserID(lLoginID, ref stuInInsert, ref stuOutInsert, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_RemoveFingerByUserID(IntPtr lLoginID, ref NET_CTRL_IN_FINGERPRINT_REMOVE_BY_USERID stuInRemove, ref NET_CTRL_OUT_FINGERPRINT_REMOVE_BY_USERID stuOutRemove, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_RemoveFingerByUserID(lLoginID, ref stuInRemove, ref stuOutRemove, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_GetFingerByUserID(IntPtr lLoginID, ref NET_IN_FINGERPRINT_GETBYUSER stuIn, ref NET_OUT_FINGERPRINT_GETBYUSER stuOut, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_GetFingerByUserID(lLoginID, ref stuIn, ref stuOut, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachMotionData(IntPtr lLoginID, NET_IN_ATTACH_MOTION_DATA inParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		NET_OUT_ATTACH_MOTION_DATA pstOutParam = new NET_OUT_ATTACH_MOTION_DATA
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_ATTACH_MOTION_DATA))
		};
		IntPtr intPtr = OriginalSDK.CLIENT_AttachMotionData(lLoginID, ref inParam, ref pstOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachMotionData(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachMotionData(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool SearchDevicesByIPs(NET_DEVICE_IP_SEARCH_INFO pIpSearchInfo, fSearchDevicesCB cbSearchDevices, IntPtr dwUserData, string szLocalIp, uint dwWaitTime)
	{
		bool num = OriginalSDK.CLIENT_SearchDevicesByIPs(ref pIpSearchInfo, cbSearchDevices, dwUserData, szLocalIp, dwWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool InitDevAccount(NET_IN_INIT_DEVICE_ACCOUNT pInitAccountIn, ref NET_OUT_INIT_DEVICE_ACCOUNT pInitAccountOut, uint dwWaitTime, string szLocalIp)
	{
		bool num = OriginalSDK.CLIENT_InitDevAccount(ref pInitAccountIn, ref pInitAccountOut, dwWaitTime, szLocalIp);
		NetGetLastError(num);
		return num;
	}

	public static bool GetDevCaps(IntPtr lLoginID, EM_DEVCAP_TYPE nType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetDevCaps(lLoginID, (int)nType, pInBuf, pOutBuf, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr ListenServer(string ip, ushort port, int nTimeout, fServiceCallBack cbListen, IntPtr dwUserData)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_ListenServer(ip, port, nTimeout, cbListen, dwUserData);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopListenServer(IntPtr lServerHandle)
	{
		bool num = OriginalSDK.CLIENT_StopListenServer(lServerHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool QueryProductionDefinition(IntPtr lLoginID, ref NET_PRODUCTION_DEFNITION pstuProdDef, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_QueryProductionDefinition(lLoginID, ref pstuProdDef, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool QueryDevInfo(IntPtr lLoginID, EM_QUERY_DEV_INFO emQueryType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_QueryDevInfo(lLoginID, (int)emQueryType, pInBuf, pOutBuf, IntPtr.Zero, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachCameraState(IntPtr lLoginID, NET_IN_CAMERASTATE pstInParam, ref NET_OUT_CAMERASTATE pstOutParam, int nWaitTime = 3000)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachCameraState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachCameraState(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachCameraState(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool GetSoftwareVersion(IntPtr lLoginID, NET_IN_GET_SOFTWAREVERSION_INFO pstInParam, ref NET_OUT_GET_SOFTWAREVERSION_INFO pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetSoftwareVersion(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetDeviceType(IntPtr lLoginID, NET_IN_GET_DEVICETYPE_INFO pstInParam, ref NET_OUT_GET_DEVICETYPE_INFO pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetDeviceType(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool LogOpen(NET_LOG_SET_PRINT_INFO pstLogPrintInfo)
	{
		bool num = OriginalSDK.CLIENT_LogOpen(ref pstLogPrintInfo);
		NetGetLastError(num);
		return num;
	}

	public static bool AudioDecEx(IntPtr lTalkHandle, IntPtr pAudioDataBuf, uint dwBufSize)
	{
		bool num = OriginalSDK.CLIENT_AudioDecEx(lTalkHandle, pAudioDataBuf, dwBufSize);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_GetFingerRecord(IntPtr lLoginID, ref NET_CTRL_IN_FINGERPRINT_GET pstuInGet, ref NET_CTRL_OUT_FINGERPRINT_GET pstuOutGet, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_GetFingerRecord(lLoginID, ref pstuInGet, ref pstuOutGet, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool Attendance_RemoveFingerRecord(IntPtr lLoginID, ref NET_CTRL_IN_FINGERPRINT_REMOVE pstuInRemove, ref NET_CTRL_OUT_FINGERPRINT_REMOVE pstuOutRemove, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_Attendance_RemoveFingerRecord(lLoginID, ref pstuInRemove, ref pstuOutRemove, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool OperateAccessFingerprintService(IntPtr lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, emtype, pstInParam, pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool OperateAccessControlManager(IntPtr lLoginID, NET_EM_ACCESS_CTL_MANAGER emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_OperateAccessControlManager(lLoginID, emtype, pstInParam, pstInParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool EncryptString(NET_IN_ENCRYPT_STRING pInParam, ref NET_OUT_ENCRYPT_STRING pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_EncryptString(ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr DownloadMediaFile(IntPtr lLoginID, EM_FILE_QUERY_TYPE emType, IntPtr lpMediaFileInfo, string sSavedFileName, fDownLoadPosCallBack cbDownLoadPos, IntPtr dwUserData, IntPtr reserved)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(sSavedFileName);
		IntPtr intPtr2 = OriginalSDK.CLIENT_DownloadMediaFile(lLoginID, emType, lpMediaFileInfo, intPtr, cbDownLoadPos, dwUserData, reserved);
		Marshal.FreeHGlobal(intPtr);
		NetGetLastError(intPtr2);
		return intPtr2;
	}

	public static bool StopDownloadMediaFile(IntPtr lFileHandle)
	{
		bool num = OriginalSDK.CLIENT_StopDownloadMediaFile(lFileHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr SCADAAlarmAttachInfo(IntPtr lLoginID, NET_IN_SCADA_ALARM_ATTACH_INFO pInParam, NET_OUT_SCADA_ALARM_ATTACH_INFO pOutParam, int nWaitTime = 3000)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_SCADAAlarmAttachInfo(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool SCADAAlarmDetachInfo(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_SCADAAlarmDetachInfo(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr SCADAAttachInfo(IntPtr lLoginID, NET_IN_SCADA_ATTACH_INFO pInParam, NET_OUT_SCADA_ATTACH_INFO pOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_SCADAAttachInfo(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool SCADADetachInfo(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_SCADADetachInfo(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachPTZStatusProc(IntPtr lLoginID, NET_IN_PTZ_STATUS_PROC pstuInPtzStatusProc, ref NET_OUT_PTZ_STATUS_PROC pstuOutPtzStatusProc, int nWaitTime = 3000)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachPTZStatusProc(lLoginID, ref pstuInPtzStatusProc, ref pstuOutPtzStatusProc, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachPTZStatusProc(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachPTZStatusProc(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool StartFind(IntPtr lLoginID, EM_FIND emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_StartFind(lLoginID, emType, pInBuf, pOutBuf, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool DoFind(IntPtr lLoginID, EM_FIND emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_DoFind(lLoginID, emType, pInBuf, pOutBuf, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StopFind(IntPtr lLoginID, EM_FIND emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_StopFind(lLoginID, emType, pInBuf, pOutBuf, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr RadiometryAttach(IntPtr lLoginID, NET_IN_RADIOMETRY_ATTACH pInParam, ref NET_OUT_RADIOMETRY_ATTACH pOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_RadiometryAttach(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool RadiometryDetach(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_RadiometryDetach(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool RadiometryFetch(IntPtr lLoginID, NET_IN_RADIOMETRY_FETCH pInParam, ref NET_OUT_RADIOMETRY_FETCH pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_RadiometryFetch(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr RealPlayByDataType(IntPtr lLoginID, NET_IN_REALPLAY_BY_DATA_TYPE pstInParam, ref NET_OUT_REALPLAY_BY_DATA_TYPE pstOutParam, uint dwWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_RealPlayByDataType(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static IntPtr PlayBackByDataType(IntPtr lLoginID, NET_IN_PLAYBACK_BY_DATA_TYPE pstInParam, ref NET_OUT_PLAYBACK_BY_DATA_TYPE pstOutParam, uint dwWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_PlayBackByDataType(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static IntPtr DownloadByDataType(IntPtr lLoginID, NET_IN_DOWNLOAD_BY_DATA_TYPE pstInParam, ref NET_OUT_DOWNLOAD_BY_DATA_TYPE pstOutParam, uint dwWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_DownloadByDataType(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool GetConnectionStatus(IntPtr lLoginID, NET_IN_GETCONNECTION_STATUS pstInParam, ref NET_OUT_GETCONNECTION_STATUS pstOutParam, int dwWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetConnectionStatus(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetDefenceArmMode(IntPtr lLoginID, NET_IN_GET_DEFENCEMODE pstInParam, ref NET_OUT_GET_DEFENCEMODE pstOutParam, int dwWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetDefenceArmMode(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetDefenceArmMode(IntPtr lLoginID, NET_IN_SET_DEFENCEMODE pstInParam, int dwWaitTime)
	{
		NET_OUT_SET_DEFENCEMODE pOutParam = new NET_OUT_SET_DEFENCEMODE
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_SET_DEFENCEMODE))
		};
		bool num = OriginalSDK.CLIENT_SetDefenceArmMode(lLoginID, ref pstInParam, ref pOutParam, dwWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetParkingSpaceLightPlan(IntPtr lLoginID, NET_IN_SET_PARKING_SPACE_LIGHT_PLAN pstInParam, int nWaitTime)
	{
		NET_OUT_SET_PARKING_SPACE_LIGHT_PLAN pOutParam = new NET_OUT_SET_PARKING_SPACE_LIGHT_PLAN
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_SET_PARKING_SPACE_LIGHT_PLAN))
		};
		bool num = OriginalSDK.CLIENT_SetParkingSpaceLightPlan(lLoginID, ref pstInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool FaceOpenDoor(IntPtr lLoginID, NET_IN_FACE_OPEN_DOOR pInParam, NET_OUT_FACE_OPEN_DOOR pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_FaceOpenDoor(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool FaceRecognitionDetectMultiFace(IntPtr lLoginID, IntPtr pstInParam, ref NET_OUT_FACE_RECOGNITION_DETECT_MULTI_FACE_INFO pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_FaceRecognitionDetectMultiFace(lLoginID, pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachDetectMultiFaceState(IntPtr lLoginID, ref NET_IN_MULTIFACE_DETECT_STATE pstInParam, ref NET_OUT_MULTIFACE_DETECT_STATE pstOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachDetectMultiFaceState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachDetectMultiFaceState(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachDetectMultiFaceState(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool GetAlarmRegionInfo(IntPtr lLoginID, EM_A_NET_EM_GET_ALARMREGION_INFO emType, IntPtr pstuInParam, IntPtr pstuOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetAlarmRegionInfo(lLoginID, emType, pstuInParam, pstuOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SubcribeGPS(IntPtr lLoginID, bool bStart, int KeepTime, int InterTime)
	{
		bool num = OriginalSDK.CLIENT_SubcribeGPS(lLoginID, bStart, KeepTime, InterTime);
		NetGetLastError(num);
		return num;
	}

	public static void SetSubcribeGPSCallBack(fGPSRevEx2 OnGPSMessage, IntPtr dwUser)
	{
		OriginalSDK.CLIENT_SetSubcribeGPSCallBackEX2(OnGPSMessage, dwUser);
	}

	public static IntPtr AttachAnalyseTaskState(IntPtr lLoginID, ref NET_IN_ATTACH_ANALYSE_TASK_STATE pInParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachAnalyseTaskState(lLoginID, ref pInParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachAnalyseTaskState(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachAnalyseTaskState(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool PushAnalysePictureFile(IntPtr lLoginID, ref NET_IN_PUSH_ANALYSE_PICTURE_FILE pInParam, ref NET_OUT_PUSH_ANALYSE_PICTURE_FILE pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_PushAnalysePictureFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool PushAnalysePictureFileByRule(IntPtr lLoginID, ref NET_IN_PUSH_ANALYSE_PICTURE_FILE_BYRULE pInParam, ref NET_OUT_PUSH_ANALYSE_PICTURE_FILE_BYRULE pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_PushAnalysePictureFileByRule(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool AddAnalyseTask_PushPicFile(IntPtr lLoginID, NET_PUSH_PICFILE_INFO stuPushInfo, ref NET_OUT_ADD_ANALYSE_TASK pOutParam, int nWaitTime)
	{
		IntPtr intPtr = IntPtr.Zero;
		EM_DATA_SOURCE_TYPE emDataSourceType = EM_DATA_SOURCE_TYPE.PUSH_PICFILE;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(stuPushInfo));
			Marshal.StructureToPtr(stuPushInfo, intPtr, fDeleteOld: true);
			bool num = OriginalSDK.CLIENT_AddAnalyseTask(lLoginID, emDataSourceType, intPtr, ref pOutParam, nWaitTime);
			NetGetLastError(num);
			return num;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static bool AddAnalyseTask(IntPtr lLoginID, EM_DATA_SOURCE_TYPE emDataSourceType, IntPtr pInParam, ref NET_OUT_ADD_ANALYSE_TASK pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_AddAnalyseTask(lLoginID, emDataSourceType, pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool RemoveAnalyseTask(IntPtr lLoginID, ref NET_IN_REMOVE_ANALYSE_TASK pInParam, ref NET_OUT_REMOVE_ANALYSE_TASK pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_RemoveAnalyseTask(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachAnalyseTaskResult(IntPtr lLoginID, ref NET_IN_ATTACH_ANALYSE_RESULT pInParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachAnalyseTaskResult(lLoginID, ref pInParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachAnalyseTaskResult(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachAnalyseTaskResult(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool FindAnalyseTask(IntPtr lLoginID, ref NET_IN_FIND_ANALYSE_TASK stuInParam, ref NET_OUT_FIND_ANALYSE_TASK stuOutParam, int nWaitTime)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_FIND_ANALYSE_TASK)));
			flag = OriginalSDK.CLIENT_FindAnalyseTask(lLoginID, ref stuInParam, intPtr, nWaitTime);
			if (flag)
			{
				stuOutParam = (NET_OUT_FIND_ANALYSE_TASK)Marshal.PtrToStructure(intPtr, typeof(NET_OUT_FIND_ANALYSE_TASK));
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
		NetGetLastError(flag);
		return flag;
	}

	public static IntPtr OpenPlayGroup()
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_OpenPlayGroup();
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool AddPlayHandleToPlayGroup(ref NET_IN_ADD_PLAYHANDLE_TO_PLAYGROUP pInParam, ref NET_OUT_ADD_PLAYHANDLE_TO_PLAYGROUP pOutParam)
	{
		bool num = OriginalSDK.CLIENT_AddPlayHandleToPlayGroup(ref pInParam, ref pOutParam);
		NetGetLastError(num);
		return num;
	}

	public static bool PausePlayGroup(IntPtr lPlayGroupHandle, bool bPause)
	{
		bool num = OriginalSDK.CLIENT_PausePlayGroup(lPlayGroupHandle, bPause);
		NetGetLastError(num);
		return num;
	}

	public static bool QueryPlayGroupTime(ref NET_IN_QUERY_PLAYGROUP_TIME pInParam, ref NET_OUT_QUERY_PLAYGROUP_TIME pOutParam)
	{
		bool num = OriginalSDK.CLIENT_QueryPlayGroupTime(ref pInParam, ref pOutParam);
		NetGetLastError(num);
		return num;
	}

	public static bool DeletePlayHandleFromPlayGroup(ref NET_IN_DELETE_FROM_PLAYGROUP pInParam, ref NET_OUT_DELETE_FROM_PLAYGROUP pOutParam)
	{
		bool num = OriginalSDK.CLIENT_DeleteFromPlayGroup(ref pInParam, ref pOutParam);
		NetGetLastError(num);
		return num;
	}

	public static bool ClosePlayGroup(IntPtr lPlayGroupHandle)
	{
		bool num = OriginalSDK.CLIENT_ClosePlayGroup(lPlayGroupHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool SetPlayGroupDirection(ref NET_IN_SET_PLAYGROUP_DIRECTION pInParam, ref NET_OUT_SET_PLAYGROUP_DIRECTION pOutParam)
	{
		bool num = OriginalSDK.CLIENT_SetPlayGroupDirection(ref pInParam, ref pOutParam);
		NetGetLastError(num);
		return num;
	}

	public static bool SetPlayGroupSpeed(ref NET_IN_SET_PLAYGROUP_SPEED pInParam, ref NET_OUT_SET_PLAYGROUP_SPEED pOutParam)
	{
		bool num = OriginalSDK.CLIENT_SetPlayGroupSpeed(ref pInParam, ref pOutParam);
		NetGetLastError(num);
		return num;
	}

	public static bool FastPlayGroup(IntPtr lPlayGroupHandle)
	{
		bool num = OriginalSDK.CLIENT_FastPlayGroup(lPlayGroupHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool SlowPlayGroup(IntPtr lPlayGroupHandle)
	{
		bool num = OriginalSDK.CLIENT_SlowPlayGroup(lPlayGroupHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool NormalPlayGroup(IntPtr lPlayGroupHandle)
	{
		bool num = OriginalSDK.CLIENT_NormalPlayGroup(lPlayGroupHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartUploadRemoteFile(IntPtr lLoginID, ref NET_IN_UPLOAD_REMOTE_FILE pInParam, ref NET_OUT_UPLOAD_REMOTE_FILE pOutParam, fUploadFileCallBack cbUploadFile, IntPtr dwUser)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartUploadRemoteFile(lLoginID, ref pInParam, ref pOutParam, cbUploadFile, dwUser);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopUploadRemoteFile(IntPtr lPlayGroupHandle)
	{
		bool num = OriginalSDK.CLIENT_StopUploadRemoteFile(lPlayGroupHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool TagManagerStartTag(IntPtr lLoginID, ref NET_IN_TAGMANAGER_STARTTAG_INFO pInParam, ref NET_OUT_TAGMANAGER_STARTTAG_INFO pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_TagManagerStartTag(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool TagManagerStopTag(IntPtr lLoginID, ref NET_IN_TAGMANAGER_STOPTAG_INFO pInParam, ref NET_OUT_TAGMANAGER_STOPTAG_INFO pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_TagManagerStopTag(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool TagManagerGetTagState(IntPtr lLoginID, ref NET_IN_TAGMANAGER_GETTAGSTATE_INFO pInParam, ref NET_OUT_TAGMANAGER_GETTAGSTATE_INFO pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_TagManagerGetTagState(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr TagManagerStartFind(IntPtr lLoginID, ref NET_IN_TAGMANAGER_STARTFIND_INFO pInParam, ref NET_OUT_TAGMANAGER_STARTFIND_INFO pOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_TagManagerStartFind(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool TagManagerDoFind(IntPtr lLoginID, ref NET_IN_TAGMANAGER_DOFIND_INFO pInParam, ref NET_OUT_TAGMANAGER_DOFIND_INFO pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_TagManagerDoFind(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool TagManagerGetCaps(IntPtr lLoginID, ref NET_IN_TAGMANAGER_GETCAPS_INFO pInParam, ref NET_OUT_TAGMANAGER_GETCAPS_INFO pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_TagManagerGetCaps(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool TagManagerStopFind(IntPtr lLoginID)
	{
		bool num = OriginalSDK.CLIENT_TagManagerStopFind(lLoginID);
		NetGetLastError(num);
		return num;
	}

	public static bool GetHumanRadioCaps(IntPtr lLoginID, ref NET_IN_GET_HUMAN_RADIO_CAPS pInParam, ref NET_OUT_GET_HUMAN_RADIO_CAPS pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetHumanRadioCaps(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool AsyncAddCustomDevice(IntPtr lLoginID, ref NET_IN_ASYNC_ADD_CUSTOM_DEVICE pInParam, ref NET_OUT_ASYNC_ADD_CUSTOM_DEVICE pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_AsyncAddCustomDevice(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool RemoveDevice(IntPtr lLoginID, ref NET_IN_REMOVE_DEVICE pInParam, ref NET_OUT_REMOVE_DEVICE pOutParam, int nWaitTime)
	{
		IntPtr intPtr = Marshal.AllocHGlobal((int)pInParam.dwSize);
		Marshal.StructureToPtr(pInParam, intPtr, fDeleteOld: true);
		IntPtr intPtr2 = Marshal.AllocHGlobal((int)pOutParam.dwSize);
		Marshal.StructureToPtr(pOutParam, intPtr2, fDeleteOld: true);
		bool num = OriginalSDK.CLIENT_RemoveDevice(lLoginID, intPtr, intPtr2, nWaitTime);
		NetGetLastError(num);
		if (num)
		{
			pOutParam = (NET_OUT_REMOVE_DEVICE)Marshal.PtrToStructure(intPtr2, typeof(NET_OUT_REMOVE_DEVICE));
		}
		Marshal.FreeHGlobal(intPtr);
		Marshal.FreeHGlobal(intPtr2);
		return num;
	}

	public static IntPtr LoadOffLineFile(IntPtr lLoginID, int nChannelID, uint dwAlarmType, NET_TIME_EX lpStartTime, NET_TIME_EX lpEndTime, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_LoadOffLineFile(lLoginID, nChannelID, dwAlarmType, lpStartTime, lpEndTime, cbAnalyzerData, dwUser);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool GetFramePlayBack(IntPtr lPlayBackID, ref int nfileframerate, ref int nplayframerate)
	{
		bool num = OriginalSDK.CLIENT_GetFramePlayBack(lPlayBackID, ref nfileframerate, ref nplayframerate);
		NetGetLastError(num);
		return num;
	}

	public static bool SetFramePlayBack(IntPtr lPlayBackID, int framerate)
	{
		bool num = OriginalSDK.CLIENT_SetFramePlayBack(lPlayBackID, framerate);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartSearchDevicesEx(ref NET_IN_STARTSERACH_DEVICE pInBuf, ref NET_OUT_STARTSERACH_DEVICE pOutBuf)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartSearchDevicesEx(ref pInBuf, ref pOutBuf);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool QueryDevLogCount(IntPtr lLoginID, ref NET_IN_GETCOUNT_LOG_PARAM pInParam, ref NET_OUT_GETCOUNT_LOG_PARAM pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_QueryDevLogCount(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartQueryLog(IntPtr lLoginID, ref NET_IN_START_QUERYLOG pInParam, ref NET_OUT_START_QUERYLOG pOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartQueryLog(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool QueryNextLog(IntPtr lFindLogID, ref NET_IN_QUERYNEXTLOG pInParam, ref NET_OUT_QUERYNEXTLOG pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_QueryNextLog(lFindLogID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StopQueryLog(IntPtr lFindLogID)
	{
		bool num = OriginalSDK.CLIENT_StopQueryLog(lFindLogID);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartUpgrade(IntPtr lLoginID, EM_UPGRADE_TYPE emType, string pchFileName, fUpgradeCallBack cbUpgrade, IntPtr dwUser)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartUpgradeEx(lLoginID, emType, pchFileName, cbUpgrade, dwUser);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool ResetSystem(IntPtr lLoginID, ref NET_IN_RESET_SYSTEM pInParam, ref NET_OUT_RESET_SYSTEM pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_ResetSystem(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool ResetSystemEx(IntPtr lLoginID, ref NET_IN_RESET_SYSTEM_EX pInParam, ref NET_OUT_RESET_SYSTEM_EX pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_ResetSystemEx(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SendUpgrade(IntPtr lUpgradeID)
	{
		bool num = OriginalSDK.CLIENT_SendUpgrade(lUpgradeID);
		NetGetLastError(num);
		return num;
	}

	public static bool StopUpgrade(IntPtr lUpgradeID)
	{
		bool num = OriginalSDK.CLIENT_StopUpgrade(lUpgradeID);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartFindUserInfo(IntPtr lLoginID, ref NET_IN_USERINFO_START_FIND pstIn, ref NET_OUT_USERINFO_START_FIND pstOut, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartFindUserInfo(lLoginID, ref pstIn, ref pstOut, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DoFindUserInfo(IntPtr lFindHandle, ref NET_IN_USERINFO_DO_FIND pstIn, ref NET_OUT_USERINFO_DO_FIND pstOut, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_DoFindUserInfo(lFindHandle, ref pstIn, ref pstOut, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StopFindUserInfo(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_StopFindUserInfo(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartFindCardInfo(IntPtr lLoginID, ref NET_IN_CARDINFO_START_FIND pstIn, ref NET_OUT_CARDINFO_START_FIND pstOut, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartFindCardInfo(lLoginID, ref pstIn, ref pstOut, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DoFindCardInfo(IntPtr lFindHandle, ref NET_IN_CARDINFO_DO_FIND pstIn, ref NET_OUT_CARDINFO_DO_FIND pstOut, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_DoFindCardInfo(lFindHandle, ref pstIn, ref pstOut, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StopFindCardInfo(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_StopFindCardInfo(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool OperateAccessFaceService(IntPtr lLoginID, EM_NET_ACCESS_CTL_FACE_SERVICE emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_OperateAccessFaceService(lLoginID, emtype, pstInParam, pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachRadarAlarmPointInfo(IntPtr lLoginID, NET_IN_RADAR_ALARMPOINTINFO pInParam, ref NET_OUT_RADAR_ALARMPOINTINFO pOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachRadarAlarmPointInfo(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachRadarAlarmPointInfo(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachRadarAlarmPointInfo(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool RadarOperate(IntPtr lLoginID, EM_RADAR_OPERATE_TYPE emtype, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_RadarOperate(lLoginID, emtype, pInBuf, pOutBuf, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool AddRadarLinkSD(IntPtr lLoginID, ref NET_IN_RADAR_ADD_RADARLINKSD pstInParam, ref NET_OUT_RADAR_ADD_RADARLINKSD pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_AddRadarLinkSD(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool DelRadarLinkSD(IntPtr lLoginID, ref NET_IN_RADAR_DEL_RADARLINKSD pstInParam, ref NET_OUT_RADAR_DEL_RADARLINKSD pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_DelRadarLinkSD(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetRadarLinkSDState(IntPtr lLoginID, ref NET_IN_RADAR_GET_LINKSTATE pstInParam, ref NET_OUT_RADAR_GET_LINKSTATE pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetRadarLinkSDState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool QueryIOControlState(IntPtr lLoginID, EM_NET_IOTYPE emType, IntPtr pState, int maxlen, ref int nIOCount, int waittime = 1000)
	{
		bool num = OriginalSDK.CLIENT_QueryIOControlState(lLoginID, emType, pState, maxlen, ref nIOCount, waittime);
		NetGetLastError(num);
		return num;
	}

	public static bool IOControl(IntPtr lLoginID, EM_NET_IOTYPE emType, IntPtr pState, int maxlen)
	{
		bool num = OriginalSDK.CLIENT_IOControl(lLoginID, emType, pState, maxlen);
		NetGetLastError(num);
		return num;
	}

	public static bool SCADAGetAttributeInfo(IntPtr lLoginID, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_SCADAGetAttributeInfo(lLoginID, pstInParam, pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetFloorInfo(IntPtr lLoginID, ref NET_IN_GET_FLOOR_INFO pstInParam, ref NET_OUT_GET_FLOOR_INFO pstOutParam, uint dwWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetFloorInfo(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachCustomSnapInfo(IntPtr lLoginID, ref NET_IN_ATTACH_CUSTOM_SNAP_INFO pstInParam, ref NET_OUT_ATTACH_CUSTOM_SNAP_INFO pstOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachCustomSnapInfo(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachCustomSnapInfo(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachCustomSnapInfo(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool OperateMonitorWall(IntPtr lLoginID, NET_MONITORWALL_OPERATE_TYPE emType, IntPtr pInParam, IntPtr pOutParam, int nWaitTime = 5000)
	{
		bool num = OriginalSDK.CLIENT_OperateMonitorWall(lLoginID, emType, pInParam, pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool MonitorWallGetScene(IntPtr lLoginID, ref NET_A_IN_MONITORWALL_GET_SCENE pInParam, ref NET_A_OUT_MONITORWALL_GET_SCENE pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_MonitorWallGetScene(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetDeviceSerialNo(IntPtr lLoginID, ref NET_IN_GET_DEVICESERIALNO_INFO pstInParam, ref NET_OUT_GET_DEVICESERIALNO_INFO pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetDeviceSerialNo(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetMachineName(IntPtr lLoginID, ref NET_IN_GET_MACHINENAME_INFO pstInParam, ref NET_OUT_GET_MACHINENAME_INFO pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetMachineName(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachBusState(IntPtr lLoginID, ref NET_IN_BUS_ATTACH pstuInBus, ref NET_OUT_BUS_ATTACH pstuOutBus, int nWaitTime = 3000)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachBusState(lLoginID, ref pstuInBus, ref pstuOutBus, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachBusState(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachBusState(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool SetPlayBackSpeed(IntPtr lPlayHandle, EM_PLAY_BACK_SPEED emSpeed)
	{
		bool num = OriginalSDK.CLIENT_SetPlayBackSpeed(lPlayHandle, emSpeed);
		NetGetLastError(num);
		return num;
	}

	public static bool SetMarkFileByTime(IntPtr lLoginID, ref NET_IN_SET_MARK_FILE_BY_TIME pInParam, ref NET_OUT_SET_MARK_FILE_BY_TIME pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_SetMarkFileByTime(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetMarkInfo(IntPtr lLoginID, ref NET_IN_GET_MARK_INFO pInParam, ref NET_OUT_GET_MARK_INFO pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_GetMarkInfo(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetRecordState(IntPtr lLoginID, ref NET_IN_GET_RECORD_STATE pInParam, ref NET_OUT_GET_RECORD_STATE pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_GetRecordState(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetCourseRecordState(IntPtr lLoginID, ref NET_IN_SET_COURSE_RECORD_STATE pInParam, ref NET_OUT_SET_COURSE_RECORD_STATE pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_SetCourseRecordState(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetVideoEncodeBitrate(IntPtr lLoginID, ref NET_IN_GET_VIDEO_ENCODE_BITRATE_INFO pInParam, ref NET_OUT_GET_VIDEO_ENCODE_BITRATE_INFO pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_GetVideoEncodeBitrate(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool RemotePreUploadFile(IntPtr lLoginID, ref NET_IN_REMOTE_PREUPLOAD_FILE pInParam, ref NET_OUT_REMOTE_PREUPLOAD_FILE pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_RemotePreUploadFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartRemoteUploadFile(IntPtr lLoginID, ref NET_IN_REMOTE_UPLOAD_FILE pInParam, ref NET_OUT_REMOTE_UPLOAD_FILE pOutParam, int nWaitTime = 1000)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartRemoteUploadFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopRemoteUploadFile(IntPtr lRemoteUploadFileID)
	{
		bool num = OriginalSDK.CLIENT_StopRemoteUploadFile(lRemoteUploadFileID);
		NetGetLastError(num);
		return num;
	}

	public static bool RemoteList(IntPtr lLoginID, ref NET_IN_REMOTE_LIST pInParam, ref NET_OUT_REMOTE_LIST pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_RemoteList(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool RemoteRemoveFiles(IntPtr lLoginID, ref NET_IN_REMOTE_REMOVE_FILES pInParam, ref NET_OUT_REMOTE_REMOVE_FILES pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_RemoteRemoveFiles(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool PreUploadRemoteFile(IntPtr lLoginID, ref NET_IN_PRE_UPLOAD_REMOTE_FILE pInParam, ref NET_OUT_PRE_UPLOAD_REMOTE_FILE pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_PreUploadRemoteFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool UploadRemoteFile(IntPtr lLoginID, ref NET_IN_UPLOAD_REMOTE_FILE pInParam, ref NET_OUT_UPLOAD_REMOTE_FILE pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_UploadRemoteFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool ListRemoteFile(IntPtr lLoginID, ref NET_IN_LIST_REMOTE_FILE pInParam, ref NET_OUT_LIST_REMOTE_FILE pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_ListRemoteFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool RemoveRemoteFiles(IntPtr lLoginID, ref NET_IN_REMOVE_REMOTE_FILES pInParam, ref NET_OUT_REMOVE_REMOTE_FILES pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_RemoveRemoteFiles(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StartMultiFindFaceRecognitionRecord(IntPtr lLoginID, ref NET_IN_STARTMULTIFIND_FACERECONGNITIONRECORD pInParam, ref NET_OUT_STARTMULTIFIND_FACERECONGNITIONRECORD pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_StartMultiFindFaceRecognitionRecord(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool DoFindFaceRecognitionRecord(ref NET_IN_DOFIND_FACERECONGNITIONRECORD inParam, ref NET_OUT_DOFIND_FACERECONGNITIONRECORD outParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_DoFindFaceRecognitionRecord(ref inParam, ref outParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StopFindFaceRecognitionRecord(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_StopFindFaceRecognitionRecord(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool StartService(uint wPort, IntPtr pIp, fServiceCallBack pfscb, uint dwTimeOut = uint.MaxValue, IntPtr dwUserData = default(IntPtr))
	{
		bool num = OriginalSDK.CLIENT_StartService(wPort, pIp, pfscb, dwTimeOut, dwUserData);
		NetGetLastError(num);
		return num;
	}

	public static bool MatrixAddCamerasByGroup(IntPtr lLoginID, ref NET_IN_ADD_LOGIC_BYGROUP_CAMERA pInParam, ref NET_OUT_ADD_LOGIC_BYGROUP_CAMERA pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_MatrixAddCamerasByGroup(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool MatrixGetCameraAllByGroup(IntPtr lLoginID, ref NET_IN_GET_CAMERA_ALL_BY_GROUP pInParam, ref NET_OUT_GET_CAMERA_ALL_BY_GROUP pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_MatrixGetCameraAllByGroup(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool MatrixDeleteCameraByGroup(IntPtr lLoginID, ref NET_IN_DELETE_CAMERA_BY_GROUP pInParam, ref NET_OUT_DELETE_CAMERA_BY_GROUP pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_MatrixDeleteCameraByGroup(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartBurnSession(IntPtr lLoginID, ref NET_IN_START_BURN_SESSION pstInParam, ref NET_OUT_START_BURN_SESSION pstOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartBurnSession(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopBurnSession(IntPtr lBurnSession)
	{
		bool num = OriginalSDK.CLIENT_StopBurnSession(lBurnSession);
		NetGetLastError(num);
		return num;
	}

	public static bool StartBurn(IntPtr lBurnSession, ref NET_IN_START_BURN pstInParam, ref NET_OUT_START_BURN pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_StartBurn(lBurnSession, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StopBurn(IntPtr lBurnSession)
	{
		bool num = OriginalSDK.CLIENT_StopBurn(lBurnSession);
		NetGetLastError(num);
		return num;
	}

	public static bool PauseBurn(IntPtr lBurnSession, bool bPause)
	{
		bool num = OriginalSDK.CLIENT_PauseBurn(lBurnSession, bPause);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachBurnState(IntPtr lLoginID, ref NET_IN_ATTACH_STATE pstInParam, ref NET_OUT_ATTACH_STATE pstOutParam, int nWaitTime = 1000)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachBurnState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachBurnState(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachBurnState(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool BurnMarkTag(IntPtr lBurnSession, ref NET_IN_BURN_MARK_TAG pstInParam, ref NET_OUT_BURN_MARK_TAG pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_BurnMarkTag(lBurnSession, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool BurnGetState(IntPtr lBurnSession, ref NET_IN_BURN_GET_STATE pstInParam, ref NET_OUT_BURN_GET_STATE pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_BurnGetState(lBurnSession, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StartBackupTask(IntPtr lLoginID, ref NET_IN_START_BACKUP_TASK_INFO pstInParam, ref NET_OUT_START_BACKUP_TASK_INFO pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_StartBackupTask(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachBackupTaskState(IntPtr lLoginID, ref NET_IN_ATTACH_BACKUP_STATE pstInParam, ref NET_OUT_ATTACH_BACKUP_STATE pstOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachBackupTaskState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachBackupTaskState(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachBackupTaskState(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr RealPlayEx2(IntPtr lLoginID, ref NET_IN_REALPLAY pInParam, ref NET_OUT_REALPLAY pOutParam, uint dwWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_RealPlayEx2(lLoginID, ref pInParam, ref pOutParam, dwWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static void RigisterDrawFun(fDrawCallBack cbDraw, IntPtr dwUser)
	{
		OriginalSDK.CLIENT_RigisterDrawFun(cbDraw, dwUser);
	}

	public static bool MatchTwoFaceImage(IntPtr lLoginID, ref NET_MATCH_TWO_FACE_IN pstInParam, ref NET_MATCH_TWO_FACE_OUT pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_MatchTwoFaceImage(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool FindRecordBackupRestoreTaskInfos(IntPtr lLoginID, ref NET_IN_FIND_REC_BAK_RST_TASK pInParam, ref NET_OUT_FIND_REC_BAK_RST_TASK pOutParam, int nWaitTime = 3000)
	{
		bool num = OriginalSDK.CLIENT_FindRecordBackupRestoreTaskInfos(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetExamRecordingPlans(IntPtr lLoginID, ref NET_IN_SET_EXAM_RECORDING_PLANS pstuInParam, ref NET_OUT_SET_EXAM_RECORDING_PLANS pstuOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_SetExamRecordingPlans(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool ManualSnap(IntPtr lLoginID, ref NET_IN_MANUAL_SNAP pInParam, ref NET_OUT_MANUAL_SNAP pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_ManualSnap(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool PlayOpenStream(int nPort, IntPtr pFileHeadBuf, uint nSize, uint nBufPoolSize)
	{
		return OriginalSDK.PLAY_OpenStream(nPort, pFileHeadBuf, nSize, nBufPoolSize);
	}

	public static bool PlayPlay(int nPort, IntPtr hWnd)
	{
		return OriginalSDK.PLAY_Play(nPort, hWnd);
	}

	public static bool PlayInputData(int nPort, IntPtr pBuf, uint nSize)
	{
		return OriginalSDK.PLAY_InputData(nPort, pBuf, nSize);
	}

	public static bool PlayStop(int nPort)
	{
		return OriginalSDK.PLAY_Stop(nPort);
	}

	public static bool PlayCloseStream(int nPort)
	{
		return OriginalSDK.PLAY_CloseStream(nPort);
	}

	public static bool GetMonitorWallCollections(IntPtr lLoginID, ref NET_IN_WM_GET_COLLECTIONS pInParam, ref NET_OUT_WM_GET_COLLECTIONS pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_GetMonitorWallCollections(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool LoadMonitorWallCollection(IntPtr lLoginID, ref NET_IN_WM_LOAD_COLLECTION pInParam, ref NET_OUT_WM_LOAD_COLLECTION pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_LoadMonitorWallCollection(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SaveMonitorWallCollection(IntPtr lLoginID, ref NET_IN_WM_SAVE_COLLECTION pInParam, ref NET_OUT_WM_SAVE_COLLECTION pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_SaveMonitorWallCollection(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool RenameMonitorWallCollection(IntPtr lLoginID, ref NET_IN_WM_RENAME_COLLECTION pInParam, ref NET_OUT_WM_RENAME_COLLECTION pOutParam, int nWaitTime = 1000)
	{
		bool num = OriginalSDK.CLIENT_RenameMonitorWallCollection(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool TransmitInfoForWebEx(IntPtr lLoginID, ref NET_IN_TRANSMIT_INFO pInParam, ref NET_OUT_TRANSMIT_INFO pOutParam, int nWaittime = 3000)
	{
		bool num = OriginalSDK.CLIENT_TransmitInfoForWebEx(lLoginID, ref pInParam, ref pOutParam, nWaittime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr StartFindFluxStat(IntPtr lLoginID, ref NET_IN_TRAFFICSTARTFINDSTAT pstInParam, ref NET_OUT_TRAFFICSTARTFINDSTAT pstOutParam)
	{
		return OriginalSDK.CLIENT_StartFindFluxStat(lLoginID, ref pstInParam, ref pstOutParam);
	}

	public static int DoFindFluxStat(IntPtr lFindHandle, ref NET_IN_TRAFFICDOFINDSTAT pstInParam, ref NET_OUT_TRAFFICDOFINDSTAT pstOutParam)
	{
		int num = 0;
		num = OriginalSDK.CLIENT_DoFindFluxStat(lFindHandle, ref pstInParam, ref pstOutParam);
		if (num == -1)
		{
			NetGetLastError(num);
		}
		return num;
	}

	public static bool StopFindFluxStat(IntPtr lFindHandle)
	{
		bool num = OriginalSDK.CLIENT_StopFindFluxStat(lFindHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool AddFaceDbDownLoadTask(IntPtr lLoginID, ref NET_IN_ADD_FACEDB_DOWNLOAD_TASK pInParam, ref NET_OUT_ADD_FACEDB_DOWNLOAD_TASK pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_AddFaceDbDownLoadTask(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachFaceDbDownLoadResult(IntPtr lLoginID, ref NET_IN_ATTACH_FACEDB_DOWNLOAD_RESULT pInParam, ref NET_OUT_ATTACH_FACEDB_DOWNLOAD_RESULT pOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachFaceDbDownLoadResult(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachFaceDbDownLoadResult(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachFaceDbDownLoadResult(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool SetSplitOSDEx(IntPtr lLoginID, ref NET_IN_SPLIT_SET_OSD_EX pInParam, ref NET_OUT_SPLIT_SET_OSD_EX pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_SetSplitOSDEx(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetSplitOSDEx(IntPtr lLoginID, ref NET_IN_SPLIT_GET_OSD_EX pInParam, ref NET_OUT_SPLIT_GET_OSD_EX pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetSplitOSDEx(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool CheckCloudUpgrader(IntPtr lLoginID, ref NET_IN_CHECK_CLOUD_UPGRADER pInParam, ref NET_OUT_CHECK_CLOUD_UPGRADER pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_CheckCloudUpgrader(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool ExecuteCloudUpgrader(IntPtr lLoginID, ref NET_IN_EXECUTE_CLOUD_UPGRADER pInParam, ref NET_OUT_EXECUTE_CLOUD_UPGRADER pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_ExecuteCloudUpgrader(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool GetCloudUpgraderState(IntPtr lLoginID, ref NET_IN_GET_CLOUD_UPGRADER_STATE pInParam, ref NET_OUT_GET_CLOUD_UPGRADER_STATE pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetCloudUpgraderState(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool StartMultiPersonFindFaceR(IntPtr lLoginID, ref NET_IN_STARTMULTIPERSONFIND_FACER pstInParam, ref NET_OUT_STARTMULTIPERSONFIND_FACER pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_StartMultiPersonFindFaceR(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool FaceRServerGetDetectToken(IntPtr lLoginID, ref NET_IN_FACERSERVER_GETDETEVTTOKEN pInParam, ref NET_OUT_FACERSERVER_GETDETEVTTOKEN pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_FaceRServerGetDetectToken(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetFileAlias(IntPtr lLoginID, ref NET_IN_SET_FILE_ALIAS_INFO pstuInParam, ref NET_OUT_SET_FILE_ALIAS_INFO pstuOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_SetFileAlias(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SearchFileByAlias(IntPtr lLoginID, ref NET_IN_SEARCH_FILE_BYALIAS_INFO pstuInParam, ref NET_OUT_SEARCH_FILE_BYALIAS_INFO pstuOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_SearchFileByAlias(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr GetWaterDataStatServerCaps(IntPtr lLoginID, ref NET_IN_WATERDATA_STAT_SERVER_GETCAPS_INFO pstuInParam, ref NET_OUT_WATERDATA_STAT_SERVER_GETCAPS_INFO pstuOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_GetWaterDataStatServerCaps(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static IntPtr StartFindWaterDataStatServer(IntPtr lLoginID, ref NET_IN_START_FIND_WATERDATA_STAT_SERVER_INFO pstuInParam, ref NET_OUT_START_FIND_WATERDATA_STAT_SERVER_INFO pstuOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StartFindWaterDataStatServer(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static IntPtr DoFindWaterDataStatServer(IntPtr lLoginID, ref NET_IN_DO_FIND_WATERDATA_STAT_SERVER_INFO pstuInParam, ref NET_OUT_DO_FIND_WATERDATA_STAT_SERVER_INFO pstuOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_DoFindWaterDataStatServer(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static IntPtr StopFindWaterDataStatServer(IntPtr lLoginID, ref NET_IN_STOP_FIND_WATERDATA_STAT_SERVER_INFO pstuInParam, ref NET_OUT_STOP_FIND_WATERDATA_STAT_SERVER_INFO pstuOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_StopFindWaterDataStatServer(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static IntPtr GetWaterDataStatServerWaterData(IntPtr lLoginID, ref NET_IN_WATERDATA_STAT_SERVER_GETDATA_INFO pstuInParam, ref NET_OUT_WATERDATA_STAT_SERVER_GETDATA_INFO pstuOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_GetWaterDataStatServerWaterData(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool GetUnifiedStatus(IntPtr lLoginID, ref NET_IN_UNIFIEDINFOCOLLECT_GET_DEVSTATUS pInParam, ref NET_OUT_UNIFIEDINFOCOLLECT_GET_DEVSTATUS pOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_GetUnifiedStatus(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachVideoStatStream(IntPtr lLoginID, ref NET_IN_ATTACH_VIDEOSTAT_STREAM pInParam, ref NET_OUT_ATTACH_VIDEOSTAT_STREAM pOutParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachVideoStatStream(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachVideoStatStream(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachVideoStatStream(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool BatchAppendFaceRecognition(IntPtr lLoginID, ref NET_IN_BATCH_APPEND_FACERECONGNITION pstInParam, ref NET_OUT_BATCH_APPEND_FACERECONGNITION pstOutParam, int nWaitTime)
	{
		bool num = OriginalSDK.CLIENT_BatchAppendFaceRecognition(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
		NetGetLastError(num);
		return num;
	}

	public static bool SetGPSUuidInfo(IntPtr lLoginID, ref NET_IN_SET_GPS_UUID_INFO pInParam, ref NET_OUT_SET_GPS_UUID_INFO pOutParam)
	{
		bool num = OriginalSDK.CLIENT_SetGPSUuidInfo(lLoginID, ref pInParam, ref pOutParam);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr ImportFaceDB(IntPtr lLoginID, ref NET_IN_IMPORT_FACE_DB pInParam, ref NET_OUT_IMPORT_FACE_DB pOutParam)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_ImportFaceDB(lLoginID, ref pInParam, ref pOutParam);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopImportFaceDB(IntPtr lImportFaceDbHandle)
	{
		bool num = OriginalSDK.CLIENT_StopImportFaceDB(lImportFaceDbHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr ExportFaceDB(IntPtr lLoginID, ref NET_IN_EXPORT_FACE_DB pInParam, ref NET_OUT_EXPORT_FACE_DB pOutParam)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_ExportFaceDB(lLoginID, ref pInParam, ref pOutParam);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool StopExportFaceDB(IntPtr lExportFaceDbHandle)
	{
		bool num = OriginalSDK.CLIENT_StopExportFaceDB(lExportFaceDbHandle);
		NetGetLastError(num);
		return num;
	}

	public static IntPtr AttachEventRestore(IntPtr lLoginID, ref NET_IN_ATTACH_EVENT_RESTORE pInParam, int nWaitTime)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = OriginalSDK.CLIENT_AttachEventRestore(lLoginID, ref pInParam, nWaitTime);
		NetGetLastError(intPtr);
		return intPtr;
	}

	public static bool DetachEventRestore(IntPtr lAttachHandle)
	{
		bool num = OriginalSDK.CLIENT_DetachEventRestore(lAttachHandle);
		NetGetLastError(num);
		return num;
	}

	public static bool QueryRemotDevState(IntPtr lLoginID, int nType, int nChannelID, IntPtr pBuf, int nBufLen, IntPtr pRetLen, int waittime)
	{
		bool num = OriginalSDK.CLIENT_QueryRemotDevState(lLoginID, nType, nChannelID, pBuf, nBufLen, pRetLen, waittime);
		NetGetLastError(num);
		return num;
	}
}
