using Microsoft.Maui.Controls;
using MedicalPracticeManagementMAUI.ViewModels;

namespace MedicalPracticeManagementMAUI.Views
{
    public partial class PatientsPage : ContentPage
    {
        public PatientsPage()
        {
            InitializeComponent();
            BindingContext = new PatientsViewModel();
        }
    }
}
