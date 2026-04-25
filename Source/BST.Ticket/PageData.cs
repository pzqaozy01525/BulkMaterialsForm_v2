// Decompiled from: BulkMaterialsForm.exe
// Namespace: BST.Ticket
// Type: BST.Ticket.PageData

using System.Data;

namespace BST.Ticket;

public class PageData
{
	private int _PageSize = 10;

	private int _PageIndex = 1;

	private int _PageCount;

	private int _TotalCount;

	private string _TableName;

	private string _QueryFieldName = "*";

	private string _OrderStr = string.Empty;

	private string _QueryCondition = string.Empty;

	private string _PrimaryKey = string.Empty;

	private bool _isQueryTotalCounts = true;

	public string sizeSql = "";

	public bool IsQueryTotalCounts
	{
		get
		{
			return _isQueryTotalCounts;
		}
		set
		{
			_isQueryTotalCounts = value;
		}
	}

	public int PageSize
	{
		get
		{
			return _PageSize;
		}
		set
		{
			_PageSize = value;
		}
	}

	public int PageIndex
	{
		get
		{
			return _PageIndex;
		}
		set
		{
			_PageIndex = value;
		}
	}

	public int PageCount => _PageCount;

	public int TotalCount => _TotalCount;

	public string TableName
	{
		get
		{
			return _TableName;
		}
		set
		{
			_TableName = value;
		}
	}

	public string QueryFieldName
	{
		get
		{
			return _QueryFieldName;
		}
		set
		{
			_QueryFieldName = value;
		}
	}

	public string OrderStr
	{
		get
		{
			return _OrderStr;
		}
		set
		{
			_OrderStr = value;
		}
	}

	public string QueryCondition
	{
		get
		{
			return _QueryCondition;
		}
		set
		{
			_QueryCondition = value;
		}
	}

	public string PrimaryKey
	{
		get
		{
			return _PrimaryKey;
		}
		set
		{
			_PrimaryKey = value;
		}
	}

	public DataTable QueryDataTable(int _TotalCount)
	{
		if (_TotalCount == 0)
		{
			_PageIndex = 0;
			_PageCount = 0;
		}
		else
		{
			_PageCount = ((_TotalCount % _PageSize == 0) ? (_TotalCount / _PageSize) : (_TotalCount / _PageSize + 1));
			if (_PageIndex > _PageCount)
			{
				_PageIndex = _PageCount;
			}
		}
		this._TotalCount = _TotalCount;
		return null;
	}

	public int GetTotalCount(int count)
	{
		_TotalCount = count;
		return 0;
	}
}
