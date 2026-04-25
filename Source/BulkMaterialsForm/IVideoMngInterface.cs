// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm
// Type: BulkMaterialsForm.IVideoMngInterface

namespace BulkMaterialsForm;

internal interface IVideoMngInterface
{
	void Open();

	void Init();

	void StartVideoNetThread();

	void Snap(string model);

	void Close();
}
