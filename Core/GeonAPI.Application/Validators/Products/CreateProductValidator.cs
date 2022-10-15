using System;
using FluentValidation;
using GeonAPI.Application.ViewModels.Products;

namespace GeonAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<WM_CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Title).
                  NotEmpty().
                  NotNull().WithMessage("Boş geçilemez.").
                  MinimumLength(3).
                  MaximumLength(200).WithMessage("Lütfen geçerli karakter aralığında giriş yapınız.");
            RuleFor(p => p.Description).NotNull().NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}

