namespace AW.DataAccess.Common
{
    using AW.DataAccess.Entities;
    public interface IDbFactory
    {
        AdventureWorks2014Entities GetDb();
    }
}
