namespace AW.DataAccess.Common
{
    using System;
    // The unit of work class serves one purpose: to make sure that when you use multiple repositories, they share a single database context.
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}
