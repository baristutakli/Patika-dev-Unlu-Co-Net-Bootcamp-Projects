using BarisTutakli.WebApi.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ECommerceDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ECommerceDbContext>>()))
            {
                //// Look for any book.
                if (context.Products.Any())
                {
                    return;   // Data was already seeded
                }

                context.Products.AddRange(
                   new Product { ProductName = "Iphone", PublishDate = DateTime.Now, CategoryId = 1 },
                   new Product { ProductName = "Hp", PublishDate = DateTime.Now, CategoryId = 2 },
                   new Product { ProductName = "Monster", PublishDate = DateTime.Now, CategoryId = 2 }
                   );
               

                context.SaveChanges();
            }
        }
    }
}
