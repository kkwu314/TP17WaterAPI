using System;
using System.Collections.Generic;

#nullable disable

namespace WaterAPI.Models
{
    public partial class ShowerRecord
    {
        public int RecordId { get; set; }
        public int? ShowerTime { get; set; }
        public DateTime? RecordDate { get; set; }
        public int? UserId { get; set; }
    }
}
