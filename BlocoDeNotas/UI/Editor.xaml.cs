using BlocoDeNotas.Interfaces.UI;
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

namespace BlocoDeNotas.UI
{
    /// <summary>
    /// Interação lógica para Editor.xam
    /// </summary>
    public partial class Editor : Page, IEditor
    {
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly IBarraDeMenu _barraDeMenu;

        public Editor(IEditorDeDocumentos editorDeDocumentos, IBarraDeMenu barraDeMenu)
        {
            InitializeComponent();
            _editorDeDocumentos = editorDeDocumentos;
            _barraDeMenu = barraDeMenu;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EditorDeDocumentosFrame.Navigate(_editorDeDocumentos);
            BarraDeMenuFrame.Navigate(_barraDeMenu);
        }
    }
}
