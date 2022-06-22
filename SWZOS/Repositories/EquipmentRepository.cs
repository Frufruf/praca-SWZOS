using Serilog;
using SWZOS.Models.Equipment;
using SWZOS_Database;
using SWZOS_Database.Entities;
using System.Linq;

namespace SWZOS.Repositories
{
    public class EquipmentRepository: BaseRepository
    {
        public EquipmentRepository(SWZOSContext database): base(database)
        {

        }

        public void GetFullEquipment()
        {

        }

        public void Add(EquipmentFormModel model)
        {
            var item = new Equipment
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
                MaximumQuantityPerReservation = model.MaximumQuantityPerReservation,
                Description = model.Description,
            };
            _db.Equipment.Add(item);
            SaveChanges();

            foreach(var pitchTypeId in model.PitchTypeIds)
            {
                _db.PitchTypeEquipment.Add(new PitchTypeEquipment { EquipmentId = item.Id, PitchTypeId = pitchTypeId });
            }
            SaveChanges();
        }

        public void Edit(EquipmentFormModel model)
        {
            var item = _db.Equipment.Where(a => a.Id == model.Id).FirstOrDefault();

            if (item == null)
            {
                Log.Logger.Error("W trakcie edycji pozycji w magazynie wystąpił błąd, item == null");
                return;
            }

            item.Name = model.Name;
            item.Quantity = model.Quantity;
            item.Price = model.Price;
            item.MaximumQuantityPerReservation = model.MaximumQuantityPerReservation;
            item.Description = model.Description;
            SaveChanges();

            var pitchTypeEquipment = _db.PitchTypeEquipment.Where(a => a.EquipmentId == item.Id).ToList();
            _db.PitchTypeEquipment.RemoveRange(pitchTypeEquipment);
            SaveChanges();

            foreach (var pitchTypeId in model.PitchTypeIds)
            {
                _db.PitchTypeEquipment.Add(new PitchTypeEquipment { EquipmentId = item.Id, PitchTypeId = pitchTypeId });
            }
            SaveChanges();
        }
    }
}
