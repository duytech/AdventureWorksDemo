namespace AW.DataAccess.Common
{
    #region Using
    using System;
    using System.Data.Entity;
    #endregion
    // The unit of work class serves one purpose: to make sure that when you use multiple repositories, they share a single database context.
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
