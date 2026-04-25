// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.ItemObject

namespace BulkMaterialsForm.SDK;

public class ItemObject
{
	public string Text = "";

	public uint Value;

	public ItemObject(string _text, uint _value)
	{
		Text = _text;
		Value = _value;
	}
}
