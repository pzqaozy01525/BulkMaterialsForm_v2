// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Model.View
// Type: BulkMaterialsForm.Model.View.SalesData

using System;

namespace BulkMaterialsForm.Model.View;

public class SalesData
{
	public string ProductName { get; set; }

	public decimal SalesAmount { get; set; }

	public int Quantity { get; set; }

	public DateTime SaleDate { get; set; }
}
