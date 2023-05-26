using AutoMapper;
using Students.Api.Data;
using Students.Api.Models;

namespace Students.Api.AutomapperConfig
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course, CourseModel>().ReverseMap();
            CreateMap<Enrollment, EnrollmentModel>().ReverseMap();
            CreateMap<Student, StudentModel>().ReverseMap();
        }
    }
}
