using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.UI;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace BlocoDeNotas
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IServiceProvider serviceProvider = Dependencias.ConfigurarServiceProvider();
            serviceProvider.GetRequiredService<IJanela>().NavegarPara(serviceProvider.GetRequiredService<IEditor>());
            serviceProvider.GetRequiredService<IJanela>().MostrarJanela();
        }
    }

}
