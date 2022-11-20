using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Service.Security
{
    public class JwtTokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public JwtTokenResponse(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }
    }
}
