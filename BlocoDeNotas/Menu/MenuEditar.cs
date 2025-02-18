using System.Windows;

namespace BlocoDeNotas.Menu
{
    public class MenuEditar
    {
        // Atributos e objetos
        private Editor editor;
        // Construtor da classe
        public MenuEditar(Editor editor)
        {
            this.editor = editor;
        }

        // Recorta um texto selecionado
        public void Recortar()
        {
            try
            {
                if (editor.editorDeTexto.SelectedText.Length > 0)
                {
                    Clipboard.Clear();
                    Clipboard.SetDataObject(editor.editorDeTexto.SelectedText);
                    editor.editorDeTexto.SelectedText = string.Empty;
                    editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível recortar o documento:\n{ex.Message}", 
                    "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Copia um texto selecionado
        public void Copiar()
        {
            try
            {
                if (editor.editorDeTexto.SelectedText.Length > 0)
                {
                    Clipboard.Clear();
                    Clipboard.SetDataObject(editor.editorDeTexto.SelectedText);
                    editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível copiar o documento:\n{ex.Message}", 
                    "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // Cola um texto selecionado da área de transferência
        public void Colar()
        {
            try
            {
                // Corrido o bug de colar o texto selecionado
                if (editor.editorDeTexto.SelectedText.Length > 0)
                {
                    editor.editorDeTexto.SelectedText = string.Empty;
                }

                if (Clipboard.ContainsText())
                {

                    editor.editorDeTexto.Text += Clipboard.GetText();
                    editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível colar o documento:\n{ex.Message}", 
                    "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Exclui um texto selecionado
        public void Excluir()
        {
            editor.editorDeTexto.SelectedText = string.Empty;
        }

        // Seleciona todo o texto
        public void SelecionarTudo()
        {
            editor.editorDeTexto.SelectAll();
        }
    }
}
