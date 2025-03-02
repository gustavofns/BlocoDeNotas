using System.Data;
using System.Windows;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

#pragma warning disable CS8618

namespace BlocoDeNotas.Menu
{
    public class MenuEditar
    {
        // Atributos e objetos
        private Editor editor;

        // Construtor da classe
        public MenuEditar() { }

        public MenuEditar(Editor editor)
        {
            this.editor = editor;
        }

        // Insere um espaço no final do texto
        public void InserirEspaco()
        {
            if (!(editor.editorDeTexto.Text.EndsWith("\n") ||
                editor.editorDeTexto.Text.EndsWith(" ") ||
                editor.editorDeTexto.Text.Length == 0))
            {
                editor.editorDeTexto.Text += " ";
            }
        }

        // Desfaz a última ação
        public void Desfazer()
        {
            editor.editorDeTexto.Undo();
            editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
        }

        // Refaz a última ação desfeita
        public void Refazer()
        {
            editor.editorDeTexto.Redo();
            editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
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
                    InserirEspaco();
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

        // Insere a hora atual
        public void InserirHoraAtual()
        {
            InserirEspaco();
            editor.editorDeTexto.Text = editor.editorDeTexto.Text + DateTime.Now.ToString("HH:mm:ss");
            editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
        }

        // Insere a data atual
        public void InserirDataAtual()
        {
            InserirEspaco();
            editor.editorDeTexto.Text = editor.editorDeTexto.Text + DateTime.Now.ToString("dd/MM/yyyy");
            editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
        }

        // Insere a data e hora atual
        public void InserirDataHoraAtual()
        {
            InserirHoraAtual();
            InserirDataAtual();
        }
    }
}
