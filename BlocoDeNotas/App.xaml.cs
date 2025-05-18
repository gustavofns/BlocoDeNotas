using BlocoDeNotas.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Windows.Devices.WiFiDirect.Services;

namespace BlocoDeNotas
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IServiceProvider serviceProvider = Depencias.ConfigurarDependencias();
            Depencias.ConfigurarJanela(serviceProvider);
        }
    }
}
