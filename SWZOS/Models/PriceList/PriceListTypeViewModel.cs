using System.Collections.Generic;

namespace SWZOS.Models.PriceList
{
    public class PriceListTypeViewModel
    {
        public string PriceListItemTypeName { get; set; }
        public int PriceListItemType { get; set; }
        public List<PriceListViewModel> PriceList { get; set; }
    }
}
