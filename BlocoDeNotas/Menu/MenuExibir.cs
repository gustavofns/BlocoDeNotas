using BlocoDeNotas.Config;
using System.Windows;
using System.Windows.Media;

namespace BlocoDeNotas.Menu
{
    public class MenuExibir
    {
        // Atributos da classe
        Editor editor;

        // Construtor da classe
        public MenuExibir(Editor editor)
        {
            this.editor = editor;
        }

        // Carrega a configuração da barra de status
        public void CarregarBarraDeStatus(bool config)
        {
            if (config) MostrarBarraDeStatus();
            else OcultarBarraDeStatus();
        }

        // Salva a configuração da barra de status
        public void SalvarBarraDeStatus(bool config)
        {
            Properties.Settings.Default.BarraDeStatus = config;
            Properties.Settings.Default.Save();
        }

        // Mostra ou oculta a barra de status
        public void BarraDeStatus()
        {
            if (editor.textoBarraStatusMenu.Text.ToString() == "Ocultar a barra de status")
                OcultarBarraDeStatus();
            else MostrarBarraDeStatus();
        }

        // Mostra a barra de status
        public void MostrarBarraDeStatus()
        {
            editor.fonteMenu.Visibility = Visibility.Collapsed;
            editor.separadorFonte.Visibility = Visibility.Collapsed;
            editor.iconeBarraStatusMenu.FontFamily = (FontFamily)Application.Current.FindResource("SymbolThemeFontFamily");
            editor.iconeBarraStatusMenu.Text = "\uE90E";
            editor.textoBarraStatusMenu.Text = "Ocultar a barra de status";
            editor.barraStatus.Height = new GridLength(36);
            SalvarBarraDeStatus(true);
        }

        // Oculta a barra de status
        public void OcultarBarraDeStatus()
        {
            editor.fonteMenu.Visibility = Visibility.Visible;
            editor.separadorFonte.Visibility = Visibility.Visible;
            editor.iconeBarraStatusMenu.FontFamily = (FontFamily)Application.Current.FindResource("SymbolThemeFontFamily");
            editor.iconeBarraStatusMenu.Text = "\uE90E";
            editor.textoBarraStatusMenu.Text = "Mostrar a barra de status";
            editor.barraStatus.Height = new GridLength(0);
            SalvarBarraDeStatus(false);
        }

        // Mudar o tamanho da fonte no Slider
        public void MudarTamanhoFonteSlider(int tamanhoFonte)
        {
            editor.editorDeTexto.FontSize = tamanhoFonte;
            editor.tamanhoFonteSlider.Value = tamanhoFonte;
            editor.tamanhoFonteSliderMenu.Value = tamanhoFonte;
            editor.tamanhoFonteLabel.Text = $"{tamanhoFonte}";
            editor.tamanhoFontaLabelMenu.Text = $"{tamanhoFonte}";
        }
    }
}
