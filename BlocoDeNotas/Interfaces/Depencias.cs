using BlocoDeNotas.Config.Janela;
using BlocoDeNotas.Eventos;
using BlocoDeNotas.Ferramentas;
using BlocoDeNotas.Interfaces.Config.Janela;
using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Ferramentas;
using BlocoDeNotas.Interfaces.Janela;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;
using BlocoDeNotas.Interfaces.UI.Componentes;
using BlocoDeNotas.Interfaces.UI.Configuracoes;
using BlocoDeNotas.Interfaces.UI.Janela;
using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Janela;
using BlocoDeNotas.Menu.MenuArquivo;
using BlocoDeNotas.Menu.MenuEditar;
using BlocoDeNotas.UI.Componentes;
using BlocoDeNotas.UI.Configuracoes;
using BlocoDeNotas.UI.Janela;
using BlocoDeNotas.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces
{
    public class Depencias
    {
        // Configura a injeção de dependências
        public static IServiceProvider ConfigurarDependencias()
        {
            var services = new ServiceCollection();
            services.AddSingleton<INavegacao, Navegacao>();
            services.AddSingleton<IConfiguracoesDaJanela, ConfigJanela>();
            services.AddSingleton<IJanela, JanelaPrincipal>();
            services.AddSingleton<IAtualizarTituloJanela, AtualizarTituloDaJanela>();
            services.AddSingleton<IAreaDeTransferencia, AreaDeTransferencia>();
            services.AddSingleton<IAcoesDoDocumento, AcoesDoDocumento>();
            services.AddSingleton<IEditorDeDocumentos, EditorDeDocumentos>();
            services.AddSingleton<ICaixaDeMensagem, CaixaDeMensagem>();
            services.AddSingleton<IExcecoes, Excecoes>();
            services.AddSingleton<ICaixaDeDialogoArquivos, CaixaDeDialogoDeArquivos>();
            services.AddSingleton<ILeituraDeArquivos, LeituraDeArquivos>();
            services.AddSingleton<IGravacaoDeArquivos, GravacaoDeArquivos>();
            services.AddSingleton<IGerenciamentoDaJanela, GerenciamentoDaJanela>();
            services.AddSingleton<IMenuArquivo, MenuArquivo>();
            services.AddSingleton<IAcoesDoDocumento, AcoesDoDocumento>();
            services.AddSingleton<IAreaDeTransferencia, AreaDeTransferencia>();
            services.AddSingleton<IDataEHora, DataEHora>();
            services.AddSingleton<IMenuEditar, MenuEditar>();
            services.AddSingleton<IBarraDeStatus, BarraDeStatus>();
            services.AddSingleton<IConfiguracoes, Configuracoes>();
            services.AddSingleton<IBarraDeMenu, BarraDeMenu>();
            services.AddSingleton<IEditor, Editor>();
            return services.BuildServiceProvider();
        }

        // Configura a janela principal
        public static void ConfigurarJanela(IServiceProvider service)
        {
            var janela = service.GetRequiredService<IJanela>();
            janela.NavegarPara(service.GetRequiredService<IEditor>());
            janela.MostrarJanela();
        }
    }
}
