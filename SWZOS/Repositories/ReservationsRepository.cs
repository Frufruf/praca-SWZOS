using Microsoft.AspNetCore.Mvc.ModelBinding;
using Serilog;
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

        //Metoda pobierająca wszystkie rezerwacje w dniu dzisiejszym
        public List<ReservationsViewModel> GetReservationsByDate(DateTime startDate, DateTime endDate)
        {
            var result = _db.Reservations.Where(a => a.ReservationStartDate.Day >= startDate.Day 
                                    && a.ReservationStartDate.Day <= endDate.Day 
                                    && a.ReservationStatus != (int)ReservationStatusEnum.Canceled
                                    && a.ReservationStatus != (int)ReservationStatusEnum.Deleted)
            .Select(a => new ReservationsViewModel
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
            var reservation = new Reservation
            {
                PitchId = model.PitchId,
                UserId = model.UserId,
                ReservationStartDate = model.StartDate,
                ReservationDuration = model.Duration,
                ReservationPrice = model.Price,
                ReservationStatus = (int)ReservationStatusEnum.Active,
                Description = model.Description,
            };

            _db.Reservations.Add(reservation);
            _db.SaveChanges();

            if (model.EquipmentList != null)
            {
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
            }
        }

        //Metoda służąca do sprawdzenia poprawności tworzonej rezerwacji
        //zwracająca model uzupełniony o zliczoną cenę 
        //TODO (Rozbić to na dwie osobne metody)
        public ReservationFullFormModel ValidateReservation(ReservationFormModel model, ModelStateDictionary modelState)
        {
            //Blokowanie edycji typu boiska
            if (model.IsEditForm)
            {
                var old = _db.Reservations.Where(a => a.ReservationId == model.ReservationId).FirstOrDefault();
                if (old.Pitch.PitchTypeId != model.PitchTypeId)
                {
                    modelState.AddModelError("", "Nie możesz zmienić typu zarezerwowanego boiska, w tym celu anuluj obecną rezerwację i utwórz nową");
                    return null;
                }
            }       
            //Sprawdzenie czy w wybranym terminie są dostępne boiska dla danego typu
            //wywoływane również przy edycji (w przypadku zmiany godziny trzeba przypisać nowe boisko)
            var endDate = model.StartDate.AddMinutes(model.Duration);
            var busyPitches = _db.Reservations.Where(a => a.ReservationId != model.ReservationId 
                                        && a.Pitch.PitchTypeId == model.PitchTypeId
                                        && a.ReservationStartDate > model.StartDate
                                        && a.ReservationStartDate < endDate
                                        && a.ReservationStatus != (int)ReservationStatusEnum.Canceled
                                        && a.ReservationStatus != (int)ReservationStatusEnum.Deleted).Select(a => a.PitchId).ToList();

            var reservationPitchId = _db.Pitches.Where(a => (a.ActiveFlag || a.OutOfServiceEndDate < model.StartDate)
                                        && !busyPitches.Contains(a.PitchId)).Select(a => a.PitchId).FirstOrDefault();
            if (reservationPitchId == 0)
            {
                modelState.AddModelError("", "Brak wolnych boisk w wybranym terminie");
                return null;
            }
          
            if (model.EquipmentList != null && model.EquipmentList.Count > 0)
            {
                foreach (var equipment in model.EquipmentList)
                {
                    var eq = _db.Equipment.Where(a => a.Id == equipment.Id).FirstOrDefault();
                    if (eq == null)
                    {
                        modelState.AddModelError("", "Wystąpił błąd przy próbie wypożyczenia sprzętu");
                        return null;
                    }
                    //Sprawdzenie czy nie przekroczono maksymalnej dozwolonej ilości sprzętu dostępnego dla rezerwacji
                    if (equipment.Quantity > eq.MaximumQuantityPerReservation)
                    {
                        modelState.AddModelError("", "Przekroczono maksymalną wartość dostępnego sprzętu dla " + eq.Name 
                                                    + ". Możesz wypożyczyć maksymalnie " + eq.MaximumQuantityPerReservation + " sztuk.");
                        return null;
                    }
                    //Sprawdzenie czy wypożyczony sprzęt odpowiada boisku
                    if (!_db.PitchTypeEquipment.Where(a => a.PitchTypeId == model.PitchTypeId && a.EquipmentId == equipment.Id).Any())
                    {
                        modelState.AddModelError("", "Na wybrany typ obiektu nie możesz wypożyczyć " + eq.Name);
                    }

                }
            }

            var reservation = new ReservationFullFormModel(model);
            reservation.PitchId = reservationPitchId;
            reservation.Price = CountReservationPrice(model);            
            return reservation;
        }

        //Metoda obliczająca pełną kwotę rezerwacji na podstawie wybranego boiska, czasu rezerwacji i wypożyczonego sprzętu
        public double CountReservationPrice(ReservationFormModel model)
        {
            var price = 0.0;
            var pitchPrice = _db.PitchTypes.Where(a => a.PitchTypeId == model.PitchTypeId).FirstOrDefault().PitchTypePrice;
            price += pitchPrice * (model.Duration / 60.0);

            if (model.EquipmentList != null)
            {
                foreach (var equipment in model.EquipmentList)
                {
                    var equipmentPrice = _db.Equipment.Where(a => a.Id == equipment.Id).FirstOrDefault().Price;
                    price += equipmentPrice * equipment.Quantity * (model.Duration / 60.0);
                }
            }
            return price;
        }


        public void EditReservation(ReservationFullFormModel model)
        {
            var transaction = _db.Database.BeginTransaction();
            var reservation = _db.Reservations.Where(a => a.ReservationId == model.ReservationId).FirstOrDefault();

            reservation.ReservationStartDate = model.StartDate;
            reservation.ReservationDuration = model.Duration;
            reservation.Description = model.Description;
            

            //Usunięcie i ponowne przypisanie wyposażenia do rezerwacji
            var equipment = _db.ReservationsEquipment.Where(a => a.ReservationId == reservation.ReservationId).ToList();
            _db.ReservationsEquipment.RemoveRange(equipment);
            _db.SaveChanges();

            var equipmentList = new List<ReservationEquipment>();
            foreach (var eq in model.EquipmentList)
            {
                var reservationEquipment = new ReservationEquipment
                {
                    ReservationId = reservation.ReservationId,
                    EquipmentId = eq.Id,
                    Quantity = eq.Quantity
                };
                equipmentList.Add(reservationEquipment);
            }
            _db.ReservationsEquipment.AddRange(equipmentList);
            _db.SaveChanges();
            transaction.Commit();
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
