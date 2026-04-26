// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Manager
// Type: BulkMaterialsForm.Manager.Manager

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using BulkMaterialsForm.Help;
using SqlSugar;

namespace BulkMaterialsForm.Manager;

public class Manager<T> : IManager<T> where T : class, new()
{
	private SimpleClient<T> context;

	public SqlSugarClient Db;

	private List<string> sqlTableName = new List<string>();

	public Manager()
	{
		Db = CallContext.GetData("SqlSugarClient") as SqlSugarClient;
		if (Db == null)
		{
			Db = new SqlSugarClient(new ConnectionConfig
			{
				ConnectionString = MainData.M_str_sqlcon,
				DbType = DbType.SqlServer,
				InitKeyType = InitKeyType.Attribute,
				IsAutoCloseConnection = true
			});
			CallContext.SetData("SqlSugarClient", Db);
		}
		context = new SimpleClient<T>(Db);
		Type typeFromHandle = typeof(T);
		sqlTableName.Contains(typeFromHandle.Name);
		Db.Aop.OnLogExecuting = delegate
		{
		};
	}

	public void AddTran(T Model)
	{
		DbResult<bool> dbResult = Db.Ado.UseTran(delegate
		{
			context.Insert(Model);
		});
		if (!dbResult.IsSuccess)
		{
			LogSave.SaveExeLog($"[Manager.AddTran] 事务执行失败: {dbResult.ErrorMessage}");
		}
	}

	public bool Add(T Model)
	{
		return context.Insert(Model);
	}

	public bool AddBy(List<T> ListModel)
	{
		return context.InsertRange(ListModel);
	}

	public int AddReturnIdentity(T Model)
	{
		return context.InsertReturnIdentity(Model);
	}

	public List<T> AsQueryable(string OrderByFileds)
	{
		return context.AsQueryable().Where("").OrderByIF(!string.IsNullOrEmpty(OrderByFileds), OrderByFileds)
			.ToList();
	}

	public bool Delete(T Model)
	{
		return context.Delete(Model);
	}

	public bool Delete(Expression<Func<T, bool>> whereLambda)
	{
		return context.Delete(whereLambda);
	}

	public bool DeleteById(int Id)
	{
		return context.DeleteById(Id);
	}

	public bool DeleteById(params dynamic[] Id)
	{
		return context.DeleteByIds(Id);
	}

	public T GetById(int Id)
	{
		throw new NotImplementedException();
	}

	public List<T> GetList(Expression<Func<T, bool>> whereLambda)
	{
		try
		{
			return context.GetList(whereLambda);
		}
		catch
		{
			Db.CodeFirst.InitTables(typeof(T));
			return null;
		}
	}

	public List<T> GetList()
	{
		try
		{
			return context.GetList();
		}
		catch
		{
			Db.CodeFirst.InitTables(typeof(T));
			return null;
		}
	}

	public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel)
	{
		return context.GetPageList(whereExpression, pageModel);
	}

	public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
	{
		return context.GetPageList(whereExpression, pageModel, orderByExpression, orderByType);
	}

	public List<T> GetPageList(List<IConditionalModel> conditionalList, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
	{
		return context.GetPageList(conditionalList, page, orderByExpression, orderByType);
	}

	public List<T> GetQuerySql(string querysql)
	{
		return Db.SqlQueryable<T>(querysql).ToList();
	}

	public bool DeteleSql(string querysql)
	{
		Db.Deleteable<T>(querysql);
		return true;
	}

	public bool Modify(Expression<Func<T, T>> columsExpression, Expression<Func<T, bool>> whereExpression)
	{
		return context.Update(columsExpression, whereExpression);
	}

	public bool Modify(T Model)
	{
		return context.Update(Model);
	}

	public bool ModifyBy(List<T> ListModel)
	{
		return context.UpdateRange(ListModel);
	}

	public bool DeleteSql(List<string> sql)
	{
		Db.Deleteable<T>(sql).ExecuteCommand();
		DbResult<bool> dbResult = Db.Ado.UseTran(delegate
		{
			foreach (string item in sql)
			{
				Db.Deleteable<T>(item).ExecuteCommand();
			}
		});
		if (!dbResult.IsSuccess)
		{
			LogSave.SaveExeLog($"[Manager.DeleteByCondition] 事务执行失败: {dbResult.ErrorMessage}");
		}
		return true;
	}

	public SqlSugarClient DbContext()
	{
		return Db;
	}

	public T GetModel(Expression<Func<T, bool>> whereLambda)
	{
		try
		{
			return context.GetFirst(whereLambda);
		}
		catch
		{
			Db.CodeFirst.InitTables(typeof(T));
			return null;
		}
	}
}
