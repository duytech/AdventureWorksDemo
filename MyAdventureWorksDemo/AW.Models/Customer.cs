namespace AW.Models
{
    using System;
    using Newtonsoft.Json;
    public class Customer : Person
    {
        [JsonProperty("Id")]
        public int CustomerID { get; set; }
        [JsonIgnore]
        public int? PersonID { get; set; }
        public int? StoreID { get; set; }
        public int? TerritoryID { get; set; }
        public string AccountNumber { get; set; }
    }
}
