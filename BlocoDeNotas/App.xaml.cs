using BlocoDeNotas.Eventos;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Janela;
using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Interfaces.UI.Componentes;
using BlocoDeNotas.Interfaces.UI.Configuracoes;
using BlocoDeNotas.Janela;
using BlocoDeNotas.UI;
using BlocoDeNotas.UI.Componentes;
using BlocoDeNotas.UI.Configuracoes;
using BlocoDeNotas.Properties;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Windows.Devices.WiFiDirect.Services;
using BlocoDeNotas.Interfaces.Config.Janela;
using BlocoDeNotas.Config.Janela;
using BlocoDeNotas.UI.Janela;
using BlocoDeNotas.Interfaces.UI.Janela;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo.GerenciamentoDeArquivos;
using BlocoDeNotas.Interfaces.Ferramentas;
using BlocoDeNotas.Ferramentas;
using BlocoDeNotas.Menu.MenuArquivo.GerenciamentoDeArquivos;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;
using BlocoDeNotas.Menu.MenuEditar;

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
