using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Service.Security
{
    public class JwtTokenSetting
    {
        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Key = "güvenlikanahratı123321.";
        public const int Expire = 1; //hour
    }
}
