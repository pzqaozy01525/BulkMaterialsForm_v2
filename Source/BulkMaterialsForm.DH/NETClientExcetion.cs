// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NETClientExcetion

using System;

namespace BulkMaterialsForm.DH;

public class NETClientExcetion : Exception
{
	public int ErrorCode { get; private set; }

	public new string Message { get; private set; }

	public NETClientExcetion(int errorCode, string message)
	{
		ErrorCode = errorCode;
		Message = message;
	}
}
