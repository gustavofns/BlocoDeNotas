using BlocoDeNotas.Config;
using System.Windows;
using System.Windows.Media;

namespace BlocoDeNotas.Menu
{
    public class MenuExibir
    {
        // Atributos da classe
        MainWindow mainWindow;
        Editor editor;

        // Construtor da classe
        public MenuExibir(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
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

        // Mostra o tamanho da fonte
        public void MudarTamFonte(int tamanhoFonte)
        {
            editor.editorDeTexto.FontSize = tamanhoFonte;
            SalvarTamanhoFonte(tamanhoFonte);
        }

        // Slider para mudar o tamanho da fonte
        public void SliderMudarFonte(int tamanhoFonte)
        {
            editor.tamanhoFonteLabel.Text = $"{tamanhoFonte}";
            editor.tamanhoFonteSliderMenu.Value = tamanhoFonte;
            editor.tamanhoFontaLabelMenu.Text = $"{tamanhoFonte}";
            MudarTamFonte(tamanhoFonte);
        }

        // Slider para mudar o tamanho da fonte no menu
        public void SliderMudarFonteMenu(int tamanhoFonte)
        {
            editor.tamanhoFontaLabelMenu.Text = $"{tamanhoFonte}";
            editor.tamanhoFonteSlider.Value = tamanhoFonte;
            editor.tamanhoFonteLabel.Text = $"{tamanhoFonte}";
            MudarTamFonte(tamanhoFonte);
        }

        // Duplo click no slider
        public void SliderDuploClick()
        {
            editor.tamanhoFonteSlider.Value = 14;
            editor.tamanhoFonteSliderMenu.Value = 14;
            editor.tamanhoFonteLabel.Text = "14";
            editor.tamanhoFontaLabelMenu.Text = "14";
            MudarTamFonte(14);
        }

        // Carrega a configuração da barra de status
        public void CarregarBarraDeStatus(bool config)
        {
            if (config) MostrarBarraDeStatus();
            else OcultarBarraDeStatus();
        }

        // Configura a fonte
        public void CarregarTamanhoFonte(int tamanhoFonte)
        {
            editor.editorDeTexto.FontSize = tamanhoFonte;
            editor.tamanhoFonteSlider.Value = tamanhoFonte;
            editor.tamanhoFonteLabel.Text = $"{tamanhoFonte}";
            editor.tamanhoFontaLabelMenu.Text = $"{tamanhoFonte}";
            editor.tamanhoFonteSliderMenu.Value = tamanhoFonte;
        }

        // Salva a configuração da barra de status
        public void SalvarBarraDeStatus(bool config)
        {
            Properties.Settings.Default.BarraDeStatus = config;
            Properties.Settings.Default.Save();
        }

        // Salva a configuração do tamanho da fonte
        public void SalvarTamanhoFonte(int tamanhoFonte)
        {
            Properties.Settings.Default.TamanhoFonte = tamanhoFonte;
            Properties.Settings.Default.Save();
        }
    }
}
