namespace Domain.Interfaces.SharedManagement;

public interface IGridReader : IDisposable
{
    Task<IEnumerable<T>> ReadAsync<T>();
    Task<T> ReadFirstAsync<T>();
}
