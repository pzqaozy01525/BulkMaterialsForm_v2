// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fRadarAlarmPointInfoCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate void fRadarAlarmPointInfoCallBack(IntPtr lLoginId, IntPtr lAttachHandle, IntPtr pBuf, uint dwBufLen, IntPtr pReserved, IntPtr dwUser);
