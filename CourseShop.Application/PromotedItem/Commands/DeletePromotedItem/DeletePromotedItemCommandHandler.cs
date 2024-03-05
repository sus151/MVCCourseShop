using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.PromotedItem.Commands.DeletePromotedItem
{
    public class DeletePromotedItemCommandHandler : IRequestHandler<DeletePromotedItemCommand>
    {
        private readonly IPromotedItemRespository _promotedItemRespository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public DeletePromotedItemCommandHandler(IPromotedItemRespository promotedItemRespository, IMapper mapper, IUserContext context)
        {
            _mapper = mapper;
            _promotedItemRespository = promotedItemRespository;
            _context = context;
        }
        public async Task<Unit> Handle(DeletePromotedItemCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var promotedItem = _mapper.Map<Domain.Entities.CMS.PromotedItem>(request);
            await _promotedItemRespository.DeletePromotedItem(promotedItem);
            return Unit.Value;
        }
    }
}
