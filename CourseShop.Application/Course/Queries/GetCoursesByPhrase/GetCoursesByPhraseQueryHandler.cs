using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Course.Queries.GetCoursesByPhrase
{
    public class GetCoursesByPhraseQueryHandler : IRequestHandler<GetCoursesByPhraseQuery, IEnumerable<GetCoursesByPhraseQuery>>
    {
        private readonly ICourseRespository _respository;
        private readonly IMapper _mapper;

        public GetCoursesByPhraseQueryHandler(ICourseRespository respository,IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<GetCoursesByPhraseQuery>> Handle(GetCoursesByPhraseQuery request, CancellationToken cancellationToken)
        {
            var courses = await _respository.GetCoursesByPhrase(request.Phrase, request.ResultsNumber);
            var coursesDto = _mapper.Map<IEnumerable<GetCoursesByPhraseQuery>>(courses);
            return coursesDto;
        }
    }
}
