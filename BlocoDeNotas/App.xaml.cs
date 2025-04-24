using System.Configuration;
using System.Data;
using System.Windows;
using BlocoDeNotas.Aplicativo;
using BlocoDeNotas.Aplicativo.Componentes;
using BlocoDeNotas.Interfaces;

#pragma warning disable WPF0001

namespace BlocoDeNotas
{
    /// <summary>  
    /// Interaction logic for App.xaml  
    /// </summary>  
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Application.Current.ThemeMode = ThemeMode.None;
            IJanela _janela = new Janela(e.Args);
            _janela.MostrarJanela();
        }
    }
}
