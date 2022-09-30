namespace SWZOS.Models.User
{
    public class UserSimpleModel
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
    }
}
