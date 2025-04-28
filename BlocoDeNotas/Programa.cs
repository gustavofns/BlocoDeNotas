using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocoDeNotas.Aplicativo;
using BlocoDeNotas.Aplicativo.Componentes;
using BlocoDeNotas.Eventos;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;
using BlocoDeNotas.Interfaces.Menu;
using BlocoDeNotas.Interfaces.Utilitarios;
using BlocoDeNotas.Menu.ItensMenuArquivo;
using BlocoDeNotas.Menu.ItensMenuEditar;
using BlocoDeNotas.Menu;
using BlocoDeNotas.Utilitarios;
using Microsoft.Extensions.DependencyInjection;

namespace BlocoDeNotas
{
    public class Programa
    {
        public static IServiceProvider Dependencias(string[] args)
        {
            var services = new ServiceCollection();

            services.AddScoped<IJanela>(provider => new Janela());
            services.AddScoped<IEditorDeDocumentos>(provider => new EditorDeDocumentos());
            services.AddScoped<IBarraDeStatus>(provider => new BarraDeStatus(provider.GetRequiredService<IEditorDeDocumentos>().Documento));
            services.AddScoped<IGerenciamentoDeJanelas>(provider => new GerenciamentoDeJanelas(provider.GetRequiredService<IJanela>()));
            services.AddScoped<ICaixaDeDialogodeArquivos, CaixaDeDialogodeArquivos>();
            services.AddScoped<IExcecoes, Excecoes>();

            services.AddScoped<IOperacoesComArquivos>(provider =>
            {
                var editorDeDocumentos = provider.GetRequiredService<IEditorDeDocumentos>();
                var excecoes = provider.GetRequiredService<IExcecoes>();
                return new OperacoesComArquivos(editorDeDocumentos, excecoes);
            });


            services.AddScoped<IGerenciamentoDeArquivos>(provider =>
            {
                var editorDeDocumentos = provider.GetRequiredService<IEditorDeDocumentos>();
                var caixaDeDialogo = provider.GetRequiredService<ICaixaDeDialogodeArquivos>();
                var operacoesComArquivos = provider.GetRequiredService<IOperacoesComArquivos>();
                return new GerenciamentoDeArquivos(editorDeDocumentos, caixaDeDialogo, operacoesComArquivos);
            });

            services.AddScoped<IMenuArquivo>(provider =>
            {
                var gerenciamentoDeArquivos = provider.GetRequiredService<IGerenciamentoDeArquivos>();
                var gerenciamentoDeJanelas = provider.GetRequiredService<IGerenciamentoDeJanelas>();
                return new MenuArquivo(gerenciamentoDeArquivos, gerenciamentoDeJanelas);
            });

            services.AddScoped<IAcoesDoDocumento>(provider => new AcoesDocumento(provider.GetRequiredService<IEditorDeDocumentos>().Documento));
            services.AddScoped<ITextoSelecionado>(provider => new TextoSelecionado(provider.GetRequiredService<IEditorDeDocumentos>().Documento));
            services.AddScoped<IAreaDeTransferencia>(provider => new AreaDeTransferencia(provider.GetRequiredService<IEditorDeDocumentos>().Documento));
            services.AddScoped<IDataEHora>(provider => new DataEHora(provider.GetRequiredService<IEditorDeDocumentos>().Documento));

            services.AddScoped<IMenuEditar>(provider =>
            {
                var acoesDoDocumento = provider.GetRequiredService<IAcoesDoDocumento>();
                var textoSelecionado = provider.GetRequiredService<ITextoSelecionado>();
                var areaDeTransferencia = provider.GetRequiredService<IAreaDeTransferencia>();
                var dataEHora = provider.GetRequiredService<IDataEHora>();
                return new MenuEditar(acoesDoDocumento, textoSelecionado, areaDeTransferencia, dataEHora);
            });


            services.AddScoped<IBarraDeMenu>(provider =>
            {
                var menuArquivo = provider.GetRequiredService<IMenuArquivo>();
                var menuEditar = provider.GetRequiredService<IMenuEditar>();
                return new BarraDeMenu(menuArquivo, menuEditar);
            });

            services.AddScoped<IEventosDeAcoesDeDocumentos>(provider => 
            {
                var barraDeMenu = provider.GetRequiredService<IBarraDeMenu>();
                var documento = provider.GetRequiredService<IEditorDeDocumentos>().Documento;
                return new EventosDeAcoesDeDocumentos(barraDeMenu, documento);
            });


            services.AddScoped<IEventosDeSelecaoTexto>(provider =>
            {
                var barraDeMenu = provider.GetRequiredService<IBarraDeMenu>();
                var documento = provider.GetRequiredService<IEditorDeDocumentos>().Documento;
                return new EventosDeSelecaoTexto(barraDeMenu, documento);
            });

            services.AddScoped<IEventosDoAplicativo>(provider =>
            {
                var janela = provider.GetRequiredService<IJanela>();
                var barraDeMenu = provider.GetRequiredService<IBarraDeMenu>();
                var editorDeDocumentos = provider.GetRequiredService<IEditorDeDocumentos>();
                return new EventosDoAplicativo(janela, editorDeDocumentos, barraDeMenu);
            });

            services.AddScoped<IEditor>(provider =>
            {
                var editorDeDocumentos = provider.GetRequiredService<IEditorDeDocumentos>();
                var barraDeStatus = provider.GetRequiredService<IBarraDeStatus>();
                var barraDeMenu = provider.GetRequiredService<IBarraDeMenu>();
                var eventosDeSelecaoTexto = provider.GetRequiredService<IEventosDeSelecaoTexto>();
                var eventosDeAcoesDeDocumentos = provider.GetRequiredService<IEventosDeAcoesDeDocumentos>();
                var eventosDoAplicativo = provider.GetRequiredService<IEventosDoAplicativo>();
                return new Editor(editorDeDocumentos, barraDeStatus, barraDeMenu);
            });

            return services.BuildServiceProvider();
        }
    }
}