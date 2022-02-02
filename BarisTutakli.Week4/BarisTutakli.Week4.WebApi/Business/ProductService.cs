using BarisTutakli.Week4.WebApi.Business.Validators;
using BarisTutakli.Week4.WebApi.Business.ViewModels;
using BarisTutakli.Week4.WebApi.DataAccess.ProductDal;
using BarisTutakli.Week4.WebApi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace BarisTutakli.Week4.WebApi.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Add(ProductCreateViewModel vm)
        {
            ProductCreateViewModelValidator validator = new ProductCreateViewModelValidator();
            validator.ValidateAndThrow(vm);

            return await _repository.Add(new Product { CategoryId = vm.CategoryId, ProductName = vm.ProductName, PublishDate = DateTime.Parse(vm.PublishDate.ToShortDateString()), CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString()) });
        }

        public async Task<int> Delete(ProductDetailQuery query)
        {
            ProductIdValidator validator = new ProductIdValidator();
            validator.ValidateAndThrow(new ProductDetailQuery { Id = query.Id });
            var result = _repository.GetById(query.Id);
   
            return await _repository.Delete(result.Result);
        }

        public Task<IList<Product>> Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDetailViewModel>> GetAll()
        {
            var result = await _repository.GetAll();
            List<ProductDetailViewModel> vm = new List<ProductDetailViewModel>();
            result.ForEach(item => vm.Add(new ProductDetailViewModel
            {
                Id = item.Id,
                CategoryId = item.CategoryId,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt,
                ProductName = item.ProductName,
                PublishDate = item.PublishDate
            }));
            return vm;
        }

        public Task<ProductDetailViewModel> GetById(ProductDetailQuery query)
        {
            ProductIdValidator validator = new ProductIdValidator();
            validator.ValidateAndThrow(query);
            var result = _repository.GetById(query.Id).Result;


            return Task.FromResult(new ProductDetailViewModel
            {
                Id = result.Id,
                CategoryId = result.CategoryId,
                CreatedAt = result.CreatedAt,
                ModifiedAt = result.ModifiedAt,
                ProductName = result.ProductName,
                PublishDate = result.PublishDate
            });
        }

        public async Task<int> Update(int id,ProductUpdateModel vm)
        {
            ProductUpdateValidator validator = new ProductUpdateValidator();
            validator.ValidateAndThrow(vm);
            var product =_repository.GetById(id);
            product.Result.ProductName = vm.ProductName;
            product.Result.PublishDate = DateTime.Parse( vm.PublishDate.ToShortDateString());
            product.Result.CategoryId = vm.CategoryId;
            product.Result.ModifiedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
             var result = await _repository.Update(product.Result);

            return result;
        }
    }
}
