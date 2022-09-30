using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database
{
    public class Enum
    {
        public enum UserTypesEnum
        {
            Admin = 1,
            Employee = 2,
            Customer = 3
        }

        public enum PitchTypesEnum
        {
            Football = 1,
            Tennis = 2,
            Basketball = 3,
            Volleyball = 4
        }

        public enum ReservationStatusEnum
        {
            Active = 1,
            Paid = 2,
            Canceled = 3
        }

        public enum BlackListStatusEnum
        {
            WaitingForApproval = 1,
            Approved = 2,
            Rejected = 3,
            Deleted = 4
        }

        public enum PaymentStatusEnum
        {
            NotPaid = 1,
            Paid = 2,
            Delayed = 3,
            Overpaid = 4,
            Canceled = 5
        }

        //Rodzaje pozycji w cenniku
        public enum PriceListItemTypeEnum
        {
            Pitch = 1,
            Equipment = 2,
            Other = 3
        }
    }
}
