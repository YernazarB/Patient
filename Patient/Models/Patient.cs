namespace Patient.Models
{
    public class Patient : BaseModel
    {
        public string Iin { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}