using GymModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace GymFitnessClassWebApp.Controllers
{
    public class FitnessInstructorsController : Controller
    {
        string baseURL = "https://localhost:7169";

        // GET: FitnessInstructorsController
        public async Task<ActionResult> Index()
        {
            IEnumerable<GymModels.FitnessInstructor> modelList = new List<GymModels.FitnessInstructor>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("api/FitnessInstructors");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<IEnumerable<GymModels.FitnessInstructor>>(results);
                }
                else
                {
                    Console.WriteLine("Erro Calling WebAPI");
                }
            }
            return View(modelList);
        }

        // GET: FitnessInstructorsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FitnessInstructorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessInstructorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FitnessInstructor fitinstr)
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

        /*// GET: FitnessInstructorsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }*/

        /*// POST: FitnessInstructorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FitnessInstructor fitinstr)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        /*// GET: FitnessInstructorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FitnessInstructorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FitnessInstructor fitinstr)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
