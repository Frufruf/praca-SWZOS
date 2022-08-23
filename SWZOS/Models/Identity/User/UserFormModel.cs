using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWZOS.Models.User
{
    public class UserFormModel
    {
        //PK
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmedPassword { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string MailAddress { get; set; }
    }
}
