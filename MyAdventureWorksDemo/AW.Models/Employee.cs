namespace AW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public string BusinessEntityID { get; set; }
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }
        public short? OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public Person Person { get; set; }
        public ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
    }
}
