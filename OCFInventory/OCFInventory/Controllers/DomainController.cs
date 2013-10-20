using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCFInventory.Models;


namespace OCFInventory.Controllers 
{
    public class DomainController : Controller
    {
        DomainDAL objDs;
        public DomainController()
        {
            objDs = new DomainDAL();
        }
        // 
        // GET: /Domain/ 
        public ActionResult Index()
        {
            var Domains = objDs.GetDomains();
            return View(Domains);
        }
        // 
        // GET: /Domain/Details/5
        public ActionResult Details(int id)
        {
            Domain domain = objDs.GetDomainById(id);
            if (domain == null)
            {
                return HttpNotFound();
            }
            return View(domain); 
        }
        // 
        // GET: /Domains/Create 
        public ActionResult Create()
        {
            var domain = new Domain();
            return View(domain);
        }
        // 
        // POST: /Person/Create 
        [HttpPost]
        public ActionResult Create(Domain domain)
        {
            try
            {
                objDs.CreateDomain(domain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // 
        // GET: /Domain/Edit/5 
        public ActionResult Edit(int id)
        {
            var domain = objDs.GetDomainById(id);
            return View(domain);
        }
        // 
        // POST: /Domain/Edit/5 
        [HttpPost]
        public ActionResult Edit(int id, Domain domain)
        {
            try
            {
                objDs.UpdateDomain(domain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // 
        // GET: /Domain/Delete/5 
        public ActionResult Delete(int id)
        {
            var domain = objDs.GetDomainById(id);
            return View(domain);
        }
        // 
        // POST: /Domain/Delete/5 
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var domain = objDs.GetDomainById(id);
                objDs.DeleteDomain(domain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

