using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Category category)
        {
            await _categoryService.Add(category);
            return Ok();
        }  
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            await _categoryService.Update(category);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Category category)
        {
            await _categoryService.Delete(category);
            return Ok();
        }


        [HttpGet("getlist")]
        public async Task<IActionResult> GetList()
        {
            var result = await _categoryService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("getcategorydetails")]
        public async Task<IActionResult> GetCategoryDetails()
        {
            var result = await _categoryService.GetDetailsListAsync();
            return Ok(result);
        }

    }
}
