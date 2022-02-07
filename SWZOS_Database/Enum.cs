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
            Canceled = 1,
            Paid = 2
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

        }
    }
}
