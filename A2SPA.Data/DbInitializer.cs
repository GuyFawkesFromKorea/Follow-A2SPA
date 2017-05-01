using A2SPA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace A2SPA.Data
{
    public static class DbInitializer
    {
        public static void Initialize(A2SPAContext context)
        {
            context.Database.EnsureCreated();

            // Look for any test data.
            if (context.TestData.Any())
            {
                return;   // DB has been seeded
            }

            var testData = new TestData
            {
                Username = "JaneDoe",
                EmailAddress = "jane.doe@example.com",
                Password = "LetM@In!",
                Currency = 321.45M,
                CreateUser = "System",
                CreateDtm = DateTime.Now,
                UpdateUser = "System",
            };

            context.TestData.Add(testData);
            context.SaveChanges();
        }
    }
}
