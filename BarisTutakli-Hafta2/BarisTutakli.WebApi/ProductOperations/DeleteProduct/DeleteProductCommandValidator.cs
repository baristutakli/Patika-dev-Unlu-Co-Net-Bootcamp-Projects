using FluentValidation;

namespace BarisTutakli.WebApi.ProductOperations.DeleteProduct
{
    public class DeleteProductCommandValidator: AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.ProductId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}
