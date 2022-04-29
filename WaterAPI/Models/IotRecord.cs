using System;
using System.Collections.Generic;

#nullable disable

namespace WaterAPI.Models
{
    public partial class IotRecord
    {
        public int Id { get; set; }
        public int? DeviceId { get; set; }
        public DateTime? RecordDateTime { get; set; }
        public int? UsedSecond { get; set; }
        public double? FlowPerSec { get; set; }
    }
}
