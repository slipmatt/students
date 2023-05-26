using Students.Api.Data;

namespace Students.Api.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCourses();
        Task<Course> GetCourseById(int id);
        Task<List<Course>> GetCourseByStudentId(int id);
        Task UpdateCourse(Course model);
        Task<int> InsertCourse(Course model);

    }
}
