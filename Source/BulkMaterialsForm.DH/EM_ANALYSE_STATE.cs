// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.EM_ANALYSE_STATE

namespace BulkMaterialsForm.DH;

public enum EM_ANALYSE_STATE
{
	UNKNOWN,
	IDLE,
	ANALYSING,
	ANALYSING_WAITPUSH,
	FINISH,
	ERROR,
	REMOVED,
	ROUNDFINISH,
	STARTING
}
