using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlocoDeNotas.UI.Componentes
{
    /// <summary>
    /// Interação lógica para BarraDeStatus.xam
    /// </summary>
    public partial class BarraDeStatus : UserControl, IBarraDeStatus
    {
        private readonly IEditorDeDocumentos _editorDeDocumentos;

        public BarraDeStatus(IEditorDeDocumentos editorDeDocumentos)
        {
            InitializeComponent();
            _editorDeDocumentos = editorDeDocumentos;
        }
    }
}
