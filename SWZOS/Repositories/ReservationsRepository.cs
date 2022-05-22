using SWZOS.Models.Reservations;
using SWZOS_Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWZOS.Repositories
{
    public class ReservationsRepository: BaseRepository
    {
        public ReservationsRepository(SWZOSContext db): base(db)
        {

        }

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

        public void AddReservation()
        {

        }

        public void EditReservation()
        {

        }

        public void DeleteReservaion()
        {

        }
    }
}
