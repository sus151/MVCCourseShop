using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.DifficultyLevel.Queries.GetAllDificultyLevels
{
    public class GetAllDifficultyLevelsQuery : IRequest<IEnumerable<GetAllDifficultyLevelsQuery>>
    {
        public int IdDifficultyLevel { get; set; }
        public string Difficulty { get; set; }
    }
}
