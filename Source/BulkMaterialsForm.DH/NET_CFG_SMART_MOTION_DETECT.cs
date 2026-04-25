// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_SMART_MOTION_DETECT

namespace BulkMaterialsForm.DH;

public struct NET_CFG_SMART_MOTION_DETECT
{
	public uint dwSize;

	public bool bEnable;

	public EM_SMART_MOTION_DETECT_SENSITIVITY_LEVEL emMotionDetectSensitivityLevel;

	public NET_SMART_MOTION_DETECT_OBJECT stuMotionDetectObject;
}
