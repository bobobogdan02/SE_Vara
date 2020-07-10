using Classroom.Interfaces;
using Classroom.Models;
using Classroom.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Classroom.Controllers
{
    public class ClassController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClassRepository _classesRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IStreamRepository _streamRepository;
        private readonly IUserRepository userRepository;
        private readonly UserManager<IdentityUser> userManager;

        public ClassController(IUserRepository userRepository,UserManager<IdentityUser> userManager,AppDbContext appDbContext, IClassRepository classesRepository, IAssignmentRepository assignmentRepository, IStreamRepository streamRepository)
        {
            _appDbContext = appDbContext;
            _classesRepository = classesRepository;
            _assignmentRepository = assignmentRepository;
            _streamRepository = streamRepository;
            this.userManager = userManager;
            this.userRepository = userRepository;
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
        public IActionResult RegisterToClass(int courseId)
        {
            var registerToClassViewModel = new RegisterToClassViewModel()
            {
                CourseId = courseId
            };
            return View(registerToClassViewModel);
        }
        [HttpPost]
        public IActionResult RegisterToClass(RegisterToClassViewModel registerToClassViewModel)
        {
            var classDb = _classesRepository.GetById(registerToClassViewModel.CourseId);
            var userId = userManager.GetUserId(User);
            var userDb = userRepository.GetByUserId(userId);
            if (classDb.SecurityCode == registerToClassViewModel.SecurityCode)
            {
                var userClass = new UserClass
                {
                    User = userDb,
                    Class = classDb
                };
                userRepository.AddUserToClass(userClass);
                return RedirectToAction("Class", new { courseId = registerToClassViewModel.CourseId });
            }
            return View(registerToClassViewModel);
        }
        public IActionResult Class(int courseId, Stream stream1)
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

            var userId = userManager.GetUserId(User);
            if(userRepository.UserBelongsToClassroom(courseId, userId) == false)
            {
                return RedirectToAction("RegisterToClass", new { courseId = courseId });
            }
            var ClassStreamVM = new ClassStreamViewModel
            {
                Class = course,
                stream = stream1,
                streams = streams
            };

            return View(ClassStreamVM);
        }
        public IActionResult CreateAssignment(int courseId, AssignmentViewModel assignmentVM)
        {
            var course = _classesRepository.Classes.FirstOrDefault(d => d.Id == courseId);
            assignmentVM.course = course;
            return View(assignmentVM);
        }
        public IActionResult CreateHomework(int courseId, Assignment assignment)
        {
            IList<Stream> streams = new List<Stream>();
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

            foreach (Stream stream in _appDbContext.StreamMessages)
            {
                streams.Add(stream);
            }

            var ClassStreamVM = new ClassStreamViewModel
            {
                Class = course,
                streams = streams
            };
            return View("~/Views/Class/Class.cshtml", ClassStreamVM);
        }
        public IActionResult StatusAssignment(int courseId)
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
            return RedirectToAction("Class", new { courseId = courseId });
        }

        public IActionResult AssignmentView(int assignmentId)
        {
            Assignment assignmentDb = _appDbContext.Assignments.Where(a => a.id == assignmentId).SingleOrDefault();
            return View(assignmentDb);
        }
    }
}
