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
            _db.Categories.Add(obj); //Them du lieu 
            _db.SaveChanges(); // Luu du lieu da them vao DB
            return RedirectToAction("Index"); //Tro ve trang Index
        }
    }
}
