using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand>
    {
        private readonly INewsRespository _newsRespository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public DeleteNewsCommandHandler(INewsRespository newsRespository, IMapper mapper, IUserContext context)
        {
            _newsRespository = newsRespository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var news = _mapper.Map<Domain.Entities.CMS.News>(request);
            await _newsRespository.DeleteNews(news);
            return Unit.Value;
        }
    }
}
