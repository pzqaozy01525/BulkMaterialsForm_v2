// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fPTZStatusProcCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate void fPTZStatusProcCallBack(IntPtr lLoginID, IntPtr lAttachHandle, IntPtr pBuf, int nBufLen, IntPtr dwUser);
