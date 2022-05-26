using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        // переменная для взаимодействия с бд
        private PhoneDBContext db;
        public HomeController(PhoneDBContext context)
        {
            db = context;
        }

        // методы, которые будут добавлять новый объект в базу данных и выводить из нее все объекты
        public IActionResult Index()
        {
            // Готовим данные для представления
            ViewData["Title"] = "Автомобили";
            var Phs = db.Phs.Include(a => a.Brand).ToList();
            // Передаем управление "Представлению"
            return View(Phs);
        }

        // ************* Добавить/Создать телефон **************
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Compans = new SelectList(db.Avts, "Id", "Name");
            Phone phone = new Phone();
            return View(phone);
        }
        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            db.Phs.Add(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ************* Редактировать данные телефона **************
        [HttpGet]
        public IActionResult EditPhone(int Id)
        {
            var phone = db.Phs.FirstOrDefault(p => p.Id == Id);
            ViewBag.Compans = new SelectList(db.Avts, "Id", "Name");
            return View(phone);
        }

        [HttpPost]
        public IActionResult EditPhone(Phone phone)
        {
           db.Phs.Update(phone);
           db.SaveChanges();
           return RedirectToAction("Index");
        }

        // ************* Удалить телефон **************
        public IActionResult Delete(Phone phone)
        {
            db.Phs.Attach(phone);
            db.Phs.Remove(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Show_brand(int id)
        {
            var instr = db.Avts.FirstOrDefault(b => b.Id == id);
            var mus = db.Phs.Where(x => x.BrandId == id);
            ViewData["Phs"] = mus;
            return View(instr);
        }

        // ************* Редактировать данные бренда телефона **************
        [HttpGet]
        public IActionResult Edit_brand(int Id)
        {
            var brand = db.Avts.FirstOrDefault(p => p.Id == Id);
            ViewBag.Compans = new SelectList(db.Avts, "Id", "Name");
            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit_brand(Brand brand)
        {
            //if (ModelState.IsValid)
            //{
                db.Avts.Update(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View();
        }



    }
}