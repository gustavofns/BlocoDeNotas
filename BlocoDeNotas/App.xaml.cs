using System.ComponentModel;
using System.Windows;
using BlocoDeNotas.Aplicativo;
using BlocoDeNotas.Aplicativo.Dependencias;
using BlocoDeNotas.Config.Tema;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Properties;

namespace BlocoDeNotas
{
    /// <summary>  
    /// Interaction logic for App.xaml  
    /// </summary>  
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Tema.AplicarTema();
            ContainerDeDependencias.RegistarDependencias(e.Args);
        }
    }
}
