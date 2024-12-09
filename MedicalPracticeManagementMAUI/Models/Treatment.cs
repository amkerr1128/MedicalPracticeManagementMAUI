namespace MedicalPracticeManagementMAUI.Models
{
    public class Treatment
    {
        public int Id { get; set; }  // Added this property
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Treatment() { }

        public Treatment(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} (${Price:F2})";
        }
    }
}