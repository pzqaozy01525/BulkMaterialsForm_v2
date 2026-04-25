// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fBusStateCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate void fBusStateCallBack(IntPtr lAttachHandle, int lCommand, IntPtr pBuf, uint dwBufLen, IntPtr dwUser);
