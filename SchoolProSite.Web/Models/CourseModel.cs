using SchoolProSite.DAL.Models;

namespace SchoolProSite.Web.Models
{
    public class CourseModel
    {
        public CourseModel()
        {

        }
        public CourseModel(CourseDaoModel courseDaoModel)
        {
            this.CourseId = courseDaoModel.CourseId;
            this.DepartmentId = courseDaoModel.DepartmentId;
            this.DepartmentName = courseDaoModel.DepartmentName;
            this.Credits = courseDaoModel.Credits;
            this.CreationDate = courseDaoModel.CreationDate;
            this.Title = courseDaoModel.Title;
        }
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public decimal Credits { get; set; }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
