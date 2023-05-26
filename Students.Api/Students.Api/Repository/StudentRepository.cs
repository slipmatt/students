using Microsoft.EntityFrameworkCore;
using Students.Api.Data;
using Students.Api.Interfaces;

namespace Students.Api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _dbContext;

        public StudentRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> GetStudentByCourseId(int id)
        {
            return await _dbContext.Students.Where(i=>i.Enrollments.Any(e=>e.CourseID == id)).ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _dbContext.Students.Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task UpdateStudent(Student model)
        {
            //Automap this
            var entity = _dbContext.Students.Find(model.ID);
            entity.FirstMidName = model.FirstMidName;
            entity.LastName = model.LastName;
            _dbContext.Students.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> InsertStudent(Student model)
        {
            var entity = new Student
            {
                FirstMidName = model.FirstMidName,
                LastName = model.LastName,
                EnrollmentDate = DateTime.Now
            };
            await _dbContext.Students.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.ID;
        }
    }
}
