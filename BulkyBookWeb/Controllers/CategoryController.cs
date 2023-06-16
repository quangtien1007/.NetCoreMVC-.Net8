using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (_db.Categories == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var books = from m in _db.Categories select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Name!.Contains(searchString));
            }

            var movieGenreVM = new BooksViewModel
            {
                Categories = await books.ToListAsync()
            };

            return View(movieGenreVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        //Truy cap den trang Create va hien thi du lieu
        public IActionResult Create()
        {
            return View();
        }

        //Thuc hien them du lieu
        [HttpPost]
        public async Task<IActionResult> Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);//Them du lieu 
                await _db.SaveChangesAsync(); // Luu du lieu da them vao 
                TempData["success"] = "Create sucessfully";
                return RedirectToAction("Index");//Tro ve trang Index
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cate = await _db.Categories.FindAsync(id);
            if(cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        //Thuc hien sua du lieu
        [HttpPost]
        public async Task<IActionResult> Edit(Category obj)
        {
            //Ten khong duoc trung voi Display Order
            if (obj.Name != null && obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot exactly match Name");
            }
            if (ModelState.IsValid) //Validation form
            {
                _db.Update(obj); //Them du lieu 
                await _db.SaveChangesAsync();// Luu du lieu da them vao 
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index"); //Tro ve trang Index
            }
            return View();
        }

        //Thuc hien xoa du lieu
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
