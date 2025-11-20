using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Web.Mvc;
using System;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7260/api/SupplierAuth/"); // Update with your API base URL
    }

    // GET: Home/Index
    public ActionResult Index()
    {
        return View();
    }

    // POST: Home/Index
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Index(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ViewBag.ErrorMessage = "Email and Password are required.";
            return View();
        }

        var loginData = new { Email = email, Password = password };
        var json = JsonConvert.SerializeObject(loginData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync("login", content);

        if (response.IsSuccessStatusCode)
        {
            // Store session (or use authentication cookies)
            Session["UserEmail"] = email;

            return RedirectToAction("Dashboard"); // Redirect to dashboard on success
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid Email or Password.";
            return View();
        }
    }

    public ActionResult Logout()
    {
        Session.Clear();
        Session.Abandon();
        return RedirectToAction("Index");
    }

    public ActionResult Dashboard()
    {
        return View();
    }
}