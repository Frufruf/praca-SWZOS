namespace SWZOS.Models.BlackList
{
    public class BlackListViewModel
    {
        public int Id { get; set; }
        //Klucz główny użytkownika
        public int UserId { get; set; }
        //Klucz statusu
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string FullName { get; set; }
        public string Reason { get; set; }
    }
}
