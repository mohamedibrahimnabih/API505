using ECommerce.Models;
using ECommerce.Repository;
using ECommerce.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository _categoryRepository)
        {
            this._categoryRepository = _categoryRepository;
        }

        // READ => HttpGet
        [HttpGet]
        public IActionResult Index()
        {
            var listOfCategories = _categoryRepository.Get(null);
            return Ok(listOfCategories);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var Category = _categoryRepository.GetOne(e => e.Id == id);
            if(Category == null) return NotFound();
            else return Ok(Category);
        }

        // CREATE => HttpPost
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                return Created($"{Request.Scheme}://{Request.Host}/api/Category/{category.Id}", category);
            }
            return BadRequest(category);
        }

        // UPDATE => HttpPut
        [HttpPut]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                return Created($"{Request.Scheme}://{Request.Host}/api/Category/{category.Id}", category);
            }
            return BadRequest(category);
        }

        // DELETE => HttpDelete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Category = _categoryRepository.GetOne(e => e.Id == id);

            if (Category == null) return NotFound();
            else
            {
                _categoryRepository.Remove(Category);
                return Ok(Category);
            }
        }
    }
}
