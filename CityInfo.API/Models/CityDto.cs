using CityInfo.API.Entiteis;
using System.Security.Principal;

namespace CityInfo.API.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int NumberOfPointsOfInterset { get { return pointOfInterset.Count; } }
        public ICollection<PointOfInterestDto> pointOfInterset { get; set; } 
            = new List<PointOfInterestDto>();
    }
}
