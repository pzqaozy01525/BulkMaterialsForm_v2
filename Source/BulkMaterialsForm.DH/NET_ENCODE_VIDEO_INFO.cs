// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ENCODE_VIDEO_INFO

namespace BulkMaterialsForm.DH;

public struct NET_ENCODE_VIDEO_INFO
{
	public uint dwSize;

	public EM_FORMAT_TYPE emFormatType;

	public bool bVideoEnable;

	public EM_VIDEO_COMPRESSION emCompression;

	public int nWidth;

	public int nHeight;

	public EM_BITRATE_CONTROL emBitRateControl;

	public int nBitRate;

	public float nFrameRate;

	public int nIFrameInterval;

	public EM_IMAGE_QUALITY emImageQuality;
}
