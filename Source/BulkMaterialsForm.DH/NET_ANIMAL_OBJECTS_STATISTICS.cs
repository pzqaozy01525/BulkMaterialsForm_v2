// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANIMAL_OBJECTS_STATISTICS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANIMAL_OBJECTS_STATISTICS
{
	public uint nAnimalsAmount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_A_VA_OBJECT_ANIMAL[] stuAnimalTypes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
	public byte[] bReserved;
}
