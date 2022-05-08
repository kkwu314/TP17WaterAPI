using System;
using System.Collections.Generic;

#nullable disable

namespace WaterAPI.Models
{
    public partial class SummaryShowerhead
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double? AverageRating { get; set; }
        public int? MedianRating { get; set; }
        public double? AverageWaterConsumpLiters { get; set; }
        public double? MedianWaterConsumpLiters { get; set; }
        public int? NOfProduct { get; set; }
    }
}
