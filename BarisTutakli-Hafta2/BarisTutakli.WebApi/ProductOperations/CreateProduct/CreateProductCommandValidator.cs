using FluentValidation;

namespace BarisTutakli.WebApi.ProductOperations.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        /// <summary>
        /// Here, i control categoryId, productName and PublishingDate
        /// </summary>
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Model.CategoryId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.ProductName).MinimumLength(2).NotEmpty();
            RuleFor(command => command.Model.PublishDate.Year).GreaterThan(1800);
        }
    }
}
