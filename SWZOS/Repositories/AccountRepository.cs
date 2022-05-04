using Microsoft.AspNetCore.Mvc.ModelBinding;
using SWZOS.Models.Account;
using SWZOS.Models.User;
using SWZOS.Utils;
using SWZOS_Database;
using System;
using System.Linq;

namespace SWZOS.Repositories
{
    public class AccountRepository: BaseRepository
    {
        public AccountRepository(SWZOSContext database) : base(database)
        {

        }

        public bool AuthenticateUser(LoginModel model)
        {
            var user = _db.Users.Where(u => u.Login == model.Login).FirstOrDefault();
            if (user != null && PasswordHash.ValidatePassword(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return true;
            }
            return false;
        }

        public void ValidatePasswordChange(PasswordChangeModel model, ModelStateDictionary modelState)
        {
            //TODO Podmienić na currentUser
            var user = _db.Users.Where(u => u.UserId == model.UserId).FirstOrDefault();
            if (!AuthenticateUser(new LoginModel() { Login = user.Login, Password = model.CurrentPassword }))
            {
                modelState.AddModelError("CurrentPassword", "Niepoprawne hasło");
            }
            if (model.NewPassword != model.ConfirmedPassword)
            {
                modelState.AddModelError("ConfirmedPassowrd", "Wprowadzone hasło różni się");
            }
        }

        public void ChangePassword(PasswordChangeModel model)
        {
            var user = _db.Users.Where(u => u.UserId == model.UserId).FirstOrDefault();
            var hashedPassword = PasswordHash.GetHashedPasswordModel(model.NewPassword);

            user.PasswordHash = hashedPassword.Hash;
            user.PasswordSalt = hashedPassword.Salt;
            user.PasswordExpirationDate = DateTime.Now.AddDays(365);
            _db.SaveChanges();
        }
    }
}
