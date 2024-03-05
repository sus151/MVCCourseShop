using CourseShop.Application.CourseSteps.Commands.DeleteCourseStep;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers
{
    public class CourseStepController : Controller
    {
        private readonly IMediator _mediator;

        public CourseStepController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCourseStepCommand{IdCourseStep = id});
            if (Request.Headers["Referer"].ToString() != null)
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                return RedirectToAction("IndexAdmin", "Course");
            }
        }
    }
}
