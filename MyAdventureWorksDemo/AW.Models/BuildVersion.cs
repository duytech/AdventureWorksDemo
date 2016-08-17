namespace AW.Models
{
    using System;
    public class BuildVersion
    {
        public byte Id { get; set; }
        public string DatabaseVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
