using System;

namespace BarisTutakli.WebApi.ProductOperations.CreateProduct
{
    public class CreateProductModel
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
