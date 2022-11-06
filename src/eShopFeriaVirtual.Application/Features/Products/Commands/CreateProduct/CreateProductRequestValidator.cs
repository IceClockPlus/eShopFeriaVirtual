using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithName("Nombre").WithMessage("{PropertyName} es requerido");
            RuleFor(r => r.Price)
                .GreaterThan(0).WithName("Precio").WithMessage("{PropertyName} debe ser superior a {ComparisonValue}");
                
        }
    }
}
