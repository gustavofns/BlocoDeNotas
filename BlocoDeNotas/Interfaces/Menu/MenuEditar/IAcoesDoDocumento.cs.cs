using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;

namespace BlocoDeNotas.Interfaces.Menu.MenuEditar
{
    public interface IAcoesDoDocumento
    {
        void Desfazer(IEditorDeDocumentos editorDeDocumentos);
        void Refazer(IEditorDeDocumentos editorDeDocumentos);
        void Excluir(IEditorDeDocumentos editorDeDocumentos);
        void SelecionarTudo(IEditorDeDocumentos editorDeDocumentos);
    }
}
