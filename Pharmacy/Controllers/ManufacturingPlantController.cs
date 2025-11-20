using Newtonsoft.Json;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pharmacy.Controllers
{
    public class ManufacturingPlantController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7260/api/ManufacturingPlant";

        // GET: ManufacturingPlant
        public async Task<ActionResult> Index()
        {
            List<ManufacturingPlant> plants = new List<ManufacturingPlant>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    plants = JsonConvert.DeserializeObject<List<ManufacturingPlant>>(data);
                }
            }
            return View(plants);
        }

        // GET: ManufacturingPlant/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ManufacturingPlant plant = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    plant = JsonConvert.DeserializeObject<ManufacturingPlant>(data);
                }
            }
            return View(plant);
        }

        // GET: ManufacturingPlant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufacturingPlant/Create
        [HttpPost]
        public async Task<ActionResult> Create(ManufacturingPlant manufacturing)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(manufacturing), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // GET: ManufacturingPlant/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ManufacturingPlant plant = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    plant = JsonConvert.DeserializeObject<ManufacturingPlant>(data);
                }
            }
            return View(plant);
        }

        // POST: ManufacturingPlant/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ManufacturingPlant manufacturing)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(manufacturing), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{apiBaseUrl}/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // GET: ManufacturingPlant/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ManufacturingPlant plant = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    plant = JsonConvert.DeserializeObject<ManufacturingPlant>(data);
                }
            }
            return View(plant);
        }

        // POST: ManufacturingPlant/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{apiBaseUrl}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
