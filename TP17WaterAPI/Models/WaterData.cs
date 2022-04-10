using System;
using System.Collections.Generic;

#nullable disable

namespace TP17WaterAPI.Models
{
    public partial class WaterData
    {
        public int WaterId { get; set; }
        public string Year { get; set; }
        public int? NewSouthWales { get; set; }
        public int? Victoria { get; set; }
        public int? Queensland { get; set; }
        public int? SouthAustralia { get; set; }
        public int? WesternAustralia { get; set; }
        public int? Tasmania { get; set; }
        public int? NorthernTerritory { get; set; }
        public int? AustralianCapitalTerritory { get; set; }
    }
}
