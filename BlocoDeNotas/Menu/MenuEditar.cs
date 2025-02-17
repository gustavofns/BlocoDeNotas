using System.Windows;

namespace BlocoDeNotas.Menu
{
    public class MenuEditar
    {
        private Editor editor;

        public MenuEditar(Editor editor)
        {
            this.editor = editor;
        }

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
                MessageBox.Show($"Não foi possível recortar o documento:\n{ex.Message}", "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

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
                MessageBox.Show($"Não foi possível copiar o documento:\n{ex.Message}", "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // Cola o texto da área de transferência
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
                MessageBox.Show($"Não foi possível colar o documento:\n{ex.Message}", "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Excluir()
        {
            editor.editorDeTexto.SelectedText = string.Empty;
        }

        public void SelecionarTudo()
        {
            editor.editorDeTexto.SelectAll();
        }
    }
}
