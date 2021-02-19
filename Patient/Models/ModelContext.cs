using System.Data.Entity;

namespace Patient.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("ModelContext")
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }
}