using BlocoDeNotas.Interfaces.Menu.MenuEditar;
using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas.Menu.MenuEditar
{
    public class AreaDeTransferencia : IAreaDeTransferencia
    {
        // Cola o texto da área de transferência no editor
        public void Colar(IEditorDeDocumentos editorDeDocumentos)
        {
            if(Clipboard.ContainsText())
            {
                editorDeDocumentos.DocumentoAtual += Clipboard.GetText();
                editorDeDocumentos.DefinirPosicaoDoCursorDeTexto();
            }
        }

        // Copia o texto selecionado para a área de transferência
        public void Copiar(IEditorDeDocumentos editorDeDocumentos)
        {
            CopiarTexto(editorDeDocumentos.TextoSelecionado);
        }

        // Recorta o texto do editor e copia para a área de transferência
        public void Recortar(IEditorDeDocumentos editorDeDocumentos)
        {
            CopiarTexto(editorDeDocumentos.TextoSelecionado);
            editorDeDocumentos.ExcluirTexto();
        }

        // Método para copiar o texto para a área de transferência
        private void CopiarTexto(string texto)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                Clipboard.Clear();
                Clipboard.SetText(texto);
            }
        }
    }
}
