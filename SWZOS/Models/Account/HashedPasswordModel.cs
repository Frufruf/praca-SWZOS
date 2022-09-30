namespace SWZOS.Models.Account
{
    public class HashedPasswordModel
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}
