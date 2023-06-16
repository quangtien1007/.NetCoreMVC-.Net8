using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Models
{
    public class BooksViewModel
    {
        public List<Category>? Categories { get; set; }

        public string? SearchString { get; set; }
    }
}
