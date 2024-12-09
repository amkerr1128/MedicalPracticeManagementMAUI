namespace MedicalPracticeManagementMAUI.Models
{
    public class InsurancePlan
    {
        public string Name { get; set; }
        public decimal CoveragePercentage { get; set; } // Percentage as a decimal (e.g., 0.8 for 80% coverage)

        public InsurancePlan(string name, decimal coveragePercentage)
        {
            Name = name;
            CoveragePercentage = coveragePercentage;
        }

        public override string ToString()
        {
            return $"{Name} ({CoveragePercentage * 100}% Coverage)";
        }
    }
}