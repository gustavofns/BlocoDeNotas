using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Interfaces.UI.Componentes;
using BlocoDeNotas.Interfaces.UI.Configuracoes;
using BlocoDeNotas.UI;
using BlocoDeNotas.UI.Componentes;
using BlocoDeNotas.UI.Configuracoes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas
{
    public class Dependencias
    {
        public static IServiceProvider ServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton(Janela);
            services.AddSingleton(EditorDeDocumentos);
            services.AddSingleton(Configuracoes);
            services.AddSingleton(BarraDeMenu);
            services.AddSingleton(Editor);
            return services.BuildServiceProvider();
        }


        private static IJanela Janela(IServiceProvider provider)
        {
            return new MainWindow();
        }

        private static IEditorDeDocumentos EditorDeDocumentos(IServiceProvider provider)
        {
            return new EditorDeDocumentos();
        }

        private static IConfiguracoes Configuracoes(IServiceProvider provider)
        {
            var janela = provider.GetService<IJanela>();
            return new Configuracoes(janela);
        }

        private static IBarraDeMenu BarraDeMenu(IServiceProvider provider)
        {
            var janela = provider.GetService<IJanela>();
            var configuracoes = provider.GetService<IConfiguracoes>();
            return new BarraDeMenu(configuracoes, janela);
        }

        private static IEditor Editor(IServiceProvider provider)
        {
            var editorDeDocumentos = provider.GetService<IEditorDeDocumentos>();
            var barraDeMenu = provider.GetService<IBarraDeMenu>();
            return new Editor(editorDeDocumentos, barraDeMenu);
        }
    }
}
