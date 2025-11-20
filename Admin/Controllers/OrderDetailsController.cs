using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using Admin.Models;

namespace Admin.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7260/api/OrderDetails";

        public OrderDetailsController()
        {
            _httpClient = new HttpClient();
        }

        // GET: OrderDetails
        public async Task<ActionResult> Index()
        {
            var orderDetails = await _httpClient.GetFromJsonAsync<List<OrdersDetailss>>(ApiBaseUrl);
            return View(orderDetails);
        }

        // GET: OrderDetails/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var orderDetail = await _httpClient.GetFromJsonAsync<OrdersDetailss>($"{ApiBaseUrl}/{id}");
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        [HttpPost]
        public async Task<ActionResult> Create(OrdersDetailss orderDetail)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync(ApiBaseUrl, orderDetail);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var orderDetail = await _httpClient.GetFromJsonAsync<OrdersDetailss>($"{ApiBaseUrl}/{id}");
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, OrdersDetailss orderDetail)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiBaseUrl}/{id}", orderDetail);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var orderDetail = await _httpClient.GetFromJsonAsync<OrdersDetailss>($"{ApiBaseUrl}/{id}");
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
