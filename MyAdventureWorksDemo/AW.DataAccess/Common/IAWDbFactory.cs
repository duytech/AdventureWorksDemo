namespace AW.DataAccess.Common
{
    using AW.DataAccess.Entities;
    public interface IAWDbFactory
    {
        AdventureWorks2014Entities GetDb();
    }
}
