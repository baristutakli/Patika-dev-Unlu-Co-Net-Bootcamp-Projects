using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.Common.Abstract;
using BarisTutakli.WebApi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarisTutakli.WebApi.ProductOperations.GetProducts
{
    public class GetProductsQuery
    {
        public readonly ECommerceDbContext _context;
        private readonly Mapper _mapper;
        public GetProductsQuery(ECommerceDbContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProductsViewModel> Handle()
        {
            List<ProductsViewModel> productviewModels = _mapper.Map(_context.Products.ToList());
            if (productviewModels.Count == 0)
            {
                throw new InvalidOperationException(Messages.NotFound);
            }

            return productviewModels;


        }
    }
}
