using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MedicalPracticeManagementMAUI;
using MedicalPracticeManagementMAUI.Models;
using Microsoft.Maui.Controls;

namespace MedicalPracticeManagementMAUI.ViewModels
{
    public class PhysiciansViewModel : BaseViewModel
    {
        public ObservableCollection<Physician> Physicians { get; set; } = new ObservableCollection<Physician>();
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public PhysiciansViewModel()
        {
            AddCommand = new Command(AddPhysician);
            EditCommand = new Command<Physician>(EditPhysician);
            DeleteCommand = new Command<Physician>(DeletePhysician);
        }

        private async void AddPhysician()
        {
            var name = await Application.Current.MainPage.DisplayPromptAsync("New Physician", "Enter physician name:");
            if (string.IsNullOrWhiteSpace(name))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Input", "Name cannot be empty.", "OK");
                return;
            }

            var licenseNumber = await Application.Current.MainPage.DisplayPromptAsync("New Physician", "Enter license number:");
            if (string.IsNullOrWhiteSpace(licenseNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Input", "License number cannot be empty.", "OK");
                return;
            }

            var graduationDateInput = await Application.Current.MainPage.DisplayPromptAsync("New Physician", "Enter graduation date (yyyy-MM-dd):");
            if (!DateTime.TryParse(graduationDateInput, out var graduationDate))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Input", "Please enter a valid date.", "OK");
                return;
            }

            var specializationsInput = await Application.Current.MainPage.DisplayPromptAsync("New Physician", "Enter specializations (comma-separated):");
            var specializations = string.IsNullOrWhiteSpace(specializationsInput) ? Array.Empty<string>() : specializationsInput.Split(',');

            var newPhysician = new Physician(name, licenseNumber, graduationDate, specializations);
            Physicians.Add(newPhysician);

            await Application.Current.MainPage.DisplayAlert("Success", "Physician added successfully.", "OK");
        }

        private async void EditPhysician(Physician physician)
        {
            if (physician == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No physician selected for editing.", "OK");
                return;
            }

            // Update name
            var newName = await Application.Current.MainPage.DisplayPromptAsync(
                "Edit Physician",
                "Update the name:",
                initialValue: physician.Name);
            if (string.IsNullOrWhiteSpace(newName))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Input", "Name cannot be empty.", "OK");
                return;
            }

            // Update license number
            var newLicenseNumber = await Application.Current.MainPage.DisplayPromptAsync(
                "Edit Physician",
                "Update the license number:",
                initialValue: physician.LicenseNumber);
            if (string.IsNullOrWhiteSpace(newLicenseNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Input", "License number cannot be empty.", "OK");
                return;
            }

            // Update graduation date
            var graduationDateInput = await Application.Current.MainPage.DisplayPromptAsync(
                "Edit Physician",
                "Update the graduation date (yyyy-MM-dd):",
                initialValue: physician.GraduationDate.ToString("yyyy-MM-dd"));
            if (!DateTime.TryParse(graduationDateInput, out var newGraduationDate))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Input", "Please enter a valid date.", "OK");
                return;
            }

            // Update specializations
            var specializationsInput = await Application.Current.MainPage.DisplayPromptAsync(
                "Edit Physician",
                "Update specializations (comma-separated):",
                initialValue: string.Join(", ", physician.Specializations));
            var newSpecializations = string.IsNullOrWhiteSpace(specializationsInput) ? Array.Empty<string>() : specializationsInput.Split(',');

            // Apply changes
            physician.Name = newName;
            physician.LicenseNumber = newLicenseNumber;
            physician.GraduationDate = newGraduationDate;
            physician.Specializations = newSpecializations;

            await Application.Current.MainPage.DisplayAlert("Success", "Physician updated successfully.", "OK");
        }

        private void DeletePhysician(Physician physician)
        {
            Physicians.Remove(physician);
        }
    }
}
