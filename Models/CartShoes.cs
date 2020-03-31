namespace shoestoore.Models
{
    public class CartShoes
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ShoeId { get; set; }
    }

    public class DBCartShoe : CartShoes
    {
        public int csId { get; set; }
    }
}