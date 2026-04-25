namespace BulkMaterialsForm.SDK;

public class ItemObject
{
	public string Text = "";

	public uint Value = 0u;

	public ItemObject(string _text, uint _value)
	{
		Text = _text;
		Value = _value;
	}
}
