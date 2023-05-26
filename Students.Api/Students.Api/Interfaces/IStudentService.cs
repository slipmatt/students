using Students.Api.Data;
using Students.Api.Models;

namespace Students.Api.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudentByCourseId(int id);
        Task UpdateStudent(Student modelModel);
        Task<int> InsertStudent(Student model);
    }
}
