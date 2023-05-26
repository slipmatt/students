using Microsoft.EntityFrameworkCore;
using Students.Api.Data;
using Students.Api.Interfaces;

namespace Students.Api.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentDbContext _dbContext;

        public CourseRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Course>> GetCourseByStudentId(int id)
        {
            return await _dbContext.Courses.Where(i=>i.Enrollments.Any(e=>e.StudentID == id)).ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _dbContext.Courses.Where(i => i.CourseID == id).FirstOrDefaultAsync();
        }

        public async Task<List<Course>> GetCourses()
        {
            return await _dbContext.Courses.ToListAsync();
        }

        public async Task UpdateCourse(Course model)
        {
            //Automap this
            var entity = _dbContext.Courses.Find(model.CourseID);
            entity.Title = model.Title;
            entity.Credits = model.Credits;
            _dbContext.Courses.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> InsertCourse(Course model)
        {
            var entity = new Course
            {
                Title = model.Title,
                Credits = model.Credits
            };
            await _dbContext.Courses.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.CourseID;
        }
    }
}
