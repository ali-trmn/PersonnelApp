using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Model.UserDto
{
    public class LoginUserResult
    {
        public string Role { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
