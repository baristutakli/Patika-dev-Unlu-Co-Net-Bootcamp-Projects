using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.DbOperations;
using System;
using System.Linq;

namespace BarisTutakli.WebApi.ProductOperations.DeleteProduct
{
    public class DeleteProductCommand
    {
        private readonly ECommerceDbContext _dbcontext;
        public int ProductId { get; set; }

        public DeleteProductCommand(ECommerceDbContext context)
        {
            _dbcontext = context;
        }

        public void Handle()
        {
            var product = _dbcontext.Products.SingleOrDefault(p => p.Id == ProductId);
            if (product is null) { throw new InvalidOperationException(Messages.NotFound); }
            _dbcontext.Products.Remove(product);
            _dbcontext.SaveChanges();
        
        }
    }
}
