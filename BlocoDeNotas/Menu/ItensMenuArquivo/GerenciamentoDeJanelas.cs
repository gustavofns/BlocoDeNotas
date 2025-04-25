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
            var janela = new Janela(Array.Empty<string>())
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Height = _janela.AlturaJanela(),
                Width = _janela.LarguraJanela(),
            };
            janela.Show();
        }

        public void FecharJanela() { _janela.FecharJanela(); }

        public void Sair() { Application.Current.Shutdown(); }
    }
}
