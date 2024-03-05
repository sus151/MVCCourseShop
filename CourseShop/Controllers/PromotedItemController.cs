using AutoMapper;
using CourseShop.Application.Category.Queries.GetAllCategoriesForSelect;
using CourseShop.Application.Category.Queries.GetAllMainCategories;
using CourseShop.Application.Course.Queries.GetCoursesForSelect;
using CourseShop.Application.News.Commands.CreateNews;
using CourseShop.Application.News.Commands.DeleteNews;
using CourseShop.Application.News.Queries.GetAllNews;
using CourseShop.Application.News.Queries.GetNewsById;
using CourseShop.Application.PromotedItem.Commands.CreatePromotedItem;
using CourseShop.Application.PromotedItem.Commands.DeletePromotedItem;
using CourseShop.Application.PromotedItem.Queries.GetAllPromotedItems;
using CourseShop.Application.PromotedItem.Queries.GetPromotedItemById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers
{
    public class PromotedItemController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PromotedItemController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            var promotedItems = await _mediator.Send(new GetAllPromotedItemsQuery());
            return View(promotedItems);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Courses = await _mediator.Send(new GetCoursesForSelectQuery());
            ViewBag.SubCategories = await _mediator.Send(new GetAllSubCategoriesQuery());
            ViewBag.MainCategories = await _mediator.Send(new GetAllMainCategoriesQuery());
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreatePromotedItemCommand command)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Courses = await _mediator.Send(new GetCoursesForSelectQuery());
                ViewBag.SubCategories = await _mediator.Send(new GetAllSubCategoriesQuery());
                ViewBag.MainCategories = await _mediator.Send(new GetAllMainCategoriesQuery());
                return View(command);
            }
            if (command.PhotoFile != null && command.PhotoFile.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await command.PhotoFile.CopyToAsync(ms);
                    command.Photo = ms.ToArray();
                }
            }

            await _mediator.Send(command);

            return RedirectToAction("IndexAdmin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Details(int id)
        {
            var promotedItem = await _mediator.Send(new GetPromotedItemByIdQuery() { IdPromotedItem = id });
            if (promotedItem == null)
            {
                return NotFound("Nie znaleziono promowanego itemu o podanym id");
            }
            return View(promotedItem);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Details", "PromotedItem", new { id = id });
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(GetPromotedItemByIdQuery query)
        {
            var promotedItem = _mapper.Map<DeletePromotedItemCommand>(query);
            await _mediator.Send(promotedItem);
            return RedirectToAction("IndexAdmin");
        }
    }
}
