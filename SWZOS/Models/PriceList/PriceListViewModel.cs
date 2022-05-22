namespace SWZOS.Models.PriceList
{
    public class PriceListViewModel
    {
        public int Id { get; set; }
        //Nazwa usługi
        public string Name { get; set; }
        //Cena za godzinę
        public double Price { get; set; }
        //Opis pozycji w cenniku
        public string Description { get; set; }

    }
}
