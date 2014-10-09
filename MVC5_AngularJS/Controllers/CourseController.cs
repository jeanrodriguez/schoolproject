using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Entities.DataContexts;
using Entities.Models;
using MVC5_AngularJS.Models;
using Repositories;

namespace MVC5_AngularJS.Controllers
{
    public class CourseController : Controller
    {
        private  readonly AplicationDbContext _dbContext = new AplicationDbContext();
        private readonly GenericRepository<Course> _courseRepository;

        public CourseController()
        {
            _courseRepository = new GenericRepository<Course>(_dbContext);
        }

        //
        // GET: /Course/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseDetails(int? idCourse)
        {
            return View();
        }

        public ActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CourseList()
        {
            try
            {
                //List<CourseViewModel> persons = _courseRepository.GetAll();
                var persons = _courseRepository.GetAll();
                //var courseViewModel = new List<CourseViewModel>();
                // Mapper.Map(persons, courseViewModel);
                return Json(new { Result = "OK", Records = persons });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateCourse(CourseViewModel courseViewModel)
        {
            try
            {
                var course = new Course();
                Mapper.Map(courseViewModel, course);
                _courseRepository.Insert(course);
                var result = Mapper.Map(course, courseViewModel);
                return Json(new { Result = "OK", Record = result });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult UpdateCourse(CourseViewModel courseViewModel)
        {
            try
            {
                //mapper
                var course =  new Course();
                Mapper.Map(courseViewModel, course);
                _courseRepository.Update(course);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteCourse(int id)
        {
            try
            {
                _courseRepository.Delete(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}