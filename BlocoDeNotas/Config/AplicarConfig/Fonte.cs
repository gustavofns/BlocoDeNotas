using BlocoDeNotas.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Config.AplicarConfig
{
    public class Fonte
    {
        Editor editor;

        public Fonte(Editor editor)
        {

            this.editor = editor;
        }

        // Configura a fonte
        public void CarregarTamanhoFonte(int config)
        {
            editor.editorDeTexto.FontSize = config;
            editor.tamanhoFonteSlider.Value = config;
            editor.tamanhoFonteLabel.Text = $"{config}";
            editor.tamanhoFontaLabelMenu.Text = $"{config}";
            editor.tamanhoFonteSliderMenu.Value = config;
        }

        // Salva a configuração do tamanho da fonte
        public void SalvarTamanhoFonte(int config)
        {
            Properties.Settings.Default.TamanhoFonte = config;
            Properties.Settings.Default.Save();
        }
    }
}
