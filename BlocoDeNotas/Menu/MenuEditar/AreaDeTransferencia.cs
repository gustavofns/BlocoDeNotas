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
            ColarTexto(editorDeDocumentos);
            editorDeDocumentos.DefinirPosicaoDoCursorDeTexto();
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
            editorDeDocumentos.DefinirPosicaoDoCursorDeTexto();
        }

        // Método para copiar o texto para a área de transferência
        private void CopiarTexto(string texto)
        {
            try
            {
                if (texto.Length > 0)
                {
                    Clipboard.Clear();
                    Clipboard.SetDataObject(texto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível copiar o texto: \n{ex.Message}",
                    "Bloco de notas",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        // Método para colar o texto da área de transferência
        private void ColarTexto(IEditorDeDocumentos editorDeDocumentos)
        {
            if (Clipboard.ContainsText())
            {
                try
                {
                    editorDeDocumentos.DocumentoAtual += Clipboard.GetText();
                    editorDeDocumentos.DefinirPosicaoDoCursorDeTexto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Não foi possível copiar o texto: \n{ex.Message}",
                        "Bloco de notas",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
            }
        }
    }
}
