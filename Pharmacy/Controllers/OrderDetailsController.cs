using Intercom.Core;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Pharmacy.Controllers
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
        public ActionResult Edit(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.OrdersDetailsses.Where(x => x.OrderId == id).FirstOrDefault());
            }
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrdersDetailss order)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    dbModel.Entry(order).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                return View(dbModel.OrdersDetailsses.Where(x => x.OrderId == id).FirstOrDefault());
            }
        }

        // POST: OrderDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (Model1 dbModel = new Model1())
                {
                    Models.OrdersDetailss detail1 = dbModel.OrdersDetailsses.Where(x => x.OrderId == id).FirstOrDefault();
                    dbModel.OrdersDetailsses.Remove(detail1);  // FIXED: dbModel.Admins, not dbModel.Drugs
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
