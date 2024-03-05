﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.DTOs;
using MediatR;

namespace CourseShop.Application.Course.Queries.GetAllCourses
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<GetCourseDto>>
    {
    }
}
