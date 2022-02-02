
using FluentValidation;

namespace BarisTutakli.WebApi.ProductOperations.CreateProduct
{
    public class ProductValidator:AbstractValidator<CreateProductModel>
    {
        public ProductValidator()
        {
            RuleFor(CreateProductModel => CreateProductModel.CategoryId).GreaterThan(0);
            RuleFor(CreateProductModel => CreateProductModel.ProductName).NotNull().NotEmpty().MinimumLength(2);
           
        }
    }
}
