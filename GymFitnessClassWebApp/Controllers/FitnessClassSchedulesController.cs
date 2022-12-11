using GymModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace GymFitnessClassWebApp.Controllers
{
    public class FitnessClassSchedulesController : Controller
    {
        string baseURL = "https://localhost:7169";


        // GET: FitnessClassSchedulesController
        public async Task<ActionResult> Index()
        {
            IEnumerable<GymModels.FitnessClassSchedule> modelList = new List<GymModels.FitnessClassSchedule>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("api/FitnessClassSchedules");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<IEnumerable<GymModels.FitnessClassSchedule>>(results);
                }
                else
                {
                    Console.WriteLine("Erro Calling WebAPI");
                }
            }
            return View(modelList);
        }

        // GET: FitnessClassSchedulesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            FitnessClassSchedule instr = new FitnessClassSchedule();
            using (var client = new HttpClient())
            {
                // connection and message details
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Sending message using webservice
                HttpResponseMessage getData = await client.GetAsync($"api/FitnessClassSchedules/GetFitnessClassbyId/{id}");

                // Response check and validation
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    instr = JsonConvert.DeserializeObject<FitnessClassSchedule>(results);
                }
                else
                {
                    Console.WriteLine("Erro Calling WebAPI");
                }
            }
            return View(instr);
        }

        // GET: FitnessClassSchedulesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessClassSchedulesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FitnessClassSchedule fitclass)
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
                    var jsonClass = JsonConvert.SerializeObject(fitclass);
                    var ClassCont = new StringContent(jsonClass, Encoding.UTF8, "application/json");

                    // Sending message using webservice
                    HttpResponseMessage response = await client.PostAsync("api/FitnessClassSchedules", ClassCont);

                    // Response check and validation
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(fitclass);
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: FitnessClassSchedulesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FitnessClassSchedulesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FitnessClassSchedulesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FitnessClassSchedulesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
