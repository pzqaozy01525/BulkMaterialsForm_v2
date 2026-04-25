// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NETDEVTIME

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct NETDEVTIME
{
	[FieldOffset(0)]
	private uint _value;

	public uint Second
	{
		get
		{
			return _value & 0x3F;
		}
		set
		{
			_value = (value & 0x3F) | (_value & 0xFFFFFFC0u);
		}
	}

	public uint Minute
	{
		get
		{
			return (_value >> 6) & 0x3F;
		}
		set
		{
			_value = ((value & 0x3F) << 6) | (_value & 0xFFFFF03Fu);
		}
	}

	public uint Hour
	{
		get
		{
			return (_value >> 12) & 0x1F;
		}
		set
		{
			_value = ((value & 0x1F) << 12) | (_value & 0xFFFE0FFFu);
		}
	}

	public uint Day
	{
		get
		{
			return (_value >> 17) & 0x1F;
		}
		set
		{
			_value = ((value & 0x1F) << 17) | (_value & 0xFFC3FFFFu);
		}
	}

	public uint Month
	{
		get
		{
			return (_value >> 22) & 0xF;
		}
		set
		{
			_value = ((value & 0xF) << 22) | (_value & 0xFC3FFFFFu);
		}
	}

	public uint Year
	{
		get
		{
			return ((_value >> 26) & 0x3F) + 2000;
		}
		set
		{
			_value = (((value - 2000) & 0x3F) << 26) | (_value & 0x3FFFFFF);
		}
	}

	public override string ToString()
	{
		return string.Format("{0}-{1}-{2} {3}:{4}:{5}", Year.ToString("D4"), Month.ToString("D2"), Day.ToString("D2"), Hour.ToString("D2"), Minute.ToString("D2"), Second.ToString("D2"));
	}
}
