using System;

namespace BarisTutakli.WebApi.ProductOperations.GetProducts
{
    public  class ProductsViewModel
    {
        public string Category { get; set; }
        public string ProductName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}