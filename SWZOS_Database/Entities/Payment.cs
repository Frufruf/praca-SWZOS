using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Entities
{
    public class Payment
    {
        //PK
        public int PaymentId { get; set; }
        //Klucz obcy rezerwacji
        public int ReservationId { get; set; }
        //Klucz obcy użytkownika na którego nałożona jest płatność (bez relacji)
        public int UserId { get; set; }
        //Pełna kwota do zapłaty
        public double FullFee { get; set; }
        //Kwota wymaganej zaliczki
        public double? AdvancePayment { get; set; }
        //Ilość wpłaconej kwoty
        public double PaidInAmmount { get; set; }
        //Klucz obcy statusu płatności
        public int StatusId { get; set; }
        //Opis płatności
        public string Description { get; set; }
        public Reservation Reservation { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
