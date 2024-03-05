using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;

namespace CourseShop.Application.Course.Commands.EditCourse
{
    public class EditCourseCommandValidator : AbstractValidator<EditCourseCommand>
    {
        public EditCourseCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Podaj nazwę")
                .MaximumLength(50).WithMessage("Nazwa powinna mieć maksymalnie 50 znaków");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Podaj opis")
                .MaximumLength(1000).WithMessage("Opis powinien mieć maksymalnie 1000 znaków");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Podaj cenę");

            RuleFor(x => x.IdDifficultyLevel)
                .NotEmpty().WithMessage("Podaj poziom trudności");

            RuleFor(x => x.IdCategory)
                .NotEmpty().WithMessage("Podaj kategorię");

        }
    }
}
