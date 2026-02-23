using Day4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day4.Controllers
{
    public class TodoController : Controller
    {
         public static List<CV> _danhsach = new List<CV>()
            {
                new CV { Id = 1, Name = "Đi chợ", status = false },
                new CV { Id = 2, Name = "Chơi thể thao", status = true },
                new CV { Id = 3, Name = "Chơi game", status = false },
                new CV { Id = 4, Name = "Học bài", status = true },
                new CV { Id = 5, Name = "Chạy bộ", status = false }
            };

        [HttpGet]
        public IActionResult Index()
        {
            
            return View(_danhsach);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CV cvMoi)
        {
            cvMoi.Id = _danhsach.Count + 1;
            _danhsach.Add(cvMoi);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var congViec = _danhsach.FirstOrDefault(x => x.Id == id);
            if (congViec == null) return NotFound();
            return View(congViec);
        }
        [HttpPost]
        public IActionResult Edit(CV cvDaSua)
        {
            var cvCu = _danhsach.FirstOrDefault(x => x.Id == cvDaSua.Id);

            if (cvCu != null)
            {
                cvCu.Name = cvDaSua.Name;
                cvCu.status = cvDaSua.status;
            }
            return RedirectToAction("Index");
        }
    }

    
}
