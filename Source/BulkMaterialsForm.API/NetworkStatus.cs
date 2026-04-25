// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.API
// Type: BulkMaterialsForm.API.NetworkStatus

using System;

namespace BulkMaterialsForm.API;

public class NetworkStatus
{
	public bool IsConnected { get; set; }

	public int QualityScore { get; set; }

	public long Latency { get; set; }

	public string NetworkInterfaceInfo { get; set; }

	public string StatusDescription { get; set; }

	public DateTime CheckTime { get; set; }
}
