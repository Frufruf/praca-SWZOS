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
        //Powód wpisania na czarną listę
        public string Reason { get; set; }
        //Flaga obsługująca usunięcie z czarnej listy
        public bool DeletedFlag { get; set; }
    }
}
