using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    public class UserPermission
    {
        //Klucz obcy użytkownika
        public int UserId { get; set; }
        //Klucz obcy uprawnienia
        public int PermissionId { get; set; }

        public Permission Permission { get; set; }
        public User User { get; set; }
    }
}
