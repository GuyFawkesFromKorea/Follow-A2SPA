using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2SPA.Data
{
    public static class IdentityDbInitializer
    {
        public static void Initialize(IdentityContext context)
        {
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
    }
}
