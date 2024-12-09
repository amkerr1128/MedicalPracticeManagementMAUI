using Microsoft.Maui.Controls;
using MedicalPracticeManagementMAUI.ViewModels;

namespace MedicalPracticeManagementMAUI.Views
{
    public partial class PhysiciansPage : ContentPage
    {
        public PhysiciansPage()
        {
            InitializeComponent();
            BindingContext = new PhysiciansViewModel();
        }
    }
}
