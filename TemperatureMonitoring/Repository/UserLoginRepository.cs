using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemperatureMonitoring.Models;

namespace TemperatureMonitoring.Repository
{
    public class UserLoginRepository : BaseRepository
    {
        public List<CUserLogin> GetListUser(string _userAction)
        {

            string sql = $@"exec pro_Devive_GET '{_userAction}'";
            return SqlMapper.Query<CUserLogin>(con, sql, commandType: System.Data.CommandType.Text).ToList();

        }

        public CUserLogin GetUserLogin(string _userAction, string _password)
        {

            string sql = $@"exec pr_GetUserByUserNamePassword N'{_userAction}', N'{_password}'";
            return SqlMapper.Query<CUserLogin>(con, sql, commandType: System.Data.CommandType.Text).FirstOrDefault();

        }
        public List<UserRole> GetUserRoles(string _userAction)
        {

            string sql = $@"exec pr_GetUserRoleByUser N'{_userAction}'";
            return SqlMapper.Query<UserRole>(con, sql, commandType: System.Data.CommandType.Text).ToList();

        }
        public List<UserSendEmail> GetUserSendEmail(string _userAction)
        {
            string sql = $@"exec pr_GetUserSendEmail N'{_userAction}'";
            return SqlMapper.Query<UserSendEmail>(con, sql, commandType: System.Data.CommandType.Text).ToList();
        }

    }
}