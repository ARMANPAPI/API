using AutoMapper;
using CityInfo.API.Entiteis;
using CityInfo.API.Models;
using CityInfo.API.Repositories;
using CityInfo.API.Service;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Net.Http.Headers;

namespace CityInfo.API.Controllers
{
    [Route("api/Citeies/{cityId}/pointsfinteset")]
    [ApiController]
    public class ManagementPointOfInterstController : ControllerBase
    {
        private readonly ILogger<ManagementPointOfInterstController> _loger;
        private readonly ICityInfoRepositoriy _cityInfoRepositoriy;
        private readonly IMapper _mapper;

        public ManagementPointOfInterstController(ILogger<ManagementPointOfInterstController> logger,
            ICityInfoRepositoriy cityInfoRepositoriy,
            IMapper mapper)
        {
            _loger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cityInfoRepositoriy = cityInfoRepositoriy ?? throw new ArgumentNullException(nameof(cityInfoRepositoriy));
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointById(int cityId)
        {
            #region LocalCodeOld
            //try
            //{
            //    var city = _citiesdataSore.Citites.FirstOrDefault(i => i.Id == cityId);
            //    if (city == null)
            //    {
            //        //Use DI => Dependency Injection ILogger
            //        _loger.LogInformation($"Not Found CityId {cityId} In The DataBase");
            //        return NotFound();
            //    }

            //    var point = city.pointOfInterset.ToList();

            //    List<PointOfInterestDto> list = new List<PointOfInterestDto>();

            //    foreach (var item in point)
            //    {
            //        list.Add(item);
            //    }
            //    return Ok(list);

            //}
            //catch (Exception ex)
            //{
            //    //Is Development Or توسعه دهنده فقط میتونه از این کدها استفاده کنه
            //    _loger.LogCritical($"Exeption Getting  {cityId}", ex);
            //    return StatusCode(500, "Its Server");
            //}
            #endregion

            if (!await _cityInfoRepositoriy.CityExistAsync(cityId))
            {
                _loger.LogInformation($"{cityId} Not Found....");
                return NotFound();
            }

            var city = await _cityInfoRepositoriy.GetPointsOfIntersetForCityByIdAsycn(cityId);
            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(city));
        }



        [HttpGet("{pointid}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointid)
        {
            if (!await _cityInfoRepositoriy.CityExistAsync(cityId))
            {
                return NotFound();
            }
            var pointofinterst = await _cityInfoRepositoriy.
                GetPointOfIntersetForCityAsync(cityId, pointid);

            if (pointofinterst == null) { return NotFound(); }

            return Ok(_mapper.Map<PointOfInterestDto>(pointofinterst));
        }



        #region Create
        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePoinOfIntesrt(int cityId,
            PointOfInteresttForcreationDto pointofinterestt)
        {
            if (!await _cityInfoRepositoriy.CityExistAsync(cityId))
            {
                return NotFound();
            }

            var finalpoint = _mapper.Map<Entiteis.PointOfInterset>(pointofinterestt);

            await _cityInfoRepositoriy.AddPointOfInterstForCityAsunc(cityId, finalpoint);
            await _cityInfoRepositoriy.SaveChangesAsync();

            return Ok();
        }


        #endregion

        #region Update

        [HttpPut("{pointofintersetId}")]
        public async Task<ActionResult> UpdatePointOfInterst(int cityId,
            int pointofintersetId,
            PointOfInteresttForUppdateDto pointofinterestt)
        {
            if (!await _cityInfoRepositoriy.CityExistAsync(cityId))
            {
                return NotFound();
            }
            var point = await _cityInfoRepositoriy
                .GetPointOfIntersetForCityAsync(cityId, pointofintersetId);

            if (point == null) { return NotFound(); }

            //For Update => مدل میگیره و بجای مدلی که پیدا کردیم قرار میده
            _mapper.Map(pointofinterestt, point);

            await _cityInfoRepositoriy.SaveChangesAsync();
            return NoContent();
        }

        #endregion

        #region Update With Patch

        [HttpPatch("{pointid}")]
        public async Task<ActionResult> PartiallyUpdatepointOfInterset(int cityId,
            int pointid,
            JsonPatchDocument<PointOfInteresttForUppdateDto> patchDocument)
        {

            if (!await _cityInfoRepositoriy.CityExistAsync(cityId))
            {
                return NotFound();
            }

            var pointEntits = await _cityInfoRepositoriy.
                GetPointOfIntersetForCityAsync(cityId, pointid);
            if (pointEntits == null) { return NotFound(); }

            //Map That Profiles Used
            var pointToPatch = _mapper.Map<PointOfInteresttForUppdateDto>(pointEntits);

            patchDocument.ApplyTo(pointToPatch, ModelState);

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (!TryValidateModel(pointToPatch)) { return BadRequest(ModelState); }

            _mapper.Map(pointToPatch, pointEntits);
            await _cityInfoRepositoriy.SaveChangesAsync();
            return NoContent();
        }

        #endregion

        #region Delete
        [HttpDelete("{pointid}")]
        public async Task<ActionResult> Delete(int citId, int pointid)
        {
            if (!await _cityInfoRepositoriy.CityExistAsync(citId)) { return NotFound(); }

            var point = await _cityInfoRepositoriy.
                GetPointOfIntersetForCityAsync(citId, pointid);

            if (point == null) { return NotFound(); }

            _cityInfoRepositoriy.DeletePoint(point);
            await _cityInfoRepositoriy.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
