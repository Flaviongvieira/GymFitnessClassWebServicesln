using GymFitnessClassWebService.Controllers;
using GymModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.WebRequestMethods;

namespace GymFitnessClassWebApp.Controllers
{
    public class FitnessInstructorsController : Controller
    {
        // Dependency Injection: HttpClient
        private readonly IHttpClientFactory _httpClientFactory;
        public FitnessInstructorsController(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;


        // GET: FitnessInstructorsController
        public async Task<ActionResult> Index()
        {
            IEnumerable<GymModels.FitnessInstructor> modelList = new List<GymModels.FitnessInstructor>();

            // connection and message details
            var client = _httpClientFactory.CreateClient("GymWebService");

            // Sending message using webservice
            HttpResponseMessage getData = await client.GetAsync("api/FitnessInstructors");

            // Response check and validation
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<IEnumerable<GymModels.FitnessInstructor>>(results);
            }
            else
            {
                Console.WriteLine("Erro Calling WebAPI");
            }

            return View(modelList);
        }

        // GET: FitnessInstructorsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            FitnessInstructor instr = new FitnessInstructor();

            // connection and message details
            var client = _httpClientFactory.CreateClient("GymWebService");

            // Sending message using webservice
            HttpResponseMessage getData = await client.GetAsync($"api/FitnessInstructors/GetFitnessInstructorbyId/{id}");

            // Response check and validation
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                instr = JsonConvert.DeserializeObject<FitnessInstructor>(results);
            }
            else
            {
                Console.WriteLine("Erro Calling WebAPI");
            }
            return View(instr);
        }

        // GET: FitnessInstructorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessInstructorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FitnessInstructor fitinstr)
        {
            try
            {
                // connection and message details
                var client = _httpClientFactory.CreateClient("GymWebService");

                // Object manipulation
                var jsonIntsr = JsonConvert.SerializeObject(fitinstr);
                var instrCont = new StringContent(jsonIntsr, Encoding.UTF8, "application/json");

                // Sending message using webservice
                HttpResponseMessage response = await client.PostAsync("api/FitnessInstructors", instrCont);

                // Response check and validation
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(fitinstr);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: https://localhost:7022/FitnessClassSchedules/FitClassByIntrId/2
        [HttpGet]
        public async Task<ActionResult> FitClassByIntrId(int id)
        {
            IEnumerable<GymModels.FitnessClassSchedule> modelList = new List<GymModels.FitnessClassSchedule>();
            // connection and message details
            var client = _httpClientFactory.CreateClient("GymWebService");

            // Sending message using webservice
            HttpResponseMessage getData = await client.GetAsync($"api/FitnessClassSchedules/GetFitClassScheduleByInstr/{id}");

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
