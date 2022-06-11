
namespace SWZOS.Models.Reservations
{
    public class ReservationFullFormModel: ReservationFormModel
    {
        public ReservationFullFormModel(ReservationFormModel reservation)
        {
            ReservationId = reservation.ReservationId;
            UserId = reservation.UserId;
            PitchTypeId = reservation.PitchTypeId;
            StartDate = reservation.StartDate;
            Duration = reservation.Duration;
            Description = reservation.Description;
            IsEditForm = reservation.IsEditForm;
            EquipmentList = reservation.EquipmentList;
        }

        public int PitchId { get; set; }
        public double Price { get; set; }
    }
}
