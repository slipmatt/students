using Students.Api.Data;
using Students.Api.Interfaces;

namespace Courses.Api.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;
        public CourseService(ICourseRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Course>> GetCourseByStudentId(int id)
        {
            return await _repo.GetCourseByStudentId(id);
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _repo.GetCourseById(id);
        }

        public async Task<List<Course>> GetCourses()
        {
            return await _repo.GetCourses();
        }

        public async Task UpdateCourse(Course model)
        {
            await _repo.UpdateCourse(model);
        }

        public async Task<int> InsertCourse(Course model)
        {
            return await _repo.InsertCourse(model);
        }
    }
}
