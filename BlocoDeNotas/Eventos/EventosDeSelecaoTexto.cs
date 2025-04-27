using System.Windows.Controls;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;

namespace BlocoDeNotas.Eventos
{
    public class EventosDeSelecaoTexto : IEventosDeSelecaoTexto
    {
        private readonly TextBox _documento;
        private readonly IBarraDeMenu _barraDeMenu;

        public EventosDeSelecaoTexto(IBarraDeMenu barraDeMenu, TextBox documento)
        {
            _barraDeMenu = barraDeMenu;
            _documento = documento;
            IniciarEvento();
        }

        private void IniciarEvento() { _documento.SelectionChanged += TextoSelecionado; }

        private void TextoSelecionado(object? sender, EventArgs e)
        {
            bool textoSelecionado = _documento.SelectionLength > 0;
            _barraDeMenu.RecortarMenu.IsEnabled = textoSelecionado;
            _barraDeMenu.CopiarMenu.IsEnabled = textoSelecionado;
            _barraDeMenu.ExcluirMenu.IsEnabled = textoSelecionado;
        }
    }
}
