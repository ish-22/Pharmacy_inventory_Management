using Supplier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Suppliers.ToList());
            }
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Suppliers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier.Models.Supplier supplier)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Suppliers.Add(supplier);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Suppliers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Supplier.Models.Supplier supplier)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Entry(supplier).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Suppliers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Supplier.Models.Supplier supplier)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    Supplier.Models.Supplier supplier1 = dbModel.Suppliers.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Suppliers.Remove(supplier1);  // FIXED: dbModel.Admins, not dbModel.Drugs
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
