namespace SWZOS.Models.BlackList
{
    public class BlackListFormModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int StatusId { get; set; }
        public string Reason { get; set; }
    }
}
