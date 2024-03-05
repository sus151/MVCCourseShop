using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.News.Queries.GetNewsById
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, GetNewsByIdQuery>
    {
        private readonly INewsRespository _newsRespository;
        private readonly IMapper _mapper;

        public GetNewsByIdQueryHandler(INewsRespository newsRespository, IMapper mapper)
        {
            _newsRespository = newsRespository;
            _mapper = mapper;
        }
        public async Task<GetNewsByIdQuery> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsRespository.GetNewsById(request.IdNews);
            var newsDto = _mapper.Map<GetNewsByIdQuery>(news);
            return newsDto;
        }
    }
}
