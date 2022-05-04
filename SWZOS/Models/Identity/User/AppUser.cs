using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SWZOS.Models.User
{
    public class AppUser
    {
        public AppUser()
        {

        }

        //private static ClaimsPrincipal User
        //{
        //    get { return  }
        //}

        public static string Login { get; set; }
        public static int CurrentUserId { get; set; }
        public static int CurrentUserTypeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
