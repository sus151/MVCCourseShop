using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Category.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand>
    {
        private ICategoryRespository _categoryRespository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public CreateSubCategoryCommandHandler(ICategoryRespository categoryRespository, IMapper mapper, IUserContext context)
        {
            _categoryRespository = categoryRespository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Unit> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var category = _mapper.Map<Domain.Entities.Shop.Category>(request);
            await _categoryRespository.CreateCategory(category);

            return Unit.Value;
        }
    }
}
