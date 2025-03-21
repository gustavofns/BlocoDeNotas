﻿using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

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
            if (editor.editorDeTexto.Text == mainWindow.Documento.ToString()) mainWindow.TextoModificado = false;
            else mainWindow.TextoModificado = true;
        }

        public void VerificarDesfazerRefazer()
        {
            if(editor.editorDeTexto.CanUndo) editor.desfazerMenu.IsEnabled = true;
            else editor.desfazerMenu.IsEnabled = false;
            if (editor.editorDeTexto.CanRedo) editor.refazerMenu.IsEnabled = true;
            else editor.refazerMenu.IsEnabled = false;
        }

        public void AtualizarBarraDeTítulo()
        {
            string titulo = "Bloco de notas";
            if (editor.editorDeTexto.Text == "" && mainWindow.Arquivo == string.Empty) mainWindow.Title = titulo;
            else if (!(editor.editorDeTexto.Text == "") && mainWindow.Arquivo == string.Empty) mainWindow.Title = $"{titulo} - documento não salvo";
            else if (mainWindow.TextoModificado == true) mainWindow.Title = $"{titulo} - {mainWindow.Arquivo} - documento modificado";
            else mainWindow.Title = $"{titulo} - {mainWindow.Arquivo}";
        }

        public void RegistrarTeclas()
        {
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.A, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.C, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.V, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.X, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.Y, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.Z, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.Delete)));
        }

        // Verifica a área de transferência
        public void VerificarAreaDeTransferencia()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Tick += new EventHandler((sender, e) =>
            {
                if (Clipboard.ContainsText())
                {
                    editor.colarMenu.IsEnabled = true;
                    editor.colarMenuContexto.IsEnabled = true;
                    editor.colarConfigRapidas.Visibility = Visibility.Visible;
                }
                else
                {
                    editor.colarMenu.IsEnabled = false;
                    editor.colarMenuContexto.IsEnabled = false;
                    editor.colarConfigRapidas.Visibility = Visibility.Collapsed;
                }

            }); 
            dispatcherTimer.Start();
        }

        public void TextoSelecionado()
        {
            // Corrigido um bug que exibia os menus de copiar, recortar e excluir mesmo sem texto selecionado
            if (editor.editorDeTexto.SelectedText.Length > 0)
            {
                editor.copiarMenu.IsEnabled = true;
                editor.recortarMenu.IsEnabled = true;
                editor.excluirMenu.IsEnabled = true;
                editor.copiarMenuContexto.IsEnabled = true;
                editor.recortarMenuContexto.IsEnabled = true;
                editor.excluirMenuContexto.IsEnabled = true;
                editor.copiarConfigRapidas.Visibility = Visibility.Visible;
                editor.recortarConfigRapidas.Visibility = Visibility.Visible;
                editor.excluirConfigRapidas.Visibility = Visibility.Visible;
            }
            else
            {
                editor.copiarMenu.IsEnabled = false;
                editor.recortarMenu.IsEnabled = false;
                editor.excluirMenu.IsEnabled = false;
                editor.copiarMenuContexto.IsEnabled = false;
                editor.recortarMenuContexto.IsEnabled = false;
                editor.excluirMenuContexto.IsEnabled = false;
                editor.copiarConfigRapidas.Visibility = Visibility.Collapsed;
                editor.recortarConfigRapidas.Visibility = Visibility.Collapsed;
                editor.excluirConfigRapidas.Visibility = Visibility.Collapsed;
            }
        }
    }
}
