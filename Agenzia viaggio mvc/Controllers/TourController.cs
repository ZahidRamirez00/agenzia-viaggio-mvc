using Agenzia_viaggio_mvc.Database;
using Agenzia_viaggio_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Agenzia_viaggio_mvc.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index() {
            using AgenziaContext db = new ();
            List<Tour> listaDellePizze = db.Tours.ToList();

            return View("Index", listaDellePizze);
        }
        public IActionResult Details(int id) {
            using AgenziaContext db = new();
            List<Tour> listaDeiTour = db.Tours.ToList();
            Tour? tour = db.Tours.Where(x => x.TourId == id).FirstOrDefault();
            if (tour != null) {
                return View("Details", tour);
            } else {
                return NotFound("Il tour con l'id cercato non esiste!");
            }
        }

 

        [HttpGet]
        public IActionResult Create() {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tour formdata) {
            if (!ModelState.IsValid) {
                return View("Create", formdata);
            }
            using AgenziaContext db = new();
            db.Tours.Add(formdata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id) {
            using AgenziaContext db = new();
            Tour? tour = db.Tours.Where(x => x.TourId == id).FirstOrDefault();
            if (tour != null) {
                return View("Update", tour);
                
            } else {

                return NotFound("Pizza non presente");
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Tour formdata) {
            if (!ModelState.IsValid) {
                return View("Update", formdata);
            }
            using AgenziaContext db = new();
            Tour? ModificaTour = db.Tours.Where(x => x.TourId == formdata.TourId).FirstOrDefault();
            if (ModificaTour != null) {
                ModificaTour.Name = formdata.Name;
                ModificaTour.Price = formdata.Price;
                ModificaTour.Description = formdata.Description;
                ModificaTour.ImageUrl = formdata.ImageUrl;
                ModificaTour.ColorCard = formdata.ColorCard;
                ModificaTour.Days = formdata.Days;
                ModificaTour.Destinations = formdata.Destinations;

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult EliminaTour(int id) {
            using AgenziaContext db = new();
            Tour? EliminaTour = db.Tours.Where(x => x.TourId == id).FirstOrDefault();
            if (EliminaTour != null) {
                db.Remove(EliminaTour);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
