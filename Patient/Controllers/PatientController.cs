using System.Linq;
using System.Web.Mvc;
using Patient.Models;

namespace Patient.Controllers
{
    public class PatientController : Controller
    {
        private readonly ModelContext _db = new ModelContext();

        public ActionResult Patients()
        {
            var patients = _db.Patients.Where(x => !x.IsDeleted).ToList();
            return View(patients);
        }

        [HttpPost]
        public ActionResult AddPatient(Models.Patient patient)
        {
            _db.Patients.Add(patient);
            _db.SaveChanges();
            return RedirectToAction("Patients");
        }

        public ActionResult DeletePatient(int id)
        {
            var patient = _db.Patients.First(x => x.Id == id);
            patient.IsDeleted = true;
            _db.SaveChanges();
            return RedirectToAction("Patients");
        }
    }
}