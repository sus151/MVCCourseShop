using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.DTOs;
using FluentValidation;

namespace CourseShop.Application.Course.Commands.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Podaj nazwę")
                .MinimumLength(2).WithMessage("I co teraz młodziutki")
                .MaximumLength(50).WithMessage("Nazwa powinna mieć maksymalnie 50 znaków");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Podaj opiss")
                .MaximumLength(500).WithMessage("Opis powinien mieć maksymalnie 500 znaków");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Podaj cenę");

            RuleFor(x => x.IdDifficultyLevel)
                .NotEmpty().WithMessage("Podaj poziom trudności");

            RuleFor(x => x.IdCategory)
                .NotEmpty().WithMessage("Podaj kategorię");

            RuleFor(x => x.File)
                .NotEmpty().WithMessage("Podaj zdjęcie");
        }
    }
}
