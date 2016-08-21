namespace AW.DataAccess.Common
{
    using Entities;
    public class DbFactory : IDbFactory
    {
        private AdventureWorks2014Entities entities;
        public AdventureWorks2014Entities GetDb()
        {
            return entities ?? (entities = new AdventureWorks2014Entities());
        }
    }
}
