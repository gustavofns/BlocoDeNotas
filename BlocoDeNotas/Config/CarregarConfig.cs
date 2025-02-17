using BlocoDeNotas.Menu;

namespace BlocoDeNotas.Config
{
    public class CarregarConfig
    {
        private MainWindow mainWindow;
        private Editor editor;
        private MenuExibir menuExibir;

        public CarregarConfig(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
            menuExibir = new MenuExibir(mainWindow, editor);
        }

        // Configura a barra de status
        public void ConfigBarraDeStatus(bool config)
        {
            if (config) menuExibir.MostrarBarraDeStatus();
            else menuExibir.OcultarBarraDeStatus();
        }

        // Configura a fonte
        public void ConfigFonte(int tamanhoFonte)
        {
            editor.editorDeTexto.FontSize = tamanhoFonte;
            editor.tamanhoFonteSlider.Value = tamanhoFonte;
            editor.tamanhoFonteLabel.Text = $"{tamanhoFonte}";
            editor.tamanhoFontaLabelMenu.Text = $"{tamanhoFonte}";
            editor.tamanhoFonteSliderMenu.Value = tamanhoFonte;
        }
    }
}
