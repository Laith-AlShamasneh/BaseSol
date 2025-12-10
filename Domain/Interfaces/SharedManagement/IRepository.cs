namespace Domain.Interfaces.SharedManagement;

public interface IGetListAction<T>
{
    Task<IReadOnlyList<T>> GetList(T entity);
}

public interface IGetByIdAction<T>
{
    public Task<T> GetById(T entity);
}

public interface IAddAction<T>
{
    Task Add(T entity);
}

public interface IUpdateAction<T>
{
    Task Update(T entity);
}

public interface IDeleteAction<T>
{
    Task Delete(T entity);
}

public interface IGetListPaginationAction<T, in TPagination, in TPaginationSortColumn, in TPaginationSearchValue, in TSortDirection>
{
    Task<(IReadOnlyList<T> Result, long TotalRecords)> GetListPagination(
        T entity,
        TPagination pagination,
        TPaginationSortColumn? sortColumn,
        TSortDirection sortDirection,
        TPaginationSearchValue? searchValue);
}

