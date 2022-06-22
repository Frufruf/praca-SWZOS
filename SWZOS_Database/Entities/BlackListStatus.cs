using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    public class BlackListStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BlackList> BlackLists { get; set; }
    }
}
