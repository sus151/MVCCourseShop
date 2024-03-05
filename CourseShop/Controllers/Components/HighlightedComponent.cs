using CourseShop.Application.HighlightedCategory.Queries.GetAllHighlightedCategoriesWithCourses;
using CourseShop.Application.HighlitedCategory.Queries.GetAllHighlitedCategories;
using CourseShop.Application.News.Queries.GetAllNews;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers.Components
{
    public class HighlightedComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public HighlightedComponent(IMediator mediator)
        {
            _mediator = mediator;
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var highlighted = await _mediator.Send(new GetAllHighlightedCategoriesWithCoursesQuery()); 


            return View("Highlighted", highlighted);
        }
    }
}
