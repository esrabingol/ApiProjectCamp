using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        public ProductsController(IValidator<Product> validator, ApiContext context)
        {
            _validator = validator;
            _context = context;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            List<Product> products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            ValidationResult validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün ekleme işlemi başarılı.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int Id)
        {
            Product product = _context.Products.Find(Id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla tamamlandı.");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int Id)
        {
            Product product = _context.Products.Find(Id);
            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            ValidationResult validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Güncelleme işlemi başarıyla gerçekleşmiştir.");
            }
        }
    }
}
