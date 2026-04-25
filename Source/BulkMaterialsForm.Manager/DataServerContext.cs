// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Manager
// Type: BulkMaterialsForm.Manager.DataServerContext

namespace BulkMaterialsForm.Manager;

public class DataServerContext<T> where T : class, new()
{
	public IManager<T> Current = new Manager<T>();
}
