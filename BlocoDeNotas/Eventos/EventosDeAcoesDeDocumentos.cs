using System.Windows.Controls;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;

namespace BlocoDeNotas.Eventos
{
    public class EventosDeAcoesDeDocumentos : IEventosDeAcoesDeDocumentos
    {
        private readonly TextBox _documento;
        private readonly IBarraDeMenu _barraDeMenu;

        public EventosDeAcoesDeDocumentos(IBarraDeMenu barraDeMenu, TextBox documento)
        {
            _barraDeMenu = barraDeMenu;
            _documento = documento;
            IniciarEvento();
        }

        private void IniciarEvento() { _documento.SelectionChanged += AcoesDocumentos; }
      
        private void AcoesDocumentos(object? sender, EventArgs e)
        { 
            bool refazer = _documento.CanRedo;
            bool desfazer = _documento.CanUndo;
            _barraDeMenu.RefazerMenu.IsEnabled = refazer;
            _barraDeMenu.DesfazerMenu.IsEnabled = desfazer;
        }
    }
}
