using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CourseShop.Application.CourseSteps.Commands.CreateCourseSteps
{
    public class CreateCourseStepsCommandValidator : AbstractValidator<CreateCourseStepsCommand>
    {
        public CreateCourseStepsCommandValidator()
        {
            RuleFor(s => s.CourseSteps.Select(a=>a.Name))
                .NotEmpty().WithMessage("Podaj nazwę kroku");
            RuleFor(s => s.CourseSteps.Select(a => a.Description))
                .NotEmpty().WithMessage("Podaj opis kroku");

        }
    }
}
