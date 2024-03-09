
namespace SchoolProSite.DAL.Models
{
    public class CourseDaoModel
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public decimal Credits { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
