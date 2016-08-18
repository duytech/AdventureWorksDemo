namespace AW.Models
{
    using Newtonsoft.Json;
    using System;
    public class EmailAddress
    {
        [JsonIgnore]
        public int BusinessEntityID { get; set; }
        [JsonProperty("Id")]
        public int EmailAddressID { get; set; }
        [JsonProperty("Address")]
        public string EmailAddress1 { get; set; }
        public DateTime ModifiedDate { get; set; }
        [JsonIgnore]
        public System.Guid rowguid { get; set; }
    }
}
