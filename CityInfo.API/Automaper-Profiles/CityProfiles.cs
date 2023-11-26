using AutoMapper;

namespace CityInfo.API.Automaper_Profiles
{
    public class CityProfiles:Profile
    {
        public CityProfiles()
        {
            CreateMap<Entiteis.City, Models.CityWhthouyPointOfInterstDto>();

            CreateMap<Entiteis.City, Models.CityDto>();
        }
    }
}
