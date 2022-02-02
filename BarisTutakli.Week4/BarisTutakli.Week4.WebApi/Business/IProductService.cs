using BarisTutakli.Week4.WebApi.Business.ViewModels;
using BarisTutakli.Week4.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BarisTutakli.Week4.WebApi.Business
{
    public interface IProductService
    {
        Task<int> Add(ProductCreateViewModel productViewModel);
        Task<int> Delete(ProductDetailQuery query);
        Task<int> Update(int id, ProductUpdateModel vm);
        Task<List<ProductDetailViewModel>> GetAll();
        Task<ProductDetailViewModel> GetById(ProductDetailQuery query);
        Task<IList<Product>> Get(Expression<Func<Product, bool>> filter);
    }
}
