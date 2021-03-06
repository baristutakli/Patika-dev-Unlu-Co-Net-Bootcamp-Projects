using FluentValidation;

namespace BarisTutakli.WebApi.ProductOperations.UpdateProduct
{
    public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.ProductId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.CategoryId).GreaterThan(0).NotNull();
            RuleFor(command => command.Model.ProductName).MinimumLength(3).NotEmpty();
        }
    }
}
