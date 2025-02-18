using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using Microsoft.Win32;
using Windows.UI.StartScreen;

#pragma warning disable WPF0001
#pragma warning disable CS8600
#pragma warning disable CS8602


namespace BlocoDeNotas.Config.DefinirConfig
{
    public class Personalizacao
    {
        public Editor editor;

        public Personalizacao(Editor editor)
        {
            this.editor = editor;
        }

        // Define o tema
        public void MudarTema(string tema)
        {
            ThemeMode themeMode;

            switch (tema)
            {
                case "Claro":
                    themeMode = ThemeMode.Light;
                    break;
                case "Escuro":
                    themeMode = ThemeMode.Dark;
                    break;
                default:
                    themeMode = ThemeMode.System;
                    break;
            }
            AplicarTema(themeMode);
            AplicarCordeFundo("Sistema");
        }

        // Aplica o tema
        public void AplicarTema(ThemeMode themeMode)
        {
            try
            {
                Application.Current.ThemeMode = themeMode;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao aplicar o tema!!!",
                    "Bloco de notas", MessageBoxButton.OK);
            }
        }

        // Cor de fundo do editor
        public void AplicarCordeFundo(string cor)
        {
            switch(cor)
            {
                case "Branco":
                    editor.editorDeTexto.Background = Brushes.White;
                    editor.editorDeTexto.Foreground = Brushes.Black;
                    break;
                case "Preto":
                    editor.editorDeTexto.Background = Brushes.Black;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Azul":
                    editor.editorDeTexto.Background = Brushes.Blue;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Vemelho":
                    editor.editorDeTexto.Background = Brushes.Red;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Verde":
                    editor.editorDeTexto.Background = Brushes.Green;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Amarelo":
                    editor.editorDeTexto.Background = Brushes.Yellow;
                    editor.editorDeTexto.Foreground = Brushes.Black;
                    break;
                case "Cinza":
                    editor.editorDeTexto.Background = Brushes.Gray;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Rosa":
                    editor.editorDeTexto.Background = Brushes.Pink;
                    editor.editorDeTexto.Foreground = Brushes.Black;
                    break;
                case "Laranja":
                    editor.editorDeTexto.Background = Brushes.Orange;
                    editor.editorDeTexto.Foreground = Brushes.Black;
                    break;
                case "Roxo":
                    editor.editorDeTexto.Background = Brushes.Purple;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Marrom":
                    editor.editorDeTexto.Background = Brushes.Brown;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Ciano":
                    editor.editorDeTexto.Background = Brushes.Cyan;
                    editor.editorDeTexto.Foreground = Brushes.Black;
                    break;
                case "Magenta":
                    editor.editorDeTexto.Background = Brushes.Magenta;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Lima":
                    editor.editorDeTexto.Background = Brushes.Lime;
                    editor.editorDeTexto.Foreground = Brushes.Black;
                    break;
                case "Teal":
                    editor.editorDeTexto.Background = Brushes.Teal;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Oliva":
                    editor.editorDeTexto.Background = Brushes.Olive;
                    editor.editorDeTexto.Foreground = Brushes.White;
                    break;
                case "Prata":
                    editor.editorDeTexto.Background = Brushes.Silver;
                    editor.editorDeTexto.Foreground = Brushes.Black;
                    break;
                case "Aqua":
                    editor.editorDeTexto.Background = Brushes.Aqua;
                    editor.editorDeTexto.Foreground = Brushes.Black;
                    break;
                case "Lavanda":
                    editor.editorDeTexto.Background = Brushes.Lavender;
                    editor.editorDeTexto.Foreground = Brushes.Black;
                    break;
                default:
                    editor.editorDeTexto.Background = (Brush)Application.Current.Resources["TextOnAccentFillColorPrimaryBrush"];
                    editor.editorDeTexto.Foreground = (Brush)Application.Current.Resources["TextFillColorPrimaryBrush"];
                    break;
            }
        }

        // usar ícones coloridos
        public void UsarUIColorida(bool cor)
        {
            var ui = (Brush)Application.Current.Resources[""];

            if (cor) ui = (Brush)Application.Current.Resources["AccentTextFillColorTertiaryBrush"];
            else ui = (Brush)Application.Current.Resources["TextFillColorPrimaryBrush"];

            // Aplica a cor ao nenu principal
            editor.iconeMenuArquivo.Foreground = ui;
            editor.iconeMenuEditar.Foreground = ui;
            editor.iconeMenuExibir.Foreground = ui;
            editor.iconeMenuFerramentas.Foreground = ui;

            // Aplica a cor as ferramentas rápidas
            editor.abrirConfigRapidas.Foreground = ui;
            editor.salvarConfigRapidas.Foreground = ui;
            editor.salvarComoConfigRapidas.Foreground = ui;
            editor.recortarConfigRapidas.Foreground = ui;
            editor.copiarConfigRapidas.Foreground = ui;
            editor.colarConfigRapidas.Foreground = ui;
            editor.excluirConfigRapidas.Foreground = ui;

            // Aplica cor aos ícones do menu direito
            editor.iconeMenuAbrirNovaJanela.Foreground = ui;
            editor.iconeMenuMiniBloco.Foreground = ui;
            editor.iconeMenuConfig.Foreground = ui;

           MudarTema(Properties.Settings.Default.Tema);
        }
    }
}

