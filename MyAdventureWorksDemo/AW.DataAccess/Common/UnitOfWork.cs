namespace AW.DataAccess.Common
{
    using System;
    using System.Data.Entity;
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public int Commit() => _dbContext.SaveChanges();

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
