using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCFInventory.Models;


namespace OCFInventory.Controllers 
{
    public class PersonController : Controller
    {
        PersonDAL objDs;
        public PersonController()
        {
            objDs = new PersonDAL();
        }
        // 
        // GET: /Person/ 
        public ActionResult Index()
        {
            var People = objDs.GetPeople();
            return View(People);
        }
        // 
        // GET: /Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // 
        // GET: /Person/Create 
        public ActionResult Create()
        {
            var person = new Person();
            return View(person);
        }
        // 
        // POST: /Person/Create 
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                objDs.CreatePerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // 
        // GET: /Person/Edit/5 
        public ActionResult Edit(int id)
        {
            var Emp = objDs.GetPersonById(id);
            return View(Emp);
        }
        // 
        // POST: /Person/Edit/5 
        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            try
            {
                objDs.UpdatePerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // 
        // GET: /Person/Delete/5 
        public ActionResult Delete(int id)
        {
            var person = objDs.GetPersonById(id);
            return View(person);
        }
        // 
        // POST: /Person/Delete/5 
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var person = objDs.GetPersonById(id);
                objDs.DeletePerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

