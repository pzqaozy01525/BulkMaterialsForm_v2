// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_VIDEO_FORMAT

namespace BulkMaterialsForm.DH;

public struct NET_CFG_VIDEO_FORMAT
{
	public byte abCompression;

	public byte abWidth;

	public byte abHeight;

	public byte abBitRateControl;

	public byte abBitRate;

	public byte abFrameRate;

	public byte abIFrameInterval;

	public byte abImageQuality;

	public byte abFrameType;

	public byte abProfile;

	public NET_CFG_VIDEO_COMPRESSION emCompression;

	public int nWidth;

	public int nHeight;

	public NET_CFG_BITRATE_CONTROL emBitRateControl;

	public int nBitRate;

	public float nFrameRate;

	public int nIFrameInterval;

	public EM_CFG_IMAGE_QUALITY emImageQuality;

	public int nFrameType;

	public EM_CFG_H264_PROFILE_RANK emProfile;

	public int nMaxBitrate;
}
