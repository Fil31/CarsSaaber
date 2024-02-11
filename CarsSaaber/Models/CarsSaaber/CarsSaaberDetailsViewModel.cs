namespace CarsSaaber.Models.CarsSaaber
{
    public class CarsSaaberDetailsViewModel
    {
        public Guid? Id { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
