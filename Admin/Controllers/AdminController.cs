using Admin.Models;  // This namespace contains the Admin class
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers  // Namespace is Admin
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Admins.ToList());
            }
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Admins.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Models.Admin admin)  // FIXED: Fully qualify Admin class
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Admins.Add(admin);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Admins.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.Admin admin)  // FIXED
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Entry(admin).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Admins.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.Admin admin)  // FIXED
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    Models.Admin admin1 = dbModel.Admins.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Admins.Remove(admin1);  // FIXED: dbModel.Admins, not dbModel.Drugs
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
