using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public int UserTypeId { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public DateTime PasswordExpirationDate { get; set; }

        public UserType UserType { get; set; }
    }
}
