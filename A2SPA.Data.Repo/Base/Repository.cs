using A2SPA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace A2SPA.Data.Repo
{
    public class Repository
    {
        protected A2SPAContext DbContext;

        public Repository(A2SPAContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
