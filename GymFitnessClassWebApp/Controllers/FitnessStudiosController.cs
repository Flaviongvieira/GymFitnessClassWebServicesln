using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymFitnessClassWebApp.Controllers
{
    public class FitnessStudiosController : Controller
    {
        // GET: FitnessStudiosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FitnessStudiosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FitnessStudiosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessStudiosController/Create
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

        // GET: FitnessStudiosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FitnessStudiosController/Edit/5
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

        // GET: FitnessStudiosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FitnessStudiosController/Delete/5
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
