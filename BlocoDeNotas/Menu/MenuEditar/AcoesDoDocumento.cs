using BlocoDeNotas.Interfaces.Menu.MenuEditar;
using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Menu.MenuEditar
{
    public class AcoesDoDocumento : IAcoesDoDocumento
    {
        // Desfaz a ultima ação no editor de documentos
        public void Desfazer(IEditorDeDocumentos editorDeDocumentos)
        {
           if(editorDeDocumentos.PossivelDesfazer)
                editorDeDocumentos.Desfazer();
        }

        // Exclui o texto selecionado
        public void Excluir(IEditorDeDocumentos editorDeDocumentos)
        {
            if(editorDeDocumentos.TextoSelecionado != null)
            {
                editorDeDocumentos.ExcluirTexto();
                editorDeDocumentos.DefinirPosicaoDoCursorDeTexto();
            }
        }

        // refaz a ultima ação desfeita
        public void Refazer(IEditorDeDocumentos editorDeDocumentos)
        {
            if (editorDeDocumentos.PossivelRefazer)
                editorDeDocumentos.Refazer();
        }

        // seleciona todas as palavras do documento
        public void SelecionarTudo(IEditorDeDocumentos editorDeDocumentos)
        {
            if(editorDeDocumentos.DocumentoAtual != null)
                editorDeDocumentos.SelecionarTudo();
        }
    }
}
