using SWZOS.Models.PriceList;
using SWZOS_Database;
using System.Collections.Generic;
using System.Linq;
using static SWZOS_Database.Enum;

namespace SWZOS.Repositories
{
    public class PriceListRepository: BaseRepository
    {
        public PriceListRepository(SWZOSContext database): base(database)
        {

        }

        public List<PriceListTypeViewModel> GetPriceListFull()
        {
            var fullPriceList = new List<PriceListTypeViewModel>();
            var pitchesPriceList = _db.PitchTypes.Select(x => new PriceListViewModel
            {
                Id = x.PitchTypeId,
                Price = x.PitchTypePrice,
                Name = x.PitchTypeName,              
                Description = x.Pitches.Where(a => a.PitchTypeId == x.PitchTypeId).FirstOrDefault().Desription
            }).ToList();

            fullPriceList.Add(new PriceListTypeViewModel 
            {
                PriceListItemTypeName = "Boiska",
                PriceListItemType = (int)PriceListItemTypeEnum.Pitch,
                PriceList = pitchesPriceList
            });

            var equipmentPriceList = _db.Equipment.Select(x => new PriceListViewModel
            {
                Id = x.Id,
                Price = x.Price,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            fullPriceList.Add(new PriceListTypeViewModel
            {
                PriceListItemTypeName = "Wyposażenie",
                PriceListItemType = (int)PriceListItemTypeEnum.Equipment,
                PriceList = equipmentPriceList
            });

            return fullPriceList;
        }
    }
}
