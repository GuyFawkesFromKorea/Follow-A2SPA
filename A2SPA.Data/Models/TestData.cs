using System;
using System.Collections.Generic;

namespace A2SPA.Data.Models
{
    public partial class TestData : IAuditEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public decimal Currency { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDtm { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDtm { get; set; }
    }
}
