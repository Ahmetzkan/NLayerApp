using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Course course)
        {
            await _courseService.Add(course);
            return Ok();
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Course course)
        {
            await _courseService.Update(course);
            return Ok();
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Course course)
        {
            await _courseService.Delete(course);
            return Ok();
        }


        [HttpGet("getlist")]
        public async Task<IActionResult> GetList()
        {
            var result = await _courseService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("getcoursedetails")]
        public async Task<IActionResult> GetCourseDetails()
        {
            var result = await _courseService.GetDetailsListAsync();
            return Ok(result);
        }
    }
}
