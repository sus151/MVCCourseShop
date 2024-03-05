using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.News.Queries.GetAllNews
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<GetAllNewsQuery>>
    {
        private readonly INewsRespository _newsRespository;
        private readonly IMapper _mapper;

        public GetAllNewsQueryHandler(INewsRespository newsRespository, IMapper mapper)
        {
            _newsRespository = newsRespository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllNewsQuery>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsRespository.GetAllNews();
            var newsDto = _mapper.Map<IEnumerable<GetAllNewsQuery>>(news);
            return newsDto;
        }
    }
}
