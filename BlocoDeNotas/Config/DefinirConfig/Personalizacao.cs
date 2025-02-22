using System.Windows.Media;
using System.Windows;
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

        // usar ícones coloridos
        public void UsarUIColorida(bool cor)
        {
            var ui = (Brush)Application.Current.Resources[""];

            if (cor) ui = (Brush)Application.Current.Resources["AccentTextFillColorTertiaryBrush"];
            else ui = (Brush)Application.Current.Resources["TextFillColorPrimaryBrush"];

            // Aplica a cor ao menu principal
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
        }
    }
}

