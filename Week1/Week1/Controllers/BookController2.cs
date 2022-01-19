using Microsoft.AspNetCore.Mvc;
using Week1.Data;

namespace Week1.Controllers
{
    public class BookController2 : Controller
    {
        public readonly AppDbContext db;

        public BookController2(AppDbContext db)
        {
            this.db = db;
            
        }
        public IActionResult Index()
        {
            var lst = db.demoInfo.ToList();
            return View();
        }
    }
}
