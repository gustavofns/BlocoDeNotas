using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Menu.MenuEditar
{
    public interface IAreaDeTransferencia
    {
        void Copiar(IEditorDeDocumentos editorDeDocumentos);
        void Colar(IEditorDeDocumentos editorDeDocumentos);
        void Recortar(IEditorDeDocumentos editorDeDocumentos);
    }
}
