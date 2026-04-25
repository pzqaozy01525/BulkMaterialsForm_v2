// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fUploadFileCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate int fUploadFileCallBack(IntPtr lUploadFileHandle, int nTotalSize, int nSendSize, IntPtr dwUser);
