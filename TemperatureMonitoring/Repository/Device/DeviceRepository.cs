using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemperatureMonitoring.Models;

namespace TemperatureMonitoring.Repository.Device
{
    public class DeviceRepository: BaseRepository
    {
        public List<CDevice> GetListDevice(string _userAction)
        {

            string sql = $@"exec pro_Devive_GET '{_userAction}'";
            return SqlMapper.Query<CDevice>(con, sql, commandType: System.Data.CommandType.Text).ToList();

        }
        public string DeviceInsertUpdate(string _warehouse, string _deviceId, string _deviceName, string _Status)
        {

            string sql = $@"exec pro_Device_InsertUpdate '{_warehouse}','{_deviceId}','{_deviceName}','{_Status}'";
            return SqlMapper.Query<string>(con, sql, commandType: System.Data.CommandType.Text).First();

        }
        public string DeviceCheckExists(string _warehouse, string _deviceId)
        {

            string sql = $@"exec pro_CheckDevive_GET '{_warehouse}','{_deviceId}'";
            return SqlMapper.Query<string>(con, sql, commandType: System.Data.CommandType.Text).First();

        }
    }
}