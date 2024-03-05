using CourseShop.Application.ApplicationUser;
using CourseShop.Application.Category.Commands.CreateMainCategory;
using CourseShop.Application.Category.Commands.CreateSubCategory;
using CourseShop.Application.Category.Commands.DeleteCategory;
using CourseShop.Application.Category.Queries.GetAllMainCategories;
using CourseShop.Application.Category.Queries.GetMainCategoriesWithSubCategoriesAndCourses;
using CourseShop.Application.Category.Queries.GetMainCategoryWithSubcategoriesAndCoursesById;
using CourseShop.Application.Category.Queries.GetSubcategoriesByMainCategoryId;
using CourseShop.Application.Category.Queries.GetSubCategoryWithCoursesById;
using CourseShop.Application.Course.Commands.DeleteCourse;
using CourseShop.Application.Course.Queries.GetCourseById;
using CourseShop.Application.DTOs;
using CourseShop.Application.User.Queries.GetUserFavoritesCourses;
using CourseShop.Domain.Entities.Shop;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUserContext _user;

        public CategoryController(IMediator mediator, IUserContext user)
        {
            _mediator = mediator;
            _user = user;
        }

        [Authorize(Roles="Admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            var categories = await _mediator.Send(new GetMainCategoriesWithSubCategoriesAndCoursesQuery());
            return View(categories);

        }

       

        public async Task<IActionResult> SubCatDetails(int id)
        {
            var category = await _mediator.Send(new GetSubCategoryWithCoursesByIdQuery { IdCategory = id });
            if (category == null)
            {
                return NotFound("Nie znaleziono podkategorii o podanym id");
            }


            try
            {
                var idUser = _user.GetCurrentUser().Id;
                ViewBag.Fav = await _mediator.Send(new GetUserFavoritesCoursesQuery { Id = idUser });
            }
            catch
            {
               
            }
                


            return View(category);


        }

        public async Task<IActionResult> MainCatDetails(int id)
        {
            var category = await _mediator.Send(new GetMainCategoryWithSubcategoriesAndCoursesByIdQuery(){IdCategory = id});
            if (category == null)
            {
                return BadRequest("Nie ma głównej kategorii o podanym id");
            }
            try
            {
                var idUser = _user.GetCurrentUser().Id;
                ViewBag.Fav = await _mediator.Send(new GetUserFavoritesCoursesQuery { Id = idUser });
            }
            catch
            {

            }
            return View(category);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult CreateMainCategory()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMainCategory(CreateMainCategoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction("IndexAdmin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSubCategory()
        {
            ViewBag.MainCategories = await _mediator.Send(new GetAllMainCategoriesQuery());
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSubCategory(CreateSubCategoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MainCategories = await _mediator.Send(new GetAllMainCategoriesQuery());
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction("IndexAdmin");
        }


        
        public async Task<IActionResult> GetSubcategoriesByMainCategoryId(int id)
        {
            var categories = await _mediator.Send(new GetSubcategoriesByMainCategoryIdQuery { IdMainCategory = id });
            return Json(categories);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { IdCategory = id });
            return RedirectToAction("IndexAdmin", "Category");
        }
    }

   
   


}
