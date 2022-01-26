using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWZOS.Models.User
{
    public class AppUser :IdentityUser
    {
        public AppUser()
        {

        }

        //public static string Login { get; set; }
        //public static int CurrentUserId { get; set; }
        //public static int CurrentUserTypeId { get; set; }
    }
}
