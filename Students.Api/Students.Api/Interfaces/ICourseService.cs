using Students.Api.Data;
using Students.Api.Models;

namespace Students.Api.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetCourses();
        Task<Course> GetCourseById(int id);
        Task<List<Course>> GetCourseByStudentId(int id);
        Task UpdateCourse(Course modelModel);
        Task<int> InsertCourse(Course model);
    }
}
