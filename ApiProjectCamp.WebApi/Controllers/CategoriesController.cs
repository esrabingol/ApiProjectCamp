using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public CategoriesController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            List<Category> values = _apiContext.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _apiContext.Categories.Add(category);
            _apiContext.SaveChanges();
            return Ok("Kategori Ekleme Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int Id)
        {
            Category value = _apiContext.Categories.Find(Id);
            _apiContext.Categories.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Kategori Silme İşlemi Başarılı");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int Id)
        {
            Category value = _apiContext.Categories.Find(Id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _apiContext.Categories.Update(category);
            _apiContext.SaveChanges();
            return Ok("Kategori güncelleme  işlemi başarıyla gerçekleşti.");
        }

    }
}
