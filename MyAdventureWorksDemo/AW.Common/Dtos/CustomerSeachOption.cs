namespace AW.Common.Dtos
{
    using Newtonsoft.Json;
    public class CustomerSeachOption
    {
        [JsonProperty("Id")]
        public int CustomerID { get; set; }
        public string AccountNumber { get; set; }
    }
}
