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
                UserTypeId = (int)UserTypesEnum.Customer
            };

            _database.Users.Add(user);
            SaveChanges();
        }

        public UserModel GetUserById(int userId)
        {
            return _database.Users.Where(a => a.Id == userId).Select(a => new UserModel
            {
                Id = a.Id,
                Name = a.Name,
                Surname = a.Surname
            }).FirstOrDefault();
        }
    }
}
