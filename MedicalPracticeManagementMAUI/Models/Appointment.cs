using System.Collections.Generic;

namespace MedicalPracticeManagementMAUI.Models
{
    public class Appointment
    {
        public Patient Patient { get; set; }
        public Physician Physician { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
        public List<Treatment> Treatments { get; set; } = new(); // New Property

        public Appointment(Patient patient, Physician physician, DateTime appointmentDate, string description, List<Treatment> treatments = null)
        {
            Patient = patient;
            Physician = physician;
            AppointmentDate = appointmentDate;
            Description = description;
            if (treatments != null)
            {
                Treatments = treatments;
            }
        }

        public override string ToString()
        {
            return $"{AppointmentDate}: {Description ?? "No description"} (Treatments: {string.Join(", ", Treatments)})";
        }
    }
}