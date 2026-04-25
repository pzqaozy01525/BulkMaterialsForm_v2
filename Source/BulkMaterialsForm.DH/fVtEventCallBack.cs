// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fVtEventCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate int fVtEventCallBack(IntPtr instId, IntPtr ulRegisterId, IntPtr ulSessionId, int nEvent, IntPtr pDataBuf, uint dwBufSize, IntPtr dwUser);
