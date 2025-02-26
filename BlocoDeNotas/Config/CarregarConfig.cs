using BlocoDeNotas.Config.DefinirConfig;
using BlocoDeNotas.Menu;
using System.Windows.Threading;

namespace BlocoDeNotas.Config
{
    public class CarregarConfig
    {
        private MainWindow mainWindow;
        private Editor editor;
        private MenuExibir menuExibir;
        private AplicarConfig.UI ui;

        public CarregarConfig(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
            menuExibir = new MenuExibir(mainWindow, editor);
            ui = new AplicarConfig.UI(editor);
        }
    }
}
