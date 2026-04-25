// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.fRemoteUploadFileCallBack

using System;

namespace BulkMaterialsForm.DH;

public delegate void fRemoteUploadFileCallBack(IntPtr lRemoteUploadFileID, int nTotalSize, int nSendSize, EM_UPLOAD_PROCESS_STATUS emStatus, IntPtr dwUser);
