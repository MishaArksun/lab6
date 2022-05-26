namespace web.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public uint Price { get; set; }

        public int BrandId { get; set; } // ссылка на бренд
        public Brand Brand { get; set; }
    }
}
