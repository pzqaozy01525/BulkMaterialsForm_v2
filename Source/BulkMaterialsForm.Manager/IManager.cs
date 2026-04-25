// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Manager
// Type: BulkMaterialsForm.Manager.IManager

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SqlSugar;

namespace BulkMaterialsForm.Manager;

public interface IManager<T> where T : class, new()
{
	int AddReturnIdentity(T Model);

	bool Add(T Model);

	bool AddBy(List<T> ListModel);

	bool Modify(Expression<Func<T, T>> columsExpression, Expression<Func<T, bool>> whereExpression);

	bool Modify(T Model);

	bool ModifyBy(List<T> ListModel);

	bool Delete(T Model);

	bool DeleteSql(List<string> sql);

	bool DeleteById(int Id);

	bool DeleteById(params dynamic[] Id);

	bool Delete(Expression<Func<T, bool>> whereLambda);

	List<T> GetList(Expression<Func<T, bool>> whereLambda);

	List<T> GetList();

	List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel);

	List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc);

	List<T> GetPageList(List<IConditionalModel> conditionalList, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc);

	List<T> AsQueryable(string OrderByFileds);

	T GetById(int Id);

	List<T> GetQuerySql(string querysql);

	SqlSugarClient DbContext();

	T GetModel(Expression<Func<T, bool>> whereLambda);
}
