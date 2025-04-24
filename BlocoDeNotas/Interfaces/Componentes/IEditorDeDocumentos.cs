using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlocoDeNotas.Interfaces.Componentes
{
    public interface IEditorDeDocumentos
    {
        public string Arquivo { get; set; }
        public TextBox Documento { get; set; }
        public StringBuilder DocumentoOriginal { get; set; }
    }
}
