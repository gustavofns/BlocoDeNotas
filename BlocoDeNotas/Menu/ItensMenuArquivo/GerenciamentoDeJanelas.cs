using System.ComponentModel;
using System.Text.Encodings.Web;
using System.Windows;
using BlocoDeNotas.Aplicativo;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using Microsoft.Extensions.DependencyInjection;

namespace BlocoDeNotas.Menu.ItensMenuArquivo
{
    public class GerenciamentoDeJanelas : IGerenciamentoDeJanelas
    {
        private readonly IJanela _janela;

        public GerenciamentoDeJanelas(IJanela janela)
        {
            _janela = janela;
        }

        public void NovaJanela()
        {
            var provider = Programa.Dependencias(Array.Empty<string>());
            var novaJanela = provider.GetRequiredService<IJanela>();
            novaJanela.MostrarJanela(provider.GetRequiredService<IEditor>());
        }
      

        public void FecharJanela() { _janela.FecharJanela(); }

        public void Sair() { Application.Current.Shutdown(); }
    }
}
