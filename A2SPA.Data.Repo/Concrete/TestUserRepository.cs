using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using A2SPA.Data.Models;

namespace A2SPA.Data.Repo
{
    public class TestUserRepository : Repository, ITestUserRepository
    {        
        public TestUserRepository(A2SPAContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<TestData> GetTestDatas(Int32 pageSize, Int32 pageNumber)
        {
            return Paging<TestData>(pageSize, pageNumber);
        }

        public async Task<TestData> GetTestDataAsync(int id)
        {
            return await DbContext.Set<TestData>().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<int> AddTestDataAsync(TestData data)
        {
            this.Add<TestData>(data);

            return await CommitChangesAsync();
        }

        public async Task<int> UpdateTestDataAsync(TestData data)
        {
            this.Update<TestData>(data);

            return await CommitChangesAsync();
        }

        public async Task<int> DeleteTestDataAsync(TestData data)
        {
            Remove<TestData>(data);

            return await CommitChangesAsync();
        }
    }
}
