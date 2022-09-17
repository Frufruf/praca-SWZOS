using Microsoft.AspNetCore.Mvc.ModelBinding;
using SWZOS.Models.Account;
using SWZOS.Models.User;
using SWZOS.Utils;
using SWZOS_Database;
using SWZOS_Database.Entities;
using System;
using System.Linq;

namespace SWZOS.Repositories
{
    public class AccountRepository: BaseRepository
    {
        public AccountRepository(SWZOSContext database) : base(database)
        {

        }

        //TODO przerobić aby nie zwracało encji
        public User AuthenticateUser(LoginModel model)
        {
            var user = _db.Users.Where(u => u.Login == model.Login).FirstOrDefault();
            if (user != null && PasswordHash.ValidatePassword(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }
            return null;
        }

        public void ValidatePasswordChange(PasswordChangeModel model, string login, ModelStateDictionary modelState)
        {
            if (model.NewPassword != model.ConfirmedPassword)
            {
                modelState.AddModelError("ConfirmedPassowrd", "Wprowadzone hasło różni się");
            }
            else if (model.NewPassword.Length < 5)
            {
                modelState.AddModelError("NewPassword", "Nowe hasło musi posiadać co najmniej 5 znaków");
            }
            
            var user = AuthenticateUser(new LoginModel() { Login = login, Password = model.CurrentPassword }); 
            if (user == null)
            {
                modelState.AddModelError("CurrentPassword", "Niepoprawne hasło");
            }
            
        }

        public void ChangePassword(PasswordChangeModel model, int userId)
        {
            var user = _db.Users.Where(u => u.UserId == userId).FirstOrDefault();
            var hashedPassword = PasswordHash.GetHashedPasswordModel(model.NewPassword);

            user.PasswordHash = hashedPassword.Hash;
            user.PasswordSalt = hashedPassword.Salt;
            user.PasswordExpirationDate = DateTime.Now.AddDays(365);
            _db.SaveChanges();
        }
    }
}
