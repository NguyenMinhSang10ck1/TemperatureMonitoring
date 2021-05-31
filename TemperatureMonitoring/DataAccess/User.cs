using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemperatureMonitoring.DataAccess
{
    public class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Warehouse { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivationCode { get; set; }
        public List< Role> Roles { get; set; }
    }
}