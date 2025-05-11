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
            IServiceProvider serviceProvider = ConfigurarDependencias();
            var janela = serviceProvider.GetRequiredService<IJanela>();
            janela.NavegarPara(serviceProvider.GetRequiredService<IEditor>());
            janela.MostrarJanela();
        }

        // Configura as dependências
        static IServiceProvider ConfigurarDependencias()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<INavegacao, Navegacao>();
            services.AddSingleton<IJanela, MainWindow>();
            services.AddSingleton<IEditorDeDocumentos, EditorDeDocumentos>();
            services.AddSingleton<IAtualizarTituloJanela, AtualizarTituloDaJanela>();
            services.AddSingleton<IBarraDeStatus, BarraDeStatus>();
            services.AddSingleton<IConfiguracoes, Configuracoes>();
            services.AddSingleton<IBarraDeMenu, BarraDeMenu>();
            services.AddSingleton<IEditor, Editor>();
            return services.BuildServiceProvider();
        }
    }
}
