using CourseShop.Application.Category.Queries.GetMainCategoriesWithSubCategoriesAndCourses;
using CourseShop.Application.News.Queries.GetAllNews;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers.Components
{
    public class NewsCarouselComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public NewsCarouselComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var news = await _mediator.Send(new GetAllNewsQuery());

            return View("NewsCarousel", news);
        }
    }
}
