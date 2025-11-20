using Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace YourMvcProject.Controllers
{
    public class TenderController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7260/api/tender";

        public TenderController()
        {
            _httpClient = new HttpClient();
        }

        // GET: Tender
        public async Task<ActionResult> Index()
        {
            var tender = await _httpClient.GetFromJsonAsync<List<Tender>>(_apiBaseUrl);
            return View(tender);
        }

        // GET: Tender/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var tender = await _httpClient.GetFromJsonAsync<Tender>($"{_apiBaseUrl}/{id}");
            return View(tender);
        }

        // GET: Tender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tender/Create
        [HttpPost]
        public async Task<ActionResult> Create(Tender tender)
        {
            var response = await _httpClient.PostAsJsonAsync(_apiBaseUrl, tender);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(tender);
        }

        // GET: Tender/Edit/5
        public ActionResult Edit(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.Tenders.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Tender/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tender tender)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Entry(tender).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tender/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var tender = await _httpClient.GetFromJsonAsync<Tender>($"{_apiBaseUrl}/{id}");
            return View(tender);
        }

        // POST: Tender/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }
    }
}
