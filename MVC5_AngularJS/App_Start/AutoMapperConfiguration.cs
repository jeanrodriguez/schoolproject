using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entities.Models;
using MVC5_AngularJS.Models;

namespace MVC5_AngularJS.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappins()
        {
            Mapper.CreateMap<Course, CourseViewModel>().Bidirectional();
            Mapper.CreateMap<Student, StudentViewModel>().Bidirectional();
            Mapper.CreateMap<Instructor, InstructorViewModel>().Bidirectional();
            Mapper.CreateMap<Event, EventViewModel>().Bidirectional();
            Mapper.CreateMap<News, NewsViewModel>().Bidirectional();
        }

    }

    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TDestination, TSource> Bidirectional<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            return Mapper.CreateMap<TDestination, TSource>();
        }
    }
}