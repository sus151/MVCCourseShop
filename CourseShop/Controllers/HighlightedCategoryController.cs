using AutoMapper;
using CourseShop.Application.Category.Queries.GetAllCategoriesForSelect;
using CourseShop.Application.Category.Queries.GetAllMainCategories;
using CourseShop.Application.Course.Queries.GetCoursesForSelect;
using CourseShop.Application.HighlightedCategory.Commands.CreateHighlightedCategory;
using CourseShop.Application.HighlightedCategory.Commands.DeleteHighlightedCategory;
using CourseShop.Application.HighlightedCategory.Queries.GetHighlightedCategoryById;
using CourseShop.Application.HighlitedCategory.Queries.GetAllHighlitedCategories;
using CourseShop.Application.News.Commands.CreateNews;
using CourseShop.Application.News.Commands.DeleteNews;
using CourseShop.Application.News.Queries.GetNewsById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers
{
    public class HighlightedCategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HighlightedCategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            var highlighted = await _mediator.Send(new GetAllHighlightedCategoriesQuery());
            return View(highlighted);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _mediator.Send(new GetAllSubCategoriesQuery());
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateHighlightedCategoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                
                ViewBag.Categories = await _mediator.Send(new GetAllSubCategoriesQuery());
                
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction("IndexAdmin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Details(int id)
        {
            var highlighted = await _mediator.Send(new GetHighlightedCategoryByIdQuery { IdHighlightedCategory = id });
            if (highlighted == null)
            {
                return NotFound("Nie znaleziono wyróżnionej kategorii o podanym id");
            }
            return View(highlighted);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Details", "HighlightedCategory", new { id = id });
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(GetHighlightedCategoryByIdQuery query)
        {
            var highlighted = _mapper.Map<DeleteHighlightedCategoryCommand>(query);
            await _mediator.Send(highlighted);
            return RedirectToAction("IndexAdmin");
        }
    }
}
