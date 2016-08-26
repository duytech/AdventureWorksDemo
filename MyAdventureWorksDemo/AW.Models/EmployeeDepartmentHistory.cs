namespace AW.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Runtime.Serialization;

    public class EmployeeDepartmentHistory
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public int BusinessEntityID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public short DepartmentID { get; set; }
        [IgnoreDataMember]
        public byte ShiftID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public DateTime ModifiedDate { get; set; }
        public Department Department { get; set; }
        public Shift Shift { get; set; }
    }
}
