using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CourseShop.Application.Category.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommandValidator : AbstractValidator<CreateSubCategoryCommand>
    {
        public CreateSubCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Kategoria musi mieć nazwę")
                .MaximumLength(100).WithMessage("Nazwa kategorii nie może przekraczać 100 znaków");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Kategoria musi mieć opis")
                .MaximumLength(1000).WithMessage("Opis kategorii nie może przekraczać 1000 znaków");

            RuleFor(c => c.IdMainCategory)
                .NotEmpty().WithMessage("Podkategoria musi mieć główną kategorię");
        }
    }
}
