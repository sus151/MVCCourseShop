using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRespository _respository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public DeleteCategoryCommandHandler(ICategoryRespository respository, IMapper mapper, IUserContext context)
        {
            _mapper = mapper;
            _respository = respository;
            _context = context;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            await _respository.DeleteCategory(request.IdCategory);
            return Unit.Value;
        }
    }
}
