using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CourseShop.Application.HighlightedCategory.Commands.CreateHighlightedCategory
{
    public class CreateHighlightedCategoryCommandValidator : AbstractValidator<CreateHighlightedCategoryCommand>
    {

        public CreateHighlightedCategoryCommandValidator()
        {
            RuleFor(h => h.IdCategory)
                .NotEmpty().WithMessage("Proszę wybrać kategorię");
        }
    }
}
