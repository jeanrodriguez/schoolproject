using AutoMapper;
using Entities.DataContexts;
using Entities.Models;
using MVC5_AngularJS.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_AngularJS.Controllers
{
    public class StudentController : Controller
    {
        private readonly AplicationDbContext _context = new AplicationDbContext();
        private readonly GenericRepository<Student> _studentRepository;

        public StudentController()
        {
            _studentRepository = new GenericRepository<Student>(_context);
        }
        //
        // GET: /Student/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult StudentList()
        {
            try
            {
                 var students = _studentRepository.GetAll(); 
                return Json(new { Result = "OK", Records = students });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateStudent(StudentViewModel studentViewModel)
        {
            try
            {
                var student = new Student();
                Mapper.Map(studentViewModel, student);
                _studentRepository.Insert(student);
                var result = Mapper.Map(student, studentViewModel);
                return Json(new { Result = "OK", Record = result });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult UpdateStudent(StudentViewModel studentViewModel)
        {
            try
            {
                //mapper
                var student = new Student();
                Mapper.Map(studentViewModel, student);
                _studentRepository.Update(student);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteStudent(int id)
        {
            try
            {
                _studentRepository.Delete(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
	}
}