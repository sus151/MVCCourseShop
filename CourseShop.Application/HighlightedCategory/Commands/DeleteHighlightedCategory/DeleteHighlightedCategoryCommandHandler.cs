using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.HighlightedCategory.Commands.DeleteHighlightedCategory
{
    public class DeleteHighlightedCategoryCommandHandler : IRequestHandler<DeleteHighlightedCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IHighlightedCategoryRespository _respository;
        private readonly IUserContext _context;

        public DeleteHighlightedCategoryCommandHandler(IHighlightedCategoryRespository respository, IMapper mapper, IUserContext context)
        {
            _respository = respository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Unit> Handle(DeleteHighlightedCategoryCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var highlighted = _mapper.Map<Domain.Entities.CMS.HighlightedCategory>(request);
            await _respository.DeleteHighlightedCategory(highlighted);
            return Unit.Value;
        }
    }
}
