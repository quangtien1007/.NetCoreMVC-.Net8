using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Models
{
    public class ProductsViewModel
    {
        public List<Category>? Categories { get; set; }
        public List<Product>? Products { get; set; }
        public SelectList? Cate { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryID { get; set; }
    }
}
