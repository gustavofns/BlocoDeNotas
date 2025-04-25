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
    public class TextoSelecionado : ITextoSelecionado
    {
        private readonly TextBox _documento;

        public TextoSelecionado(TextBox documento)
        {
            _documento = documento;
        }

        public void Excluir()
        {
            if (_documento.SelectedText.Length > 0) 
                _documento.SelectedText = string.Empty;
        }

        public void SelecionarTudo()
        {
            _documento.SelectAll();
        }
    }
}
