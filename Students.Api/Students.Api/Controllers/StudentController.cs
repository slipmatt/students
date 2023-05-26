using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Students.Api.Data;
using Students.Api.Interfaces;
using Students.Api.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Students.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var studentEntity = await _studentService.GetStudents();
            var studentModel = _mapper.Map<List<Student>, List<StudentModel>>(studentEntity);
            return Ok(studentModel);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentEntity = await _studentService.GetStudentById(id);
            var studentModel = _mapper.Map<Student, StudentModel>(studentEntity);
            return Ok(studentModel);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(StudentModel model)
        {
            var studentEntity = _mapper.Map<StudentModel, Student>(model);
            var id = await _studentService.InsertStudent(studentEntity);
            return Ok(id);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public async Task<IActionResult> PutAsync(StudentModel model)
        {
            var studentEntity = _mapper.Map<StudentModel, Student>(model);
            await _studentService.UpdateStudent(studentEntity);
            return Ok();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return BadRequest("Method not allowed");
        }

        [HttpGet("GetByCourse/{id}")]
        public async Task<IActionResult> GetStudentsByCourseIdAsync(int courseId)
        {
            var studentEntity = await _studentService.GetStudentByCourseId(courseId);
            var studentModel = _mapper.Map<List<Student>, List<StudentModel>>(studentEntity);
            return Ok(studentModel);
        }
    }
}
