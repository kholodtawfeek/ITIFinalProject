using Microsoft.AspNetCore.Mvc;
using ITIFinalProject.Context;
using ITIFinalProject.Models;
using ITIFinalProject.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace ITIFinalProject.Controllers
{
    public class ProductController : Controller
    {
        MyContext db = new MyContext();

        public ActionResult Index()
        {
            var _Products = db.Products.Include(p => p.category);
            return View(_Products);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _OneProduct = db.Products.Include(p => p.category).FirstOrDefault(p => p.Id == id);
            return View(_OneProduct);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Category = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ModelState.Remove("category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Category = new SelectList(db.Categories, "Id", "Name");
                return View();
            }
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //نرفرش الداتا اللي هنعدلها
            var _Product = db.Products.Include(p => p.category).FirstOrDefault(p => p.Id == id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            //الحاجة اللي تخلينا نعرف نعدل عليها
            //بتخلي اسم الكاتيجوري المرتبط بالمنتج يظهر عن طريق الفوريجن كي عشان نعرف نعدل فيه
            ViewBag._Category = new SelectList(db.Categories, "Id", "Name");
            //هتعملي ربط ما بين الكاتيجوري اي دي و اسم الكاتيجوري
            return View(_Product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ModelState.Remove("category");
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "All Fields Required");
            //    ViewBag._Category = new SelectList(db.Categories, "Id", "Name");
            //    return View();
            //}
            db.Products.Update(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            //فايند بتدور علي الاي دي بتاع المنتج اللي هيتمسح في الداتابيز 
            var _DeletedProduct = db.Products.Find(id);
            //in case it was not found
            if (_DeletedProduct == null)
            {
                return RedirectToAction("Index");
            }
            db.Products.Remove(_DeletedProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
