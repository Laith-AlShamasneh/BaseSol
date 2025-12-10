using Dapper;
using Domain.Interfaces.SharedManagement;
using System.Data;
using static Dapper.SqlMapper;

namespace Infrastructure.Repositories.SharedManagement;

internal class DapperGridReaderWrapper(GridReader reader) : IGridReader
{
    public async Task<IEnumerable<T>> ReadAsync<T>() => await reader.ReadAsync<T>();
    public async Task<T> ReadFirstAsync<T>() => await reader.ReadFirstAsync<T>();
    public void Dispose() { }
}

internal class GlobalActions(IDbConnection connection, IDbTransaction? transaction) : IGlobalActions
{
    private IDbConnection Cn => connection;
    private IDbTransaction? Tx => transaction;

    public async Task<int> ExecuteAsync(string spName, object? parameters = null)
    {
        return await Cn.ExecuteAsync(spName, parameters, Tx, commandType: CommandType.StoredProcedure);
    }

    public async Task<dynamic?> ExecuteScalarAsync(string spName, object? parameters = null)
    {
        return await Cn.ExecuteScalarAsync<dynamic>(spName, parameters, Tx, commandType: CommandType.StoredProcedure);
    }

    public async Task<T> ExecuteMultipleAsync<T>(string spName, Func<IGridReader, Task<T>> map, object? parameters = null)
    {
        using var multi = await Cn.QueryMultipleAsync(spName, parameters, Tx, commandType: CommandType.StoredProcedure);

        var wrapper = new DapperGridReaderWrapper(multi);

        return await map(wrapper);
    }
}
