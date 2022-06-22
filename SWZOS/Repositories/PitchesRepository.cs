using Serilog;
using SWZOS.Models.Pitches;
using SWZOS_Database;
using System.Collections.Generic;
using System.Linq;
using static SWZOS_Database.Enum;

namespace SWZOS.Repositories
{
    public class PitchesRepository: BaseRepository
    {
        public PitchesRepository(SWZOSContext database): base(database)
        {

        }

        public PitchTypeModel GetPitchType(int typeId)
        {
            return _db.PitchTypes.Where(a => a.PitchTypeId == typeId).Select(a => new PitchTypeModel
            {
                PitchTypeId = a.PitchTypeId,
                PitchTypeName = a.PitchTypeName,
                PitchTypePrice = a.PitchTypePrice
            }).FirstOrDefault();
        }

        public List<PitchTypeModel> GetAllPitchTypes()
        {
            return _db.PitchTypes.Select(a => new PitchTypeModel
            {
                PitchTypeId = a.PitchTypeId,
                PitchTypeName = a.PitchTypeName,
                PitchTypePrice = a.PitchTypePrice
            }).ToList();
        }

        public PitchModel GetPitch(int pitchId)
        {
            return _db.Pitches.Where(a => a.PitchId == pitchId).Select(a => new PitchModel
            {
                PitchId = a.PitchId,
                PitchTypeId = a.PitchTypeId,
                PitchTypeName = a.PitchType.PitchTypeName,
                ActiveFlag = a.ActiveFlag,
                Desription = a.Desription,
                OutOfServiceStartDate = a.OutOfServiceStartDate,
                OutOfServiceEndDate = a.OutOfServiceEndDate,
                OutOfServiceReason = a.OutOfServiceReason
            }).FirstOrDefault();
        }

        public List<PitchModel> GetAllPitches()
        {
            return _db.Pitches.Select(a => new PitchModel
            {
                PitchId = a.PitchId,
                PitchTypeId = a.PitchTypeId,
                PitchTypeName = a.PitchType.PitchTypeName,
                ActiveFlag = a.ActiveFlag,
                Desription = a.Desription,
                OutOfServiceStartDate = a.OutOfServiceStartDate,
                OutOfServiceEndDate = a.OutOfServiceEndDate,
                OutOfServiceReason = a.OutOfServiceReason
            }).ToList();
        }

        public void EditPitchType(PitchTypeModel model)
        {
            var type = _db.PitchTypes.Where(a => a.PitchTypeId == model.PitchTypeId).FirstOrDefault();

            type.PitchTypePrice = model.PitchTypePrice;
            _db.SaveChanges();
        }

        public void EditPitch(PitchModel model)
        {
            var transaction = _db.Database.BeginTransaction();
            var pitch = _db.Pitches.Where(a => a.PitchId == model.PitchId).FirstOrDefault();

            if (pitch == null)
            {
                Log.Logger.Error("Przy edycji boiska wystąpił błąd, pitch == null");
                return;
            }

            pitch.ActiveFlag = model.ActiveFlag;
            pitch.Desription = model.Desription;
            pitch.OutOfServiceStartDate = model.OutOfServiceStartDate;
            pitch.OutOfServiceEndDate = model.OutOfServiceEndDate;
            pitch.OutOfServiceReason = model.OutOfServiceReason;
            SaveChanges();
            
            //TODO
            //Boisko wyłączone z użytku trzeba przenieść wszystkie rezerwacje
            //a w razie braku takiej możliwości usunąć i wysłać powiadomienie
            if (model.ActiveFlag == false)
            {
                var reservations = _db.Reservations.Where(a => a.PitchId == pitch.PitchId).ToList();

                foreach (var res in reservations)
                {
                    var endDate = res.ReservationStartDate.AddMinutes(res.ReservationDuration);
                    var busyPitches = _db.Reservations.Where(a => a.ReservationId != res.ReservationId
                                        && a.Pitch.PitchTypeId == pitch.PitchTypeId
                                        && a.ReservationStartDate > res.ReservationStartDate
                                        && a.ReservationStartDate < endDate
                                        && a.ReservationStatus != (int)ReservationStatusEnum.Canceled
                                        && a.ReservationStatus != (int)ReservationStatusEnum.Deleted).Select(a => a.PitchId).ToList();

                    var reservationPitchId = _db.Pitches.Where(a => a.PitchId != pitch.PitchId
                                        && (a.ActiveFlag || a.OutOfServiceEndDate < res.ReservationStartDate)
                                        && !busyPitches.Contains(a.PitchId)).Select(a => a.PitchId).FirstOrDefault();
                    if (reservationPitchId == 0)
                    {
                        //Usunięcie rezerwacji i wysłanie wiadomości do klienta
                        //TODO wysłanie wiadomości
                        res.ReservationStatus = (int)ReservationStatusEnum.Canceled;                        
                    }
                    else
                    {
                        res.PitchId = reservationPitchId;
                    }
                    SaveChanges();
                }
            }

            transaction.Commit();
        }

    }
}
