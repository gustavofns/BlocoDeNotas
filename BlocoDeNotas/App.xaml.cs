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

namespace BlocoDeNotas
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IServiceProvider serviceProvider = ConfigurarDependencias();
            ConfigurarJanela(serviceProvider);
        }

        // Configura as dependências
        static IServiceProvider ConfigurarDependencias()
        {
            var services = new ServiceCollection();
            services.AddSingleton<INavegacao, Navegacao>();
            services.AddSingleton<IConfiguracoesDaJanela, ConfigJanela>();
            services.AddSingleton<IJanela, JanelaPrincipal>();
            services.AddSingleton<IAtualizarTituloJanela, AtualizarTituloDaJanela>();
            services.AddSingleton<IEditorDeDocumentos, EditorDeDocumentos>();
            services.AddSingleton<IBarraDeStatus, BarraDeStatus>();
            services.AddSingleton<IConfiguracoes, Configuracoes>();
            services.AddSingleton<IBarraDeMenu, BarraDeMenu>();
            services.AddSingleton<IEditor, Editor>();
            return services.BuildServiceProvider();
        }

        static void ConfigurarJanela(IServiceProvider service)
        {
            var janela = service.GetRequiredService<IJanela>();
            janela.NavegarPara(service.GetRequiredService<IEditor>());
            janela.MostrarJanela();
        }
    }
}
