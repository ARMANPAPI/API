using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{

    [ApiController]
    //[Authorize]
    [Route("api/Citeies")]
    public class CiteiesController : ControllerBase
    {
        private readonly ICityInfoRepositoriy _cityInfoRepositoriy;
        private readonly IMapper _mapper;
        public CiteiesController(ICityInfoRepositoriy cityInfoRepositoriy,IMapper mapper)
        {
            _cityInfoRepositoriy = cityInfoRepositoriy ?? throw new ArgumentNullException(nameof(cityInfoRepositoriy))  ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWhthouyPointOfInterstDto>>> GetCities()
        {
            var cities= await _cityInfoRepositoriy.GetCitiesAsync();

            return Ok(
                _mapper.Map<IEnumerable<CityWhthouyPointOfInterstDto>>(cities)
                ) ;

            //var result = new List<CityWhthouyPointOfInterstDto>();

            //foreach (var city in cities)
            //{
            //    result.Add(new CityWhthouyPointOfInterstDto()
            //    {
            //        Id = city.Id,
            //        Name = city.Name,
            //        Description= city.Description
            //    });
            //}

            //return Ok(result);
        }
         



        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity([FromBody] int id, bool inclouadPointOfIntrest=false)
        {
            var city=await _cityInfoRepositoriy.GetCityAsync(id,inclouadPointOfIntrest);
            if (city == null) { return NotFound(); }

            if(inclouadPointOfIntrest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }
            return Ok(_mapper.Map<CityWhthouyPointOfInterstDto>(city));
        }
    }
} 
