using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Menu;

namespace BlocoDeNotas.Eventos
{
    public class EventosDeSelecaoTexto
    {
        private readonly TextBox _documento;
        private readonly IBarraDeMenu _barraDeMenu;

        public EventosDeSelecaoTexto(IBarraDeMenu barraDeMenu, TextBox documento)
        {
            _barraDeMenu = barraDeMenu;
            _documento = documento;
            IniciarEvento();
        }

        private void IniciarEvento()
        {
            _documento.SelectionChanged += TextoSelecionado;
        }

        private void TextoSelecionado(object? sender, EventArgs e)
        {
            if (_documento.SelectionLength > 0)
            {
                _barraDeMenu.RecortarMenu.IsEnabled = true;
                _barraDeMenu.CopiarMenu.IsEnabled = true;
                _barraDeMenu.ExcluirMenu.IsEnabled = true;
            }
            else
            {
                _barraDeMenu.RecortarMenu.IsEnabled = false;
                _barraDeMenu.CopiarMenu.IsEnabled = false;
                _barraDeMenu.ExcluirMenu.IsEnabled = false;
            }
        }
    }
}
