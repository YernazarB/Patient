using System.Data.Entity;

namespace Patient.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("ModelContext")
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ReceptionHistory> ReceptionHistories { get; set; }
    }
}