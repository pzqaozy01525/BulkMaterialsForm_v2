// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_VIDEOENC_OPT

namespace BulkMaterialsForm.DH;

public struct NET_CFG_VIDEOENC_OPT
{
	public byte abVideoEnable;

	public byte abAudioEnable;

	public byte abSnapEnable;

	public byte abAudioAdd;

	public byte abAudioFormat;

	public bool bVideoEnable;

	public NET_CFG_VIDEO_FORMAT stuVideoFormat;

	public bool bAudioEnable;

	public bool bSnapEnable;

	public bool bAudioAddEnable;

	public NET_CFG_AUDIO_ENCODE_FORMAT stuAudioFormat;
}
