using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TemperatureMonitoring.Repository
{
    public class BaseRepository : IDisposable
    {
        protected string connectionString = @"server=HCM-ITD-LTP002\SQL2014;database=TemperatureMonitoring;UId=sa; Password=sa123456";
        protected IDbConnection con;

        public BaseRepository()
        {
            con = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}