using System.Collections.Generic;
using A2SPA.Data.Models;

namespace A2SPA.Data.Repo
{
    public interface ITestUserRepository
    {
        TestData GetTestData(int id);
        IEnumerable<TestData> GetTestDatas(int pageSize, int pageNumber);
    }
}