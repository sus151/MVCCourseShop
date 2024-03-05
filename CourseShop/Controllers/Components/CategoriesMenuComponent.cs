using CourseShop.Application.Category.Queries.GetMainCategoriesWithSubCategoriesAndCourses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseShop.Controllers.Components
{
    public class CategoriesMenuComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public CategoriesMenuComponent(IMediator mediator)
        {
            _mediator = mediator;   
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _mediator.Send(new GetMainCategoriesWithSubCategoriesAndCoursesQuery());

            return View("CategoriesMenu", categories);
        }
    }
}
