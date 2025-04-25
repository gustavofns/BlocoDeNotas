using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;

namespace BlocoDeNotas.Menu.ItensMenuEditar
{
    public class AreaDeTransferencia : IAreaDeTransferencia
    {
        private readonly TextBox _documento;

        public AreaDeTransferencia(TextBox documento)
        {
            _documento = documento;
        }

        public void Colar()
        {
            if(Clipboard.ContainsText())
            {
                _documento.Text += Clipboard.GetText();
                _documento.CaretIndex = _documento.Text.Length;
            }
        }

        public void Copiar()
        {
            if (_documento.SelectedText.Length > 0)
            {
                Clipboard.Clear();
                Clipboard.SetDataObject(_documento.SelectedText);
            }
        }

        public void Recortar()
        {
            if(_documento.SelectedText.Length > 0)
            {
                Clipboard.Clear();
                Clipboard.SetDataObject(_documento.SelectedText);
                _documento.SelectedText = string.Empty;
            }
        }
    }
}
