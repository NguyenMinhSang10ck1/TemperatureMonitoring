using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TemperatureMonitoring.CustomAuthorize;
using TemperatureMonitoring.Models;
using TemperatureMonitoring.Repository;
using TemperatureMonitoring.Repository.Device;
using TemperatureMonitoring.Repository.InputTemperature;

namespace TemperatureMonitoring.Controllers
{
    [CustomAuthorize(Roles = "Administrator,Manager,Staff")]
    public class InputTemperatureController : Controller
    {
        DeviceRepository _deviceRepository = new DeviceRepository();
        // GET: InputTemperature
        public ActionResult Index()
        {
            List<CDevice> lsdevices = _deviceRepository.GetListDevice(User.Identity.Name);
            List<CInputTemperature> _lscInputTemperatures = new List<CInputTemperature>();
            foreach (var item in lsdevices)
            {
                CInputTemperature _cInputTemperature = new CInputTemperature();
                _cInputTemperature.Warehouse = item.Warehouse;
                _cInputTemperature.DeviceID = item.DeviceID;
                _cInputTemperature.DeviceName = item.DeviceName;
                _cInputTemperature.LeftDevice = "";
                _cInputTemperature.RightDevice = "";
                _cInputTemperature.Remark = "";
                _cInputTemperature.UserInput = User.Identity.Name;
                _lscInputTemperatures.Add(_cInputTemperature);
                
            }
            ViewBag.UserAction = User.Identity.Name;
            return View(_lscInputTemperatures);
        }

        // GET: InputTemperature/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InputTemperature/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InputTemperature/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InputTemperature/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InputTemperature/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InputTemperature/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public JsonResult SaveData(List<CInputTemperature> values)  //JsonResult
        {
            var json = new JavaScriptSerializer().Serialize(values);
            InputtemperatureRepository inputtemperatureRepository = new InputtemperatureRepository();
            string _TimeInput = "";
            _TimeInput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (values == null)
            {
                values = new List<CInputTemperature>();
            }
            string _result = "";
            foreach (var item in values)
            {
                _result += inputtemperatureRepository.InputTemperatureInsert(item.Warehouse, item.DeviceID, item.LeftDevice, item.RightDevice, _TimeInput,User.Identity.Name, item.Remark);
            }
            ResultData _resultData = new ResultData();
            if (_result.Trim() == "")
            {
                //string[] emailto = new string[]{};
                UserLoginRepository _userlogin = new UserLoginRepository();
                List<UserSendEmail> _usersendmails= _userlogin.GetUserSendEmail(User.Identity.Name);
                string[] emailto = new string[_usersendmails.Count];
                int iuser = 0;
                foreach (var _userSendmail in _usersendmails)
                {
                    emailto[iuser] = _userSendmail.Email;
                    iuser=iuser+1;
                }
                //new string [] { "minhsang.nguyen@vn.yusen-logistics.com" }
                SendMail.SendmailTemp(emailto, "test send mail", GetStringBodySendmail(values), "");
                _resultData.Status = "Success";
                _resultData.TimeInput = _TimeInput;
                _resultData.Error = "Gửi thông tin thành công. Xin cảm ơn";
            }
            else
            {
                _resultData.Status = "Error";
                _resultData.TimeInput = "";
                _resultData.Error = "Lỗi: " + _result;
            }

            return Json(_resultData);
            //return RedirectToAction("SaveData");
        }


        // POST: InputTemperature/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Report(string FromDate="", string ToDate="")
        {
            InputtemperatureRepository inputtemperatureRepository = new InputtemperatureRepository();
           
            if (FromDate =="")
            {
                ViewBag.FromDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }
            else
            {
                ViewBag.FromDate = FromDate;
            }
            if (ToDate == "")
            {
                ViewBag.ToDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }
            else
            {
                ViewBag.ToDate = ToDate;
            }
            List<CInputTemperature> ls_cInputTemperature = inputtemperatureRepository.InputTemperatureGET(ViewBag.FromDate,ViewBag.ToDate, User.Identity.Name);
            List<CInputTemperature> _lscInputTemperatures = new List<CInputTemperature>();
            foreach (var item in ls_cInputTemperature)
            {
                CInputTemperature _cInputTemperature = new CInputTemperature();
                _cInputTemperature.Warehouse = item.Warehouse;
                _cInputTemperature.DeviceID = item.DeviceID;
                _cInputTemperature.DeviceName = item.DeviceName;
                _cInputTemperature.LeftDevice = item.LeftDevice;
                _cInputTemperature.RightDevice = item.RightDevice;
                _cInputTemperature.Remark = item.Remark;
                _cInputTemperature.UserInput = item.UserInput;
                _cInputTemperature.TimeInput = item.TimeInput;
                _lscInputTemperatures.Add(_cInputTemperature);
            }
            return View(_lscInputTemperatures);
        }
        private string GetStringBodySendmail(List<CInputTemperature> values)
        {
            string _result = "";
            string _body = "";
            foreach (var item in values)
            {
                _body = _body + $@"<tr bgcolor='#FFFFFF'><td><b>BTLC</b></td> <td> <b> {item.DeviceName}	 </b> </td> <td> <b> {item.LeftDevice}</b></td> <td> <b>{item.RightDevice}</b></td> <td> <b> </b></td> <td> <b> {item.TimeInput}</b></td> <td> <b>{item.UserInput}</b></td> </tr> ";
            }
            _result = @"<p>Dear team,</p>
                        <p>Đây là mail gửi báo cáo ghi nhận nhiệt độ lúc: 2021-05-20 17:14:02</p>
                    <table border=" + 0 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 800 + ">" +
                "<tr bgcolor='#4da6ff'><td><b>Warehouse</b></td> <td> <b> Device </b> </td> <td> <b> Nhiệt độ IN</b></td> <td> <b> Nhiệt độ OUT</b></td> <td> <b> Ghi Chú</b></td> <td> <b> Thời gian ghi nhận</b></td> <td> <b> Người ghi nhận</b></td> </tr> " +
                 _body +
                "</table> </br></br>" +
                "*************************************************************************************</br> "+
                "This is an auto - generated email.Please do not reply to this email or its recipients.</br>" +
                "************************************************************************************* "
                ;
            return _result;
        }
        
        
    }
    public class ResultData
    {
        public string Status { get; set; }
        public string Error { get; set; }
        public string TimeInput { get; set; }
    }
}
