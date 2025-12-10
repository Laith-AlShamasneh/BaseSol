using System.Data;

namespace Domain.Interfaces.SharedManagement;

public interface IUnitOfWork : IAsyncDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();

    IDbConnection Connection { get; }
    IDbTransaction? Transaction { get; }

    IGlobalActions GlobalActions { get; }
}
