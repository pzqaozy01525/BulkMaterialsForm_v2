// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_FACE_FIND_STATE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_FACE_FIND_STATE
{
	public uint dwSize;

	public int nTokenNum;

	public IntPtr nTokens;

	public fFaceFindStateCallBack cbFaceFindState;

	public IntPtr dwUser;
}
