using SWZOS.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SWZOS_Database.Entities;
using SWZOS_Database;
using static SWZOS_Database.Enum;
using SWZOS.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SWZOS.Utils;

namespace SWZOS.Repositories
{
    public class UsersRepository: BaseRepository
    {
        public UsersRepository(SWZOSContext database): base(database)
        {

        }

        public void AddUser(UserFormModel model)
        {
            var hashedPassword = PasswordHash.GetHashedPasswordModel(model.Password);

            var user = new User
            {
                Login = model.Login,
                Name = model.Name,
                Surname = model.Surname,
                PESEL = model.PESEL,
                MailAddress = model.MailAddress,
                PhoneNumber = model.PhoneNumber,
                UserTypeId = (int)UserTypesEnum.Customer,
                ActiveFlag = true,
                PasswordExpirationDate = DateTime.Now.AddDays(365),
                PasswordHash = hashedPassword.Hash,
                PasswordSalt = hashedPassword.Salt
            };

            _db.Users.Add(user);
            SaveChanges();
        }

        public void EditUser(UserFormModel model)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserId == model.Id);


            throw new NotImplementedException();
        }

        public UserFormModel GetUserById(int userId)
        {
            return _db.Users.Where(a => a.UserId == userId).Select(a => new UserFormModel
            {
                Id = a.UserId,
                Login = a.Login,
                Name = a.Name,
                Surname = a.Surname,
                PhoneNumber = a.PhoneNumber,
                MailAddress = a.MailAddress,
                PESEL = a.PESEL
            }).FirstOrDefault();
        }

        public void ValidateUserFormModel(UserFormModel user, ModelStateDictionary modelState)
        {
            if (user.Password != user.ConfirmedPassword) 
            {
                modelState.AddModelError("ConfirmedPassowrd", "Wprowadzone hasło różni się");
            }
            if (_db.Users.Where(u => u.Login == user.Login).FirstOrDefault() != null) 
            {
                modelState.AddModelError("Login", "Podany Login jest zajęty");
            }
            if (_db.Users.Where(u => u.MailAddress == user.MailAddress).FirstOrDefault() != null)
            {
                modelState.AddModelError("MailAddress", "Podany adres email jest już wykorzystywany");
            }
        }

    }
}
