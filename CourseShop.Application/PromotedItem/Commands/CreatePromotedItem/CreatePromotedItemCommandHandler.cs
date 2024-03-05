using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.PromotedItem.Commands.CreatePromotedItem
{
    public class CreatePromotedItemCommandHandler : IRequestHandler<CreatePromotedItemCommand>
    {
        private readonly IPromotedItemRespository _promotedItemRespository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public CreatePromotedItemCommandHandler(IPromotedItemRespository promotedItemRespository, IMapper mapper, IUserContext context)
        {
            _promotedItemRespository = promotedItemRespository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Unit> Handle(CreatePromotedItemCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var promotedItem = _mapper.Map<Domain.Entities.CMS.PromotedItem>(request);
            await _promotedItemRespository.CreatePromotedItem(promotedItem);
            return Unit.Value;
        }
    }
}
