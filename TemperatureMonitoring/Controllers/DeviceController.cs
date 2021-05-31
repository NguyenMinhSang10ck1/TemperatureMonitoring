using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemperatureMonitoring.CustomAuthorize;
using TemperatureMonitoring.Models;
using TemperatureMonitoring.Repository.Device;

namespace TemperatureMonitoring.Controllers
{
    [CustomAuthorize(Roles = "Administrator,Manager")]
    public class DeviceController : Controller
    {
        // GET: Device
        //[Authorize(Roles ="adim")]
        public ActionResult Index()
        {
            DeviceRepository _deviceRepository = new DeviceRepository();
            List<CDevice> lsdevices = _deviceRepository.GetListDevice(User.Identity.Name);
            
            return View(lsdevices);
        }

        // GET: Device/Details/5
        public ActionResult Details(string Warehouse, string DeviceID)
        {
            return View();
        }

        // GET: Device/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Device/Create
        [HttpPost]
        public ActionResult Create(CDevice collection)
        {
            try
            {
                // TODO: Add insert logic here
                DeviceRepository _deviceRepository = new DeviceRepository();
                string _result = _deviceRepository.DeviceCheckExists(collection.Warehouse, collection.DeviceID);
                if (_result=="0")
                {
                    string _result1 = _deviceRepository.DeviceInsertUpdate(collection.Warehouse, collection.DeviceID, collection.DeviceName, collection.Status);
                    if (_result1 == "")
                    {
                        ViewBag.TypeMessage = "1";
                        ViewBag.Message = $@"Thêm mới thiết bị thành công";
                        //return RedirectToAction("Index");
                        return View(collection);
                    }
                    else
                    {
                        ViewBag.TypeMessage = "0";
                        ViewBag.Message = "Lỗi: " + _result1;
                        //  ModelState.AddModelError("DeviceID", $@"Error: {_result}");
                        return View(collection);
                    }
                }
                else
                {
                    ViewBag.TypeMessage = "0";
                    ViewBag.Message = $"Lỗi: Đã tồn tại thiết bị: {collection.DeviceID} tại kho {collection.Warehouse} " ;
                    ModelState.AddModelError("DeviceID", $@"Đã tồn tại, vui lòng kiểm tra lại mã thiết bị");
                    ModelState.AddModelError("Warehouse", $@"Đã tồn tại, vui lòng kiểm tra lại mã kho");
                    return View(collection);
                }
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Device/Edit/5
        public ActionResult Edit(string Warehouse, string DeviceID, string DeviceName, string Status)
        {
            return View();
        }

        // POST: Device/Edit/5
        [HttpPost]
        public ActionResult Edit( CDevice collection) //FormCollection collection
        {
            try
            {
                // TODO: Add update logic here
                DeviceRepository _deviceRepository = new DeviceRepository();
                string _result = _deviceRepository.DeviceInsertUpdate(collection.Warehouse, collection.DeviceID, collection.DeviceName, collection.Status);
                if (_result =="")
                {
                    ViewBag.TypeMessage = "1";
                    ViewBag.Message = $@"Đã thay đổi thông tin";
                    //return RedirectToAction("Index");
                    return View(collection);
                }
                else
                {
                    ViewBag.TypeMessage = "0";
                    ViewBag.Message = "Lỗi: " +_result;
                  //  ModelState.AddModelError("DeviceID", $@"Error: {_result}");
                    return View(collection);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Device/Delete/5
        public ActionResult Delete(string Warehouse, string DeviceID, string DeviceName)
        {
            CDevice _cdevice = new CDevice();
            _cdevice.Warehouse = Warehouse;
            _cdevice.DeviceID = DeviceID;
            _cdevice.DeviceName = DeviceName;
            _cdevice.Status = "I";
            return View(_cdevice);
        }

        // POST: Device/Delete/5
        [HttpPost]
        public ActionResult Delete( CDevice collection)
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

        public ActionResult DeleteDevice(string warehouse, string DeviceID, string DeviceName, string Status)
        {
            try
            {
                // TODO: Add update logic here
                DeviceRepository _deviceRepository = new DeviceRepository();
                string _result = _deviceRepository.DeviceInsertUpdate(warehouse, DeviceID, DeviceName, Status);
                if (_result == "")
                {
                    ViewBag.TypeMessage = "1";
                    ViewBag.Message = "Đã thay đổi thông tin";
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index");
                }
                else
                {
                    CDevice _cdevice = new CDevice();
                    _cdevice.Warehouse = warehouse;
                    _cdevice.DeviceID = DeviceID;
                    _cdevice.DeviceName = DeviceName;
                    _cdevice.Status = "I";
                    ViewBag.TypeMessage = "0";
                    ViewBag.Message = "Error: " + _result;
                    //  ModelState.AddModelError("DeviceID", $@"Error: {_result}");
                    return View(_cdevice);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
