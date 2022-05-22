namespace SWZOS.Models.BlackList
{
    public class BlackListFormModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int StatusId { get; set; }
        public string Reason { get; set; }
    }
}
