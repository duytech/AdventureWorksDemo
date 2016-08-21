namespace AW.Bussiness.Common
{
    using System.Collections.Generic;
    public static class PropertyDictionary
    {
        public static Dictionary<string, string> GetCustomer()
        {
            var model = new Models.Customer();
            var entity = new DataAccess.Entities.Customer();
            return new Dictionary<string, string>
            {
                { nameof(model.CustomerID), nameof(entity.CustomerID) },
                { nameof(model.AccountNumber), nameof(entity.AccountNumber) },
                { nameof(model.StoreID), nameof(entity.StoreID) },
                { nameof(model.TerritoryID), nameof(entity.TerritoryID) }
            };
        }
    }
}
