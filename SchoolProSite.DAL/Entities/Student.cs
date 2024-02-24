
using SchoolProSite.DAL.Core;

namespace SchoolProSite.DAL.Entities
{
    public partial class Student : PersonBase
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        
    }
}