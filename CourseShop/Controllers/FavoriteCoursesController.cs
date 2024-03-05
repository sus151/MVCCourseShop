using CourseShop.Application.User.Queries.GetUserFavoriteCoursesWithInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers
{
    public class FavoriteCoursesController : Controller
    {
        private readonly IMediator _mediator;

        public FavoriteCoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var courses = await _mediator.Send(new GetUserFavoriteCoursesWithInfoQuery());
            return View(courses);
        }
    }
}
