using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Navegacao;
using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Interfaces.UI.Componentes;
using BlocoDeNotas.Interfaces.UI.Configuracoes;
using BlocoDeNotas.Janela;
using BlocoDeNotas.UI;
using BlocoDeNotas.UI.Componentes;
using BlocoDeNotas.UI.Configuracoes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BlocoDeNotas
{
    public class Dependencias
    {
        public static IServiceProvider ConfigurarServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<Frame>(provider => Frame(provider));
            services.AddSingleton<INavegacao>(provider => new Navegacao(provider.GetRequiredService<Frame>()));
            services.AddSingleton<IJanela>(provider => Janela(provider));
            services.AddSingleton<IEditorDeDocumentos, EditorDeDocumentos>();
            services.AddSingleton<IBarraDeStatus>(provider => BarraDeStatus(provider));
            services.AddSingleton<IConfiguracoes>(provider => Configuracoes(provider));
            services.AddSingleton<IBarraDeMenu>(provider => BarraDeMenu(provider));
            services.AddSingleton<IEditor>(provider => Editor(provider));

            return services.BuildServiceProvider();
        }

        private static Frame Frame (IServiceProvider provider)
        {
            Frame frame = new Frame();
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            return frame;
        }

        private static IJanela Janela(IServiceProvider provider)
        {
            var frame = provider.GetRequiredService<Frame>();
            var navegacao = provider.GetRequiredService<INavegacao>();
            return new MainWindow(navegacao, frame);
        }

        private static IConfiguracoes Configuracoes(IServiceProvider provider)
        {
            var janela = provider.GetRequiredService<IJanela>();
            return new Configuracoes(janela);
        }

        private static IBarraDeStatus BarraDeStatus(IServiceProvider provider)
        {
            var editorDeDocumentos = provider.GetRequiredService<IEditorDeDocumentos>();
            return new BarraDeStatus(editorDeDocumentos);
        }

        private static IBarraDeMenu BarraDeMenu(IServiceProvider provider)
        {
            var configuracoes = provider.GetRequiredService<IConfiguracoes>();
            var janela = provider.GetRequiredService<IJanela>();
            return new BarraDeMenu(configuracoes, janela);
        }

        private static IEditor Editor(IServiceProvider provider)
        {
            var editorDeDocumentos = provider.GetRequiredService<IEditorDeDocumentos>();
            var barraDeStatus = provider.GetRequiredService<IBarraDeStatus>();
            var barraDeMenu = provider.GetRequiredService<IBarraDeMenu>();
            return new Editor(editorDeDocumentos, barraDeStatus,barraDeMenu);
        }
    }
}
