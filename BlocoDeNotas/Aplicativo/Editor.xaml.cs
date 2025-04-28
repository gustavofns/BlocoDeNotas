using System.Windows;
using System.Windows.Controls;
using BlocoDeNotas.Aplicativo.Componentes;
using BlocoDeNotas.Eventos;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Menu;
using BlocoDeNotas.Menu;
using BlocoDeNotas.Menu.ItensMenuArquivo;
using BlocoDeNotas.Menu.ItensMenuEditar;
using BlocoDeNotas.Utilitarios;

namespace BlocoDeNotas.Aplicativo
{
    /// <summary>
    /// Interação lógica para Editor.xam
    /// </summary>
    public partial class Editor : Page, IEditor
    {
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly IBarraDeStatus _barraDeStatus;
        private readonly IBarraDeMenu _barraDeMenu;

        public Editor(IEditorDeDocumentos editorDeDocumentos, IBarraDeStatus barraDeStatus, IBarraDeMenu barraDeMenu)
        {
            InitializeComponent();
            _editorDeDocumentos = editorDeDocumentos;
            _barraDeStatus = barraDeStatus;
            _barraDeMenu = barraDeMenu;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FrameEditorDeDocumentos.Navigate(_editorDeDocumentos);
            FrameBarraDeStatus.Navigate(_barraDeStatus);
            FrameBarraMenu.Navigate(_barraDeMenu);
        }
    }
}
