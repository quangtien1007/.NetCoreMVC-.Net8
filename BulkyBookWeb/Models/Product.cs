using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBookWeb.Models
{
    [Table("Product")]   
    
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }
    }
}
