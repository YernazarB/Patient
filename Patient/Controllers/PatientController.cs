using System.Linq;
using System.Web.Mvc;
using Patient.Models;

namespace Patient.Controllers
{
    public class PatientController : Controller
    {
        private readonly ModelContext _db = new ModelContext();

        [HttpGet]
        public ActionResult Patients()
        {
            var patients = _db.Patients.ToList();
            return View(patients);
        }

        [HttpPost]
        public ActionResult AddPatient(string iin, string fullName, string address, string phoneNumber)
        {
            _db.Patients.Add(new Models.Patient
            {
                PhoneNumber = phoneNumber,
                Address = address,
                FullName = fullName,
                Iin = iin
            });
            _db.SaveChanges();
            return RedirectToAction("Patients");
        }

        [HttpDelete]
        public ActionResult DeletePatient(int id)
        {
            var patient = _db.Patients.First(x => x.Id == id);
            _db.Patients.Remove(patient);
            _db.SaveChanges();
            return RedirectToAction("Patients");
        }
    }
}