using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Docs.Samples;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var products = _db.Products.ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new Products()
                {
                    Name = obj.Name!,
                    Description = obj.Description!,
                    Image = obj.Image!,
                    CategoryID = 1
                };

                _db.Products.Add(obj);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var products = await _db.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return ControllerContext.MyDisplayRouteInfo(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product obj)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Update(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
