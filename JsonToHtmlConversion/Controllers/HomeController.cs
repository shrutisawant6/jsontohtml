using JsonToHtmlConversion.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JsonToHtmlConversion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var result = JsonFileToObject();
            return View(result);
        }

        //https://stackoverflow.com/questions/44267150/how-to-convert-dynamic-json-to-an-html-table
        //read json file and convert to json object
        private static object JsonFileToObject()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(currentDirectory, @"..\..\..\JsonFiles\sampleFile.json");
            string jsonFilePath = Path.GetFullPath(path);

            using StreamReader r = new(jsonFilePath);
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<object>(json);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
