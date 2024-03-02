
using System.ComponentModel.DataAnnotations;

namespace SchoolProSite.DAL.Entities
{
    public partial class OnlineCourse
    {
        [Key]
        public int CourseId { get; set; }
        public string Url { get; set; }

        public virtual Course Course { get; set; }
    }
}