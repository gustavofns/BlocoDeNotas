using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Menu.MenuArquivo
{
    public interface IGravacaoDeArquivos
    {
        void Salvar(IEditorDeDocumentos editorDeDocumentos);
        void SalvarComo(IEditorDeDocumentos editorDeDocumentos);
    }
}
