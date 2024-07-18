using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DoctorsController : Controller
    {
       // static List<Doctor>  doctor;
            private HospitalDbContext ctx = new HospitalDbContext();
        public DoctorsController() {

            //doctor = new List<Doctor>() {
            //    new Doctor() {Id = 1, FirstName ="Grec", Name = "Stepan", LastName = "Ivanivuch" , Birthday = new DateTime(1985,05,01), Categori = "LOR", Work_experience =5},
            //    new Doctor() {Id = 1, FirstName ="Ivanov", Name = "Stanislav", LastName = "Ivanivuch" , Birthday = new DateTime(1988,11,12), Categori = "TERAPEVT", Work_experience =6},
            //    new Doctor() {Id = 1, FirstName ="Sidorov", Name = "Sergii", LastName = "Romanovich" , Birthday = new DateTime(1981,06,25), Categori = "SURGEON", Work_experience =10},
            //    };
        }
        public IActionResult Index()
        {
            var doctors = ctx.Doctors
                .Include(x => x.Category)
                .Where(x => !x.Archived)
                .ToList();
            return View(doctors);
        }
        public IActionResult Archive()
        {
            // .. load data from database ..
            var doctors = ctx.Doctors
                .Include(x => x.Category) // LEFT JOIN
                .Where(x => x.Archived)
                .ToList();

            return View(doctors);
        }

        // GET: 
        [HttpGet]
        public IActionResult Create()
        {
            // ViewBag.PropertyName = value;
            ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
            //LoadCategories();
            ViewBag.CreateMode = true;

            return View("Upsert");
        }

        
        // POST
        [HttpPost]
        public IActionResult Create(Doctor model)
        {
            // TODO: add data validation
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = false;
                LoadCategories();
                return View("Upsert", model);
            }
            ctx.Doctors.Add(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doctors = ctx.Doctors.Find(id);

            if (doctors == null) return NotFound();

            LoadCategories();
            ViewBag.CreateMode = false;
            return View("Upsert", doctors);
        }

        [HttpPost]
        public IActionResult Edit(Doctor model)
        {
            // TODO: add data validation
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = false;
                LoadCategories();
                return View("Upsert", model);
            }
            ctx.Doctors.Update(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }










        public IActionResult Delete(int id)
        {
            var doctors = ctx.Doctors.Find(id);

            if (doctors == null) return NotFound();

            ctx.Doctors.Remove(doctors);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult ArchiveItem(int id)
        {
            var doctors = ctx.Doctors.Find(id);

            if (doctors == null) return NotFound();

            doctors.Archived = true;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult RestoreItem(int id)
        {
            var doctors = ctx.Doctors.Find(id);

            if (doctors == null) return NotFound();

            doctors.Archived = false;
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }
        private void LoadCategories()
        {
            // ViewBag.PropertyName = value;
            ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
        }
    }
}
