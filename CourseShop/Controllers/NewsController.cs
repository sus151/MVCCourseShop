using AutoMapper;
using CourseShop.Application.Category.Queries.GetAllCategoriesForSelect;
using CourseShop.Application.Category.Queries.GetAllMainCategories;
using CourseShop.Application.Course.Commands.CreateCourse;
using CourseShop.Application.Course.Queries.GetCoursesForSelect;
using CourseShop.Application.News.Commands.CreateNews;
using CourseShop.Application.News.Commands.DeleteNews;
using CourseShop.Application.News.Queries.GetAllNews;
using CourseShop.Application.News.Queries.GetNewsById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers
{
    public class NewsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public NewsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            var news = await _mediator.Send(new GetAllNewsQuery());
            return View(news);
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
        public async Task<IActionResult> Create(CreateNewsCommand command)
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
            if (command.PhotoSmallFile != null && command.PhotoSmallFile.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await command.PhotoSmallFile.CopyToAsync(ms);
                    command.PhotoSmall = ms.ToArray();
                }
            }

            await _mediator.Send(command);

            return RedirectToAction("IndexAdmin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Details(int id)
        {
            var news = await _mediator.Send(new GetNewsByIdQuery { IdNews = id });
            if (news==null)
            {
                return NotFound("Nie znaleziono kursu o podanym id");
            }
            return View(news);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Details", "News", new { id = id });
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(GetNewsByIdQuery query)
        {
            var news = _mapper.Map<DeleteNewsCommand>(query);
            await _mediator.Send(news);
            return RedirectToAction("IndexAdmin");
        }

    }
}
