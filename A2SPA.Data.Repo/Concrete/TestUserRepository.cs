using System;
using System.Collections.Generic;
using System.Text;
using A2SPA.Data.Models;
using System.Linq;

namespace A2SPA.Data.Repo
{
    public class TestUserRepository : Repository, ITestUserRepository
    {        
        public TestUserRepository(A2SPAContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<TestData> GetTestDatas(int pageSize, int pageNumber)
        {
            var query = DbContext.Set<TestData>().AsQueryable();

            return pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
        }

        public TestData GetTestData(int id)
        {
            return DbContext.Set<TestData>().Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
