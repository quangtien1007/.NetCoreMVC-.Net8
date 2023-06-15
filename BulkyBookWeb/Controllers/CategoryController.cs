using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList(); //Lay tat ca cac the loai voi dang List
            return View(objCategoryList); // Pass du lieu den view
        }

        //Truy cap den trang Create va hien thi du lieu
        public IActionResult Create()
        {
            return View();
        }

        //Thuc hien them du lieu
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid) //Validation form
            {
                _db.Categories.Update(obj); //Them du lieu 
                _db.SaveChanges(); // Luu du lieu da them vao 
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index"); //Tro ve trang Index
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //Thuc hien sua du lieu
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            //Ten khong duoc trung voi Display Order
            if (obj.Name != null && obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot exactly match Name");
            }
            if (ModelState.IsValid) //Validation form
            {
                _db.Categories.Add(obj); //Them du lieu 
                _db.SaveChanges(); // Luu du lieu da them vao 
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
