using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemperatureMonitoring.Models
{
    public class CDevice
    {
        [Display(Name = "Mã Kho")]
        public string Warehouse { get; set; }
        [Display(Name = "Mã thiết bị")]
        public string DeviceID { get; set; }
        [Display(Name = "Tên thiết bị")]
        public string DeviceName { get; set; }
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
    }
}