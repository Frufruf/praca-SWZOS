namespace SWZOS.Models.Account
{
    public class PasswordChangeModel
    {     
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}
