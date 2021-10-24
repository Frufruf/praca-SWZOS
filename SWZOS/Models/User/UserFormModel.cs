using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWZOS.Models.User
{
    public class UserFormModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string PESEL { get; set; }
        public string MailAddress { get; set; }
        public bool IsEditForm { get; set; }
    }
}
