using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;


public class EmployeeController : Controller

{
    private EMSContext db;
    public EmployeeController(EMSContext _db)
    {
        db =_db;

    }
    public ActionResult Index()
    {
        //List<Person> employees = Person.GetPerson();
       var employees =db.Employees.Include(x => x.Department).ToList();
        
        return View(employees);
    }
    public ActionResult Detail(int id)
    {
        var employee=db.Employees.Find(id);
        return View(employee);
        
        
    }
    public ActionResult Add()
    {
        var departments = db.Departments.ToList();
        ViewData["depOptions"] = departments;
        return View();
    }

    [HttpPost]
    public ActionResult Add(Person person)  // Model binding
    {
        db.Employees.Add(person);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public ActionResult Delete(int id)
    {
        var employee = db.Employees.Find(id);
        return View(employee);
    }


    [HttpPost]
    public ActionResult Delete(Person employee)
    {
        db.Employees.Attach(employee);
        db.Employees.Remove(employee);
        db.SaveChanges();

        //var rowsAffected=db.SaveChanges();
        return RedirectToAction(nameof(Index));


    }
    public ActionResult Edit(int id)
    {
        var employee=db.Employees.Find(id);
        

        //var rowsAffected=db.SaveChanges();
        
        return View(employee);


    }

    [HttpPost]
    public ActionResult Edit(Person person)
    {
        db.Employees.Attach(person);
        
        db.Employees.Update(person);
        db.SaveChanges();
        
        return RedirectToAction(nameof(Index));


    }

}
