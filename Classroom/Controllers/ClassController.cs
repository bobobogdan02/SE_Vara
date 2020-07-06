using Classroom.Interfaces;
using Classroom.Models;
using Classroom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Controllers
{
    public class ClassController : Controller
    {
        private readonly DatabaseContext _appDbContext;
        private readonly IClassRepository _classesRepository;
        public ClassController(DatabaseContext appDbContext, IClassRepository classesRepository)
        {
            _appDbContext = appDbContext;
            _classesRepository = classesRepository;
        }
        public IActionResult ListOfClasses()
        {
            IList<Class> classes = new List<Class>();
            foreach (Class @class in _appDbContext.Classes)
            {
                classes.Add(@class);
            }

            var classesVM = new ClassListViewModel()
            {
                ClassCourses = classes
            };
            return View(classesVM);
        }

        public IActionResult NewClass(Class @class)
        {

            return View(@class);
        }

        public IActionResult NewClassCreator(Class @class)
        {
            _classesRepository.AddClass(@class);
            IList<Class> classes = new List<Class>();
            foreach (Class classCourse1 in _appDbContext.Classes)
            {
                classes.Add(classCourse1);
            }

            var classesVM = new ClassListViewModel()
            {
                ClassCourses = classes
            };
            return View("~/Views/Classes/ListOfClasses.cshtml", classesVM);
        }

        public ViewResult Class(int courseId)
        {
            var course = _classesRepository.Classes.FirstOrDefault(d => d.Id == courseId);
            if (course == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }
            return View(course);
        }
    }
}
