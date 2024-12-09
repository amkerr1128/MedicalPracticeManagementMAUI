using Microsoft.Maui.Controls;
using MedicalPracticeManagementMAUI.ViewModels;

namespace MedicalPracticeManagementMAUI.Views
{
    public partial class AppointmentsPage : ContentPage
    {
        public AppointmentsPage()
        {
            InitializeComponent();
            BindingContext = new AppointmentsViewModel();
        }
    }
}
