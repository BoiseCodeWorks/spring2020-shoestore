using System.ComponentModel.DataAnnotations;

namespace shoestoore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}