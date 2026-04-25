// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.EM_MATRIX_CARD_TYPE

using System;

namespace BulkMaterialsForm.DH;

[Flags]
public enum EM_MATRIX_CARD_TYPE
{
	MAIN = 0x10000000,
	INPUT = 1,
	OUTPUT = 2,
	ENCODE = 4,
	DECODE = 8,
	CASCADE = 0x10,
	INTELLIGENT = 0x20,
	ALARM = 0x40,
	RAID = 0x80,
	NET_DECODE = 0x100
}
