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
using SWZOS.Models.Reservations;
using SWZOS.Models.Payments;
using SWZOS.Models.Identity.User;

namespace SWZOS.Repositories
{
    public class UsersRepository: BaseRepository
    {
        public UsersRepository(SWZOSContext database): base(database)
        {

        }

        public void AddUser(UserFormModel model, int? userTypeId = null)
        {
            var hashedPassword = PasswordHash.GetHashedPasswordModel(model.Password);

            var user = new User
            {
                Login = model.Login,
                Name = model.Name,
                Surname = model.Surname,
                MailAddress = model.MailAddress,
                PhoneNumber = model.PhoneNumber,
                UserTypeId = userTypeId != null ? (int)userTypeId : (int)UserTypesEnum.Customer,
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

            user.PhoneNumber = model.PhoneNumber;
            SaveChanges();
        }

        public UserFormModel GetUserFormById(int userId)
        {
            return _db.Users.Where(a => a.UserId == userId).Select(a => new UserFormModel
            {
                Id = a.UserId,
                Login = a.Login,
                Name = a.Name,
                Surname = a.Surname,
                PhoneNumber = a.PhoneNumber,
                MailAddress = a.MailAddress
            }).FirstOrDefault();
        }

        public UserViewModel GetUserViewModel(int userId)
        {
            var user = _db.Users.Where(a => a.UserId == userId).Select(a => new UserViewModel
            {
                Id = userId,
                Login = a.Login,
                Name = a.Name,
                Surname = a.Surname,
                MailAddress = a.MailAddress,
                PhoneNumber = a.PhoneNumber,
                Reservations = a.Reservations.Select(b => new ReservationsViewModel
                {
                    UserId = userId,
                    ReservationId = b.ReservationId,
                    PitchId = b.PitchId,
                    PitchTypeId = b.Pitch.PitchTypeId,
                    PitchTypeName = b.Pitch.PitchType.PitchTypeName,
                    StartDate = b.ReservationStartDate,
                    EndDate = b.ReservationStartDate.AddMinutes(b.ReservationDuration),
                    Price = b.ReservationPrice,
                    Description = b.Description,
                    Payments = new PaymentViewModel
                    {
                        PaymentId = b.Payment.PaymentId,
                        FullFee = b.Payment.FullFee,
                        PaidInAmmount = b.Payment.PaidInAmmount,
                        AdvancePayment = b.Payment.AdvancePayment,
                        StatusId = b.Payment.StatusId,
                        Description = b.Description
                    }
                }).OrderBy(b => b.StartDate).ToList()
            }).FirstOrDefault();

            return user;
        }

        public UserSimpleModel GetUserSimpleModel (int userId)
        {
            var user = _db.Users.Where(a => a.UserId == userId).Select(a => new UserSimpleModel
            {
                Id = userId,
                UserTypeId = a.UserTypeId,
                Login = a.Login,
                Name = a.Name,
                Surname = a.Surname,
                MailAddress = a.MailAddress,
                PhoneNumber = a.PhoneNumber,
            }).FirstOrDefault();

            return user;
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

        public List<UserViewModel> SearchCustomers(UserSearchModel searchModel)
        {
            var users = _db.Users.Where(a => a.UserTypeId == (int)UserTypesEnum.Customer).AsQueryable();

            if (!String.IsNullOrEmpty(searchModel.Email))
            {
                users = users.Where(a => a.MailAddress.ToLower() == searchModel.Email.ToLower()).AsQueryable();
                 
            }
            if (!String.IsNullOrEmpty(searchModel.Name))
            {
                users = users.Where(a => a.Name.ToLower() == searchModel.Name.ToLower()).AsQueryable();
            }
            if (!String.IsNullOrEmpty(searchModel.Surname))
            {
                users = users.Where(a => a.Surname.ToLower() == searchModel.Surname.ToLower()).AsQueryable();
            }
            return users.Select(a => new UserViewModel
            {
                Id = a.UserId,
                Name = a.Name,
                Surname = a.Surname,
                MailAddress = a.MailAddress,
                Login = a.Login,
                PhoneNumber = a.PhoneNumber
            }).ToList();
        }

    }
}
