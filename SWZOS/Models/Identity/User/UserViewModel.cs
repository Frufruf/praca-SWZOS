using SWZOS.Models.Payments;
using SWZOS.Models.Reservations;
using System.Collections.Generic;

namespace SWZOS.Models.User
{
    public class UserViewModel
    {
        //PK
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public bool IsBlackListed { get; set; }
        public List<ReservationsViewModel> Reservations { get; set; }
    }
}
