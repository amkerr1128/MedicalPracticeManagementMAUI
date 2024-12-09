using System.Collections.ObjectModel;
using System.Windows.Input;
using MedicalPracticeManagementMAUI.Models;
using MedicalPracticeManagementMAUI.Services;

namespace MedicalPracticeManagementMAUI.ViewModels
{
    public class AppointmentsViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        public ObservableCollection<Treatment> Treatments { get; set; } = new ObservableCollection<Treatment>();

        public ICommand RefreshCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }

        public AppointmentsViewModel()
        {
            _apiService = new ApiService();

            RefreshCommand = new Command(async () => await LoadTreatmentsAsync());
            CreateCommand = new Command(async () => await CreateTreatmentAsync());
            DeleteCommand = new Command<Treatment>(async t => await DeleteTreatmentAsync(t));
            UpdateCommand = new Command<Treatment>(async t => await UpdateTreatmentAsync(t));

            LoadTreatmentsAsync();
        }

        private async Task LoadTreatmentsAsync()
        {
            Treatments.Clear();
            var treatments = await _apiService.GetTreatmentsAsync();
            foreach (var treatment in treatments)
            {
                Treatments.Add(treatment);
            }
        }

        private async Task CreateTreatmentAsync()
        {
            var name = await Application.Current.MainPage.DisplayPromptAsync("New Treatment", "Enter the name:");
            var priceInput = await Application.Current.MainPage.DisplayPromptAsync("New Treatment", "Enter the price:");

            if (!decimal.TryParse(priceInput, out var price))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Input", "Please enter a valid price.", "OK");
                return;
            }

            var treatment = new Treatment { Name = name, Price = price };
            if (await _apiService.CreateTreatmentAsync(treatment))
            {
                await LoadTreatmentsAsync();
            }
        }

        private async Task DeleteTreatmentAsync(Treatment treatment)
        {
            if (await _apiService.DeleteTreatmentAsync(treatment.Id))
            {
                Treatments.Remove(treatment);
            }
        }

        private async Task UpdateTreatmentAsync(Treatment treatment)
        {
            var newName = await Application.Current.MainPage.DisplayPromptAsync("Update Treatment", $"Enter new name for {treatment.Name}:", initialValue: treatment.Name);
            var newPriceInput = await Application.Current.MainPage.DisplayPromptAsync("Update Treatment", $"Enter new price for {treatment.Name}:", initialValue: treatment.Price.ToString());

            if (!decimal.TryParse(newPriceInput, out var newPrice))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Input", "Please enter a valid price.", "OK");
                return;
            }

            treatment.Name = newName;
            treatment.Price = newPrice;

            if (await _apiService.UpdateTreatmentAsync(treatment))
            {
                await LoadTreatmentsAsync();
            }
        }
    }
}
