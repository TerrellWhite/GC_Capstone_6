using GC_Cap_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GC_Cap_6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            todolistEntities ORM = new todolistEntities();
            ViewBag.task = ORM.tasks.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Switch(int id)
        {
            todolistEntities ORM = new todolistEntities();
            task Oldtask = ORM.tasks.Find(id);
            Oldtask.done = true;
            ORM.Entry(Oldtask).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("Index"); //that will run the action first of index then runs the view

        }
        public ActionResult NewTask()
        {
            return View();
        }
        public ActionResult SaveNewTask(task newTask)
        {
            todolistEntities ORM = new todolistEntities(); //need this is every operation that takes in information

            //ToDo : validation

            ORM.tasks.Add(newTask);
            ORM.SaveChanges(); //sync with the database

            return RedirectToAction("Index");
        }
    }
}