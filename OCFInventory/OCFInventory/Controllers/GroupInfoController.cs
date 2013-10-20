using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCFInventory.Models;


namespace OCFInventory.Controllers 
{
    public class GroupInfoController : Controller
    {
        GroupInfoDAL objDs;
        public GroupInfoController()
        {
            objDs = new GroupInfoDAL();
        }
        // 
        // GET: /Group/
        
        public ActionResult Index()
        {
            var Groups = objDs.GetGroups();
            return View(Groups);
        }
        // 
        // GET: /Group/Details/5
        public ActionResult Details(int id)
        {
            GroupInfo group = objDs.GetGroupById(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group); 
        }
        // 
        // GET: /Group/Create 
        public ActionResult Create()
        {
            var Grp = new GroupInfo();
            return View(Grp);
        }
        // 
        // POST: /Group/Create 
        [HttpPost]
        public ActionResult Create(GroupInfo Grp)
        {
            try
            {
                Grp.LastUpdated = DateTime.Now;
                objDs.CreateGroup(Grp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // 
        // GET: /Group/Edit/5 
        public ActionResult Edit(int id)
        {
            var Grp = objDs.GetGroupById(id);
            return View(Grp);
        }
        // 
        // POST: /Group/Edit/5 
        [HttpPost]
        public ActionResult Edit(int id, GroupInfo Grp)
        {
            try
            {
                objDs.UpdateGroup(Grp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // 
        // GET: /Group/Delete/5 
        public ActionResult Delete(int id)
        {
            var Grp = objDs.GetGroupById(id);
            return View(Grp);
        }
        // 
        // POST: /Group/Delete/5 
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var Grp = objDs.GetGroupById(id);
                objDs.DeleteGroup(Grp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

