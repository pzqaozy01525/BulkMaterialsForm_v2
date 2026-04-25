// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fSCADAAlarmAttachInfoCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate void fSCADAAlarmAttachInfoCallBack(IntPtr lAttachHandle, IntPtr pInfo, int nBufLen, IntPtr dwUser);
