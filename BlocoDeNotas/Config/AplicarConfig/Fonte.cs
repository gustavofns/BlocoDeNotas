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
        MainWindow mainWindow;
        Editor editor;

        public Fonte(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
        }

    }
}
