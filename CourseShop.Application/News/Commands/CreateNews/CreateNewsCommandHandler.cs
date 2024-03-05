using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.News.Commands.CreateNews
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand>
    {
        private readonly INewsRespository _newsRespository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public CreateNewsCommandHandler(INewsRespository newsRespository, IMapper mapper, IUserContext context)
        {
            _newsRespository = newsRespository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Unit> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var news = _mapper.Map<Domain.Entities.CMS.News>(request);
            await _newsRespository.CreateNews(news);
            return Unit.Value;
        }
    }
}
