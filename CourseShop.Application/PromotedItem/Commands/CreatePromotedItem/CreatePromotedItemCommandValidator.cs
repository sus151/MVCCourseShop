using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CourseShop.Application.PromotedItem.Commands.CreatePromotedItem
{
    public class CreatePromotedItemCommandValidator : AbstractValidator<CreatePromotedItemCommand>
    {
        public CreatePromotedItemCommandValidator()
        {
            RuleFor(x => x.PhotoFile)
                .NotEmpty().WithMessage("Dodaj zdjęcie");


            RuleFor(x => x)
                .Custom((command, context) => {
                    var idsSet = new List<int?> { command.IdCourse, command.IdCategory, command.IdMainCategory }
                        .Count(id => id.HasValue);

                    if (idsSet != 1)
                    {
                        context.AddFailure("IdCourse", "Tylko jedno z pól 'IdCourse', 'IdCategory' lub 'IdMainCategory' musi mieć wartość.");
                        context.AddFailure("IdCategory", "Tylko jedno z pól 'IdCourse', 'IdCategory' lub 'IdMainCategory' musi mieć wartość.");
                        context.AddFailure("IdMainCategory", "Tylko jedno z pól 'IdCourse', 'IdCategory' lub 'IdMainCategory' musi mieć wartość.");
                    }
                });
        }
    }
}
