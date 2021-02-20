using System.Linq;
using System.Web.Mvc;
using Patient.Models;

namespace Patient.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ModelContext _db = new ModelContext();

        public ActionResult Doctors()
        {
            var doctors = _db.Doctors.Where(x => !x.IsDeleted).ToList();
            return View(doctors);
        }

        [HttpPost]
        public ActionResult AddDoctor(Models.Doctor doctor)
        {
            _db.Doctors.Add(doctor);
            _db.SaveChanges();
            return RedirectToAction("Doctors");
        }

        public ActionResult DeleteDoctor(int id)
        {
            var doctor = _db.Doctors.First(x => x.Id == id);
            doctor.IsDeleted = true;
            _db.SaveChanges();
            return RedirectToAction("Doctors");
        }
    }
}