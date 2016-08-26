namespace AW.Models
{
    using Newtonsoft.Json;
    public class Department
    {
        public short DepartmentID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        [JsonIgnore]
        public System.DateTime ModifiedDate { get; set; }
    }
}
