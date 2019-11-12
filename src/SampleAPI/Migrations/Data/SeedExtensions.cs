using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Migrations.Data
{
    public static class SeedExtensions
    {
        public static readonly User[] UsersSeed = new User[] {
            new User
            {
                Username = "Mr. Sample",
                Email = "sample@email.com",
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               UsersSeed
            );
        }
    }
}
