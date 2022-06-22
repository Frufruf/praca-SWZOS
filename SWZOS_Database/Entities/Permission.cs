using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    public class Permission
    {
        //PK
        public int PermissionId { get; set; }
        //Nazwa uprawnienia
        public string Name { get; set; }
        //Opis działania, które dane uprawnienie umożliwia na wykonanie
        public string Description { get; set; }
        //Flaga sterująca usunięciem uprawnienia
        public bool DeletedFlag { get; set; }

        public List<UserPermission> UserPermissions { get; set; }
    }
}
