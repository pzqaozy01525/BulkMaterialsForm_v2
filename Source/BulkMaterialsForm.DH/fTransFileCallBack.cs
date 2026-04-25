// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fTransFileCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate void fTransFileCallBack(IntPtr lHandle, int nTransType, int nState, int nSendSize, int nTotalSize, IntPtr dwUser);
