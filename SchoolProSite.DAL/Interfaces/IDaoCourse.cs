using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Models;

namespace SchoolProSite.DAL.Interfaces
{
    public interface IDaoCourse
    {
        void SaveCourse(Course Course);
        void UpdateCourse(Course Course);
        void RemoveCourse(Course Course);
        CourseDaoModel GetCourse(int Id);
        List<CourseDaoModel> GetCourses();
        List<CourseDaoModel> GetCourses(Func<Course, bool> filter);
        bool ExistsCourse(Func<Course, bool> filter);

         
    }
}
