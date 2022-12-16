using GymModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace GymFitnessClassWebApp.Controllers
{
    public class FitnessStudiosController : Controller
    {
        // Dependency Injection: HttpClient
        private readonly IHttpClientFactory _httpClientFactory;
        public FitnessStudiosController(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;


        // GET: FitnessStudiosController
        public async Task<ActionResult> Index()
        {
            IEnumerable<GymModels.FitnessStudio> modelList = new List<GymModels.FitnessStudio>();

            // connection and message details
            var client = _httpClientFactory.CreateClient("GymWebService");

            // connection and message details
            HttpResponseMessage getData = await client.GetAsync("api/FitnessStudios");

            // Response check and validation
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<IEnumerable<GymModels.FitnessStudio>>(results);
            }
            else
            {
                Console.WriteLine("Erro Calling WebAPI");
            }
            return View(modelList);
        }

        // GET: FitnessStudiosController/Details/5
         public async Task<ActionResult> Details(int id)
        {
            FitnessStudio instr = new FitnessStudio();
            // connection and message details
            var client = _httpClientFactory.CreateClient("GymWebService");

            // Sending message using webservice
            HttpResponseMessage getData = await client.GetAsync($"api/FitnessStudios/GetFitnessStudiobyId/{id}");

            // Response check and validation
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                instr = JsonConvert.DeserializeObject<FitnessStudio>(results);
            }
            else
            {
                Console.WriteLine("Erro Calling WebAPI");
            }
            return View(instr);
        }

        // GET: FitnessStudiosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessStudiosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FitnessStudio fitstudio)
        {
            try
            {
                // connection and message details
                var client = _httpClientFactory.CreateClient("GymWebService");

                // Object manipulation
                var jsonStudio = JsonConvert.SerializeObject(fitstudio);
                    var StudioCont = new StringContent(jsonStudio, Encoding.UTF8, "application/json");

                // Sending message using webservice
                HttpResponseMessage response = await client.PostAsync("api/FitnessStudios", StudioCont);

                // Response check and validation
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(fitstudio);
                }
            }
            catch
            {
                return View();
            }
        }



        // Get Fitness Classes for a specific Studio	
        // GET: https://localhost:7022/FitnessClassSchedules/FitClassBySutdioId/2
        [HttpGet]
        public async Task<ActionResult> FitClassBySutdioId(int id)
        {
            IEnumerable<GymModels.FitnessClassSchedule> modelList = new List<GymModels.FitnessClassSchedule>();
            // connection and message details
            var client = _httpClientFactory.CreateClient("GymWebService");

            // Sending message using webservice
            HttpResponseMessage getData = await client.GetAsync($"api/FitnessClassSchedules/GetFitClassScheduleByStuId/{id}");

            // Response check and validation
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<GymModels.FitnessClassSchedule>>(results);
            }
            else
            {
                Console.WriteLine("Erro Calling WebAPI");
            }
            return View(modelList);
        }
    }
}
