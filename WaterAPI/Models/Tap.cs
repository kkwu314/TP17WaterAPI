using System;
using System.Collections.Generic;

#nullable disable

namespace WaterAPI.Models
{
    public partial class Tap
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ModelCode { get; set; }
        public string Subtype { get; set; }
        public string Status { get; set; }
        public string ExpiryDate { get; set; }
        public int? LicenseNumber { get; set; }
        public string Regnumber { get; set; }
        public string StarRating { get; set; }
        public double? Waterconsump { get; set; }
        public string Testedpressure { get; set; }
        public string Variants { get; set; }
        public int? IntStarRating { get; set; }
        public string Autoshutoff { get; set; }
    }
}
