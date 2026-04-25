// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model.Result
// Type: BulkMaterialsForm.Model.Result.ClinetMsgResult

using System.Collections.Generic;

namespace BulkMaterialsForm.Model.Result;

public class ClinetMsgResult
{
	public List<CmdEntity> data { get; set; }

	public string msg { get; set; }

	public int code { get; set; }
}
