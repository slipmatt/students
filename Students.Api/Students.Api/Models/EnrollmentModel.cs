using Students.Api.Enums;

namespace Students.Api.Models
{
    public class EnrollmentModel
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
    }
}
