using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MedicalPracticeManagementMAUI;
using MedicalPracticeManagementMAUI.Models;
using Microsoft.Maui.Controls;

namespace MedicalPracticeManagementMAUI.ViewModels
{
    public class PatientsViewModel : BaseViewModel
    {
        public ObservableCollection<Patient> Patients { get; set; } = new ObservableCollection<Patient>();
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public PatientsViewModel()
        {
            AddCommand = new Command(AddPatient);
            EditCommand = new Command<Patient>(EditPatient);
            DeleteCommand = new Command<Patient>(DeletePatient);
        }

        private async void AddPatient()
        {
            var name = await Application.Current.MainPage.DisplayPromptAsync("New Patient", "Enter patient name:");
            if (string.IsNullOrWhiteSpace(name)) return;

            var address = await Application.Current.MainPage.DisplayPromptAsync("New Patient", "Enter patient address:");
            if (string.IsNullOrWhiteSpace(address)) return;

            var birthdateInput = await Application.Current.MainPage.DisplayPromptAsync("New Patient", "Enter birthdate (yyyy-MM-dd):");
            if (!DateTime.TryParse(birthdateInput, out var birthdate)) return;

            var race = await Application.Current.MainPage.DisplayPromptAsync("New Patient", "Enter patient race:");
            if (string.IsNullOrWhiteSpace(race)) return;

            var gender = await Application.Current.MainPage.DisplayPromptAsync("New Patient", "Enter patient gender:");
            if (string.IsNullOrWhiteSpace(gender)) return;

            var newPatient = new Patient(name, address, birthdate, race, gender);
            Patients.Add(newPatient);

            await Application.Current.MainPage.DisplayAlert("Success", "Patient added successfully.", "OK");
        }

        private async void EditPatient(Patient patient)
        {
            if (patient == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No patient selected for editing.", "OK");
                return;
            }

            var newName = await Application.Current.MainPage.DisplayPromptAsync(
                "Edit Patient - Name",
                $"Current: {patient.Name}\nEnter new name (leave blank to keep current):");

            if (!string.IsNullOrWhiteSpace(newName))
            {
                patient.Name = newName;
            }

            var newAddress = await Application.Current.MainPage.DisplayPromptAsync(
                "Edit Patient - Address",
                $"Current: {patient.Address}\nEnter new address (leave blank to keep current):");

            if (!string.IsNullOrWhiteSpace(newAddress))
            {
                patient.Address = newAddress;
            }

            var birthdateInput = await Application.Current.MainPage.DisplayPromptAsync(
                "Edit Patient - Birthdate",
                $"Current: {patient.Birthdate:yyyy-MM-dd}\nEnter new birthdate (leave blank to keep current):");

            if (!string.IsNullOrWhiteSpace(birthdateInput) && DateTime.TryParse(birthdateInput, out var newBirthdate))
            {
                patient.Birthdate = newBirthdate;
            }

            var newRace = await Application.Current.MainPage.DisplayPromptAsync(
                "Edit Patient - Race",
                $"Current: {patient.Race}\nEnter new race (leave blank to keep current):");

            if (!string.IsNullOrWhiteSpace(newRace))
            {
                patient.Race = newRace;
            }

            var newGender = await Application.Current.MainPage.DisplayPromptAsync(
                "Edit Patient - Gender",
                $"Current: {patient.Gender}\nEnter new gender (leave blank to keep current):");

            if (!string.IsNullOrWhiteSpace(newGender))
            {
                patient.Gender = newGender;
            }

            await Application.Current.MainPage.DisplayAlert("Success", "Patient updated successfully.", "OK");
        }

        private void DeletePatient(Patient patient)
        {
            if (patient == null) return;
            Patients.Remove(patient);
        }
    }
}
