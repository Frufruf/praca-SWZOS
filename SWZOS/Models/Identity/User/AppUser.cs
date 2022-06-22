using Microsoft.AspNetCore.Http;
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
        public AppUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private static ClaimsPrincipal User
        {
            get { return _httpContextAccessor.HttpContext?.User ?? null; }
        }

        private static IHttpContextAccessor _httpContextAccessor;
        public static string Login { get; set; }
        public static int? CurrentUserId { get; set; }
        public static int? CurrentUserTypeId { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string FullName { get { return Name + " " + Surname; } }
    }
}
