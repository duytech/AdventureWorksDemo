namespace AW.Models
{
    using System;
    using Newtonsoft.Json;
    public class PhoneNumberType
    {
        [JsonProperty("Id")]
        public int PhoneNumberTypeID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
