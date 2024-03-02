
using System.ComponentModel.DataAnnotations;

namespace SchoolProSite.DAL.Entities
{
    public partial class OnsiteCourse
    {

        [Key]
        public int CourseId { get; set; }
        public string? Location { get; set; }
        public string? Days { get; set; }
        public DateTime Time { get; set; }

        public virtual Course? Course { get; set; }
    }
}