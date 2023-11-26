using CityInfo.API.DbContexts;
using CityInfo.API.Entiteis;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CityInfo.API.Repositories
{
    public class CityInfoRepositoriy : ICityInfoRepositoriy
    {
        private readonly CityInfoDbContext _Context;

        public CityInfoRepositoriy(CityInfoDbContext cityInfoDbContext)
        {
            _Context = cityInfoDbContext ?? throw new ArgumentException(nameof(cityInfoDbContext));
        }


        public async Task<bool> CityExistAsync(int CityId)
        {
            return await _Context.Cities.AnyAsync(c=>c.Id == CityId);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _Context.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<City?> GetCityAsync(int CityId, bool inclouadPointOfIntrest)
        {
            if (inclouadPointOfIntrest == true)
            {
                return await _Context.Cities
                    .Include(i => i.pointOfInterset)
                    .Where(c => c.Id == CityId).FirstOrDefaultAsync();
            }
            return await _Context.Cities.Where(c => c.Id == CityId).FirstOrDefaultAsync();
        }

        public async Task<PointOfInterset?> GetPointOfIntersetForCityAsync(int CityId, int PointOfIntersetId)
        {
              return await _Context.PointsOfInterset
                .Where(p=>p.Id == PointOfIntersetId && p.CityId == CityId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterset>> GetPointsOfIntersetForCityByIdAsycn(int CityId)
        {
            return await _Context.PointsOfInterset
                .Where(c=>c.CityId == CityId).ToListAsync();
        }

        public async Task AddPointOfInterstForCityAsunc(int CityId, PointOfInterset pointOfInterset)
        {
            var city = await GetCityAsync(CityId,false);

            if(city != null)
            {
                city.pointOfInterset.Add(pointOfInterset);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _Context.SaveChangesAsync() > 0);
        }

        public void DeletePoint(PointOfInterset pointOfInterset)
        {
            _Context.Remove(pointOfInterset);
        }
    }
}
 