using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemperatureMonitoring.Models;

namespace TemperatureMonitoring.Repository.InputTemperature
{
    public class InputtemperatureRepository : BaseRepository
    {
        public string InputTemperatureInsert(string _warehouse, string _deviceID, string _LeftDevice, string _RightDevice,string _TimeInput, string _UserAction, string _remark)
        {
            string sql = $@"exec pro_InputTemperature_Insert '{_warehouse}','{_deviceID}','{_LeftDevice}','{_RightDevice}','{_TimeInput}','{_UserAction}','{_remark}'";
            return SqlMapper.Query<string>(con, sql, commandType: System.Data.CommandType.Text).First();
        }

        public List<CInputTemperature> InputTemperatureGET(string _fromdate, string _todate, string _UserAction)
        {
            string sql = $@"exec pro_InputTemperature_GET '{_fromdate}','{_todate}','{_UserAction}'";
            return SqlMapper.Query<CInputTemperature>(con, sql, commandType: System.Data.CommandType.Text).ToList();
        }
    }
}