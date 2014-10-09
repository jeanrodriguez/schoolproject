using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Entities.DataContexts;
using Entities.Models;
using MVC5_AngularJS.Models;
using Repositories;
using Repositories.Services.Event;

namespace MVC5_AngularJS.Controllers
{
    public class EventController : Controller
    {
        #region fields
        private readonly AplicationDbContext _context = new AplicationDbContext();
        private readonly GenericRepository<Event> _eventRepository;
        #endregion

        #region Constructor
        public EventController()
        {
            _eventRepository = new GenericRepository<Event>(_context);
           
        }
        #endregion

        #region Methods
        public ActionResult HomePageEvent()
        {
            var eventViewModel = new List<EventViewModel>();
            var events = _eventRepository.GetRecentEvent(); 
             Mapper.Map(events, eventViewModel);
            return PartialView("_homePageEvent", eventViewModel);
        }
        //
        // GET: /Event/
        public ActionResult Index()
        {
            return View();
        }

        #region maintenance crud
        public ActionResult EventAdminIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EventList()
        {
            try
            {
                //List<CourseViewModel> persons = _courseRepository.GetAll();
                var events = _eventRepository.GetAll();
               
                return Json(new { Result = "OK", Records = events });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateEvent(EventViewModel eventViewModel)
        {
            try
            {
                var eventEntity = new Event();

                Mapper.Map(eventViewModel, eventEntity);

                _eventRepository.Insert(eventEntity);

                var result = Mapper.Map(eventEntity, eventViewModel);

                return Json(new { Result = "OK", Record = result });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult UpdateEvent(EventViewModel eventViewModel)
        {
            try
            {
                var eventEntity = new Event();
                //Mapper
                Mapper.Map(eventViewModel, eventEntity);

                _eventRepository.Update(eventEntity);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            try
            {
                _eventRepository.Delete(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        #endregion

#endregion
    }
}