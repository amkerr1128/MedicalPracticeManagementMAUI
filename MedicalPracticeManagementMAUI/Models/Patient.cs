namespace MedicalPracticeManagementMAUI.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public InsurancePlan InsurancePlan { get; set; } // New Property

        public Patient(string name, string address, DateTime birthdate, string race, string gender, InsurancePlan insurancePlan = null)
        {
            Name = name;
            Address = address;
            Birthdate = birthdate;
            Race = race;
            Gender = gender;
            InsurancePlan = insurancePlan;
        }
    }
}