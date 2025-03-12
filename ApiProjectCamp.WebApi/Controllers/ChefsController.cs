using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public ChefsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            List<Chef> value = _apiContext.Chefs.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _apiContext.Chefs.Add(chef);
            _apiContext.SaveChanges();
            return Ok("Şef sisteme başarıyla eklendi.");

        }

        [HttpDelete]
        public IActionResult DeleteCheF(int Id)
        {
            Chef value = _apiContext.Chefs.Find(Id);
            _apiContext.Chefs.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Şef sistemden silindi.");
        }

        [HttpGet("GetChef")]
        public IActionResult GetChef(int Id)
        {
            return Ok(_apiContext.Chefs.Find(Id));
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _apiContext.Chefs.Update(chef);
            _apiContext.SaveChanges();
            return Ok("Şef sistemden güncellendi.");
        }
    }
}
