using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    public class PaymentStatus
    {
        //PK
        public int PaymentStatusId { get; set; }
        //Nazwa statusu
        public string Name { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
