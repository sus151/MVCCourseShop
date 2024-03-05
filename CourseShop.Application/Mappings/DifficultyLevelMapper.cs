using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.DifficultyLevel.Queries.GetAllDificultyLevels;
using CourseShop.Application.DTOs;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Application.Mappings
{
    public class DifficultyLevelMapper : Profile
    {
        public DifficultyLevelMapper()
        {
            CreateMap<Domain.Entities.Shop.DifficultyLevel, GetAllDifficultyLevelsQuery>();
        }
    }
}
