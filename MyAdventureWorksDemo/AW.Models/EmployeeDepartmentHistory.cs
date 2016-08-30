namespace AW.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class EmployeeDepartmentHistory
    {
        [JsonIgnore]
        [IgnoreDataMember]
        [Key]
        public int BusinessEntityID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        [Key]
        public short DepartmentID { get; set; }
        [IgnoreDataMember]
        [Key]
        public byte ShiftID { get; set; }
        [Key]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public DateTime ModifiedDate { get; set; }
        public Department Department { get; set; }
        public Shift Shift { get; set; }
    }
}
