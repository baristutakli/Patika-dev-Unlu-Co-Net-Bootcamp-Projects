
using System;

namespace BarisTutakli.WebApi.ProductOperations.UpdateProduct
{
    public class UpdateProductModel
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
