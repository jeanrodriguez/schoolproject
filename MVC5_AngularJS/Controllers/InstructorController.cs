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
    public class InstructorController : Controller
    {
        private AplicationDbContext _context = new AplicationDbContext();
        private GenericRepository<Instructor> _instructoRepository;

        public InstructorController()
        {
            _instructoRepository = new GenericRepository<Instructor>(_context);
        }

        //
        // GET: /Instructor/
        public ActionResult Index()
        {
            return View();
        }
         
        [HttpPost]
        public JsonResult InstructorList()
        {
            try
            {
                var instructors = _instructoRepository.GetAll();
                return Json(new { Result = "OK", Records = instructors });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateInstructor(InstructorViewModel instructorViewModel)
        {
            try
            {
                var instructor = new Instructor();

                Mapper.Map(instructorViewModel, instructor);

                _instructoRepository.Insert(instructor);

                //mapper de instructor hacia instructorViewModel
                //var result = Mapper.Map(instructor, instructorViewModel);

                 Mapper.Map(instructor, instructorViewModel);

                 return Json(new { Result = "OK", Record = instructorViewModel });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult UpdateInstructor(InstructorViewModel instructorViewModel)
        {
            try
            {
                //mapper
                var instructor = new Instructor();

                Mapper.Map(instructorViewModel, instructor);

                _instructoRepository.Update(instructor);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteInstructor(int id)
        {
            try
            {
                _instructoRepository.Delete(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
	}
}