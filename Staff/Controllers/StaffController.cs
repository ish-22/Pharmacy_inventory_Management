
using Staff.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staff.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Staffs.ToList());
            }
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Staffs.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(Models.Staff staff)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Staffs.Add(staff);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Staffs.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Models.Staff staff)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Entry(staff).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Staffs.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.Staff staff)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    Models.Staff sta = dbModel.Staffs.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Staffs.Remove(sta);  // FIXED: dbModel.Admins, not dbModel.Drugs
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
