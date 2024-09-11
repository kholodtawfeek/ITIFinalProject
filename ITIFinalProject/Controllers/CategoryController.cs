using Microsoft.AspNetCore.Mvc;
using ITIFinalProject.Context;
using ITIFinalProject.Models;
using ITIFinalProject.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITIFinalProject.Controllers
{
    public class CategoryController : Controller
    {
        MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var _Cates = db.Categories;
            return View(_Cates);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _OneCate = db.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
            return View(_OneCate);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _Category = db.Categories.FirstOrDefault(c => c.Id == id);
            return View(_Category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var _DeletedCategory = db.Categories.Find(id);
            if(_DeletedCategory == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(_DeletedCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
