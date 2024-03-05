using CourseShop.Application.News.Queries.GetAllNews;
using CourseShop.Application.PromotedItem.Queries.GetAllPromotedItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Controllers.Components
{
    public class PromotedItemsComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public PromotedItemsComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var promotedItems = await _mediator.Send(new GetAllPromotedItemsQuery());

            return View("PromotedItems", promotedItems);
        }
    }
}
