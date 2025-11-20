
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacy.Controllers
{
    public class PharmacyController : Controller
    {
        // GET: Pharmacy
        public ActionResult Index()
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.pharmacies.ToList());
            }
        }

        // GET: Pharmacy/Details/5
        public ActionResult Details(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.pharmacies.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Pharmacy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pharmacy/Create
        [HttpPost]
        public ActionResult Create(pharmacy phamacy)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.pharmacies.Add(phamacy);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pharmacy/Edit/5
        public ActionResult Edit(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.pharmacies.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Pharmacy/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, pharmacy phamacy)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Entry(phamacy).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pharmacy/Delete/5
        public ActionResult Delete(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.pharmacies.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Pharmacy/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, pharmacy phamacy)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    Pharmacy.Models.pharmacy phama = dbModel.pharmacies.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.pharmacies.Remove(phama);  // FIXED: dbModel.Admins, not dbModel.Drugs
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
