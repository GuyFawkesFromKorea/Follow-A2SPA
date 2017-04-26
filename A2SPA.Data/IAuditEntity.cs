using System;
using System.Collections.Generic;
using System.Text;

namespace A2SPA.Data
{
    public interface IAuditEntity : IEntity
    {
        String CreateUser { get; set; }
        DateTime? CreateDtm { get; set; }
        String UpdateUser { get; set; }
        DateTime? UpdateDtm { get; set; }
    }
}
