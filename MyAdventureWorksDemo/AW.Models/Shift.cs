namespace AW.Models
{
    using System;
    using System.Runtime.Serialization;

    public class Shift
    {
        public byte ShiftID { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [IgnoreDataMember]
        public DateTime ModifiedDate { get; set; }
    }
}
