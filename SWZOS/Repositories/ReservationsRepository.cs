using Microsoft.AspNetCore.Mvc.ModelBinding;
using SWZOS.Models.Reservations;
using SWZOS_Database;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static SWZOS_Database.Enum;

namespace SWZOS.Repositories
{
    public class ReservationsRepository: BaseRepository
    {
        public ReservationsRepository(SWZOSContext db): base(db)
        {

        }

        //Metoda pobierająca wszystkie rezerwacje użytkownika o podanym ID
        public List<ReservationsViewModel> GetUserReservations(int userId)
        {
            var result = _db.Reservations.Where(a => a.UserId == userId).Select(a => new ReservationsViewModel
            {
                UserId = a.UserId,
                ReservationId = a.ReservationId,
                PitchId = a.PitchId,
                StartDate = a.ReservationStartDate,
                EndDate = a.ReservationStartDate.AddMinutes(a.ReservationDuration),
                Price = a.ReservationPrice,
                Description = a.Description
            }).ToList();

            return result;
        }

        public ReservationFormModel GetReservationById(int reservationId)
        {
            return _db.Reservations.Where(a => a.ReservationId == reservationId).Select(a => new ReservationFormModel
            {
                ReservationId = a.ReservationId,
                UserId = a.UserId,
                StartDate = a.ReservationStartDate,
                Duration = a.ReservationDuration,
                PitchTypeId = a.Pitch.PitchTypeId,
                Description = a.Description
            }).FirstOrDefault();
        }

        //Metoda dodająca rezerwację wraz ze sprzętem do bazy
        public void AddReservation(ReservationFullFormModel model)
        {
            var transaction = _db.Database.BeginTransaction();

            var reservation = new Reservation
            {
                PitchId = model.PitchId,
                UserId = model.UserId, //TODO zalogowany użytkownik
                ReservationStartDate = model.StartDate,
                ReservationDuration = model.Duration,
                ReservationPrice = model.Price,
                ReservationStatus = (int)ReservationStatusEnum.Active,
                Description = model.Description,
            };

            _db.Reservations.Add(reservation);
            _db.SaveChanges();

            var equipmentList = new List<ReservationEquipment>();
            foreach (var equipment in model.EquipmentList)
            {
                var reservationEquipment = new ReservationEquipment
                {
                    ReservationId = reservation.ReservationId,
                    EquipmentId = equipment.Id,
                    Quantity = equipment.Quantity
                };
                equipmentList.Add(reservationEquipment);
            }
            _db.ReservationsEquipment.AddRange(equipmentList);
            _db.SaveChanges();

            transaction.Commit();
        }

        //Metoda służąca do sprawdzenia poprawności tworzonej rezerwacji
        //zwracająca model uzupełniony o zliczoną cenę 
        //TODO (Rozbić to na dwie osobne metody)
        public ReservationFullFormModel ValidateReservation(ReservationFormModel model, ModelStateDictionary modelState)
        {
            //TODO Sprawdzenie czy w wybranym terminie są dostępne boiska dla danego typu
            throw new NotImplementedException();
        }

        //Metoda obliczająca pełną kwotę rezerwacji na podstawie wybranego boiska, czasu rezerwacji i wypożyczonego sprzętu
        public double CountReservationPrice(ReservationFormModel model)
        {
            var price = 0.0;
            var pitchPrice = _db.PitchTypes.Where(a => a.PitchTypeId == model.PitchTypeId).FirstOrDefault().PitchTypePrice;
            price += pitchPrice * (model.Duration / 60.0);

            foreach (var equipment in model.EquipmentList)
            {
                var equipmentPrice = _db.Equipment.Where(a => a.Id == equipment.Id).FirstOrDefault().Price;
                price += equipmentPrice * equipment.Quantity * (model.Duration / 60.0);
            }
            return price;
        }


        public void EditReservation(ReservationFormModel model)
        {
            var reservation = _db.Reservations.Where(a => a.ReservationId == model.ReservationId).FirstOrDefault();


        }

        //Metoda usuwająca rezerwację z systemu
        public void DeleteReservaion(int reservationId)
        {
            var reservation = _db.Reservations.Where(a => a.ReservationId == reservationId).FirstOrDefault();

            if (reservation != null)
            {
                reservation.ReservationStatus = (int)ReservationStatusEnum.Deleted;
                _db.SaveChanges();
            }
        }

        //Metoda anulująca rezerwację
        public void CancelReservation(int reservationId)
        {
            var reservation = _db.Reservations.Where(a => a.ReservationId == reservationId).FirstOrDefault();

            if (reservation != null)
            {
                reservation.ReservationStatus = (int)ReservationStatusEnum.Canceled;
                _db.SaveChanges();
            }
        }
    }
}
