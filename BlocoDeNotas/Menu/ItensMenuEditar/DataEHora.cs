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
    public class DataEHora : IDataEHora
    {
        private readonly TextBox _documento;

        public DataEHora(TextBox documento) 
        {
            _documento = documento;
        }

        public void InserirData()
        {
            InserirEspaço();
            _documento.Text += DateTime.Now.ToString("dd/MM/yyyy");
            IndiceCursor();
        }

        public void InserirDataHora()
        {
            InserirHora();
            InserirData();
        }

        public void InserirHora()
        {
            InserirEspaço();
            _documento.Text += DateTime.Now.ToString("HH:mm:ss");
            IndiceCursor();
        }

        private void InserirEspaço()
        {
            if (_documento.Text.EndsWith("")
            && _documento.Text.Length > 0
            && (!_documento.Text.EndsWith("\n")))
                _documento.Text += " ";
        }

        private void IndiceCursor()
        {
            _documento.CaretIndex = _documento.Text.Length;
        }
    }
}
