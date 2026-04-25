// Decompiled from: BulkMaterialsForm.exe
// Namespace: BST.Ticket
// Type: BST.Ticket.EventPagingArg

using System;

namespace BST.Ticket;

public class EventPagingArg : EventArgs
{
	private int _intPageIndex;

	public EventPagingArg(int PageIndex)
	{
		_intPageIndex = PageIndex;
	}
}
