using System.Text.Encodings.Web;
using System.Windows;
using BlocoDeNotas.Aplicativo;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;

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
            IJanela janela = new Janela(Array.Empty<string>());
            janela.MostrarJanela(new Editor(janela));
        }
      

        public void FecharJanela() { _janela.FecharJanela(); }

        public void Sair() { Application.Current.Shutdown(); }
    }
}
