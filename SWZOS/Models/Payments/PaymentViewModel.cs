namespace SWZOS.Models.Payments
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public double FullFee { get; set; }
        public double? AdvancePayment { get; set; }
        public double PaidInAmmount { get; set; }
        public int StatusId { get; set; }
        public string Description { get; set; }
    }
}
