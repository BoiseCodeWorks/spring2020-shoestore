using System.ComponentModel.DataAnnotations;

namespace shoestoore.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Size { get; set; }
        public float Price { get; set; }
    }
}