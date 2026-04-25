// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RESTORE

namespace BulkMaterialsForm.DH;

public enum NET_RESTORE : uint
{
	COMMON = 1u,
	CODING = 2u,
	VIDEO = 4u,
	COMM = 8u,
	NETWORK = 0x10u,
	ALARM = 0x20u,
	VIDEODETECT = 0x40u,
	PTZ = 0x80u,
	OUTPUTMODE = 0x100u,
	CHANNELNAME = 0x200u,
	VIDEOINOPTIONS = 0x400u,
	CPS = 0x800u,
	INTELLIGENT = 0x1000u,
	REMOTEDEVICE = 0x2000u,
	DECODERVIDEOOUT = 0x4000u,
	LINKMODE = 0x8000u,
	COMPOSITE = 0x10000u,
	ALL = 0x80000000u
}
