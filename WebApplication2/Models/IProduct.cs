using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public interface IProduct
    {
        bool? Active { get; set; }
        [Required]
        decimal? Price { get; set; }
        int ProductId { get; set; }
        string ProductName { get; set; }
        decimal? Stock { get; set; }
    }
}