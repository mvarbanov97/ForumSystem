using System.Collections.Generic;
using ForumSystem.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<string> { "Sport", "Coronavirus", "News", "Music", "Programming", "Cats", "Dogs" };
            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category,
                    Description = category,
                    Title = category,
                    ImageUrl = null,
                });
            }

        }
    }
}
