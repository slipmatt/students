using Students.Api.Data;

namespace Students.Api.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudentByCourseId(int id);
        Task UpdateStudent(Student model);
        Task<int> InsertStudent(Student model);

    }
}
