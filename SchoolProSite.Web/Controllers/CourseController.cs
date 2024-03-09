using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProSite.DAL.Interfaces;
using SchoolProSite.Web.Models;

namespace SchoolProSite.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly IDaoCourse daoCourse;
        private readonly IDaoDepartment daoDepartment;

        public CourseController(IDaoCourse daoCourse, IDaoDepartment daoDepartment)
        {
            this.daoCourse = daoCourse;
            this.daoDepartment = daoDepartment;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var courses = this.daoCourse.GetCourses().Select(cd => new CourseModel(cd));

            return View(courses);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var course = this.daoCourse.GetCourse(id);

            CourseModel courseModel = new CourseModel(course);

            return View(courseModel);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {




            var deparmentList = this.daoDepartment.GetDepartments()
                                                .Select(cd => new DepartmentList()
                                                {
                                                    DepartmentId = cd.DepartmentId,
                                                    Name = cd.Name
                                                })
                                                .ToList();

            ViewData["Deparments"] = new SelectList(deparmentList, "DepartmentId", "Name");

            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseModel courseModel)
        {
            try
            {
                this.daoCourse.SaveCourse(new DAL.Entities.Course()
                {
                    CreationDate = DateTime.Now,
                    CreationUser = 1,
                    Title = courseModel.Title,
                    Credits = courseModel.Credits,
                    DepartmentId = courseModel.DepartmentId 

                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = this.daoCourse.GetCourse(id);

            CourseModel courseModel = new CourseModel(course);


            var deparmentList = this.daoDepartment.GetDepartments()
                                                  .Select(cd => new DepartmentList()
                                                  {
                                                      DepartmentId = cd.DepartmentId,
                                                      Name = cd.Name
                                                  })
                                                  .ToList();

            ViewData["Deparments"] = new SelectList(deparmentList, "DepartmentId", "Name");

            return View(courseModel);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseModel courseModel)
        {
            try
            {
                this.daoCourse.UpdateCourse(new DAL.Entities.Course()
                {
                    CourseId = courseModel.CourseId,
                    ModifyDate = DateTime.Now,
                    DepartmentId = courseModel.DepartmentId,
                    Credits = courseModel.Credits,
                    UserMod = 1,
                    Title = courseModel.Title
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
