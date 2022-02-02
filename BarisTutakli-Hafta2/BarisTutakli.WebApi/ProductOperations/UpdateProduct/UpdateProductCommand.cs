using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.Common.Abstract;
using BarisTutakli.WebApi.DbOperations;
using System;
using System.Linq;

namespace BarisTutakli.WebApi.ProductOperations.UpdateProduct
{


    public class UpdateProductCommand
    {
        private readonly ECommerceDbContext _context;

        public int ProductId { get; set; }

        public UpdateProductModel Model { get; set; }
        private readonly Mapper _mapper;

        public UpdateProductCommand(ECommerceDbContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == ProductId);
            if (product is null)
            {
                throw new InvalidOperationException(Messages.NotFound);
            }

            product = _mapper.Map(Model);

            _context.SaveChanges();
        }
    }
}
