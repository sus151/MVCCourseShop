using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.CourseSteps.Commands.CreateCourseSteps;
using CourseShop.Application.CourseSteps.Commands.DeleteCourseStep;
using CourseShop.Application.DTOs;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Application.Mappings
{
    public class CourseStepMapper : Profile
    {
        public CourseStepMapper()
        {
            CreateMap<CourseStepDto, CourseStep>();
            CreateMap<CourseStepDto, CreateCourseStepsCommand>();
            CreateMap<DeleteCourseStepCommand, CourseStep>();
        }
    }
}
