using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalJurayEop.Application.Interfaces.Repositories;

namespace UniversalJurayEop.Application.Features.Foods.Commands.Create
{
    public class CreateFoodCommandValidation
    {
    }
    public class CreateFoodCommandValidator : AbstractValidator<CreateFoodCommand>
    {
        private readonly IFoodRepositoryAsync FoodRepository;

        public CreateFoodCommandValidator(IFoodRepositoryAsync FoodRepository)
        {
            this.FoodRepository = FoodRepository;

            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.")
                .MustAsync(IsUniqueBarcode).WithMessage("{Name} already exists.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

        }

        private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        {
            return await FoodRepository.IsUniqueBarcodeAsync(barcode);
        }
    }

}
