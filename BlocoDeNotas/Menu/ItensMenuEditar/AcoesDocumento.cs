using System.Windows.Controls;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;

namespace BlocoDeNotas.Menu.ItensMenuEditar
{
    public class AcoesDocumento : IAcoesDoDocumento
    {
        private readonly TextBox _documento;

        public AcoesDocumento(TextBox documento)
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

        private void IndiceCursor() { _documento.CaretIndex = _documento.Text.Length; }
    }
}
