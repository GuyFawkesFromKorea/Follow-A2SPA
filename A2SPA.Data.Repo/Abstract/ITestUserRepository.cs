using System.Threading.Tasks;
using System.Linq;

using A2SPA.Data.Models;

namespace A2SPA.Data.Repo
{
    public interface ITestUserRepository
    {
        Task<int> AddTestDataAsync(TestData data);
        Task<int> DeleteTestDataAsync(TestData data);
        Task<TestData> GetTestDataAsync(int id);
        IQueryable<TestData> GetTestDatas(int pageSize, int pageNumber);
        Task<int> UpdateTestDataAsync(TestData data);
    }
}