using System;

namespace MedicalPracticeManagementMAUI.Models
{
    public class Physician
    {
        public string Name { get; set; } // Changed from read-only to mutable
        public string LicenseNumber { get; set; } // Changed to mutable
        public DateTime GraduationDate { get; set; } // Changed to mutable
        public string[] Specializations { get; set; } // Changed to mutable

        public Physician(string name, string licenseNumber, DateTime graduationDate, string[] specializations)
        {
            Name = name;
            LicenseNumber = licenseNumber;
            GraduationDate = graduationDate;
            Specializations = specializations;
        }
    }
}
