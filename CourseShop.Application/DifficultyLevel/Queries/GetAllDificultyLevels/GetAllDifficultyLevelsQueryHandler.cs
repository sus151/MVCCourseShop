using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.DifficultyLevel.Queries.GetAllDificultyLevels
{
    internal class GetAllDifficultyLevelsQueryHandler : IRequestHandler<GetAllDifficultyLevelsQuery, IEnumerable<GetAllDifficultyLevelsQuery>>
    {
        private IDifficultyLevelRespository _difficultyLevelRespository;
        private readonly IMapper _mapper;

        public GetAllDifficultyLevelsQueryHandler(IDifficultyLevelRespository difficultyLevelRespository, IMapper mapper)
        {
            _difficultyLevelRespository = difficultyLevelRespository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllDifficultyLevelsQuery>> Handle(GetAllDifficultyLevelsQuery request, CancellationToken cancellationToken)
        {
            var difficultyLevels = await _difficultyLevelRespository.GetAllDifficultyLevels();
            return _mapper.Map<IEnumerable<GetAllDifficultyLevelsQuery>>(difficultyLevels);
        }
    }
}
