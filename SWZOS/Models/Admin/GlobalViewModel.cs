namespace SWZOS.Models.Admin
{
    public class GlobalViewModel
    {
        public string Key { get; set; }
        public string DisplayedValue {
            get 
            {
                return Value.Length > 50 ? Value.Substring(0, 50) + "...": Value;
            }}
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
