using AutoMapper;
using CityInfo.API.Models;

namespace CityInfo.API.Automaper_Profiles
{
    public class PointOfIntersetProfile:Profile
    {

        public PointOfIntersetProfile()
        {
             CreateMap<Entiteis.PointOfInterset,Models.PointOfInterestDto>();

            //For Create
            CreateMap<Models.PointOfInteresttForcreationDto, Entiteis.PointOfInterset>();
            //For Update
            CreateMap<Models.PointOfInteresttForUppdateDto, Entiteis.PointOfInterset>();
            //For Update Path

            CreateMap<Entiteis.PointOfInterset, Models.PointOfInteresttForUppdateDto>();

        }

    }
}
