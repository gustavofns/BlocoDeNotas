using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlocoDeNotas.Interfaces.UI.Componentes
{
    public interface IEditorDeDocumentos
    {
        string Arquivo { get; set; }
        StringBuilder DocumentoOriginal { get; set; }
        TextBox Documento { get; }
    }
}
