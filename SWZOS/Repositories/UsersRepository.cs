using SWZOS.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SWZOS_Database.Entities;
using SWZOS_Database;
using static SWZOS_Database.Enum;

namespace SWZOS.Repositories
{
    public class UsersRepository: BaseRepository
    {
        public UsersRepository(SWZOSContext database): base(database)
        {

        }

        public void AuthenticateUser(LoginModel model)
        {
            //var currentUser = _db.Users.Where(a => a.Login == model.LoginOrEmail || a.MailAddress == model.LoginOrEmail)
            //            .Select(a => new CurrentUser
            //            {
            //                Login = a.Login,

            //            }).FirstOrDefault();
        }

        public void AddUser(UserFormModel model)
        {
            var user = new User
            {
                Login = model.Login,
                Name = model.Name,
                Surname = model.Surname,
                PESEL = model.PESEL,
                MailAddress = model.MailAddress,
                PhoneNumber = model.PhoneNumber,
                UserTypeId = (int)UserTypesEnum.Customer,
                PasswordExpirationDate = DateTime.Now.AddDays(180)
            };

            //_db.Users.Add(user);
            //SaveChanges();
        }

        public void EditUser(UserFormModel model)
        {
            throw new NotImplementedException();
        }

        public UserFormModel GetUserById(int userId)
        {
            throw new NotImplementedException();
            //return _db.Users.Where(a => a.Id == userId).Select(a => new UserFormModel
            //{
            //    Id = a.Id,
            //    Login = a.Login,
            //    Name = a.Name,
            //    Surname = a.Surname,
            //    PhoneNumber = a.PhoneNumber,
            //    MailAddress = a.MailAddress,
            //    PESEL = a.PESEL
            //}).FirstOrDefault();
        }

    }
}
