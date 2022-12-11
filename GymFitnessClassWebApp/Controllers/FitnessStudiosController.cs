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
        string baseURL = "https://localhost:7169";

        // GET: FitnessStudiosController
        public async Task<ActionResult> Index()
        {
            IEnumerable<GymModels.FitnessStudio> modelList = new List<GymModels.FitnessStudio>();

            using (var client = new HttpClient())
            {
                // connection and message details
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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
            }
            return View(modelList);
        }

        // GET: FitnessStudiosController/Details/5
         public async Task<ActionResult> Details(int id)
        {
            FitnessStudio instr = new FitnessStudio();
            using (var client = new HttpClient())
            {
                // connection and message details
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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
                using (var client = new HttpClient())
                {
                    // connection and message details
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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
            using (var client = new HttpClient())
            {
                // connection and message details
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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
            }
            return View(modelList);
        }
    }
}
