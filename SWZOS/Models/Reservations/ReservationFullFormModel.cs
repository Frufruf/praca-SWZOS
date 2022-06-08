
namespace SWZOS.Models.Reservations
{
    public class ReservationFullFormModel: ReservationFormModel
    {
        public ReservationFullFormModel(ReservationFormModel reservation)
        {
            ReservationId = reservation.ReservationId;

        }

        public int PitchId { get; set; }
        public double Price { get; set; }
    }
}
