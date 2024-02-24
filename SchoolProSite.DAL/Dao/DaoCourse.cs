

using Microsoft.EntityFrameworkCore;
using SchoolProSite.DAL.Context;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Interfaces;

namespace SchoolProSite.DAL.Dao
{
    public class DaoCourse : IDaoCourse
    {
        private readonly SchoolContext context;

        public DaoCourse(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExistsCourse(Func<Course, bool> filter)
        {
            return this.context.Courses.Any(filter);
        }

        public Course GetCourse(int Id)
        {
            return this.context.Courses.Find(Id);
        }

        public List<Course> GetCourses()
        {
            return this.context.Courses.ToList();
        }

        public List<Course> GetCourses(Func<Course, bool> filter)
        {
            return this.context.Courses.Where(filter).ToList();
        }

        public void RemoveCourse(Course Course)
        {
            throw new NotImplementedException();
        }

        public void SaveCourse(Course Course)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(Course Course)
        {
            throw new NotImplementedException();
        }
    }
}
