﻿using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointOfInteresttForcreationDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
