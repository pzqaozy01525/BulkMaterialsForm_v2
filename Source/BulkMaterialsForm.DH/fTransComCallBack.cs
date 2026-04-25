// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fTransComCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate void fTransComCallBack(IntPtr lLoginID, IntPtr lTransComChannel, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser);
