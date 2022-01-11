using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller

    {
        private EMSContext db;
        public DepartmentController(EMSContext _db)
        {
            db = _db;

        }
        public ActionResult Index()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }
        public ActionResult Detail(int id)
        {

            var departments = db.Departments.Include(x => x.Employees);
            var department = departments.FirstOrDefault(x => x.Id == id);
            return View(department);


        }
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();

            //var rowsAffected=db.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public ActionResult Delete(int id)
        {

            var department = db.Departments.Find(id);
            return View(department);


        }

        [HttpPost]
        public ActionResult Delete(Department department)
        {

            db.Departments.Attach(department);
            db.Departments.Remove(department);
            db.SaveChanges();

            //var rowsAffected=db.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
        public ActionResult Edit(int id)
        {
            var department = db.Departments.Find(id);
            return View(department);


        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            db.Departments.Attach(department);

            db.Departments.Update(department);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));


        }

    }


}
