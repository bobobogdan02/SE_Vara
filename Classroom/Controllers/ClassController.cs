using Classroom.Interfaces;
using Classroom.Models;
using Classroom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classroom.Interfaces;
using Classroom.Models;
using Classroom.ViewModels;

namespace Classroom.Controllers
{
    public class ClassController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClassRepository _classesRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IStreamRepository _streamRepository;

        public ClassController(AppDbContext appDbContext, IClassRepository classesRepository, IAssignmentRepository assignmentRepository, IStreamRepository streamRepository)
        {
            _appDbContext = appDbContext;
            _classesRepository = classesRepository;
            _assignmentRepository = assignmentRepository;
            _streamRepository = streamRepository;
        }
        public IActionResult ClassList()
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

        public IActionResult ClassCreate(Class @class)
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
            return View("~/Views/Class/ClassList.cshtml", classesVM);
        }

        public ViewResult Class(int courseId, Stream stream1)
        {
            IList<Stream> streams = new List<Stream>();
            var course = _classesRepository.Classes.FirstOrDefault(d => d.Id == courseId);
            if (course == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            foreach (Stream stream in _appDbContext.StreamMessages)
            {
                streams.Add(stream);
            }

            var ClassStreamVM = new ClassStreamViewModel
            {
                Class = course,
                stream = stream1,
                streams = streams
            };

            return View(ClassStreamVM);
        }
        public IActionResult CreateHomeworkView(int courseId, AssignmentViewModel assignment)
        {
            var course = _classesRepository.Classes.FirstOrDefault(d => d.Id == courseId);
            assignment.course = course;
            return View(assignment);
        }
        public IActionResult CreateHomework(int courseId, Assignment assignment)
        {
            var course = _classesRepository.Classes.FirstOrDefault(d => d.Id == courseId);
            if (course == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            var AssignmentModel = new AssignmentViewModel()
            {
                assignment = assignment,
                course = course

            };
            AssignmentModel.assignment.course = course;
            _assignmentRepository.AddAssignment(AssignmentModel.assignment);

            return View("~/Views/Classes/Class.cshtml", AssignmentModel.course);
        }
        public IActionResult StatusHomeworks(int courseId)
        {
            var course = _classesRepository.Classes.FirstOrDefault(d => d.Id == courseId);
            IList<Assignment> assignments = new List<Assignment>();
            foreach (Assignment assignment in _appDbContext.Assignments)
            {
                if (course == assignment.course)
                {
                    assignments.Add(assignment);


                }
            }

            var AssignmentStatusViewModel = new AssignmentStatusViewModel()
            {
                assignments = assignments
            };

            return View(AssignmentStatusViewModel);
        }

        public IActionResult CreateMessage(int courseId, Stream stream)
        {
            IList<Stream> streams = new List<Stream>();
            var course = _classesRepository.Classes.FirstOrDefault(d => d.Id == courseId);
            if (course == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            var StreamModel = new StreamViewModel
            {
                stream = stream,
                course = course
            };
            StreamModel.stream.Class = course;
            StreamModel.stream.dateTime = DateTime.Now;
            _streamRepository.AddMessage(StreamModel.stream);

            foreach (Stream stream1 in _appDbContext.StreamMessages)
            {
                streams.Add(stream1);
            }

            var ClassStreamVM = new ClassStreamViewModel
            {
                Class = course,
                stream = stream,
                streams = streams
            };
            return View("~/Views/Classes/Class.cshtml", ClassStreamVM);
        }
    }
}
