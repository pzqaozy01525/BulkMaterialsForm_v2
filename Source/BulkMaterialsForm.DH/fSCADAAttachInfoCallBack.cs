// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fSCADAAttachInfoCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate void fSCADAAttachInfoCallBack(IntPtr lLoginID, IntPtr lAttachHandle, IntPtr pInfo, int nBufLen, IntPtr dwUser);
