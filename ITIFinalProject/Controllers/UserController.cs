using Microsoft.AspNetCore.Mvc;
using ITIFinalProject.Context;
using ITIFinalProject.Models;
using ITIFinalProject.Controllers;

namespace ITIFinalProject.Controllers
{
    public class UserController : Controller
    {
        MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var _Users = db.Users;
            return View(_Users);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _OneU = db.Users.FirstOrDefault(u => u.Id == id);
            return View(_OneU);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, int password)
        {
            var user = db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return RedirectToAction("Index", "Product");
            }

            ModelState.AddModelError("", "Wrong Email or Password");
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _User = db.Users.FirstOrDefault(u => u.Id == id);
            return View(_User);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var _DeletedUser = db.Users.Find(id);
            if (_DeletedUser == null)
            {
                return RedirectToAction("Index");
            }
            db.Users.Remove(_DeletedUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
