namespace AW.Models
{
    using System;
    using Newtonsoft.Json;
    public class PersonPhone
    {
        [JsonProperty("Id")]
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
