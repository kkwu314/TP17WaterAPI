using System;
using System.Collections.Generic;

#nullable disable

namespace WaterAPI.Models
{
    public partial class Device
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
    }
}
