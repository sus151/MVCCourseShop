using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Application.Category.Queries.GetAllMainCategories;
using CourseShop.Application.Category.Queries.GetSubcategoriesByMainCategoryId;
using CourseShop.Application.Course.Commands.CreateCourse;
using CourseShop.Application.Course.Commands.DeleteCourse;
using CourseShop.Application.Course.Commands.EditCourse;
using CourseShop.Application.Course.Queries.GetAllCourses;
using CourseShop.Application.Course.Queries.GetCourseById;
using CourseShop.Application.Course.Queries.GetCoursesByPhrase;
using CourseShop.Application.CourseSteps.Commands.CreateCourseSteps;
using CourseShop.Application.DifficultyLevel.Queries.GetAllDificultyLevels;
using CourseShop.Application.DTOs;
using CourseShop.Application.User.Commands.AddCourseToUserFavorites;
using CourseShop.Application.User.Commands.DeleteCourseFormUserFavorites;
using CourseShop.Application.User.Queries.CheckIfCourseIsAlreadyFavorite;
using CourseShop.Application.User.Queries.GetUserFavoritesCourses;
using CourseShop.Domain.Entities.Shop;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers
{
    public class CourseController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserContext _user;

        public CourseController(IMediator mediator, IMapper mapper, IUserContext user)
        {
            _mediator = mediator;
            _mapper = mapper;
            _user = user;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            var courses = await _mediator.Send(new GetAllCoursesQuery());
            return View(courses);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DetailsAdmin(int id)
        {
            var course = await _mediator.Send(new GetCourseByIdQuery { IdCourse = id });
            return View(course);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategorySelect = await _mediator.Send(new GetAllMainCategoriesQuery());
            ViewBag.DifficultyLevelsSelect = await _mediator.Send(new GetAllDifficultyLevelsQuery());

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCourseCommand command)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategorySelect = await _mediator.Send(new GetAllMainCategoriesQuery());
                ViewBag.DifficultyLevelsSelect = await _mediator.Send(new GetAllDifficultyLevelsQuery());
                return View(command);
            }
            if (command.File != null && command.File.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await command.File.CopyToAsync(ms);
                    command.CoursePicture = ms.ToArray();
                }
            }

            await _mediator.Send(command);
            return RedirectToAction("IndexAdmin", "Course");
        }



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var course = await _mediator.Send(new GetCourseByIdQuery { IdCourse = id });
            if (course == null)
            {
                return NotFound("Nie znaleziono kursu o podanym id");
            }

            try
            {
                var userId = _user.GetCurrentUser().Id;
                var courseId = await _mediator.Send(new GetUserFavoritesCoursesQuery{Id = userId});
                if (courseId.ToList().Contains(course.IdCourse))
                {
                    course.IsFavorite = true;
                }
            }
            catch
            {
    
            }
            
            return View(course);
        }


        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.MainCategorySelect = await _mediator.Send(new GetAllMainCategoriesQuery());
            ViewBag.DifficultyLevelsSelect = await _mediator.Send(new GetAllDifficultyLevelsQuery());
            ViewBag.SubCategorySelect = await _mediator.Send(new GetSubcategoriesByMainCategoryIdQuery { IdMainCategory = id });
            var course = await _mediator.Send(new GetCourseByIdQuery{IdCourse = id});
            if (course == null)
            {
                return NotFound();
            }
            EditCourseCommand model = _mapper.Map<EditCourseCommand>(course);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(EditCourseCommand command)
        {
            

            if (!ModelState.IsValid)
            {
                ViewBag.MainCategorySelect = await _mediator.Send(new GetAllMainCategoriesQuery());
                ViewBag.DifficultyLevelsSelect = await _mediator.Send(new GetAllDifficultyLevelsQuery());
                ViewBag.SubCategorySelect = await _mediator.Send(new GetSubcategoriesByMainCategoryIdQuery { IdMainCategory = command.IdMainCategory });
                return View(command);
            }

            if (command.File != null && command.File.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await command.File.CopyToAsync(ms);
                    command.CoursePicture = ms.ToArray();
                }
            }

            await _mediator.Send(command);
            return RedirectToAction("IndexAdmin");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {

            return RedirectToAction("DetailsAdmin", "Course", new { id = id });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(GetCourseByIdQuery query)
        {
            var course = _mapper.Map<DeleteCourseCommand>(query);
            await _mediator.Send(course);
            return RedirectToAction("IndexAdmin", "Course");
        }

        public async Task<ActionResult> GetCourseSuggestions(string input)
        {
            var courses = await _mediator.Send(new GetCoursesByPhraseQuery { Phrase = input, ResultsNumber = 4 });
            foreach (var course in courses)
            {
                course.PictureString =
                    course.CoursePicture != null ? System.Convert.ToBase64String(course.CoursePicture) : null;
            }
            return Json(courses);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddCourseSteps(int id)
        {
            ViewBag.IdCourse = id;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AddCourseSteps(CreateCourseStepsCommand command, int id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IdCourse = id; 
                return View();
            }
            await _mediator.Send(command);
            return RedirectToAction("DetailsAdmin", new {id = id});
        }

        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToFavorites(int idCourse)
        {
            var idUser = _user.GetCurrentUser().Id;
            var exists = await _mediator.Send(new CheckIfCourseIsAlreadyFavoriteQuery { Id = idUser, IdCourse = idCourse });
            if (!exists)
            {
                try
                {

                    await _mediator.Send(new AddCourseToUserFavoritesCommand { Id = idUser, IdCourse = idCourse });

                    return Json(new { success = true, action = "Added" });
                }
                catch (Exception ex)
                {

                    return Json(new { success = false, message = ex.Message });
                }
            }
            else
            {
                try
                {

                    await _mediator.Send(new DeleteCourseFromUserFavoritesCommand() {Id = idUser, IdCourse = idCourse});

                    return Json(new { success = true, action = "Deleted" });
                }
                catch (Exception ex)
                {

                    return Json(new { success = false, message = ex.Message });
                }

            }
        }




    }
}
