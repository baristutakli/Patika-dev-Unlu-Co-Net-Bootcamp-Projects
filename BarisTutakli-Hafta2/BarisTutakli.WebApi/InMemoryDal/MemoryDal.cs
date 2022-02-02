using BarisTutakli.WebApi.Models.Concrete;
using System;
using System.Collections.Generic;

namespace BarisTutakli.WebApi.InMemoryDal
{
    public class MemoryDal
    {
        public static List<Product> ProductList = new List<Product> {
                new Product { Id=1, CategoryId=2, ProductName="Watch", PublishDate=DateTime.Now },
                new Product { Id=2, CategoryId=3, ProductName="Phone", PublishDate=DateTime.Now },
                new Product { Id=3, CategoryId=4, ProductName="Dumbell", PublishDate=DateTime.Now }
            };
        
    }
}
               