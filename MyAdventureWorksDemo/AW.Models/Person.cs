namespace AW.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        [JsonProperty("PersonId")]
        [Key]
        public string BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        public string AdditionalContactInfo { get; set; }
        public string Demographics { get; set; }
        [JsonIgnore]
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<EmailAddress> EmailAddresses { get; set; }
        public ICollection<PersonPhone> PersonPhones { get; set; }
    }
}
