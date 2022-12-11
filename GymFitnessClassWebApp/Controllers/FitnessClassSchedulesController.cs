using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GymFitnessClassWebApp.Controllers
{
    public class FitnessClassSchedulesController : Controller
    {
        // GET: FitnessClassSchedulesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FitnessClassSchedulesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FitnessClassSchedulesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessClassSchedulesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
