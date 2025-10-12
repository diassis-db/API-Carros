using Microsoft.EntityFrameworkCore.Storage;

namespace APICarros.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly MySqlContext _context;
        private IDbContextTransaction _transaction;

        public UnityOfWork(MySqlContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _transaction.Commit();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
    }

    public interface IUnityOfWork
    {
    }
}
