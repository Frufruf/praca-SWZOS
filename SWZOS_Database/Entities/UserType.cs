using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Entities
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
