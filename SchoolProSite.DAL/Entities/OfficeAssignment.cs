
using System.ComponentModel.DataAnnotations;

namespace SchoolProSite.DAL.Entities
{
    public partial class OfficeAssignment
    {

        [Key]
        public int InstructorId { get; set; }
        public string Location { get; set; }
        public byte[] Timestamp { get; set; }

        public virtual Person Instructor { get; set; }
    }
}