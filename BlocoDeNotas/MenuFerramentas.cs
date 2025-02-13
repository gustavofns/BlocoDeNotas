using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas
{
    public class MenuFerramentas
    {
        MainWindow mainWindow;
        Editor editor;

        public MenuFerramentas(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
        }
    }
}
