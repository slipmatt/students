using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Students.Api.Data;
using Students.Api.Interfaces;
using Students.Api.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CourseController(ICourseService CourseService, IMapper mapper)
        {
            _courseService = CourseService;
            _mapper = mapper;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var CourseEntity = await _courseService.GetCourses();
            var CourseModel = _mapper.Map<List<Course>, List<CourseModel>>(CourseEntity);
            return Ok(CourseModel);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var CourseEntity = await _courseService.GetCourseById(id);
            var CourseModel = _mapper.Map<Course, CourseModel>(CourseEntity);
            return Ok(CourseModel);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(CourseModel model)
        {
            var CourseEntity = _mapper.Map<CourseModel, Course>(model);
            var id = await _courseService.InsertCourse(CourseEntity);
            return Ok(id);
        }

        // PUT api/<CourseController>/5
        [HttpPut]
        public async Task<IActionResult> PutAsync(CourseModel model)
        {
            var CourseEntity = _mapper.Map<CourseModel, Course>(model);
            await _courseService.UpdateCourse(CourseEntity);
            return Ok();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return BadRequest("Method not allowed");
        }

        [HttpGet("GetByCourse/{id}")]
        public async Task<IActionResult> GetCoursesByCourseIdAsync(int courseId)
        {
            var CourseEntity = await _courseService.GetCourseByStudentId(courseId);
            var CourseModel = _mapper.Map<List<Course>, List<CourseModel>>(CourseEntity);
            return Ok(CourseModel);
        }
    }
}
