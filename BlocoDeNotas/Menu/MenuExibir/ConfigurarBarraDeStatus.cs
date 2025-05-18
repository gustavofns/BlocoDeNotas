using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Menu.MenuExibir
{
    public class ConfigurarBarraDeStatus
    {
        private readonly IEditor _editor;

        public ConfigurarBarraDeStatus(IEditor editor)
        {
            _editor = editor;
        }

        public void ExibirBarraDeStatus(bool sender)
        {
            Properties.Settings.Default.BarraDeStatus = false;
            Properties.Settings.Default.Save();
            _editor.ExibirBarraDeStatus(sender);
        }
    }
}
