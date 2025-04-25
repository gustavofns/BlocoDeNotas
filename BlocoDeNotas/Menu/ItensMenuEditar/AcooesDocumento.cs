using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;

namespace BlocoDeNotas.Menu.ItensMenuEditar
{
    public class AcooesDocumento : IAcoesDoDocumento
    {
        private readonly TextBox _documento;

        public AcooesDocumento(TextBox documento)
        {
            _documento = documento;
        }

        public void Desfazer()
        {
            if(_documento.CanUndo)
            {
                _documento.Undo();
                IndiceCursor();
            }
        }

        public void Refazer()
        {
           if (_documento.CanRedo)
            {
                _documento.Redo();
                IndiceCursor();
            }
        }

        private void IndiceCursor()
        {
            _documento.CaretIndex = _documento.Text.Length;
        }
    }
}
