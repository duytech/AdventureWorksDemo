namespace AW.Models
{
    using Newtonsoft.Json;
    using System;
    public class BuildVersion
    {
        [JsonProperty("Id")]
        public byte SystemInformationID { get; set; }
        [JsonProperty("DatabaseVersion")]
        public string Database_Version { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
