using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    public class BlackList
    {
        //PK
        public int Id { get; set; }
        //Klucz obcy użytkownika z zakazem wstępu na teren obiektu
        public int UserId { get; set; }
        //Klucz obcy statusu wpisu na czarną listę
        public int StatusId { get; set; }
        //Powód wpisania na czarną listę
        public string Reason { get; set; }
        //Data dodania wpisu
        //public DateTime Created { get; set; }
        //Id twórcy wpisu
        //public int CreateUserId { get; set; }
       
        public User User { get; set; }
        public BlackListStatus BlackListStatus { get; set; }
    }
}
