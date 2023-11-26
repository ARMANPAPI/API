using CityInfo.API.Entiteis;

namespace CityInfo.API.Repositories
{
    public interface ICityInfoRepositoriy
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        Task<City?> GetCityAsync(int CityId, bool inclouadPointOfIntrest);
        Task<bool> CityExistAsync(int CityId);

        Task<IEnumerable<PointOfInterset>> GetPointsOfIntersetForCityByIdAsycn(int CityId);

        Task<PointOfInterset?> GetPointOfIntersetForCityAsync(int CityId,int PointOfIntersetId);

        Task AddPointOfInterstForCityAsunc(int CityId,PointOfInterset pointOfInterset);

        void DeletePoint(PointOfInterset pointOfInterset); 
        Task<bool> SaveChangesAsync(); 
    }
}
