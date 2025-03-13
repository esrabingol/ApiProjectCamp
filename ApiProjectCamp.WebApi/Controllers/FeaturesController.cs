using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.FeatureDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            List<Feature> values = _context.Features.ToList();

            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            Feature values = _mapper.Map<Feature>(createFeatureDto);

            _context.Features.Add(values);
            _context.SaveChanges();

            return Ok("Ekleme işlemi başarılı olarak gerçekleşti.");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            Feature value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int Id)
        {
            Feature value = _context.Features.Find(Id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeature)
        {
            Feature values = _mapper.Map<Feature>(updateFeature);
            _context.Features.Update(values);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla tamamlandı.");
        }
    }
}
