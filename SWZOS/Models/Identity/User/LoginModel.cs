using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWZOS.Models.User
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int FailedAttempts { get; set; }
    }
}
