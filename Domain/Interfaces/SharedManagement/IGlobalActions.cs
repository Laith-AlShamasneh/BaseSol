namespace Domain.Interfaces.SharedManagement;

public interface IGlobalActions
{
    Task<int> ExecuteAsync(string spName, object? parameters = null);
    Task<dynamic?> ExecuteScalarAsync(string spName, object? parameters = null);
    Task<T> ExecuteMultipleAsync<T>(
        string spName,
        Func<IGridReader, Task<T>> map,
        object? parameters = null);
}
