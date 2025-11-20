using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using Admin.Models;
using System.Linq;
using System.Data.Entity;

namespace Admin.Controllers
{
    public class DrugController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7260/api/Drug";

        // GET: Drug
        public async Task<ActionResult> Index()
        {
            List<Drug> drugs = new List<Drug>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    drugs = JsonConvert.DeserializeObject<List<Drug>>(jsonData);
                }
            }
            return View(drugs);
        }

        // GET: Drug/Details/5
        public ActionResult Details(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Drugs.Where(x => x.DrugId == id).FirstOrDefault());
            }

        }


        // GET: Drug/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drug/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Drug drug)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonDrug = JsonConvert.SerializeObject(drug);
                    StringContent content = new StringContent(jsonDrug, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(drug);
        }
        // GET: Drug/Edit/5
        public ActionResult Edit(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Drugs.Where(x => x.DrugId == id).FirstOrDefault());
            }
        }

        // POST: Drug/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Drug drug)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Entry(drug).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Drug/Delete/5
        public ActionResult Delete(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Drugs.Where(x => x.DrugId == id).FirstOrDefault());
            }
        }

        // POST: Drug/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Drug drug)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    Drug drug1 = dbModel.Drugs.Where(x => x.DrugId == id).FirstOrDefault();
                    dbModel.Drugs.Remove(drug1);
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
