using System.ComponentModel.DataAnnotations;

namespace APIproje.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
