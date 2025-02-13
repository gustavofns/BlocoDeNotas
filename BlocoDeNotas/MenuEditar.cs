using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas
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
            catch(Exception ex)
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

        public void Colar()
        {
            try
            {
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
