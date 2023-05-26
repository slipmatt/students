using Students.Api.Data;
using Students.Api.Interfaces;

namespace Students.Api.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Student>> GetStudentByCourseId(int id)
        {
            return await _repo.GetStudentByCourseId(id);
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _repo.GetStudentById(id);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _repo.GetStudents();
        }

        public async Task UpdateStudent(Student model)
        {
            await _repo.UpdateStudent(model);
        }

        public async Task<int> InsertStudent(Student model)
        {
            return await _repo.InsertStudent(model);
        }
    }
}
