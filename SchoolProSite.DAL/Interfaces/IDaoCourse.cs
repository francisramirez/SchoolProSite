using SchoolProSite.DAL.Entities;

namespace SchoolProSite.DAL.Interfaces
{
    public interface IDaoCourse
    {
        void SaveCourse(Course Course);
        void UpdateCourse(Course Course);
        void RemoveCourse(Course Course);
        Course GetCourse(int Id);
        List<Course> GetCourses();
        List<Course> GetCourses(Func<Course, bool> filter);
        bool ExistsCourse(Func<Course, bool> filter);
    }
}
