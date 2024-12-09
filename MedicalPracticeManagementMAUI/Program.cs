using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MedicalPracticeManagementMAUI.ViewModels;
using MedicalPracticeManagementMAUI.Views;
using MedicalPracticeManagementMAUI.Services;

namespace MedicalPracticeManagementMAUI
{
    public static class Program
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register ViewModels and Services
            builder.Services.AddSingleton<AppointmentsViewModel>();
            builder.Services.AddSingleton<ApiService>();

            // Register Views
            builder.Services.AddSingleton<AppointmentsPage>();

            return builder.Build();
        }
    }
}
