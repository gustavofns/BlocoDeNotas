using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Linq;

namespace BlocoDeNotas
{
    public class Eventos
    {
        private MainWindow mainWindow;
        private Editor editor;

        public Eventos(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
        }

        public void AtualizarRotulos()
        {
            editor.linhasColunasLbn.Content = $"{editor.editorDeTexto.LineCount} linha(s)";
            editor.caracteresLbn.Content = $"{editor.editorDeTexto.Text.Length} caractere(s)";
            editor.palavrasLbn.Content = $"{editor.editorDeTexto.Text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length} palavra(s)";
            if (string.IsNullOrEmpty(editor.editorDeTexto.Text)) editor.palavrasLbn.Content = "0 palavra(s)";
        }

        public void VerificarTextoModificado()
        {
            if (editor.editorDeTexto.Text == editor.Documento.ToString()) editor.TextoModificado = false;
            else editor.TextoModificado = true;
        }

        public void AtualizarBarraDeTítulo()
        {
            string titulo = "Bloco de notas";
            if (editor.editorDeTexto.Text == "" && editor.Arquivo == string.Empty) mainWindow.Title = titulo;
            else if (!(editor.editorDeTexto.Text == "") && editor.Arquivo == string.Empty) mainWindow.Title = $"{titulo} - documento não salvo";
            else if (editor.TextoModificado == true) mainWindow.Title = $"{titulo} - {editor.Arquivo} - documento modificado";
            else mainWindow.Title = $"{titulo} - {editor.Arquivo}";
        }

        public void RegistrarTeclas()
        {
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.A, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.C, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.V, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.X, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.Delete)));
        }

        public void VerificarAreaDeTransferencia()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMicroseconds(1);
            dispatcherTimer.Tick += new EventHandler((sender, e) =>
            {
                if (Clipboard.ContainsText())
                {
                    editor.colarMenu.IsEnabled = true;
                    editor.colarMenuContexto.IsEnabled = true;
                }
                else 
                { 
                    editor.colarMenu.IsEnabled = false;
                    editor.colarMenuContexto.IsEnabled = false;
                }
            });
            dispatcherTimer.Start();
        }

        public void TextoSelecionado()
        {
            if (editor.editorDeTexto.SelectedText.Length > 0)
            {
                editor.copiarMenu.IsEnabled = true;
                editor.recortarMenu.IsEnabled = true;
                editor.excluirMenu.IsEnabled = true;
                editor.copiarMenuContexto.IsEnabled = true;
                editor.recortarMenuContexto.IsEnabled = true;
                editor.excluirMenuContexto.IsEnabled = true;
            }
            else
            {
                editor.copiarMenu.IsEnabled = false;
                editor.recortarMenu.IsEnabled = false;
                editor.excluirMenu.IsEnabled = false;
                editor.copiarMenuContexto.IsEnabled = false;
                editor.recortarMenuContexto.IsEnabled = false;
                editor.excluirMenuContexto.IsEnabled = false;
            }
        }
    }
}
