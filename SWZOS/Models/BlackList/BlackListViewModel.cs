namespace SWZOS.Models.BlackList
{
    public class BlackListViewModel
    {
        //Klucz główny użytkownika
        public int UserId { get; set; }
        //Klucz statusu
        public int StatusId { get; set; }
        public string FullName { get; set; }
        public string Reason { get; set; }
    }
}
