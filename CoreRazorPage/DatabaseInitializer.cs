using CoreRazorPage.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRazorPage
{
    public static class DatabaseInitializer
    {
        public static void Initialize(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Roles.Any())
            {
                dbContext.Add(new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "Admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );
                dbContext.SaveChanges();
            }
        }
    }
}
