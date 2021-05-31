using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemperatureMonitoring.Models
{
    public class CInputTemperature
    {
        [Display (Name ="Mã Kho") ]
        public string Warehouse { get; set; }
        [Display(Name = "Mã thiết bị")]
        public string DeviceID { get; set; }
        [Display(Name = "Tên thiết bị")]
        public string DeviceName { get; set; }
        [Display(Name = "Nhiệt độ IN")]
        [Required(ErrorMessage = "Nhập nhiệt độ IN")]
        public string LeftDevice { get; set; }
        [Display(Name = "Nhiệt độ OUT")]
        [Required(ErrorMessage = "Nhập nhiệt độ OUT")]
        public string RightDevice { get; set; }

        [Display(Name = "Ghi chú")]
        public string Remark { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        [Display(Name = "Thời gian thực hiện")]
        public DateTime TimeInput { get; set; }
        [Display(Name = "Nhân viên thực hiện")]
        public string UserInput { get; set; }
    }
}