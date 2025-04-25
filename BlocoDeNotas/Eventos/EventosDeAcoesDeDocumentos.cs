using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;

namespace BlocoDeNotas.Eventos
{
    public class EventosDeAcoesDeDocumentos
    {
        private readonly TextBox _documento;
        private readonly IBarraDeMenu _barraDeMenu;

        public EventosDeAcoesDeDocumentos(IBarraDeMenu barraDeMenu, TextBox documento)
        {
            _barraDeMenu = barraDeMenu;
            _documento = documento;
            IniciarEvento();
        }

        private void IniciarEvento()
        {
            _documento.SelectionChanged += AcoesDocumentos;
        }
      
        private void AcoesDocumentos(object? sender, EventArgs e)
        { 
            if (_documento.CanRedo)
                _barraDeMenu.RefazerMenu.IsEnabled = true;
            else _barraDeMenu.RefazerMenu.IsEnabled = false;
     
            if(_documento.CanUndo)
                _barraDeMenu.DesfazerMenu.IsEnabled = true;
            else _barraDeMenu.DesfazerMenu.IsEnabled = false;
        }
    }
}
