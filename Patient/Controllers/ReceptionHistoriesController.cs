using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Patient.Dtos;
using Patient.Models;

namespace Patient.Controllers
{
    public class ReceptionHistoriesController : Controller
    {
        private readonly ModelContext _db = new ModelContext();
        
        public ActionResult ReceptionHistories()
        {
            var patients = _db.Patients.Where(x => !x.IsDeleted).ToList();
            var doctors = _db.Doctors.Where(x => !x.IsDeleted).ToList();
            var receptionHistories = _db.ReceptionHistories
                .Where(x => !x.IsDeleted)
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .OrderBy(x => x.DateTime).ToList();

            var dto = new ReceptionHistoryModelDto
            {
                Doctors = doctors,
                Patients = patients,
                ReceptionHistories = receptionHistories
            };

            return View(dto);
        }

        public ActionResult DeleteReceptionHistory(int id)
        {
            var receptionHistory = _db.ReceptionHistories.First(x => x.Id == id);
            receptionHistory.IsDeleted = true;
            _db.SaveChanges();
            return RedirectToAction("ReceptionHistories");
        }

        [HttpPost]
        public ActionResult AddReceptionHistory(ReceptionHistoryDto receptionHistoryDto)
        {
            var patient =
                _db.Patients.FirstOrDefault(x => !x.IsDeleted && x.FullName + " / " + x.Iin == receptionHistoryDto.PatientName);
            var doctor = _db.Doctors.FirstOrDefault(x => !x.IsDeleted && x.FullName + " / " + x.Specialty == receptionHistoryDto.DoctorName);
            if (patient == null || doctor == null)
            {
                return HttpNotFound();
            }

            var receptionHistory = new ReceptionHistory
            {
                Complaint = receptionHistoryDto.Complaint,
                DateTime = receptionHistoryDto.DateTime,
                Diagnosis = receptionHistoryDto.Diagnosis,
                DoctorId = doctor.Id,
                PatientId = patient.Id
            };

            _db.ReceptionHistories.Add(receptionHistory);
            _db.SaveChanges();
            return RedirectToAction("ReceptionHistories");
        }

        [HttpPost]
        public ActionResult SearchHistories(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return RedirectToAction("ReceptionHistories");
            }

            var patients = _db.Patients.Where(x => !x.IsDeleted).ToList();
            var doctors = _db.Doctors.Where(x => !x.IsDeleted).ToList();
            var receptionHistories = _db.ReceptionHistories
                .Where(x => !x.IsDeleted && x.Patient.FullName.Contains(searchText))
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .OrderBy(x => x.DateTime).ToList();

            var dto = new ReceptionHistoryModelDto
            {
                Doctors = doctors,
                Patients = patients,
                ReceptionHistories = receptionHistories
            };

            return View("ReceptionHistories", dto);
        }
    }
}