using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Menu.MenuArquivo
{
    public interface ILeituraDeArquivos
    {
        void AbrirArquivo(IEditorDeDocumentos editorDeDocumentos);
    }
}
