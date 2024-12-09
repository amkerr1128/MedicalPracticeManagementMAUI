using System;
using MedicalPracticeManagementMAUI.Views;
using Microsoft.Maui.Controls;

namespace MedicalPracticeManagementMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnManagePatientsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PatientsPage());
        }

        private async void OnManagePhysiciansClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PhysiciansPage());
        }

        private async void OnManageAppointmentsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppointmentsPage());
        }
    }
}
