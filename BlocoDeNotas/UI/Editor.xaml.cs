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
        private readonly IBarraDeStatus _barraDeStatus;
        private readonly IBarraDeMenu _barraDeMenu;

        public Editor(IEditorDeDocumentos editorDeDocumentos,IBarraDeStatus barraDeStatus ,IBarraDeMenu barraDeMenu)
        {
            InitializeComponent();
            _editorDeDocumentos = editorDeDocumentos;
            _barraDeStatus = barraDeStatus;
            _barraDeMenu = barraDeMenu;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EditorDeDocumentosFrame.Content = _editorDeDocumentos;  
            BarraDeStatusFrame.Content = _barraDeStatus;
            BarraDeMenuFrame.Content = _barraDeMenu;
        }
    }
}
