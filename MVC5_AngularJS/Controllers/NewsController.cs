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
using Repositories.Services;

namespace MVC5_AngularJS.Controllers
{
    public class NewsController : Controller
    {
        #region fields
        private readonly AplicationDbContext _context = new AplicationDbContext();
        private readonly GenericRepository<News> _newsRepository;
        #endregion

        #region Constructor
        public NewsController()
        {
            _newsRepository = new GenericRepository<News>(_context);
        }
        #endregion

        #region Methods
        //
        // GET: /News/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewsDetails(int? idNews)
        {
            return View();
        }

        public ActionResult NewsDetailsVideo(int? idNews)
        {
            return View();
        }

        public ActionResult HomePageNews()
        {
            var mostRecentNews = _newsRepository.GetRecentNewses();

            var newsViewModel = new List<NewsViewModel>();

            Mapper.Map(mostRecentNews, newsViewModel);

            return PartialView(newsViewModel);
        }

        #region maintenance crud
        [HttpPost]
        public JsonResult EventList()
        {
            try
            {
                //List<CourseViewModel> persons = _courseRepository.GetAll();
                var events = _newsRepository.GetAll();

                return Json(new { Result = "OK", Records = events });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateEvent(NewsViewModel newsViewModel)
        {
            try
            {
                var newsEntity = new News();

                Mapper.Map(newsViewModel, newsEntity);

                _newsRepository.Insert(newsEntity);

                var result = Mapper.Map(newsEntity, newsViewModel);

                return Json(new { Result = "OK", Record = result });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult UpdateEvent(NewsViewModel newsViewModel)
        {
            try
            {
                var newsEntity = new News();
                //Mapper
                Mapper.Map(newsViewModel, newsEntity);

                _newsRepository.Update(newsEntity);

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
                _newsRepository.Delete(id);
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