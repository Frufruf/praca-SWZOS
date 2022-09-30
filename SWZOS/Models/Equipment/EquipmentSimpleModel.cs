namespace SWZOS.Models.Equipment
{
    public class EquipmentSimpleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int MaximumAmountPerReservation { get; set; }
        public double Price { get; set; }
    }
}
