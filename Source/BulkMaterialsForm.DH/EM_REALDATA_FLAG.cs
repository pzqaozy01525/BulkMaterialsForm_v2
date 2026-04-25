// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.EM_REALDATA_FLAG

using System;

namespace BulkMaterialsForm.DH;

[Flags]
public enum EM_REALDATA_FLAG
{
	RAW_DATA = 1,
	DATA_WITH_FRAME_INFO = 2,
	YUV_DATA = 4,
	PCM_AUDIO_DATA = 8
}
